using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for Facilities.
	/// </summary>
	public class Facility_Types : System.Collections.CollectionBase
	{
		
		public void Add(cFac_type fac)
		{
			List.Add(fac);
		}

		public cFac_type Item(int Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Widget type, then returned to the 
			// caller.
			return (cFac_type) List[Index];
		}

	}
}
