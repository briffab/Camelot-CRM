using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for User.
	/// </summary>
	public class cInvoice_Item
	{
		string pID;
		string pDescription;
		string pAmount;
		string pVat;
		
		public string Item_ID
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

		public string Description
		{
			get
			{
				return pDescription;
			}
			set
			{
				pDescription = value;
			}
		}

		public string Amount
		{
			get
			{
				return pAmount;
			}
			set
			{
				pAmount= value;
			}
		}

		public string VAT
		{
			get
			{
				return pVat;
			}
			set
			{
				pVat= value;
			}
		}
	}
}
