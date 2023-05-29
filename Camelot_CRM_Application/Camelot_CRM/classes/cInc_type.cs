using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for cInc_type.
	/// </summary>
	public class cInc_type
	{
		private string pIncName;
		private string pIncID;

		public string Incident_Type
		{
			get
			{
				return pIncName;
			}
			set
			{
				pIncName = value;
			}
		} 

		public string Inc_ID
		{
			get
			{
				return pIncID;
			}
			set
			{
				pIncID = value;
			}
		} 
	}
}
