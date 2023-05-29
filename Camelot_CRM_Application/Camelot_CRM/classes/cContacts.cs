using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for Areas.
	/// </summary>
	public class cContacts : System.Collections.CollectionBase
	{
		public void Add(cContact ct)
		{
			List.Add(ct);
		}

		public cContact Item(int Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Widget type, then returned to the 
			// caller.
			return (cContact) List[Index];
		}

	}
}
