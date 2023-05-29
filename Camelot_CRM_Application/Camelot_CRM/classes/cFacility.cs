using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for property.
	/// </summary>
	public class cFacility
	{
		private string pFacilityName;
		private string pFacilityID;

		public string Facility_Name
		{
			get
			{
				return pFacilityName;
			}
			set
			{
				pFacilityName = value;
			}
		} 

		public string Facility_ID
		{
			get
			{
				return pFacilityID;
			}
			set
			{
				pFacilityID = value;
			}
		} 

		public cFacility()
		{
			
		}
	}
}
