using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for Facilities.
	/// </summary>
	public class Incident_Types : System.Collections.CollectionBase
	{
		
		public void Add(cInc_type inc)
		{
			List.Add(inc);
		}

		public cInc_type Item(int Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Widget type, then returned to the 
			// caller.
			return (cInc_type) List[Index];
		}

	}
}
