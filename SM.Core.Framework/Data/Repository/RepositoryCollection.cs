using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SM.Core.Framework.Data.Repository
{
    /// <summary>
    ///
    /// </summary>
    public class RepositoryCollection : List<IRepository>, IRepositoryCollection, IList<IRepository>, ICollection<IRepository>, IEnumerable<IRepository>, IEnumerable
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="repositories"></param>
        public RepositoryCollection(params IRepository[] repositories)
        {
            base.AddRange(repositories);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IRepository<TEntity> Get<TEntity>() where TEntity : class
        {
            return (this[typeof(TEntity)] as IRepository<TEntity>);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entityType"></param>
        /// <returns></returns>
        public IRepository this[Type entityType]
        {
            get
            {
                return this.FirstOrDefault<IRepository>(x => (x.GetEntityType() == entityType));
            }
        }
    }
}