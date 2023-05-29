using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for Cont_stat.
	/// </summary>
	public class Cont_stat
	{
		private string pStatus_ID;
		private string pDescription;
		


		public string Status_ID
		{
			get
			{
				return pStatus_ID;
			}
			set
			{
				pStatus_ID = value;
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
