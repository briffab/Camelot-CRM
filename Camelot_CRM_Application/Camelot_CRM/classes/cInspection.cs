using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for cInspection.
	/// </summary>
	public class cInspection
	{
		private string pInspDate;
		private string pInspID;

		public string Inspection_Date
		{
			get
			{
				return pInspDate;
			}
			set
			{
				pInspDate = value;
			}
		} 

		public string Inspection_ID
		{
			get
			{
				return pInspID;
			}
			set
			{
				pInspID = value;
			}
		} 

	}
}
