using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for cUsers.
	/// </summary>
	public class Inv_Periods: System.Collections.CollectionBase
	{
		public void Add(Inv_Period p)
		{
			List.Add(p);
		}

		public Inv_Period Item(int Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Widget type, then returned to the 
			// caller.
			return (Inv_Period) List[Index];
		}

	}
}

