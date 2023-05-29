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
	/// Summary description for add_doc.
	/// </summary>
	public class add_doc : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblfacdesc;
		protected System.Web.UI.WebControls.TextBox txtDocName;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.DropDownList cmbType;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtnotes;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.HtmlControls.HtmlInputFile doc;
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
					hiderr();
					poptypes();
				}
			}
		}

		private void poptypes()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.Utils us = new Camelot.classes.Utils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_document_types";

			rdr = cmd.ExecuteReader();
			
		
			this.cmbType.Items.Clear();
			this.cmbType.DataSource = rdr;
			this.cmbType.DataTextField = "description";
			this.cmbType.DataValueField = "document_type";
			this.cmbType.DataBind();
				
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

		}

		private void hiderr()
		{
			this.lblMessage.Visible=false;
			this.Label11.Visible=false;
			this.Label16.Visible=false;
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
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.close();</script>");
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			if(this.txtDocName.Text == "")
			{
				this.lblMessage.Text = "Please give List Name";
				this.lblMessage.Visible = true;
				this.Label11.Visible = true;
			}
			else
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
				cmd.CommandText = "add_doc";

				cmd.Parameters.Add(
					new SqlParameter("@FILENAME", strPath));
				cmd.Parameters.Add(
					new SqlParameter("@LIST_NAME", this.txtDocName.Text));
				cmd.Parameters.Add(
					new SqlParameter("@TYPE", this.cmbType.SelectedValue));
				cmd.Parameters.Add(
					new SqlParameter("@DESCRIPTION", this.txtnotes.Text));
				cmd.Parameters.Add(
					new SqlParameter("@DOC", full));
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
