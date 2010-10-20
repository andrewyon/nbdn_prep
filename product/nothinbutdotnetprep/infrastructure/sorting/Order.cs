using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class Order<ItemToCompare>
    {
        public static IComparer<ItemToCompare> by_descending<PropertyType>(
            Func<ItemToCompare, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new ReverseComparer<ItemToCompare>(by(accessor));
        }

        public static IComparer<ItemToCompare> by<PropertyType>(
            Func<ItemToCompare, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new PropertyComparer<ItemToCompare, PropertyType>(accessor,
                                                                     new ComparableComparer<PropertyType>());
        }

        public static void by<PropertyType>(Func<ItemToCompare, PropertyType> property_accessor,
            params  PropertyType[] values)
        {
            throw new NotImplementedException();
        }
    }
}