using System.Diagnostics;

namespace SM.Core.Framework.Security
{
    /// <summary>
    ///
    /// </summary>
    public static class TokenGenerator
    {
        /// <summary>
        /// The CreateUniqueId function is used to create a unique string field of 16 upper case hexadecimal characters.
        /// It is not mathmatically guaranteed to be unique, but is close ennough for most purposes. This is created
        /// by creating two GUIDs and for each GUID it will convert it to a hash value and convert the hash value
        /// to a hexadecimal string of 8 characters. It will then concatenate them together.
        /// </summary>
        /// <returns>
        /// The string containing the new 16 character upper case hexadecimal value.
        /// </returns>
        /// -----------------------------------------------------------------------------
        public static string CreateUniqueId()
        {
            string sId = null;

            sId = System.Guid.NewGuid().GetHashCode().ToString("X8") + System.Guid.NewGuid().GetHashCode().ToString("X8");

            Debug.Assert(sId.Length == 16, "The ID should always be 16 characters");

            return sId;
        }
    }
}