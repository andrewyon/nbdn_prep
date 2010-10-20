using System;

namespace nothinbutdotnetprep.infrastructure.ranges
{
    public class RangeWithNoLowerBound<T> : Range<T> where T : IComparable<T>
    {
        T start;

        public RangeWithNoLowerBound(T start)
        {
            this.start = start;
        }

        public bool contains(T value)
        {
            return value.CompareTo(start) < 0;
        }

    }
}