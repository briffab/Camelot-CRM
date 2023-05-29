using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for cMeter.
	/// </summary>
	public class cRoute
	{
		private string pRouteID;
		private string pName;

		public string Route_ID
		{
			get
			{
				return pRouteID;
			}
			set
			{
				pRouteID = value;
			}
		} 

		public string Name
		{
			get
			{
				return pName;
			}
			set
			{
				pName = value;
			}
		}

	}
}

