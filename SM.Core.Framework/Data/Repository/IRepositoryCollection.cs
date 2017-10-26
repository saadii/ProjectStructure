using System;
using System.Collections;
using System.Collections.Generic;

namespace SM.Core.Framework.Data.Repository
{
    public interface IRepositoryCollection : IList<IRepository>, ICollection<IRepository>, IEnumerable<IRepository>, IEnumerable
    {
        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IRepository<TEntity> Get<TEntity>() where TEntity : class;

        /// <summary>
        ///
        /// </summary>
        /// <param name="entityType"></param>
        /// <returns></returns>
        IRepository this[Type entityType] { get; }
    }
}