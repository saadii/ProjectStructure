using System.Data;

namespace SM.Core.Framework.Data.Connection
{
    /// <summary>
    /// 
    /// </summary>
    public interface IConnectionFactory
    {
        /// <summary>
        /// CreateConnection
        /// </summary>
        /// <returns></returns>
        IDbConnection CreateConnection();
    }
}