using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for Cont_stat.
	/// </summary>
	public class cJTitle
	{
		private string pTitle_ID;
		private string pDescription;
		


		public string Title_ID
		{
			get
			{
				return pTitle_ID;
			}
			set
			{
				pTitle_ID = value;
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
