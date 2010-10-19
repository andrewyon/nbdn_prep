using System;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class ComparableCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter, PropertyType>
        where PropertyType : IComparable<PropertyType>
    {
        Func<ItemToFilter, PropertyType> accessor;
        CriteriaFactory<ItemToFilter, PropertyType> original;

        public ComparableCriteriaFactory(Func<ItemToFilter, PropertyType> accessor,
                                         CriteriaFactory<ItemToFilter, PropertyType> original)
        {
            this.accessor = accessor;
            this.original = original;
        }

        public Criteria<ItemToFilter> greater_than(PropertyType value)
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(accessor,
                                                                    new IsGreaterThan<PropertyType>(value));
        }

        public Criteria<ItemToFilter> between(PropertyType start, PropertyType end)
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(accessor,
                                                                    new IsBetween<PropertyType>(start, end));
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value_to_equal)
        {
            return original.equal_to(value_to_equal);
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] values)
        {
            return original.equal_to_any(values);
        }

        public Criteria<ItemToFilter> not_equal_to(PropertyType value)
        {
            return original.not_equal_to(value);
        }

        public Criteria<ItemToFilter> get_criteria(Predicate<ItemToFilter> criteria_predicate)
        {
            return original.get_criteria(criteria_predicate);
        }
    }
}