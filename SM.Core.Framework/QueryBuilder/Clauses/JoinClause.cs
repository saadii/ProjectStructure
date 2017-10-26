using SM.Core.Framework.QueryBuilder.Enums;

namespace SM.Core.Framework.QueryBuilder.Clauses
{
    /// <summary>
    /// Represents a JOIN clause to be used with SELECT statements
    /// </summary>
    public struct JoinClause
    {
        public JoinType JoinType;
        public string FromTable;
        public string FromColumn;
        public Comparison ComparisonOperator;
        public string ToTable;
        public string ToColumn;

        /// <summary>
        ///
        /// </summary>
        /// <param name="join"></param>
        /// <param name="toTableName"></param>
        /// <param name="toColumnName"></param>
        /// <param name="operator"></param>
        /// <param name="fromTableName"></param>
        /// <param name="fromColumnName"></param>
        public JoinClause(JoinType join, string toTableName, string toColumnName, Comparison @operator, string fromTableName, string fromColumnName)
        {
            JoinType = join;
            FromTable = fromTableName;
            FromColumn = fromColumnName;
            ComparisonOperator = @operator;
            ToTable = toTableName;
            ToColumn = toColumnName;
        }
    }
}