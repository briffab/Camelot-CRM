using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for cDoc_Type.
	/// </summary>
	public class cDoc_Type
	{
		private string pType_id;
		private string pDesc;

		public string Type_ID
		{
			get
			{
				return pType_id;
			}
			set
			{
				pType_id = value;
			}
		}

		public string Description
		{
			get
			{
				return pDesc;
			}
			set
			{
				pDesc = value;
			}
		}

	}
}
