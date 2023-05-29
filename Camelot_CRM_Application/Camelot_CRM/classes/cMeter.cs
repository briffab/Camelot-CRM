using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for cMeter.
	/// </summary>
	public class cMeter
	{
		private string pMeterLoc;
		private string pMeterID;
		private string pMeterType;

		public string Meter_Location
		{
			get
			{
				return pMeterLoc;
			}
			set
			{
				pMeterLoc = value;
			}
		} 

		public string Meter_ID
		{
			get
			{
				return pMeterID;
			}
			set
			{
				pMeterID = value;
			}
		} 

		public string Meter_Type
		{
			get
			{
				return pMeterType;
			}
			set
			{
				pMeterType = value;
			}
		}

	}
}

