using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for User.
	/// </summary>
	public class photo
	{
		string pID;
		string pParent;
		string pDescription;
		string pFileName;
		string pThumbName;
		string pRecord_Modifier;
		string pDate_Entered;
		string pDefault;


		public string ThumbName
		{
			get
			{
				return pThumbName;
			}
			set
			{
				pThumbName = value;
			}
		}
		
		public string Photo_ID
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

		public string Default
		{
			get
			{
				return pDefault;
			}
			set
			{
				pDefault = value;
			}
		}

		public string Parent
		{
			get
			{
				return pParent;
			}
			set
			{
				pParent = value;
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

		public string FileName
		{
			get
			{
				return pFileName;
			}
			set
			{
				pFileName = value;
			}
		}

		public string Record_Modifier
		{
			get
			{
				return pRecord_Modifier;
			}
			set
			{
				pRecord_Modifier= value;
			}
		}

		public string Date_Entered
		{
			get
			{
				return pDate_Entered;
			}
			set
			{
				pDate_Entered= value;
			}
		}
	}
}
