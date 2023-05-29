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
	/// Summary description for photos.
	/// </summary>
	public class photos : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Button btnUpload;
		Camelot.classes.cProperty lprop;
		Camelot.classes.cMeter lmet;
		Camelot.classes.cFacility lfac;
		Camelot.classes.cUser lUser;
		Camelot.classes.cSecurity lsec;
		Camelot.classes.cGuardian lguard;
		public Camelot.classes.Photos lPhotos = new Photos();
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Button btnDef;
		protected System.Web.UI.WebControls.TextBox txtDesc;
		protected System.Web.UI.WebControls.TextBox txtPicID;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnDel;
		protected System.Web.UI.WebControls.DataGrid dgImgs;
		public string imgUrl;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.Button btnClose;
		private string ptype="";

		private void Page_Load(object sender, System.EventArgs e)
		{
			
			bool oktogo;
			Camelot.classes.Utils pUtil = new Camelot.classes.Utils();
			lprop= (Camelot.classes.cProperty)Session["curProperty"];
			lmet=(Camelot.classes.cMeter)Session["curMeter"];
			lfac=(Camelot.classes.cFacility)Session["curfac"];
			lsec=(Camelot.classes.cSecurity)Session["cursec"];
			lguard=(Camelot.classes.cGuardian)Session["curGuardian"];
			lUser = (Camelot.classes.cUser)Session["curUser"];
			oktogo = pUtil.valid_user(lUser);

			
			Session["user"] = lUser.ID;

			if(!oktogo)
			{
				Response.Write("<script>window.close();</script>");
			}
			else
			{
				ptype = Session["ptype"].ToString();
				switch(ptype)
				{
					case "1":
						Session["parent"] =lprop.Property_ID;
						this.lblTitle.Text = lprop.Property_Name;
						break;
					case "2":
						Session["parent"] =lfac.Facility_ID;
						this.lblTitle.Text = lfac.Facility_ID;
						break;
					case "3":
						Session["parent"] =lmet.Meter_ID;
						this.lblTitle.Text = lmet.Meter_Location;
						break;
					case "5":
						Session["parent"] =lguard.Guardian_ID;
						this.lblTitle.Text = lguard.Guardian_Name;
						break;
					case "6":
						Session["parent"] =lsec.Security_ID;
						this.lblTitle.Text = lsec.Security_Name;
						break;
				}
				getpictures(Session["parent"].ToString());	
			}			
		}

		private void getphoto(string photo_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_photo";

			cmd.Parameters.Add(
				new SqlParameter("@P_ID", photo_id));

			rdr = cmd.ExecuteReader();
			lPhotos.Clear();
			while(rdr.Read())
			{
				byte[] img= new byte[0];
				img =  (byte[])rdr["PHOTO"];
				string file = "c:\\inetpub\\wwwroot\\camelot_crm\\\\photos\\\\" + rdr["filename"].ToString();
				string sfile = "\\camelot_crm\\\\photos\\\\" + rdr["filename"].ToString();
				FileStream fs = new FileStream(file, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write, System.IO.FileShare.ReadWrite);
				fs.Write(img,0,(int)rdr["filesize"]);
				fs.Close();
				imgUrl=sfile;
			}
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();   
		}

		private void getpictures(string parent)
		{
		
 
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			imgUrl = "";
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_photos";

			cmd.Parameters.Add(
				new SqlParameter("@P_ID", parent));
			cmd.Parameters.Add(
				new SqlParameter("@type", ptype));

			rdr = cmd.ExecuteReader();
			lPhotos.Clear();
			while(rdr.Read())
			{
				Camelot.classes.photo pt = new Camelot.classes.photo();
				pt.Photo_ID = rdr["photo_id"].ToString();
				pt.Description = rdr["description"].ToString();
				pt.FileName = "c:\\inetpub\\wwwroot\\camelot_crm\\\\photos\\\\" + rdr["filename"].ToString();
				pt.ThumbName = "\\camelot_crm\\\\photos\\\\t" + rdr["filename"].ToString();
				string sfile = "c:\\inetpub\\wwwroot\\camelot_crm\\\\photos\\\\t" + rdr["filename"].ToString();
				pt.Parent = rdr["parent"].ToString();
				pt.Record_Modifier = rdr["record_modifier"].ToString();
				pt.Date_Entered = rdr["date_entered"].ToString();
				pt.Default = rdr["is_default"].ToString();
				

				byte[] img= new byte[0];
				img =  (byte[])rdr["THUMBNAIL"];
 
				FileStream fs = new FileStream(sfile, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write, System.IO.FileShare.ReadWrite);
				fs.Write(img,0,(int)rdr["thumbsize"]);
				fs.Close();

				if(pt.Default=="True")
				{
					getphoto(pt.Photo_ID);
				}
				lPhotos.Add(pt);
			}
			if(imgUrl=="")
			{
				imgUrl = "\\camelot_crm\\images\\cam_logo.gif";

			}
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();   

			this.dgImgs.DataSource = lPhotos;
			this.dgImgs.DataBind();
			set_cells();


		}

		private void set_cells()
		{
			foreach(DataGridItem dgi in dgImgs.Items)
			{
				string dt = dgi.Cells[1].Text;
				if(dt=="True")
				{
					dgi.Cells[2].ForeColor=System.Drawing.Color.Blue;
					dgi.Cells[3].ForeColor=System.Drawing.Color.Blue;
					dgi.Cells[4].ForeColor=System.Drawing.Color.Blue;
				}
			}
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
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public void ShowPhoto(Object sender, DataGridCommandEventArgs e) 
		{
			if(e.CommandName=="Def")
			{
				setdef(e.Item.Cells[0].Text, Session["parent"].ToString());
				getpictures(Session["parent"].ToString());
			}
			else
			{
				getphoto(e.Item.Cells[0].Text);
			}
		}

		public void dgImgs_Delete(Object sender, DataGridCommandEventArgs e) 
		{
			deletephoto(e.Item.Cells[0].Text);
			getpictures(Session["parent"].ToString());
		}

		private void setdef(string photo_id, string prop)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "set_def_photo";

			cmd.Parameters.Add(
				new SqlParameter("@photo_id", photo_id));
			cmd.Parameters.Add(
				new SqlParameter("@parent", prop));
			cmd.Parameters.Add(
				new SqlParameter("@type", ptype));
			
			cmd.ExecuteNonQuery();
				
			cmd.Dispose();
			conn.Close();
			conn.Dispose();	
		}


		

		private void deletephoto(string photo_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "delete_photo";

			cmd.Parameters.Add(
				new SqlParameter("@photo_id", photo_id));
			
			cmd.ExecuteNonQuery();
				
			cmd.Dispose();
			conn.Close();
			conn.Dispose();	
		}

		private void btnUpload_Click(object sender, System.EventArgs e)
		{
			/*if( filMyFile.PostedFile != null )
			{
				// Get a reference to PostedFile object
				HttpPostedFile myFile = filMyFile.PostedFile;

				// Get size of uploaded file
				int nFileLen = myFile.ContentLength; 

				// make sure the size of the file is > 0
				if( nFileLen > 0 )
				{
					// Allocate a buffer for reading of the file
					byte[] myData = new byte[nFileLen];

					// Read uploaded file from the Stream
					myFile.InputStream.Read(myData, 0, nFileLen);

					// Create a name for the file to store
					string strFilename = Path.GetFileName(myFile.FileName);
					byte[] thumb = makeThumb(myFile.FileName);
					byte[] img = makeMain(myFile.FileName);
					WriteToDB(strFilename, ref img, myFile.ContentType, ref thumb);
					getpictures(lprop.Property_ID);
				}
			}*/
		}


		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.close();</script>");
		}

		private void btnDef_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
