using System.Collections.ObjectModel;

namespace SM.Core.Framework.Diagnostics.ExceptionHandling
{
    /// <summary>
    ///
    /// </summary>
    public class ErrorInformation
    {
        /// <summary>
        /// Errors
        /// </summary>
        public Collection<SmError> Errors
        {
            get;
            set;
        }
    }
}