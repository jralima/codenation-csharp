using AceleraDev.Data.Auditoria;
using AceleraDev.Data.Context;
using AceleraDev.Domain.Interfaces.Base;
using AceleraDev.Domain.Models.Base;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AceleraDev.Data.Repositories.Base
{
    /// <summary>
    /// Classe de repositório base
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class RepositoryBase<TModel> : IRepositoryBase<TModel> where TModel : ModelBase
    {
        //protected IList<TModel> _mock;
        protected readonly AceleraDevContext _context;
        protected readonly MongoDbContext _mongoDbContext;

        public RepositoryBase(AceleraDevContext context)
        {
            _context = context;
            _mongoDbContext = new MongoDbContext();
        }

        /// <summary>
        /// Método para incluir
        /// </summary>
        /// <param name="obj">Registro a ser inlcuído</param>   
        public TModel Add(TModel obj)
        {
            obj.Id = Guid.NewGuid();
            obj.CriadoEm = obj.AtualizadoEm = DateTime.Now;
            obj.Ativo = true;

            _context.Set<TModel>().Add(obj);
            _context.SaveChanges();
            //_mock.Add(obj);

            IncluirAuditoria("Add", obj.Id.Value);

            return obj;
        }

        /// <summary>
        /// Método para pesquisar
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>IList<TModel></returns>
        public IList<TModel> Find(Func<TModel, bool> predicate)
        {
            return _context.Set<TModel>().Where(predicate).ToList();
            //return _mock.Where(predicate).ToList();
        }

        /// <summary>
        /// Método para listar todos
        /// </summary>
        /// <returns>IList<TModel></returns>
        public IList<TModel> GetAll()
        {
            return _context.Set<TModel>().ToList();
            //return _mock;
        }

        /// <summary>
        /// Método para buscar registro especifico
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>TModel</returns>
        public TModel GetById(Guid id)
        {
            return _context.Set<TModel>().FirstOrDefault(p => p.Id == id);
            //return _mock.FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// Método para remover
        /// </summary>
        /// <param name="id">Identificador</param>
        public void Remove(Guid id)
        {
            _context.Set<TModel>().Remove(this.GetById(id));
            _context.SaveChanges();

            //_mock.Remove(this.GetById(id));

            IncluirAuditoria("Remove", id);
        }

        /// <summary>
        /// Método para atualizar
        /// </summary>
        /// <param name="obj">Registro a ser atualizado</param>
        public void Update(TModel obj)
        {
            _context.Update<TModel>(obj);
            _context.SaveChanges();
            //this.Remove(obj.Id);
            //this.Add(obj);

            IncluirAuditoria("Update", obj.Id.Value);
        }

        /// <summary>
        /// Consulta utilizada com Dapper
        /// </summary>
        /// <param name="query">A consulta que será executada</param>
        /// <param name="param">Parâmetros da consulta</param>
        /// <returns></returns>
        public List<TModel> GetWithDapper(string query, object param = null)
        {
            //using (var con = new SqlConnection(_context.GetConnectionString()))
            using var con = new SqlConnection(_context.GetConnectionString());
            //{
                try
                {
                    con.Open();
                    return con.Query<TModel>(query, param).ToList();
                }
                catch (Exception ex)
                {
                    //throw ex;
                    throw new Exception("Ocorreu um erro ao executar uma pesquisa com Dapper.", ex);
                }
                finally
                {
                    con.Close();
                }
            //}
        }
        
        private void IncluirAuditoria(string operacao, Guid entidadeId)
        {
            // Rodando assincrono 
            Task.Run(() => {
                var auditoria = new AuditoriaModel
                {
                    UsuarioId = "FD989C24-E76D-43BD-A862-F563CDA5B616",
                    Data = DateTime.UtcNow,
                    Entidade = typeof(TModel).Name,
                    EntidadeId = entidadeId.ToString(),
                    Operacao = operacao
                };

                _mongoDbContext.Auditorias.InsertOne(auditoria);
            });
        }
    }
}
