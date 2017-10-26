using System.Dynamic;

namespace SM.Core.Framework.Data.Projection
{
    /// <summary>
    /// 
    /// </summary>
    public interface IProjection
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ExpandoObject CreateParameters();
    }
}