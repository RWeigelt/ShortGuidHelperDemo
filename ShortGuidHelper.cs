using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortGuidHelperDemo
{
    /// <summary>
    /// Functions for converting a <see cref="Guid"/> to shorter string and back
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    public static class ShortGuidHelper
    {
        // See info on Base64 encoding:  https://datatracker.ietf.org/doc/html/rfc4648#section-4
        private const char _Value62Encoding = '+';
        private const char _Value63Encoding = '/';

        // Use other characters as I did not want arithmetic operators in my ID
        // The chosen characters are rather arbitrary
        private const char _Value62Replacement = '_';
        private const char _Value63Replacement = '$';

        public static string GetShortId(Guid guid)
        {
            var bytes = guid.ToByteArray();
            var cellValue = Convert.ToBase64String(bytes);
            cellValue = cellValue.Substring(0, 22); // Remove "=" characters added by Base64 encoding for padding
            cellValue = cellValue
                .Replace(_Value62Encoding, _Value62Replacement)
                .Replace(_Value63Encoding, _Value63Replacement);
            return cellValue;
        }

        public static Guid GetGuid(string shortId)
        {
            var base64Text = shortId
                                 .Replace(_Value62Replacement, _Value62Encoding)
                                 .Replace(_Value63Replacement, _Value63Encoding)
                             + "==";
            var bytes = Convert.FromBase64String(base64Text);
            return new Guid(bytes);
        }
    }
}
