namespace SM.Core.Framework.Parser
{
    /// <summary>
    ///
    /// </summary>
    public class Filter
    {
        /// <summary>
        ///
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Op Operation { get; set; }

        /// <summary>
        ///
        /// </summary>
        public object Value { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    public enum Op
    {
        Equals,
        GreaterThan,
        LessThan,
        GreaterThanOrEqual,
        LessThanOrEqual,
        Contains,
        StartsWith,
        EndsWith
    }
}