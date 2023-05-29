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
	/// Summary description for doc_admin.
	/// </summary>
	public class doc_admin : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label lblUpBy;
		protected System.Web.UI.WebControls.Label lblUby;
		protected System.Web.UI.WebControls.Label lblUpOn;
		protected System.Web.UI.WebControls.Label lblUDate;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtnotes;
		protected System.Web.UI.WebControls.Button btnClose;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Button btnView;
		protected System.Web.UI.WebControls.TextBox txtDocName;
		protected System.Web.UI.WebControls.DropDownList cmbType;
		protected System.Web.UI.WebControls.Label lblDoc;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Label lblDocName;
		protected System.Web.UI.WebControls.Label lblNameStar;
	
		private cc.cUser pUser;
		protected System.Web.UI.WebControls.Button btnChange;
		protected System.Web.UI.WebControls.Button btnMfields;
		private string doc;

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
					doc = Request.QueryString["doc"];
					Session["doc_id"] = doc;
					hiderr();
					popdoc();
					setenabled(false);
					this.btnCancel.Visible = false;
					this.btnUpdate.Visible=false;
				}
			}
			doc=Session["doc_id"].ToString();
			if(this.btnEdit.Visible)
			{
				popdoc();
			}

			if (!Page.IsClientScriptBlockRegistered("change"))
			{		
				string height="250";
				string width="600";	
			 
				// use next line for direct with <base target="_self"> between <Head> and </HEAD> 
				string scrp="<script>var rc = new Array(0,0);function doRIt(){rc= window.showModalDialog('change_doc.aspx?doc=" + doc + "','','dialogHeight:"+height+" px;dialogWidth:"+width+" px;');"+"\n";
				scrp+="document.forms[0].submit();}</script>";

				Page.RegisterStartupScript("change",scrp);			
				this.btnChange.Attributes.Add("onClick","doRIt();");
			}
		}

		private void setenabled(bool edit)
		{
			this.txtnotes.Enabled=edit;
			this.txtDocName.Enabled=edit;
			this.cmbType.Enabled=edit;
		}

        private void popdoc()
		{	
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.saveUtils us = new Camelot.classes.saveUtils();
			string type = "";

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_merge_document";

			cmd.Parameters.Add(
				new SqlParameter("@doc_id", doc));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				this.txtDocName.Text = rdr["doc_list_name"].ToString();
				this.txtnotes.Text = rdr["description"].ToString();
				this.lblDoc.Text = rdr["doc_name"].ToString();
				type = rdr["doc_type"].ToString();
				lblUby.Text = get_employeename(Convert.ToInt32(rdr["record_manager"]));
				lblUDate.Text = us.getdate(rdr["Date_entered"].ToString());
			}
			rdr.NextResult();

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			poptypes(type);
		}

		public string get_employeename(int emp)
		{
			string name = "";
			cc.Employees lemps = (cc.Employees)Session["Emps"];
			
			foreach(cc.Employee em in lemps)
			{
				if(Convert.ToInt32(em.Emp_ID) == emp)
				{
					name = em.Emp_Name;
					break;
				}
			}
			return name;
		}

		private void poptypes(string type)
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
				
			if(type!="")
			{
				this.cmbType.SelectedValue = type;
			}

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

		}

		private void hiderr()
		{
			this.lblMessage.Visible=false;
			this.lblNameStar.Visible=false;
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
			this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			this.btnView.Click += new System.EventHandler(this.btnView_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.close();</script>");
		}

		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			setenabled(true);
			this.btnUpdate.Visible = true;
			this.btnCancel.Visible = true;
			this.btnEdit.Visible = false;
			this.btnView.Visible = false;
			this.btnChange.Visible=false;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			setenabled(false);
			
			this.btnUpdate.Visible = false;
			this.btnCancel.Visible = false;
			this.btnEdit.Visible = true;
			this.btnView.Visible = true;
			this.btnChange.Visible=true;
		}

		private void btnChange_Click(object sender, System.EventArgs e)
		{
		
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			savedoc();
		}

		private void savedoc()
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
				cmd.CommandText = "update_merge_doc";


				cmd.Parameters.Add(
					new SqlParameter("@doc_id", doc));
				cmd.Parameters.Add(
					new SqlParameter("@doc_list_name", this.txtDocName.Text));
				cmd.Parameters.Add(
					new SqlParameter("@desc", this.txtnotes.Text));
				cmd.Parameters.Add(
					new SqlParameter("@type", this.cmbType.SelectedValue));
				cmd.Parameters.Add(
					new SqlParameter("@record_modifier", pUser.ID));
				rdr = cmd.ExecuteReader();

				setenabled(false);
				this.btnUpdate.Visible = false;
				this.btnCancel.Visible = false;
				this.btnEdit.Visible = true;
				this.btnView.Visible = true;
				this.btnChange.Visible=true;

			}
			catch(Exception e)
			{
				Response.Write(e.Message);
			}
		}

		private void btnView_Click(object sender, System.EventArgs e)
		{
			showdoc();
		}

		private void showdoc()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			string sfile = "";

			try
			{
				conn.ConnectionString = (string)Session["Connection"];
				conn.Open();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "get_merge_doc";


				cmd.Parameters.Add(
					new SqlParameter("@doc_id", doc));

				rdr = cmd.ExecuteReader();

				while(rdr.Read())
				{
					string ex = System.DateTime.Now.Day.ToString() + "_" + System.DateTime.Now.Month.ToString() + "_" + System.DateTime.Now.Year.ToString() + "_" + rdr["doc_name"].ToString();
					byte[] mdoc= new byte[0];
					mdoc =  (byte[])rdr["document"];
					string file = "c:\\inetpub\\wwwroot\\camelot_crm\\\\mergedocs\\\\" + ex;
					sfile = "http://ntsbs01/camelot_crm/mergedocs/" + ex;
					FileStream fs = new FileStream(file, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write, System.IO.FileShare.ReadWrite);
					fs.Write(mdoc,0,(int)rdr["filesize"]);
					fs.Close();
				}
				rdr.Close();
				cmd.Dispose();
				conn.Close();
				conn.Dispose();   

				Response.Write("<script>window.open('" + sfile + "');</script>");

			}
			catch(Exception e)
			{
				Response.Write(e.Message);
			}

		}

		private void btnMfields_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
