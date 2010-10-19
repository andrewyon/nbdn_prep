namespace nothinbutdotnetprep.infrastructure.searching
{
    public interface CriteriaFactory<ItemToFilter, PropertyType>
    {
        Criteria<ItemToFilter> equal_to(PropertyType value_to_equal);
        Criteria<ItemToFilter> equal_to_any(params PropertyType[] values);
        Criteria<ItemToFilter> create_property_criteria_for(Criteria<PropertyType> criteria);
    }
}