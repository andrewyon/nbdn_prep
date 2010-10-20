using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetprep.infrastructure.sorting
{
	public class Order<ItemToCompare>
	{
		public static CustomComparer<ItemToCompare, PropertyType> by_descending<PropertyType>(
			Func<ItemToCompare, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
		{
			return new CustomComparer<ItemToCompare, PropertyType>(accessor, false);
		}

		public static CustomComparer<ItemToCompare, PropertyType> by_ascending<PropertyType>(
			Func<ItemToCompare, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
		{
			return new CustomComparer<ItemToCompare, PropertyType>(accessor, true);
		}
	}
}
