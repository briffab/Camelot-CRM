using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data.SqlClient;
using CC = Camelot.classes;

namespace Camelot.forms
{
	/// <summary>
	/// Summary description for upload1.
	/// </summary>
	/// 
	public class upload_insp_att : System.Web.UI.Page
	{
		private CC.cFiles files = new Camelot.classes.cFiles();

		private void Page_Load(object sender, System.EventArgs e)
		{
			if( Request.ContentType.IndexOf( "multipart/form-data" ) < 0 )
				return;

			string strFilename = "";
			//pUser = (Camelot.classes.cUser)Session["curUser"];
			//Response.Write( Request.Files.Count.ToString() + " file(s) have been uploaded:\r\n\r\n" );
			
			CC.cFiles nfiles = (CC.cFiles)Session["insp_files"];
			if(nfiles != null)
			{
				files = nfiles;
			}

			for( int i = 0; i < Request.Files.Count; i++ )
			{
				HttpPostedFile myFile = Request.Files[i];
				int nFileLen = myFile.ContentLength; 
				if( nFileLen > 0 )
				{
					// Allocate a buffer for reading of the file
					byte[] myData = new byte[nFileLen];

					// Read uploaded file from the Stream
					myFile.InputStream.Read(myData, 0, nFileLen);

					// Create a name for the file to store
					strFilename = "c:\\inetpub\\wwwroot\\camelot_crm\\email\\" + Path.GetFileName(myFile.FileName);
					CC.cFile file = new Camelot.classes.cFile();
					file.File = strFilename;
					file.Size = nFileLen.ToString();
					file.Data = myData;
					myFile.SaveAs(strFilename);
					files.Add(file);
				}
				//Response.Write( strFilename + "\r\n" );
			}

			Session["insp_files"] = files;
		}


		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
