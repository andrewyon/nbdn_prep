using System;
using nothinbutdotnetprep.infrastructure.ranges;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class FallInRange<T> : Criteria<T> where T : IComparable<T>
    {
        Range<T> range;

        public FallInRange(Range<T> range)
        {
            this.range = range;
        }

        public bool is_satisfied_by(T item)
        {
            return range.contains(item);
        }
    }
}