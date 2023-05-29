using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for C_TYpes.
	/// </summary>
	public class cont_types: System.Collections.CollectionBase
	{
		public void Add(cont_type c)
		{
			List.Add(c);
		}

		public cont_type Item(int Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Widget type, then returned to the 
			// caller.
			return (cont_type) List[Index];
		}

	}
}
