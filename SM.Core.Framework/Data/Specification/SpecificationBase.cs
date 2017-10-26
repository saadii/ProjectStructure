using System.Dynamic;

namespace SM.Core.Framework.Data.Specification
{
    /// <summary>
    /// Specification Base
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class SpecificationBase<T> : ISpecification<T> where T : class
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="storedProcName"></param>
        protected SpecificationBase(string storedProcName)
        {
            this.StoredProcedureName = storedProcName;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract ExpandoObject CreateParameters(T entity);

        /// <summary>
        ///
        /// </summary>
        public string StoredProcedureName { get; private set; }
    }
}