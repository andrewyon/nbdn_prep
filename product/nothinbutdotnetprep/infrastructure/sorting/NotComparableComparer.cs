using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class NotComparableComparer<T> : IComparer<T>
    {
        private List<T> _values;

        public NotComparableComparer(T[] values)
        {
            _values = new List<T>(values);
        }

        public int Compare(T x, T y)
        {
            return _values.IndexOf(x).CompareTo(_values.IndexOf(y));
        }
    }
}