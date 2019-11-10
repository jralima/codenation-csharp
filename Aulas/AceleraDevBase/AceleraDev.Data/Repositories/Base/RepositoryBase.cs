using AceleraDev.Data.Repositories.Context;
using AceleraDev.Domain.Interfaces.Base;
using AceleraDev.Domain.Models.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public RepositoryBase(AceleraDevContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// Método para incluir
        /// </summary>
        /// <param name="obj">Registro a ser inlcuído</param>
        public void Add(TModel obj)
        {
            _context.Set<TModel>().Add(obj);
            _context.SaveChanges();
            //_mock.Add(obj);
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
        }
    
   }
}
