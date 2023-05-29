using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for O_Type.
	/// </summary>
	public class O_Type
	{
		private string pO_TypeID;
		private string pO_TypeCode;
		private string pDescription;
		


		public string O_TypeID
		{
			get
			{
				return pO_TypeID;
			}
			set
			{
				pO_TypeID = value;
			}
		}

		public string O_TypeCode
		{
			get
			{
				return pO_TypeCode;
			}
			set
			{
				pO_TypeCode = value;
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
