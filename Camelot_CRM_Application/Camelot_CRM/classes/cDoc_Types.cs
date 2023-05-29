using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for C_TYpes.
	/// </summary>
	public class cDoc_Types: System.Collections.CollectionBase
	{
		public void Add(cDoc_Type d)
		{
			List.Add(d);
		}

		public cDoc_Type Item(int Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Widget type, then returned to the 
			// caller.
			return (cDoc_Type) List[Index];
		}

	}
}
