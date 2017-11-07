using SM.BusinessEntites;
using SM.Core.Framework.Data.Connection;
using SM.Core.Framework.Data.Projection;
using SM.Core.Framework.Data.Repository;
using SM.Core.Framework.Data.Specification;
using System.Collections.Generic;
using System.Data;

namespace SM.DataAccess.RepositoryImpl
{
    public class CustomerRepository : RepositoryBase<Customer>
    {
        private readonly IConnectionFactory _factory;

        public CustomerRepository(IConnectionFactory connectionFactory)
            : base(connectionFactory)
        {
            _factory = connectionFactory;
        }

        public override Customer Create(Customer entity)
        {
            using (IDbConnection connection = _factory.CreateConnection())
            {
            }
            throw new System.NotImplementedException();
        }

        public override IEnumerable<Customer> Create(params Customer[] entities)
        {
            throw new System.NotImplementedException();
        }

        public override void Delete(ISpecification<Customer> specification = null, params Customer[] entities)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<Customer> Read(params IProjection[] projections)
        {
            throw new System.NotImplementedException();
        }

        public override Customer Read(long id, params IProjection[] projections)
        {
            throw new System.NotImplementedException();
        }

        public override Customer Update(Customer entity, ISpecification<Customer> specification)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<Customer> Update(ISpecification<Customer> specification = null, params Customer[] entities)
        {
            throw new System.NotImplementedException();
        }
    }
}