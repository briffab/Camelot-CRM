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
using cc = Camelot.classes;
using System.IO;
using System.Data.SqlClient;

namespace Camelot.forms
{
	/// <summary>
	/// Summary description for import_pictures.
	/// </summary>
	public class import_pictures : System.Web.UI.Page
	{
		string prop_id= "";
		string rec_man = "";
		string date = "";

		private void Page_Load(object sender, System.EventArgs e)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_old_pictures";

			rdr = cmd.ExecuteReader();

			string path = "";
	
			while(rdr.Read())
			{
				prop_id = rdr["object_id"].ToString();
				rec_man = rdr["record_manager"].ToString();
				date = rdr["date_entered"].ToString();
				path = rdr["picture_path"].ToString();

				FileInfo finfo = new FileInfo(path);
				if(finfo.Exists)
				{
					FileStream fs = new FileStream(path, FileMode.Open,FileAccess.Read);

					byte[] myData = new byte[fs.Length];
					fs.Read(myData, 0,System.Convert.ToInt32(fs.Length));

					// Create a name for the file to store
					string strFilename = Path.GetFileName(fs.Name);
					byte[] thumb = makeThumb(fs.Name);
					byte[] img = makeMain(fs.Name);
					WriteToDB(strFilename, ref img, ref thumb, ref myData);
				}
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

		private void WriteToDB(string strPath, ref byte[] Buffer, ref byte[] thumb, ref byte[] full)
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
				new SqlParameter("@CONT_TYPE", "image/jpeg"));
			cmd.Parameters.Add(
				new SqlParameter("@FILESIZE", Buffer.Length));
			cmd.Parameters.Add(
				new SqlParameter("@THUMBSIZE", thumb.Length));
			cmd.Parameters.Add(
				new SqlParameter("@FULLSIZE", full.Length));	
			cmd.Parameters.Add(
				new SqlParameter("@PARENT", prop_id));
			cmd.Parameters.Add(
				new SqlParameter("@PHOTO_TYPE", "1"));
			cmd.Parameters.Add(
				new SqlParameter("@record_modifier", rec_man));
			rdr = cmd.ExecuteReader();

			rdr.Close();
			cmd.Dispose();
			conn.Dispose();
			
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
