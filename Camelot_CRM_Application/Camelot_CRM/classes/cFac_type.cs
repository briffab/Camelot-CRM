using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for cFac_type.
	/// </summary>
	public class cFac_type
	{
		private string pFacName;
		private string pFacID;
		private string pModifier;
		private string pModdate;

		public string Facility_Type
		{
			get
			{
				return pFacName;
			}
			set
			{
				pFacName = value;
			}
		} 

		public string Facility_Modifier
		{
			get
			{
				return pModifier;
			}
			set
			{
				pModifier = value;
			}
		} 

		public string Mod_Date
		{
			get
			{
				return pModdate;
			}
			set
			{
				pModdate = value;
			}
		} 

		public string Fac_ID
		{
			get
			{
				return pFacID;
			}
			set
			{
				pFacID = value;
			}
		} 
	}
}
