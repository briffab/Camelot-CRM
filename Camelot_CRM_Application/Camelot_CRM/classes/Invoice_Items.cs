using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for cUsers.
	/// </summary>
	public class Invoice_Items: System.Collections.CollectionBase
	{
		public void Remove(cInvoice_Item p)
		{
			List.Remove(p);
		}

		public void Add(cInvoice_Item p)
		{
			List.Add(p);
		}

		public cInvoice_Item Item(int Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Widget type, then returned to the 
			// caller.
			return (cInvoice_Item) List[Index];
		}

	}
}

