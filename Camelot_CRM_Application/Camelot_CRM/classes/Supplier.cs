using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for Supplier.
	/// </summary>
	public class Supplier: System.Collections.CollectionBase
	{
		
		public void Add(cSupplier man)
		{
			List.Add(man);
		}

		public cSupplier Item(int Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Widget type, then returned to the 
			// caller.
			return (cSupplier) List[Index];
		}

	}
}
