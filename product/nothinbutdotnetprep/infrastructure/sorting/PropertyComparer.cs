using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class PropertyComparer<ItemToCompare, PropertyType> : IComparer<ItemToCompare>
    {
        Func<ItemToCompare, PropertyType> accessor;
        IComparer<PropertyType> actual_comparer;

        public PropertyComparer(Func<ItemToCompare, PropertyType> accessor, IComparer<PropertyType> actual_comparer)
        {
            this.accessor = accessor;
            this.actual_comparer = actual_comparer;
        }

        public int Compare(ItemToCompare x, ItemToCompare y)
        {
            return actual_comparer.Compare(accessor(x), accessor(y));
        }
    }
}