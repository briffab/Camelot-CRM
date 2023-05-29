using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for cInc_type.
	/// </summary>
	public class cInc_urg
	{
		private string pIncUrg;
		private string pUrgID;
		private string pUrgTime;

		public string Incident_Urgency
		{
			get
			{
				return pIncUrg;
			}
			set
			{
				pIncUrg = value;
			}
		} 

		public string Urg_ID
		{
			get
			{
				return pUrgID;
			}
			set
			{
				pUrgID = value;
			}
		}
 
		public string Urg_Time
		{
			get
			{
				return pUrgTime;
			}
			set
			{
				pUrgTime = value;
			}
		}
	}
}
