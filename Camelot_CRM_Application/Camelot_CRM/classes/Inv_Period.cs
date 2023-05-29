using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for Inv_Period.
	/// </summary>
	public class Inv_Period
	{
		private string pID;
		private string pDesc;
		private string pPeriod;

		public string ID
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
				return pDesc;
			}
			set
			{
				pDesc = value;
			}
		} 

		public string Period
		{
			get
			{
				return pPeriod;
			}
			set
			{
				pPeriod = value;
			}
		} 

	}
}
