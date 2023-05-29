using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for Cont_Stats.
	/// </summary>
	public class Cont_Stats: System.Collections.CollectionBase
	{
		public void Add(Cont_stat oc)
		{
			List.Add(oc);
		}

		public Cont_stat Item(int Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Widget type, then returned to the 
			// caller.
			return (Cont_stat) List[Index];
		}

	}
}

