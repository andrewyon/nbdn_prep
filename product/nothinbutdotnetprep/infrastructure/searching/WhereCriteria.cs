using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetprep.infrastructure.searching
{
	public class WhereCriteria<T> : Criteria<T>
	{
		private Criteria<T> whereCriteria;

		public WhereCriteria(Criteria<T> where_Criteria)
		{
			this.whereCriteria = where_Criteria;
		}

		public bool is_satisfied_by(T item)
		{
			return whereCriteria.is_satisfied_by(item);
		}
	}
}
