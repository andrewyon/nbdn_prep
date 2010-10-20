using System;
using nothinbutdotnetprep.infrastructure.ranges;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public static class FilteringExtensions
    {
        public static Criteria<ItemToFilter> equal_to<ItemToFilter, PropertyType>(
            this ExtensionPoint<ItemToFilter, PropertyType> extension_point, PropertyType value)
        {
            return equal_to_any(extension_point,value);
        }

        public static Criteria<ItemToFilter> equal_to_any<ItemToFilter, PropertyType>(
            this ExtensionPoint<ItemToFilter, PropertyType> extension_point, params PropertyType[] values)
        {
            return create_property_criteria_for(extension_point,
                                                new IsEqualToAny<PropertyType>(values));
        }

        public static Criteria<ItemToFilter> greater_than<ItemToFilter, PropertyType>(
            this ExtensionPoint<ItemToFilter, PropertyType> extension_point, PropertyType value)
            where PropertyType : IComparable<PropertyType>
        {
            return create_property_criteria_for(extension_point,
                                                new IsGreaterThan<PropertyType>(value));
        }

        public static Criteria<ItemToFilter> less_than<ItemToFilter,PropertyType>(this ExtensionPoint<ItemToFilter,PropertyType> extension_point,PropertyType end) where PropertyType : IComparable<PropertyType>
        {
            return create_property_criteria_for(extension_point,
                                                new FallsInRange<PropertyType>(
                                                    new RangeWithNoLowerBound<PropertyType>(end)));
        }

        public static Criteria<ItemToFilter> between<ItemToFilter,PropertyType>(this ExtensionPoint<ItemToFilter,PropertyType> extension_point,PropertyType start, PropertyType end) where PropertyType : IComparable<PropertyType>
        {
            return create_property_criteria_for(extension_point,
                                                new IsBetween<PropertyType>(start, end));
        }


         static Criteria<ItemToFilter> create_property_criteria_for<ItemToFilter,PropertyType>(ExtensionPoint<ItemToFilter,PropertyType> extension_point,Criteria<PropertyType> criteria)
         {
             return extension_point.create_using(criteria);
         }
    }
}