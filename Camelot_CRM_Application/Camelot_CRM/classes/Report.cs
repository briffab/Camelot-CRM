using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for cContact.
	/// </summary>
	public class Report
	{
		private string pReportName;
		private string pReportID;
		private string pDates;
		private string pProperty;
		private string pCompany;
		private string pAcc_man;

		
		public string AccMan
		{
			get
			{
				return pAcc_man;
			}
			set
			{
				pAcc_man = value;
			}
		}

		public string Dates
		{
			get
			{
				return pDates;
			}
			set
			{
				pDates = value;
			}
		}

		public string Property
		{
			get
			{
				return pProperty;
			}
			set
			{
				pProperty = value;
			}
		}

		public string Company
		{
			get
			{
				return pCompany;
			}
			set
			{
				pCompany = value;
			}
		}

		public string Report_Name
		{
			get
			{
				return pReportName;
			}
			set
			{
				pReportName = value;
			}
		} 

		public string Report_ID
		{
			get
			{
				return pReportID;
			}
			set
			{
				pReportID = value;
			}
		} 

		
	}
}
