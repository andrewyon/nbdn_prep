using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public static class GeneralExtensions
    {
        public static FormattingExtensionPoint<T> for_formatting<T>(this T item)
        {
           return new FormattingExtensionPoint<T>(item); 
        }

        public static string as_other(this FormattingExtensionPoint<DateTime> item)
        {
            return string.Empty;
        }

        public static string as_complex_stream(this FormattingExtensionPoint<string> item)
        {
            return string.Empty;
        }
        public static string as_xml<T>(this FormattingExtensionPoint<T> item) where T : IComparable<T>
        {
            return string.Empty;
        }

        public static string as_xml<T>(this T item) where T : IComparable<T>
        {
            return string.Empty;
        }
    }
}