using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for C_TYpes.
	/// </summary>
	public class cFiles: System.Collections.CollectionBase
	{
		public void Add(cFile c)
		{
			List.Add(c);
		}

		public cFile Item(int Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Widget type, then returned to the 
			// caller.
			return (cFile) List[Index];
		}

		public void Remove(cFile c)
		{
			List.Remove(c);
		}

	}
}
