using SM.Core.Framework.Data.Connection;
using SM.Core.Framework.Data.Projection;
using SM.Core.Framework.Data.Specification;
using System;
using System.Collections.Generic;

namespace SM.Core.Framework.Data.Repository
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class CommandRepositoryBase<TEntity> : RepositoryBase<TEntity> where TEntity : class
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="connectionFactory"></param>
        protected CommandRepositoryBase(IConnectionFactory connectionFactory)
            : base(connectionFactory)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract override TEntity Create(TEntity entity);

        /// <summary>
        ///
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public abstract override IEnumerable<TEntity> Create(params TEntity[] entities);

        /// <summary>
        ///
        /// </summary>
        /// <param name="projections"></param>
        /// <returns></returns>
        public override IEnumerable<TEntity> Read(params IProjection[] projections)
        {
            throw new NotSupportedException("This is a command only repository, you cannot affect data here. Please implement RepositoryBase<T>");
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        public override TEntity Read(long id, params IProjection[] projections)
        {
            throw new NotSupportedException("This is a command only repository, you cannot affect data here. Please implement RepositoryBase<T>");
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="specification"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        public override IEnumerable<TEntity> Read(TEntity entity, ISpecification<TEntity> specification, params IProjection[] projections)
        {
            throw new NotSupportedException("This is a command only repository, you cannot affect data here. Please implement RepositoryBase<T>");
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="specification"></param>
        /// <returns></returns>
        public abstract override TEntity Update(TEntity entity, ISpecification<TEntity> specification = null);

        /// <summary>
        ///
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="entities"></param>
        /// <returns></returns>
        public abstract override IEnumerable<TEntity> Update(ISpecification<TEntity> specification = null, params TEntity[] entities);
    }
}