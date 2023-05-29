using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for cContact.
	/// </summary>
	public class cContact
	{
		private string pContactName;
		private string pContactID;

		public string Contact_Name
		{
			get
			{
				return pContactName;
			}
			set
			{
				pContactName = value;
			}
		} 

		public string Contact_ID
		{
			get
			{
				return pContactID;
			}
			set
			{
				pContactID = value;
			}
		} 

		public cContact()
		{
			
		}
	}
}
