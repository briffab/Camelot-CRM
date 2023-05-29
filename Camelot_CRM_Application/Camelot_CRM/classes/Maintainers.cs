using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for Maintainers.
	/// </summary>
	public class Maintainers: System.Collections.CollectionBase
	{
		
		public void Add(cMaintenance man)
		{
			List.Add(man);
		}

		public cMaintenance Item(int Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Widget type, then returned to the 
			// caller.
			return (cMaintenance) List[Index];
		}

	}
}
