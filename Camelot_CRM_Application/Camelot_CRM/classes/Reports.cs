using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for Areas.
	/// </summary>
	public class Reports : System.Collections.CollectionBase
	{
		public void Add(Report ct)
		{
			List.Add(ct);
		}

		public Report Item(int Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Widget type, then returned to the 
			// caller.
			return (Report) List[Index];
		}

	}
}
