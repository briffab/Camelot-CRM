using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for cInc_type.
	/// </summary>
	public class cInc_src
	{
		private string pIncSrc;
		private string pSrcID;
		private string pSrcType;

		public string Incident_Source
		{
			get
			{
				return pIncSrc;
			}
			set
			{
				pIncSrc = value;
			}
		} 

		public string Source_Type
		{
			get
			{
				return pSrcType;
			}
			set
			{
				pSrcType = value;
			}
		} 


		public string Src_ID
		{
			get
			{
				return pSrcID;
			}
			set
			{
				pSrcID = value;
			}
		} 
	}
}
