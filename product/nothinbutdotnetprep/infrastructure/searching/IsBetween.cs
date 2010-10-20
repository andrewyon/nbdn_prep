using System;
using nothinbutdotnetprep.infrastructure.ranges;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class IsBetween<T> : Criteria<T> where T : IComparable<T>
    {
        Criteria<T> the_range;

        public IsBetween(T start, T end)
        {
            var starting_part = new FallsInRange<T>(new RangeWithNoUpperBound<T>(start))
                .or(new IsEqualToAny<T>(start));

            var ending_part = new FallsInRange<T>(new RangeWithNoLowerBound<T>(end))
                .or(new IsEqualToAny<T>(end));

            the_range = starting_part.and(ending_part);
        }

        public bool is_satisfied_by(T item)
        {
            return the_range.is_satisfied_by(item);
        }
    }
}