using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for Security.
	/// </summary>
	public class cSecurity
	{
		private string pSecurityName;
		private string pSecurityID;

		public string Security_Name
		{
			get
			{
				return pSecurityName;
			}
			set
			{
				pSecurityName = value;
			}
		} 

		public string Security_ID
		{
			get
			{
				return pSecurityID;
			}
			set
			{
				pSecurityID = value;
			}
		} 

		public cSecurity()
		{
			
		}
	}
}
