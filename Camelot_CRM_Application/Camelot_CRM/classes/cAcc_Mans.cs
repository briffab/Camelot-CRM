using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for cAcc_Mans.
	/// </summary>
	public class cAcc_Mans : System.Collections.CollectionBase
	{
		public void Add(cAccMan ac)
		{
			List.Add(ac);
		}

		public cAccMan Item(int Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Widget type, then returned to the 
			// caller.
			return (cAccMan) List[Index];
		}

	}
}
