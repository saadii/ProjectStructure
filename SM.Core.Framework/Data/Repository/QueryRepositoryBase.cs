using SM.Core.Framework.Data.Connection;
using SM.Core.Framework.Data.Projection;
using SM.Core.Framework.Data.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Core.Framework.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class QueryRepositoryBase<TEntity> : RepositoryBase<TEntity> where TEntity : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionFactory"></param>
        protected QueryRepositoryBase(IConnectionFactory connectionFactory)
            : base(connectionFactory)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override TEntity Create(TEntity entity)
        {
            throw new NotSupportedException("This is a query only repository, you cannot affect data here. Please implement RepositoryBase<T>");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public override IEnumerable<TEntity> Create(params TEntity[] entities)
        {
            throw new NotSupportedException("This is a query  only repository, you cannot affect data here. Please implement RepositoryBase<T>");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="specification"></param>
        public override void Delete(TEntity entity, ISpecification<TEntity> specification = null)
        {
            throw new NotSupportedException("This is a query  only repository, you cannot affect data here. Please implement RepositoryBase<T>");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="entities"></param>
        public override void Delete(ISpecification<TEntity> specification = null, params TEntity[] entities)
        {
            throw new NotSupportedException("This is a query  only repository, you cannot affect data here. Please implement RepositoryBase<T>");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projections"></param>
        /// <returns></returns>
        public abstract override IEnumerable<TEntity> Read(params IProjection[] projections);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        public abstract override TEntity Read(long id, params IProjection[] projections);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="specification"></param>
        /// <returns></returns>
        public override TEntity Update(TEntity entity, ISpecification<TEntity> specification = null)
        {
            throw new NotSupportedException("This is a query  only repository, you cannot affect data here. Please implement RepositoryBase<T>");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="entities"></param>
        /// <returns></returns>

        public override IEnumerable<TEntity> Update(ISpecification<TEntity> specification = null, params TEntity[] entities)
        {
            throw new NotSupportedException("This is a query  only repository, you cannot affect data here. Please implement RepositoryBase<T>");
        }
    }
}
