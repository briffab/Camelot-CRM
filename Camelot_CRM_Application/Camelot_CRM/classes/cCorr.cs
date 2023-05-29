using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for cCorr.
	/// </summary>
	public class cCorr
	{
		private string pCorrDesc;
		private string pCorrID;

		public string Corr_Desc
		{
			get
			{
				return pCorrDesc;
			}
			set
			{
				pCorrDesc = value;
			}
		} 

		public string Corr_ID
		{
			get
			{
				return pCorrID;
			}
			set
			{
				pCorrID = value;
			}
		} 

	}
}
