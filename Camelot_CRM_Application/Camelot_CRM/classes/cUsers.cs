using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for cUsers.
	/// </summary>
	public class cUsers: System.Collections.CollectionBase
	{
		public void Add(cUser u)
		{
			List.Add(u);
		}

		public cUser Item(int Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Widget type, then returned to the 
			// caller.
			return (cUser) List[Index];
		}

	}
}

