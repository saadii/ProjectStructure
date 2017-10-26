namespace SM.Core.Framework.QueryBuilder
{
    /// <summary>
    ///
    /// </summary>
    public class SqlLiteral
    {
        /// <summary>
        ///
        /// </summary>
        public static string StatementRowsAffected = "SELECT @@ROWCOUNT";

        /// <summary>
        ///
        /// </summary>
        private string _value;

        /// <summary>
        ///
        /// </summary>
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        public SqlLiteral(string value)
        {
            _value = value;
        }
    }
}