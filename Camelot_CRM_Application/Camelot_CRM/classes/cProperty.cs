using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for property.
	/// </summary>
	public class cProperty
	{
		private string pPropertyName;
		private string pPropertyID;

		public string Property_Name
		{
			get
			{
				return pPropertyName;
			}
			set
			{
				pPropertyName = value;
			}
		} 

		public string Property_ID
		{
			get
			{
				return pPropertyID;
			}
			set
			{
				pPropertyID = value;
			}
		} 

		public cProperty()
		{
			
		}
	}
}
