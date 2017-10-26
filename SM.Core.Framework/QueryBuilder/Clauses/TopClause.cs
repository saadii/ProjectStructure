using SM.Core.Framework.QueryBuilder.Enums;

namespace SM.Core.Framework.QueryBuilder.Clauses
{
    /// <summary>
    /// Represents a TOP clause for SELECT statements
    /// </summary>
    public struct TopClause
    {
        public int Quantity;
        public TopUnit Unit;

        /// <summary>
        ///
        /// </summary>
        /// <param name="nr"></param>
        public TopClause(int nr)
        {
            Quantity = nr;
            Unit = TopUnit.Records;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="nr"></param>
        /// <param name="aUnit"></param>
        public TopClause(int nr, TopUnit aUnit)
        {
            Quantity = nr;
            Unit = aUnit;
        }
    }
}