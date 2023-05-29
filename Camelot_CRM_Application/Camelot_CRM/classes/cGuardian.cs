using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for Guardian.
	/// </summary>
	public class cGuardian
	{

		private string pGuardianName;
		private string pGuardianID;

		public string Guardian_Name
		{
			get
			{
				return pGuardianName;
			}
			set
			{
				pGuardianName = value;
			}
		} 

		public string Guardian_ID
		{
			get
			{
				return pGuardianID;
			}
			set
			{
				pGuardianID = value;
			}
		} 
	}
}
