using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for cMeter_type.
	/// </summary>
	public class cMeter_type
	{
		
			private string pMetName;
			private string pMetID;

			public string Meter_Type
			{
				get
				{
					return pMetName;
				}
				set
				{
					pMetName = value;
				}
			} 

			public string Met_ID
			{
				get
				{
					return pMetID;
				}
				set
				{
					pMetID = value;
				}
			} 
		}
	}
