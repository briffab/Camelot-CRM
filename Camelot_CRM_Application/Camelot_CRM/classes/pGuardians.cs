using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for pGuardians.
	/// </summary>
	public class pGuardians: System.Collections.CollectionBase
	{
		
		public void Add(cGuardian gd)
		{
			List.Add(gd);
		}

		public cGuardian Item(int Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Widget type, then returned to the 
			// caller.
			return (cGuardian) List[Index];
		}

	}
}
