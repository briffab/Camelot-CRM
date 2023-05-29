using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for cSec_type.
	/// </summary>
	public class cSec_type
	{
		private string pSecName;
		private string pSecID;
		private string pModifier;
		private string pModdate;

		public string Security_Type
		{
			get
			{
				return pSecName;
			}
			set
			{
				pSecName = value;
			}
		} 

		public string Security_Modifier
		{
			get
			{
				return pModifier;
			}
			set
			{
				pModifier = value;
			}
		} 

		public string Mod_Date
		{
			get
			{
				return pModdate;
			}
			set
			{
				pModdate = value;
			}
		} 

		public string Sec_ID
		{
			get
			{
				return pSecID;
			}
			set
			{
				pSecID = value;
			}
		} 
	}
}
