namespace nothinbutdotnetprep.infrastructure.searching
{
    public interface ExtensionPoint<ItemToFilter,PropertyType>
    {
        Criteria<ItemToFilter> create_using(Criteria<PropertyType> specific_criteria);
    }
}