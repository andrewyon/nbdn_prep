using System;
using System.Collections.Generic;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class OrderingComparer<ItemToCompare> : IComparer<ItemToCompare>
    {
        private IComparer<ItemToCompare> _comparer;

        public OrderingComparer(IComparer<ItemToCompare> comparer)
        {
            _comparer = comparer;
        }

        public int Compare(ItemToCompare x, ItemToCompare y)
        {
            return _comparer.Compare(x, y);
        }

        public OrderingComparer<ItemToCompare> then_by<PropertyType>(Func<ItemToCompare, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            var right = new PropertyComparer<ItemToCompare, PropertyType>(accessor, new ComparableComparer<PropertyType>());
            return new OrderingComparer<ItemToCompare>(new ChainedComparer<ItemToCompare>(this, right));
        }

        public OrderingComparer<ItemToCompare> then_by_descending<PropertyType>(Func<ItemToCompare, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            var right = new ReverseComparer<ItemToCompare>(new PropertyComparer<ItemToCompare, PropertyType>(accessor, new ComparableComparer<PropertyType>()));
            return new OrderingComparer<ItemToCompare>(new ChainedComparer<ItemToCompare>(this, right));
        }
    }
}