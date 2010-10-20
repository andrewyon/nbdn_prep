using System.Collections.Generic;

namespace nothinbutdotnetprep.specs.utility
{
    public class ObjectMother
    {
        public static IEnumerable<T> create_from<T>(params T[] items)
        {
            return new List<T>(items);
        }
    }
}