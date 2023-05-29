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
using Camelot.classes;

namespace Camelot.forms
{
	/// <summary>
	/// Summary description for upload1.
	/// </summary>
	public class upload : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			if( Request.ContentType.IndexOf( "multipart/form-data" ) < 0 )
				return;

			string strFilename = "";
			string path = "c:\\inetpub\\wwwroot\\camelot_crm\\upload\\";
		
			//Response.Write( Request.Files.Count.ToString() + " file(s) have been uploaded:\r\n\r\n" );

			for( int i = 0; i < Request.Files.Count; i++ )
			{
				HttpPostedFile myFile = Request.Files[i];
				int nFileLen = myFile.ContentLength; 
				if( nFileLen > 0 )
				{
					// Allocate a buffer for reading of the file
					byte[] myData = new byte[nFileLen];
					
					myFile.SaveAs(path + Path.GetFileName(myFile.FileName));
					// Read uploaded file from the Stream
					myFile.InputStream.Read(myData, 0, nFileLen);

					// Create a name for the file to store
					strFilename = Path.GetFileName(path + myFile.FileName);
					byte[] thumb = makeThumb(path + strFilename);
					byte[] img = makeMain(path + strFilename);
					WriteToDB(strFilename, ref img, myFile.ContentType, ref thumb, ref myData);
				}

				//Response.Write( strFilename + "\r\n" );
			}
		}

		public  bool ThumbnailCallback()
		{
			return true;
		}

		private byte[] makeThumb(string filename)
		{
			System.Drawing.Image image = System.Drawing.Image.FromFile(filename);

			System.Drawing.Image thumbnailImage = image.GetThumbnailImage(120,80, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);

			MemoryStream imageStream = new MemoryStream();

			// put the image into the memory stream
			thumbnailImage.Save(imageStream, System.Drawing.Imaging.ImageFormat.Jpeg);
			

			// make byte array the same size as the image
			byte[] imageContent = new Byte[imageStream.Length];

			// rewind the memory stream
			imageStream.Position = 0;

			// load the byte array with the image
			imageStream.Read(imageContent, 0, (int)imageStream.Length);

			return imageContent;

		}

		private byte[] makeMain(string filename)
		{
			System.Drawing.Image image = System.Drawing.Image.FromFile(filename);

			System.Drawing.Image thumbnailImage = image.GetThumbnailImage(400,300, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);

			MemoryStream imageStream = new MemoryStream();

			// put the image into the memory stream
			thumbnailImage.Save(imageStream, System.Drawing.Imaging.ImageFormat.Jpeg);
			

			// make byte array the same size as the image
			byte[] imageContent = new Byte[imageStream.Length];

			// rewind the memory stream
			imageStream.Position = 0;

			// load the byte array with the image
			imageStream.Read(imageContent, 0, (int)imageStream.Length);

			return imageContent;

		}

		private void WriteToDB(string strPath, ref byte[] Buffer, string cType, ref byte[] thumb, ref byte[] full)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			
			
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "add_photo";

			cmd.Parameters.Add(
				new SqlParameter("@FILENAME", strPath));
			cmd.Parameters.Add(
				new SqlParameter("@DESCRIPTION", ""));
			cmd.Parameters.Add(
				new SqlParameter("@PHOTO", Buffer));
			cmd.Parameters.Add(
				new SqlParameter("@thumb", thumb));
			cmd.Parameters.Add(
				new SqlParameter("@full", full));
			cmd.Parameters.Add(
				new SqlParameter("@CONT_TYPE", cType));
			cmd.Parameters.Add(
				new SqlParameter("@FILESIZE", Buffer.Length));
			cmd.Parameters.Add(
				new SqlParameter("@THUMBSIZE", thumb.Length));
			cmd.Parameters.Add(
				new SqlParameter("@FULLSIZE", full.Length));	
			cmd.Parameters.Add(
				new SqlParameter("@PARENT", Session["parent"].ToString()));
			cmd.Parameters.Add(
				new SqlParameter("@PHOTO_TYPE", Session["ptype"].ToString()));
			cmd.Parameters.Add(
				new SqlParameter("@record_modifier", Session["user"].ToString()));
			rdr = cmd.ExecuteReader();
			
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
