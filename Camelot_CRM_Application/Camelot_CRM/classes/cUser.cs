using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for User.
	/// </summary>
	public class cUser
	{
		string pUname;
		int pID;
		string pName;
		string pMenu;
		string pPermission;
		string pAccMan;
		string pEmail;
		string pPhone;
		string pPMobile;
		string pWMobile;
		string pJob;

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
		
		public string Uname
		{
			get
			{
				return pUname;
			}
			set
			{
				pUname = value;
			}
		}

		public int ID
		{
			get
			{
				return pID;
			}
			set
			{
				pID = value;
			}
		}

		public string Name
		{
			get
			{
				return pName;
			}
			set
			{
				pName = value;
			}
		}

		public string Menu
		{
			get
			{
				return pMenu;
			}
			set
			{
				pMenu= value;
			}
		}

		public string Permission
		{
			get
			{
				return pPermission;
			}
			set
			{
				pPermission= value;
			}
		}
	}
}
