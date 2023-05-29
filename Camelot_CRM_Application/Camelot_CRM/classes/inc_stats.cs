using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for Comp_stats.
	/// </summary>
	public class inc_stats: System.Collections.CollectionBase
	{
		public void Add(inc_stat oc)
		{
			List.Add(oc);
		}

		public inc_stat Item(int Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Widget type, then returned to the 
			// caller.
			return (inc_stat) List[Index];
		}

	}
}
