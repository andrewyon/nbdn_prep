using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class IsGreaterThan<T> : Criteria<T> where T : IComparable<T>
    {
        T start;

        public IsGreaterThan(T start)
        {
            this.start = start;
        }

        public bool is_satisfied_by(T item)
        {
            return item.CompareTo(start) > 0;
        }
    }
}