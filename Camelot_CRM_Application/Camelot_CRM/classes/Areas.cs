using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for Areas.
	/// </summary>
	public class Areas : System.Collections.CollectionBase
	{
		public void Add(Area Ar)
		{
			List.Add(Ar);
		}

		public Area Item(int Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Widget type, then returned to the 
			// caller.
			return (Area) List[Index];
		}

	}
}
