using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for cUsers.
	/// </summary>
	public class Photos: System.Collections.CollectionBase
	{
		public void Add(photo p)
		{
			List.Add(p);
		}

		public photo Item(int Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Widget type, then returned to the 
			// caller.
			return (photo) List[Index];
		}

	}
}

