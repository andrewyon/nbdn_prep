﻿using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public interface CriteriaFactory<ItemToFilter, PropertyType>
    {
        Criteria<ItemToFilter> equal_to(PropertyType value_to_equal);
        Criteria<ItemToFilter> equal_to_any(params PropertyType[] values);
        Criteria<ItemToFilter> not_equal_to(PropertyType value);
        Criteria<ItemToFilter> get_criteria(Predicate<ItemToFilter> criteria_predicate);
    }
}