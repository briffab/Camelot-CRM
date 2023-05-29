using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for User.
	/// </summary>
	public class cLogin
	{
		string pUname;
		int pID;
		string pDatabase;
		string pConstring;
		
		
		
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

		public string Database
		{
			get
			{
				return pDatabase;
			}
			set
			{
				pDatabase = value;
			}
		}

		public string ConnString
		{
			get
			{
				return pConstring;
			}
			set
			{
				pConstring = value;
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
	}
}
