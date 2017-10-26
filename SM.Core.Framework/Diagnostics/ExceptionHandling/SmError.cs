namespace SM.Core.Framework.Diagnostics.ExceptionHandling
{
    public class SmError
    {
        /// <summary>
        ///
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Unique error code.
        /// </summary>
        public string ErrorType { get; set; }

        /// <summary>
        /// Localized error message.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string ErrorKey { get; set; }
    }

    public class ApiError
    {
        /// <summary>
        ///
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// Localized error message.
        /// </summary>
        public string ErrorMessage { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    public class ApiErrorDetails
    {
        /// <summary>
        /// Localized error message.
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}