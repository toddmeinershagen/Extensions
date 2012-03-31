using System;
using System.Linq;

namespace Extensions
{
    public static class ArrayOfStringsExtensions
    {
        public static string Concat(this string[] values, string separator = "")
        {
            return values.Concat(0, separator);
        }

        public static string Concat(this string[] values, int startIndex, string separator = "")
        {
            return values.Concat(startIndex, values.Length - 1, separator);
        }

        public static string Concat(this string[] values, int startIndex, int endIndex, string separator = "")
        {
            var message = "'{0}' was out of the range of acceptable values for this list.";

            if (startIndex > endIndex)
            {
                throw new IndexOutOfRangeException("'startIndex' cannot be greater than 'endIndex'.");    
            }

            if (startIndex < 0)
            {
                throw new IndexOutOfRangeException(string.Format(message, "startIndex"));
            }

            if (endIndex + 1 > values.Length)
            {
                throw new IndexOutOfRangeException(string.Format(message, "endIndex"));
            }

            return string.Join(separator, values.ToList().Skip(startIndex).Take(endIndex - startIndex + 1));
        }
    }
}
