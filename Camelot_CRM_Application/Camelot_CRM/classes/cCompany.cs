using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for Company.
	/// </summary>
	public class cCompany
	{
		private string pCompanyName;
		private string pCompanyID;

		public string Company_Name
		{
			get
			{
				return pCompanyName;
			}
			set
			{
				pCompanyName = value;
			}
		} 

		public string Company_ID
		{
			get
			{
				return pCompanyID;
			}
			set
			{
				pCompanyID = value;
			}
		} 
	}
}
