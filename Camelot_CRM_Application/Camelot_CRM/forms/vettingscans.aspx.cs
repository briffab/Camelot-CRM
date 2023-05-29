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
using System.Data.SqlClient;
using cc = Camelot.classes;
using System.IO;

namespace Camelot.forms
{
	/// <summary>
	/// Summary description for vettingscans.
	/// </summary>
	public class vettingscans : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Button btnClose;
		protected System.Web.UI.HtmlControls.HtmlInputFile scan;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.HtmlControls.HtmlInputButton upload;
		protected System.Web.UI.WebControls.TextBox txtScan;
		protected System.Web.UI.WebControls.Label lblstar;
		protected System.Web.UI.WebControls.Label lblMessage;
	
		private cc.cGuardian lres = null;
		protected System.Web.UI.WebControls.DataGrid dgScans;
		private cc.cUser pUser = null;

		private void Page_Load(object sender, System.EventArgs e)
		{
			bool oktogo;
			Camelot.classes.Utils pUtil = new Camelot.classes.Utils();
			pUser = (Camelot.classes.cUser)Session["curUser"];
			oktogo = pUtil.valid_user(pUser);

			if(!oktogo)
			{
				Response.Redirect("../logon.aspx");
			}
			else
			{
				lres=(cc.cGuardian)Session["curGuardian"];
				this.lblTitle.Text = lres.Guardian_Name;
				if(!Page.IsPostBack)
				{
					hideErr();
				}
				pop_scans();
			}
		}

		private void pop_scans()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_vet_scans";

			cmd.Parameters.Add(
				new SqlParameter("@res_ID", lres.Guardian_ID));

			rdr = cmd.ExecuteReader();
	
			this.dgScans.DataSource = rdr;
			this.dgScans.DataBind();
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();   
		}

		private void hideErr()
		{
			this.lblMessage.Visible=false;
			this.lblstar.Visible=false;
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
			this.upload.ServerClick += new System.EventHandler(this.upload_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void WriteToDB(string strPath, ref byte[] full)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			
			try
			{

				conn.ConnectionString = (string)Session["Connection"];
				conn.Open();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "add_vet_scan";

				cmd.Parameters.Add(
					new SqlParameter("@FILENAME", strPath));
				cmd.Parameters.Add(
					new SqlParameter("@res_id", lres.Guardian_ID));
				cmd.Parameters.Add(
					new SqlParameter("@DESCRIPTION", this.txtScan.Text));
				cmd.Parameters.Add(
					new SqlParameter("@SCAN", full));
				cmd.Parameters.Add(
					new SqlParameter("@SIZE", full.Length));
				cmd.Parameters.Add(
					new SqlParameter("@record_modifier", pUser.ID));
				rdr = cmd.ExecuteReader();

				pop_scans();
			}
			catch(Exception e)
			{
				Response.Write(e.Message);
			}

		}

		public void ShowScan(Object sender, DataGridCommandEventArgs e) 
		{
			if(e.CommandName=="View")
			{
				getscan(e.Item.Cells[0].Text);
			}
		}

		private void getscan(string scan_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			string file = "";
			string hfile = "";
			string ex = "";

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_vet_scan";

			cmd.Parameters.Add(
				new SqlParameter("@scan_ID", scan_id));

			rdr = cmd.ExecuteReader();
			while(rdr.Read())
			{
				byte[] img= new byte[0];
				img =  (byte[])rdr["scan"];
				ex= System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString() + rdr["SCAN_NAME"].ToString();
				file = "c:\\inetpub\\wwwroot\\camelot_crm\\scans\\" + ex;
				hfile = "http://192.168.75.1/camelot_crm/scans/" + ex;
				FileStream fs = new FileStream(file, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write, System.IO.FileShare.ReadWrite);
				fs.Write(img,0,(int)rdr["SCAN_size"]);
				fs.Close();
			}
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
   
			Response.Write("<script>window.open('" + hfile + "');</script>");
			//Response.Redirect(hfile);
		}

		public void dgScans_Delete(Object sender, DataGridCommandEventArgs e) 
		{
			deletescan(e.Item.Cells[0].Text);
			pop_scans();
		}

		private void deletescan(string scan_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "delete_vet_scan";

			cmd.Parameters.Add(
				new SqlParameter("@scan_id", scan_id));
			
			cmd.ExecuteNonQuery();
				
			cmd.Dispose();
			conn.Close();
			conn.Dispose();	
		}


		private void upload_ServerClick(object sender, System.EventArgs e)
		{
			if(this.txtScan.Text == "")
			{
				this.lblMessage.Text = "Please give a description for the scan";
				this.lblMessage.Visible = true;
				this .lblstar.Visible = true;
			}
			else
			{
				int nFileLen = this.scan.PostedFile.ContentLength; 
				if( nFileLen > 0 )
				{
					// Allocate a buffer for reading of the file
					byte[] myData = new byte[nFileLen];

					// Read uploaded file from the Stream
					this.scan.PostedFile.InputStream.Read(myData, 0, nFileLen);

					// Create a name for the file to store
					string strFilename = Path.GetFileName(this.scan.PostedFile.FileName);
					WriteToDB(strFilename, ref myData);
				}
			}
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.close();</script>");
		}
	}
}
