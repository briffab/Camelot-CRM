using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for O_Types.
	/// </summary>
	public class O_Types: System.Collections.CollectionBase
	{
		public void Add(O_Type o)
		{
			List.Add(o);
		}

		public O_Type Item(int Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Widget type, then returned to the 
			// caller.
			return (O_Type) List[Index];
		}

	}
}
