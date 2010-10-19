using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class Where<ItemToFilter>
    {
        public static FilteringExtensionPoint<ItemToFilter, PropertyType> has_a<PropertyType>(
            Func<ItemToFilter, PropertyType> property_accessor) 
        {
            return new FilteringExtensionPoint<ItemToFilter,PropertyType>(property_accessor);
        }

    }
}