using System.Dynamic;

namespace SM.Core.Framework.Data.Specification
{
    /// <summary>
    /// ISpecification
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    public interface ISpecification<in T> where T : class
    {
        /// <summary>
        /// CreateParameters
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ExpandoObject CreateParameters(T entity);

        /// <summary>
        /// StoredProcedureName
        /// </summary>
        string StoredProcedureName { get; }
    }
}