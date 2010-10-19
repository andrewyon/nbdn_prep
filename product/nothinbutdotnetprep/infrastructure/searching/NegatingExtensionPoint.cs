namespace nothinbutdotnetprep.infrastructure.searching
{
    public class NegatingExtensionPoint<ItemToFilter, PropertyType> : ExtensionPoint<ItemToFilter, PropertyType>
    {
        ExtensionPoint<ItemToFilter, PropertyType> filtering_extension_point;

        public NegatingExtensionPoint(ExtensionPoint<ItemToFilter, PropertyType> filtering_extension_point)
        {
            this.filtering_extension_point = filtering_extension_point;
        }

        public Criteria<ItemToFilter> create_using(Criteria<PropertyType> specific_criteria)
        {
            return filtering_extension_point.create_using(specific_criteria).not();
        }
    }
}