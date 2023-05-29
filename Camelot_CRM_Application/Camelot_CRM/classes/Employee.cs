using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for Employee.
	/// </summary>
	public class Employee
	{
		private string pEmp_ID;
		private string pJob;
		private string pEmp_Name;
		private string pEmail;
		private string pPhone;
		private string pWMobile;
		private string pPMobile;
		private string pUserID;
		private string pActive;
		private string pAccMan;


		public string Phone
		{
			get
			{
				return pPhone;
			}
			set
			{
				pPhone = value;
			}
		}

		public string WMobile
		{
			get
			{
				return pWMobile;
			}
			set
			{
				pWMobile = value;
			}
		}

		public string PMobile
		{
			get
			{
				return pPMobile;
			}
			set
			{
				pPMobile = value;
			}
		}

		public string AccMan
		{
			get
			{
				return pAccMan;
			}
			set
			{
				pAccMan = value;
			}
		}

		public string Active
		{
			get
			{
				return pActive;
			}
			set
			{
				pActive = value;
			}
		}

		public string UserID
		{
			get
			{
				return pUserID;
			}
			set
			{
				pUserID = value;
			}
		}

		


		public string Email
		{
			get
			{
				return pEmail;
			}
			set
			{
				pEmail = value;
			}
		}

		public string Job
		{
			get
			{
				return pJob;
			}
			set
			{
				pJob = value;
			}
		}

		public string Emp_ID
		{
			get
			{
				return pEmp_ID;
			}
			set
			{
				pEmp_ID = value;
			}
		}

		public string Emp_Name
		{
			get
			{
				return pEmp_Name;
			}
			set
			{
				pEmp_Name = value;
			}
		} 
	}
}
