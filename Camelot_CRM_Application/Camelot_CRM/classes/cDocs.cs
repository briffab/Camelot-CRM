using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for C_TYpes.
	/// </summary>
	public class cDocs: System.Collections.CollectionBase
	{
		public void Add(cDoc d)
		{
			List.Add(d);
		}

		public cDoc Item(int Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Widget type, then returned to the 
			// caller.
			return (cDoc) List[Index];
		}

	}
}
