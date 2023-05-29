using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for Comp_stats.
	/// </summary>
	public class Comp_stats: System.Collections.CollectionBase
	{
		public void Add(Comp_stat oc)
		{
			List.Add(oc);
		}

		public Comp_stat Item(int Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Widget type, then returned to the 
			// caller.
			return (Comp_stat) List[Index];
		}

	}
}
