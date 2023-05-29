using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for C_Type.
	/// </summary>
	public class C_Type
	{
		private string pC_TypeID;
		private string pC_TypeCode;
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

		public string C_TypeCode
		{
			get
			{
				return pC_TypeCode;
			}
			set
			{
				pC_TypeCode = value;
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
