using System;
using nothinbutdotnetprep.infrastructure.ranges;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class ComparableCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter, PropertyType>
        where PropertyType : IComparable<PropertyType>
    {
        CriteriaFactory<ItemToFilter, PropertyType> original;

        public ComparableCriteriaFactory(CriteriaFactory<ItemToFilter, PropertyType> original)
        {
            this.original = original;
        }

        public Criteria<ItemToFilter> greater_than(PropertyType value)
        {
            return create_property_criteria_for(new FallInRange<PropertyType>(new RangeWithNoUpperBound<PropertyType>(value)));
        }

        public Criteria<ItemToFilter> between(PropertyType start, PropertyType end)
        {
            return create_property_criteria_for(new IsBetween<PropertyType>(start, end));
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value_to_equal)
        {
            return original.equal_to(value_to_equal);
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] values)
        {
            return original.equal_to_any(values);
        }


        public Criteria<ItemToFilter> create_property_criteria_for(Criteria<PropertyType> criteria)
        {
            return original.create_property_criteria_for(criteria);
        }

        public DefaultCriteriaFactory<ItemToFilter, PropertyType> not
        {
            get { return original.not; }
        }
    }
}