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

namespace Camelot.forms
{
	/// <summary>
	/// Summary description for companycorrespondence.
	/// </summary>
	public class companycorrespondence : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblTarget;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList cmbDoc;
		protected System.Web.UI.WebControls.Button btnGen;
		protected System.Web.UI.WebControls.Label lblCount;
		protected System.Web.UI.WebControls.Button btnCheck;
		protected System.Web.UI.WebControls.Button btnUncheck;
		protected System.Web.UI.WebControls.DataGrid dgRecipients;
		protected System.Web.UI.WebControls.DropDownList cmbCtype;
		protected System.Web.UI.WebControls.Button btnClose;
		private cc.cUser pUser;
		string comp = "";

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
					setvisible(false);
					comp = Request.QueryString["comp"];
					Session["mergecomp"] = comp;
					pop_lists();
					get_recipients();
					setchecks(true);
				}
				comp = Session["mergecomp"].ToString();
				
			}
		}
		
		private void pop_lists()
		{
			popcorr();
			popdocs();
		}

		private void setvisible(bool vis)
		{
			this.btnGen.Visible=vis;
			this.cmbDoc.Visible=vis;
			this.dgRecipients.Visible = vis;
			this.btnUncheck.Visible=vis;
			this.btnCheck.Visible=vis;
		}

		private void popdocs()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.Utils us = new Camelot.classes.Utils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_documents";

			rdr = cmd.ExecuteReader();
			
		
			this.cmbDoc.Items.Clear();
			this.cmbDoc.DataSource = rdr;
			this.cmbDoc.DataTextField = "doc_list_name";
			this.cmbDoc.DataValueField = "doc_id";
			this.cmbDoc.DataBind();

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		private void setchecks(bool check)
		{
			foreach(DataGridItem dgi in this.dgRecipients.Items)
			{
				CheckBox chkBox = (CheckBox)dgi.FindControl("chk");
				chkBox.Checked = check;
			}
			
		}

		private void popcorr()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.Utils us = new Camelot.classes.Utils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "cget_correspondence_types";

			rdr = cmd.ExecuteReader();
			
		
			this.cmbCtype.Items.Clear();
			this.cmbCtype.DataSource = rdr;
			this.cmbCtype.DataTextField = "description";
			this.cmbCtype.DataValueField = "type_id";
			this.cmbCtype.DataBind();

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		private void btnCheck_Click(object sender, System.EventArgs e)
		{
			setchecks(false);
		}

		private void btnUncheck_Click(object sender, System.EventArgs e)
		{
			setchecks(true);
		}

		private void cmbCtype_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			switch(this.cmbCtype.SelectedValue)
			{	
				case "1":
					this.cmbDoc.Visible = false;
					break;
				case "2":
					this.cmbDoc.Visible = true;
					break;
				case "3":
					this.cmbDoc.Visible = true;
					break;
			}
			get_recipients();
			setchecks(true);
		}

		private void btnGen_Click(object sender, System.EventArgs e)
		{
			string recip_type = "";
			string corr_type = "";
			string doc_id = "";

			ArrayList recip_email = new ArrayList();
			ArrayList recip = new ArrayList();

			recip_type = "2";
			corr_type = this.cmbCtype.SelectedValue;
			doc_id = this.cmbDoc.SelectedValue;

			
			foreach(DataGridItem dgi in this.dgRecipients.Items)
			{
				CheckBox chkBox = (CheckBox)dgi.FindControl("chk");
				if(chkBox.Checked)
				{
					recip.Add(dgi.Cells[0].Text);
					recip_email.Add(dgi.Cells[1].Text);
					Session["cRecip"] = recip;
					Session["cEmail"] = recip_email;
				}
			}

			if(this.cmbCtype.SelectedValue == "1")
			{
				Response.Write("<script>window.showModalDialog('emailInd.aspx?corr_type=" + corr_type + "&doc_id=" + doc_id + "&recip_type=" + recip_type + "&prop=0','corresp','dialogHeight: 700px; dialogWidth: 900px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
			}
			else if(this.cmbCtype.SelectedValue == "3")
			{
				Response.Write("<script>window.showModalDialog('emailmerge.aspx?doc_id=" + doc_id + "&recip_type=" + recip_type + "&prop=0','emailmerge','dialogHeight: 850px; dialogWidth: 800px; dialogTop: 0px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
			}
			else if(this.cmbCtype.SelectedValue == "2")
			{
				Response.Write("<script>window.showModalDialog('mailmerge.aspx?doc_id=" + doc_id + "&recip_type=" + recip_type + "&prop=0','mailmerge','dialogHeight: 400px; dialogWidth: 700px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
			}
		
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.close();</script>");
		}


		private void get_recipients()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_comp_corr_recipients";

			cmd.Parameters.Add(
				new SqlParameter("@comp_id", comp));
			cmd.Parameters.Add(
				new SqlParameter("@GCORR", this.cmbCtype.SelectedValue));
			
			this.dgRecipients.DataSource = cmd.ExecuteReader();
			this.dgRecipients.DataBind();
			this.dgRecipients.Visible = true;
			this.lblCount.Text = "Number of Recipients found : " + this.dgRecipients.Items.Count;
			if(this.dgRecipients.Items.Count > 0)
			{
				this.btnGen.Visible = true;
			}
			else
			{
				this.btnGen.Visible=false;
			} 
					
			this.lblCount.Visible=true;
			this.btnCheck.Visible=true;
			this.btnUncheck.Visible=true;
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
			this.cmbCtype.SelectedIndexChanged += new System.EventHandler(this.cmbCtype_SelectedIndexChanged);
			this.cmbDoc.SelectedIndexChanged += new System.EventHandler(this.cmbDoc_SelectedIndexChanged);
			this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
			this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
			this.btnUncheck.Click += new System.EventHandler(this.btnUncheck_Click);
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmbDoc_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
