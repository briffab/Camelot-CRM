using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for C_TYpes.
	/// </summary>
	public class C_Types: System.Collections.CollectionBase
	{
		public void Add(C_Type c)
		{
			List.Add(c);
		}

		public C_Type Item(int Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Widget type, then returned to the 
			// caller.
			return (C_Type) List[Index];
		}

	}
}
