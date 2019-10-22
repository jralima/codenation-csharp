using AceleraDev.Domain.Interfaces.Base;
using AceleraDev.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AceleraDev.Domain.Repositories.Base
{
    /// <summary>
    /// Classe de repositório base
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class RepositoryBase<TModel> : IRepositoryBase<TModel> where TModel : ModelBase
    {
        protected IList<TModel> _mock;

        /// <summary>
        /// Método para incluir
        /// </summary>
        /// <param name="obj">Registro a ser inlcuído</param>
        public void Add(TModel obj)
        {
            _mock.Add(obj);
        }

        /// <summary>
        /// Método para pesquisar
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>IList<TModel></returns>
        public IList<TModel> Find(Func<TModel, bool> predicate)
        {
            return _mock.Where(predicate).ToList();
        }

        /// <summary>
        /// Método para listar todos
        /// </summary>
        /// <returns>IList<TModel></returns>
        public IList<TModel> GetAll()
        {
            return _mock;
        }

        /// <summary>
        /// Método para buscar registro especifico
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>TModel</returns>
        public TModel GetById(Guid id)
        {
            return _mock.FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// Método para remover
        /// </summary>
        /// <param name="id">Identificador</param>
        public void Remove(Guid id)
        {
            _mock.Remove(this.GetById(id));
        }

        /// <summary>
        /// Método para atualizar
        /// </summary>
        /// <param name="obj">Registro a ser atualizado</param>
        public void Update(TModel obj)
        {
            this.Remove(obj.Id);
            this.Add(obj);
        }
    
   }
}
