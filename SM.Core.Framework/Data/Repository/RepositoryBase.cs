using Dapper;
using SM.Core.Framework.Data.Connection;
using SM.Core.Framework.Data.Projection;
using SM.Core.Framework.Data.Specification;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SM.Core.Framework.Data.Repository
{
    /// <summary>
    ///
    /// </summary>
    public abstract class RepositoryBase : IRepository
    {
        /// <summary>
        ///
        /// </summary>
        protected RepositoryBase()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public abstract Type GetEntityType();
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class RepositoryBase<TEntity> : RepositoryBase, IRepository<TEntity>, IRepository where TEntity : class
    {
        /// <summary>
        ///
        /// </summary>
        private readonly IConnectionFactory _connectionFactory;

        /// <summary>
        ///
        /// </summary>
        /// <param name="connectionFactory"></param>
        protected RepositoryBase(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract TEntity Create(TEntity entity);

        /// <summary>
        ///
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public abstract IEnumerable<TEntity> Create(params TEntity[] entities);

        /// <summary>
        ///
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="specification"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        public virtual void Delete(TEntity entity, ISpecification<TEntity> specification = null)
        {
            if (object.Equals(entity, default(TEntity)))
            {
                throw new ArgumentNullException("entity");
            }
            if (specification == null)
            {
                throw new NotSupportedException();
            }
            using (IDbConnection connection = this._connectionFactory.CreateConnection())
            {
                CommandType? commandType = CommandType.StoredProcedure;
                connection.Execute(specification.StoredProcedureName, specification.CreateParameters(entity), null, null, commandType);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="entities"></param>
        public abstract void Delete(ISpecification<TEntity> specification = null, params TEntity[] entities);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override Type GetEntityType()
        {
            return typeof(TEntity);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="specification"></param>
        public virtual void Merge(ISpecification<TEntity> specification)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="projections"></param>
        /// <returns></returns>
        public abstract IEnumerable<TEntity> Read(params IProjection[] projections);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        public abstract TEntity Read(long id, params IProjection[] projections);

        /// <summary>
        ///
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> Read(ISpecification<TEntity> specification, params IProjection[] projections)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="specification"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> Read(TEntity entity, ISpecification<TEntity> specification, params IProjection[] projections)
        {
            if (object.Equals(entity, default(TEntity)))
            {
                throw new ArgumentNullException("entity");
            }

            if (specification == null)
            {
                throw new NotSupportedException();
            }

            DynamicParameters parameters = new DynamicParameters();
            parameters.AddDynamicParams(specification.CreateParameters(entity));
            projections.ToList<IProjection>().ForEach(delegate (IProjection p)
            {
                parameters.AddDynamicParams(p.CreateParameters());
            });

            using (IDbConnection connection = this._connectionFactory.CreateConnection())
            {
                CommandType? commandType = CommandType.StoredProcedure;
                return connection.Query<TEntity>(specification.StoredProcedureName, parameters, null, true, null, commandType);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="specification"></param>
        /// <returns></returns>
        public abstract TEntity Update(TEntity entity, ISpecification<TEntity> specification);

        /// <summary>
        ///
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="entities"></param>
        /// <returns></returns>
        public abstract IEnumerable<TEntity> Update(ISpecification<TEntity> specification = null, params TEntity[] entities);

        /// <summary>
        ///
        /// </summary>
        protected IConnectionFactory ConnectionFactory
        {
            get
            {
                return this._connectionFactory;
            }
        }
    }
}