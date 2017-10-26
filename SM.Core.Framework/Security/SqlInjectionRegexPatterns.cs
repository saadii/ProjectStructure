using System;
using System.Text.RegularExpressions;

namespace SM.Core.Framework.Security
{
    /// <summary>
    /// Contains the pre-compiled regular expressions which can be used for pattern checking.
    /// </summary>
    public static class SqlInjectionRegexPatterns
    {
        #region Public Members

        #region Fields

        /// <summary>
        /// Checks for Extended Stored Procedure calls.
        /// </summary>
        /// <example>xp_terminate_process()</example>
        //public static Regex ExtendedStoredProc = new Regex(@"\s+([xX][pP])_\w+\s*\(", RegexOptions.Compiled);
        public static Regex ExtendedStoredProc = new Regex(@"\s+([xX][pP])_\w+\s*", RegexOptions.Compiled);

        /// <summary>
        /// Checks for hexadecimal patterns. The patterns of the form %00 - %FF
        /// </summary>
        //public static Regex HexPattern = new Regex(@"\%[(0-9a-fA-F]{2}", RegexOptions.Compiled);
        public static Regex HexPattern = new Regex(@"0[xX][0-9a-fA-F]+", RegexOptions.Compiled);

        /// <summary>
        /// Checks for single quote.
        /// </summary>
        public static Regex SingleQuote = new Regex(@"\'|\%27", RegexOptions.Compiled);

        /// <summary>
        /// Checks for comments in the script.
        /// </summary>
        /// <remarks>
        /// There are two comment method recognized by this pattern: -- and /* */.
        /// </remarks>
        public static Regex Comment = new Regex(@"(\-\-)|(\%23\%23)|(\/\*.*\*\/)", RegexOptions.Compiled);

        /// <summary>
        /// Checks for hexadecimal patterns of the form 0x1234abc
        /// </summary>
        //public static Regex Hex_0x = new Regex(@"\s+0[xX][0-9a-fA-F]+\s+", RegexOptions.Compiled);
        public static Regex Hex_0x = new Regex(@"\s+\'0[xX]\'+\s+", RegexOptions.Compiled);

        /// <summary>
        /// Checks for semi-colon within script.
        /// </summary>
        public static Regex SemiColon = new Regex(@";|(\%3b)|(\%3B)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// Checks for the SQL keyword 'update'.
        /// </summary>
        //public static Regex Update = new Regex(@"\s+update\s+", RegexOptions.Compiled|RegexOptions.IgnoreCase);
        public static Regex Update = new Regex(@"\bupdate\s+", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// Checks for the SQL keyword 'delete'.
        /// </summary>
        //public static Regex Delete = new Regex(@"\s+delete\s+", RegexOptions.Compiled|RegexOptions.IgnoreCase);
        public static Regex Delete = new Regex(@"\bdelete\s+", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// Checks for the SQL keyword 'insert'.
        /// </summary>
        //public static Regex Insert = new Regex(@"\s+insert\s+", RegexOptions.Compiled|RegexOptions.IgnoreCase);
        public static Regex Insert = new Regex(@"\binsert\s+", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// Checks for the SQL keyword 'drop'.
        /// </summary>
        //public static Regex Drop = new Regex(@"\s+drop\s+", RegexOptions.Compiled|RegexOptions.IgnoreCase);
        public static Regex Drop = new Regex(@"\bdrop\s+", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// Checks for the SQL keyword 'create'.
        /// </summary>
        //public static Regex Create = new Regex(@"\s+create\s+", RegexOptions.Compiled|RegexOptions.IgnoreCase);
        public static Regex Create = new Regex(@"\bcreate\s+", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        #endregion Fields

        /// <summary>
        ///
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static bool ValidateSqlInjection(string Value)
        {
            try
            {
                bool IsSqlInjectionAttack = false;

                if (SqlInjectionRegexPatterns.ExtendedStoredProc.IsMatch(Value.ToString()))
                    return !IsSqlInjectionAttack;

                if (SqlInjectionRegexPatterns.Create.IsMatch(Value.ToString()))
                    return !IsSqlInjectionAttack;

                if (SqlInjectionRegexPatterns.Delete.IsMatch(Value.ToString()))
                    return !IsSqlInjectionAttack;

                if (SqlInjectionRegexPatterns.Drop.IsMatch(Value.ToString()))
                    return !IsSqlInjectionAttack;

                if (SqlInjectionRegexPatterns.Insert.IsMatch(Value.ToString()))
                    return !IsSqlInjectionAttack;

                if (SqlInjectionRegexPatterns.Update.IsMatch(Value.ToString()))
                    return !IsSqlInjectionAttack;

                if (SqlInjectionRegexPatterns.Hex_0x.IsMatch(Value.ToString()))
                    return !IsSqlInjectionAttack;

                if (SqlInjectionRegexPatterns.HexPattern.IsMatch(Value.ToString()))
                    return !IsSqlInjectionAttack;

                return IsSqlInjectionAttack;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Public Members
    }
}