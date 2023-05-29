using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for cMeterReading.
	/// </summary>
	public class cMeterReading
	{
		private string pReading_id;
		private string pReadingDate;
		private string pInspector;
		private string pMeter_id;
		private string pReading;

	
		public string Reading_id
		{
			get
			{
				return pReading_id;
			}
			set
			{
				pReading_id = value;
			}
		}
 
		public string Reading
		{
			get
			{
				return pReading;
			}
			set
			{
				pReading = value;
			}
		}

		public string ReadingDate
		{
			get
			{
				return pReadingDate;
			}
			set
			{
				pReadingDate = value;
			}
		} 

		public string Inspector_id
		{
			get
			{
				return pInspector;
			}
			set
			{
				pInspector = value;
			}
		} 

		public string Meter_id
		{
			get
			{
				return pMeter_id;
			}
			set
			{
				pMeter_id = value;
			}
		} 
	}
}
