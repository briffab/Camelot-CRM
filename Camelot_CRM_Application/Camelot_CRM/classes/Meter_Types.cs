using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for Meter_Types.
	/// </summary>
	public class Meter_Types: System.Collections.CollectionBase
	{
		
		public void Add(cMeter_type met)
		{
			List.Add(met);
		}

		public cMeter_type Item(int Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Widget type, then returned to the 
			// caller.
			return (cMeter_type) List[Index];
		}

	}
}
