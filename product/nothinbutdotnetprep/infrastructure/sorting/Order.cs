using System;
using System.Collections;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class Order<ItemToCompare>
    {
        public static OrderingComparer<ItemToCompare> by_descending<PropertyType>(
            Func<ItemToCompare, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new OrderingComparer<ItemToCompare>(new ReverseComparer<ItemToCompare>(by(accessor)));
        }

        public static OrderingComparer<ItemToCompare> by<PropertyType>(
            Func<ItemToCompare, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new OrderingComparer<ItemToCompare>(new PropertyComparer<ItemToCompare, PropertyType>(accessor,
                                                                                                         new ComparableComparer
                                                                                                             <
                                                                                                             PropertyType
                                                                                                             >()));
        }

        public static OrderingComparer<ItemToCompare> by<PropertyType>(Func<ItemToCompare, PropertyType> property_accessor,
            params  PropertyType[] values)
        {
            return
                new OrderingComparer<ItemToCompare>(new PropertyComparer<ItemToCompare, PropertyType>(property_accessor,
                                                                                                      new NotComparableComparer
                                                                                                          <PropertyType>
                                                                                                          (values)));
        }

    }
}