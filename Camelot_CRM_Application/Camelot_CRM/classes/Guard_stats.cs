using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for Guard_stats.
	/// </summary>
	public class Guard_stats: System.Collections.CollectionBase
	{
		public void Add(Guard_stat oc)
		{
			List.Add(oc);
		}

		public Guard_stat Item(int Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Widget type, then returned to the 
			// caller.
			return (Guard_stat) List[Index];
		}

	}
}
