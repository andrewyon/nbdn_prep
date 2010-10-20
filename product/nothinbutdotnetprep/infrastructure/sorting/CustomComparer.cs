using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetprep.infrastructure.sorting
{
	public class CustomComparer<ItemToCompare, PropertyType> : IComparer<ItemToCompare> where PropertyType : IComparable<PropertyType>
	{
		private Func<ItemToCompare, PropertyType> accessor;
		private bool SortAcsending;

		public CustomComparer(Func<ItemToCompare, PropertyType> accessor, bool SortAcsending)
		{
			this.accessor = accessor;
			this.SortAcsending = SortAcsending;
		}

		public int Compare(ItemToCompare x, ItemToCompare y)
		{
			if (SortAcsending)
				return accessor(x).CompareTo(accessor(y));
			else
				return accessor(y).CompareTo(accessor(x));
		}
	}
}
