using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for Comp_stats.
	/// </summary>
	public class cInc_urgs: System.Collections.CollectionBase
	{
		public void Add(cInc_urg oc)
		{
			List.Add(oc);
		}

		public cInc_urg Item(int Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Widget type, then returned to the 
			// caller.
			return (cInc_urg) List[Index];
		}

	}
}
