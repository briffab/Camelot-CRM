using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for Cont_Stats.
	/// </summary>
	public class cJTitles: System.Collections.CollectionBase
	{
		public void Add(cJTitle jt)
		{
			List.Add(jt);
		}

		public cJTitle Item(int Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Widget type, then returned to the 
			// caller.
			return (cJTitle) List[Index];
		}

	}
}

