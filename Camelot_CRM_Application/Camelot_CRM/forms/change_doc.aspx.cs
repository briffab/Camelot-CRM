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
	/// Summary description for change_doc.
	/// </summary>
	public class change_doc : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnClose;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnUpload;
		protected System.Web.UI.HtmlControls.HtmlInputFile doc;
	
		private string doc_id = "";
		private cc.cUser pUser;

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
				if(!Page.IsPostBack)
				{
					doc_id = Request.QueryString["doc"];
					Session["doc"] = doc_id;
				}
			}
			doc_id = Session["doc_id"].ToString();
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
			this.btnUpload.ServerClick += new System.EventHandler(this.btnUpload_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.close();</script>");
		}

		private void btnUpload_ServerClick(object sender, System.EventArgs e)
		{
			
			int nFileLen = this.doc.PostedFile.ContentLength; 
			if( nFileLen > 0 )
			{
				// Allocate a buffer for reading of the file
				byte[] myData = new byte[nFileLen];

				// Read uploaded file from the Stream
				this.doc.PostedFile.InputStream.Read(myData, 0, nFileLen);

				// Create a name for the file to store
				string strFilename = Path.GetFileName(this.doc.PostedFile.FileName);
				WriteToDB(strFilename, ref myData);
			}
		}

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
				cmd.CommandText = "update_merge_doc_doc";

				cmd.Parameters.Add(
					new SqlParameter("@FILENAME", strPath));
				cmd.Parameters.Add(
					new SqlParameter("@doc_id", doc_id));
				cmd.Parameters.Add(
					new SqlParameter("@doc", full));
				cmd.Parameters.Add(
					new SqlParameter("@SIZE", full.Length));
				cmd.Parameters.Add(
					new SqlParameter("@record_modifier", pUser.ID));
				rdr = cmd.ExecuteReader();

				Response.Write("<script>window.close();</script>");

			}
			catch(Exception e)
			{
				Response.Write(e.Message);
			}
		}
	}
}
