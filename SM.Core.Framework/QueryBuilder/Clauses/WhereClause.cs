using SM.Core.Framework.QueryBuilder.Enums;
using System.Collections.Generic;

namespace SM.Core.Framework.QueryBuilder.Clauses
{
    /// <summary>
    /// Represents a WHERE clause on 1 database column, containing 1 or more comparisons on
    /// that column, chained together by logic operators: eg (UserID=1 or UserID=2 or UserID>100)
    /// This can be achieved by doing this:
    /// WhereClause myWhereClause = new WhereClause("UserID", Comparison.Equals, 1);
    /// myWhereClause.AddClause(LogicOperator.Or, Comparison.Equals, 2);
    /// myWhereClause.AddClause(LogicOperator.Or, Comparison.GreaterThan, 100);
    /// </summary>
    public struct WhereClause
    {
        private string m_FieldName;
        private Comparison m_ComparisonOperator;
        private object m_Value;

        /// <summary>
        ///
        /// </summary>
        internal struct SubClause
        {
            public LogicOperator LogicOperator;
            public Comparison ComparisonOperator;
            public object Value;

            /// <summary>
            ///
            /// </summary>
            /// <param name="logic"></param>
            /// <param name="compareOperator"></param>
            /// <param name="compareValue"></param>
            public SubClause(LogicOperator logic, Comparison compareOperator, object compareValue)
            {
                LogicOperator = logic;
                ComparisonOperator = compareOperator;
                Value = compareValue;
            }
        }

        /// <summary>
        ///
        /// </summary>
        internal List<SubClause> SubClauses;	// Array of SubClause

        /// <summary>
        /// Gets/sets the name of the database column this WHERE clause should operate on
        /// </summary>
        public string FieldName
        {
            get { return m_FieldName; }
            set { m_FieldName = value; }
        }

        /// <summary>
        /// Gets/sets the comparison method
        /// </summary>
        public Comparison ComparisonOperator
        {
            get { return m_ComparisonOperator; }
            set { m_ComparisonOperator = value; }
        }

        /// <summary>
        /// Gets/sets the value that was set for comparison
        /// </summary>
        public object Value
        {
            get { return m_Value; }
            set { m_Value = value; }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="field"></param>
        /// <param name="firstCompareOperator"></param>
        /// <param name="firstCompareValue"></param>
        public WhereClause(string field, Comparison firstCompareOperator, object firstCompareValue)
        {
            m_FieldName = field;
            m_ComparisonOperator = firstCompareOperator;
            m_Value = firstCompareValue;
            SubClauses = new List<SubClause>();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="logic"></param>
        /// <param name="compareOperator"></param>
        /// <param name="compareValue"></param>
        public void AddClause(LogicOperator logic, Comparison compareOperator, object compareValue)
        {
            SubClause NewSubClause = new SubClause(logic, compareOperator, compareValue);
            SubClauses.Add(NewSubClause);
        }
    }
}