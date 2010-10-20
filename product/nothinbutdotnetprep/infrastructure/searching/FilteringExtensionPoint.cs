using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class FilteringExtensionPoint<ItemToFilter, PropertyType> : ExtensionPoint<ItemToFilter,PropertyType>
    {
        Func<ItemToFilter, PropertyType> accessor;

        public FilteringExtensionPoint(Func<ItemToFilter, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public Criteria<ItemToFilter> create_using(Criteria<PropertyType> specific_criteria)
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(accessor, specific_criteria);
        }

        public ExtensionPoint<ItemToFilter, PropertyType> not
        {
            get
            {
                return new NegatingExtensionPoint<ItemToFilter, PropertyType>(this);
            }
        }
    }
}