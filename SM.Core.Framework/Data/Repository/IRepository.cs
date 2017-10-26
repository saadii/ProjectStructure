using SM.Core.Framework.Data.Projection;
using SM.Core.Framework.Data.Specification;
using System;
using System.Collections.Generic;

namespace SM.Core.Framework.Data.Repository
{
    /// <summary>
    ///
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        Type GetEntityType();
    }

    /// <summary>
    /// IRepository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> : IRepository where TEntity : class
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity Create(TEntity entity);

        /// <summary>
        ///
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Create(params TEntity[] entities);

        /// <summary>
        ///
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="specification"></param>
        void Delete(TEntity entity, ISpecification<TEntity> specification = null);

        /// <summary>
        ///
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="entities"></param>
        void Delete(ISpecification<TEntity> specification = null, params TEntity[] entities);

        /// <summary>
        ///
        /// </summary>
        /// <param name="specification"></param>
        void Merge(ISpecification<TEntity> specification);

        /// <summary>
        ///
        /// </summary>
        /// <param name="projections"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Read(params IProjection[] projections);

        /// <summary>
        ///
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Read(ISpecification<TEntity> specification, params IProjection[] projections);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        TEntity Read(long id, params IProjection[] projections);

        /// <summary>
        ///
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="specification"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Read(TEntity entity, ISpecification<TEntity> specification, params IProjection[] projections);

        /// <summary>
        ///
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="specification"></param>
        /// <returns></returns>
        TEntity Update(TEntity entity, ISpecification<TEntity> specification = null);

        /// <summary>
        ///
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="entities"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Update(ISpecification<TEntity> specification = null, params TEntity[] entities);
    }
}