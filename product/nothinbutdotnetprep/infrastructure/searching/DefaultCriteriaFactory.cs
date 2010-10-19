using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class DefaultCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter, PropertyType>
    {
        Func<ItemToFilter, PropertyType> property_accessor;
        Func<Criteria<ItemToFilter>, Criteria<ItemToFilter>> alteration;

        public DefaultCriteriaFactory<ItemToFilter, PropertyType> not
        {
            get
            {
                alteration = x => new NotCriteria<ItemToFilter>(x);
                return this;
            }
        }

        public DefaultCriteriaFactory(Func<ItemToFilter, PropertyType> property_accessor)
        {
            alteration = x => x;
            this.property_accessor = property_accessor;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value_to_equal)
        {
            return equal_to_any(value_to_equal);
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] values)
        {
            return create_property_criteria_for(new IsEqualToAny<PropertyType>(values));
        }


        public Criteria<ItemToFilter> create_property_criteria_for(Criteria<PropertyType> criteria)
        {
            return alteration(new PropertyCriteria<ItemToFilter, PropertyType>(property_accessor, criteria));
        }


    }
}