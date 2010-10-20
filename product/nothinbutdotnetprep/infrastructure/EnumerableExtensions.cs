using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.infrastructure
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<Item> all_items_matching<Item>(this IEnumerable<Item> items,
                                                                 Criteria<Item> criteria)
        {
            foreach (var item in items)
            {
                if (criteria.is_satisfied_by(item)) yield return item;
            }
        }

        public static IEnumerable<Item> sort_using<Item>(this IEnumerable<Item> items, IComparer<Item> comparer)
        {
            var sorted = new List<Item>(items);
            sorted.Sort(comparer);
            return sorted;
        }

        public static IEnumerable<Item> one_at_a_time<Item>(this IEnumerable<Item> items)
        {
            foreach (var item in items) yield return item;
        }
    }
}