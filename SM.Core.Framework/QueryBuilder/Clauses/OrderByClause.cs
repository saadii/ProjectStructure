using SM.Core.Framework.QueryBuilder.Enums;

namespace SM.Core.Framework.QueryBuilder.Clauses
{
    /// <summary>
    /// Represents a ORDER BY clause to be used with SELECT statements
    /// </summary>
    public struct OrderByClause
    {
        public string FieldName;
        public Sorting SortOrder;

        /// <summary>
        ///
        /// </summary>
        /// <param name="field"></param>
        public OrderByClause(string field)
        {
            FieldName = field;
            SortOrder = Sorting.Ascending;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="field"></param>
        /// <param name="order"></param>
        public OrderByClause(string field, Sorting order)
        {
            FieldName = field;
            SortOrder = order;
        }
    }
}