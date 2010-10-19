using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class DefaultCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter, PropertyType>
    {
        Func<ItemToFilter, PropertyType> property_accessor;

        public DefaultCriteriaFactory(Func<ItemToFilter, PropertyType> property_accessor)
        {
            this.property_accessor = property_accessor;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value_to_equal)
        {
            return equal_to_any(value_to_equal);
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] values)
        {
            return get_criteria(x => new List<PropertyType>(values).Contains(property_accessor(x)));
        }

        public Criteria<ItemToFilter> not_equal_to(PropertyType value)
        {
            return new NotCriteria<ItemToFilter>(equal_to(value));
        }

        public Criteria<ItemToFilter> get_criteria(Predicate<ItemToFilter> criteria_predicate)
        {
            return new AnonymousCriteria<ItemToFilter>(criteria_predicate);
        }
    }
}