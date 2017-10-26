using System.Data;
using System.Data.SqlClient;

namespace SM.Core.Framework.Data.Connection
{
    /// <summary>
    ///
    /// </summary>
    public class SqlConnectionFactory : IConnectionFactory
    {
        private readonly string _connectionString;

        /// <summary>
        /// Sql ConnectionFactory
        /// </summary>
        /// <param name="connectionString"></param>
        public SqlConnectionFactory(string connectionString)
        {
            this._connectionString = connectionString;
        }

        /// <summary>
        /// Create Connection
        /// </summary>
        /// <returns></returns>
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(this._connectionString);
        }
    }
}