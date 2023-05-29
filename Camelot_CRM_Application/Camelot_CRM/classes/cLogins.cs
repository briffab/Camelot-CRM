using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for cUsers.
	/// </summary>
	public class cLogins: System.Collections.CollectionBase
	{
		public void Add(cLogin u)
		{
			List.Add(u);
		}

		public cLogin Item(int Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Widget type, then returned to the 
			// caller.
			return (cLogin) List[Index];
		}
	}
}

