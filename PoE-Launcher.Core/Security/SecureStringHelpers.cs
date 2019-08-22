using System;
using System.Runtime.InteropServices;
using System.Security;

namespace PoE_Launcher.Core
{
    /// <summary>
    /// Helpers to work with secure strings
    /// </summary>
    public static class SecureStringHelpers
    {
        /// <summary>
        /// Unsecures a <see cref="SecureString"/> into a plain text string
        /// </summary>
        /// <param name="value">The secure string</param>
        /// <returns></returns>
        public static string Unsecure(this SecureString value)
        {
            // Make sure we have a secure string
            if (value == null)
                return string.Empty;

            // Get a pointer for an unsecured string in memory
            var unmanagedString = IntPtr.Zero;

            try
            {
                // Unsecures the password
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(value);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                // Clean up any memory allocation
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
