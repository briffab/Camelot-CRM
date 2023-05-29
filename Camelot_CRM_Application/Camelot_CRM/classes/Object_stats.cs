using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for Object_stats.
	/// </summary>
	public class Object_stats: System.Collections.CollectionBase
	{
		public void Add(Object_stat os)
		{
			List.Add(os);
		}

		public Object_stat Item(int Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Widget type, then returned to the 
			// caller.
			return (Object_stat) List[Index];
		}

	}
}
