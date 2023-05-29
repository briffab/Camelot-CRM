using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for C_Type.
	/// </summary>
	public class cont_type
	{
		private string pC_TypeID;
		private string pDescription;
		


		public string C_TypeID
		{
			get
			{
				return pC_TypeID;
			}
			set
			{
				pC_TypeID = value;
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
	}
}
