using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for Facilities.
	/// </summary>
	public class Security_Types : System.Collections.CollectionBase
	{
		
		public void Add(cSec_type sec)
		{
			List.Add(sec);
		}

		public cSec_type Item(int Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Widget type, then returned to the 
			// caller.
			return (cSec_type) List[Index];
		}

	}
}
