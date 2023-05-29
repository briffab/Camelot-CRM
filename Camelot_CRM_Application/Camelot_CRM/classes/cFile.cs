using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for C_Type.
	/// </summary>
	public class cFile
	{
		private string pFile;
		private string pSize;
		private byte[] pData;


		public string File
		{
			get
			{
				return pFile;
			}
			set
			{
				pFile = value;
			}
		}

		public string Size
		{
			get
			{
				return pSize;
			}
			set
			{
				pSize = value;
			}
		}

		public byte[] Data
		{
			get
			{
				return pData;
			}
			set
			{
				pData = value;
			}
		}

	}
}
