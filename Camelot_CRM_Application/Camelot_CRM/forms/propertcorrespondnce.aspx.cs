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
	/// Summary description for propertcorrespondnce.
	/// </summary>
	public class propertcorrespondnce : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblTarget;
		protected System.Web.UI.WebControls.DropDownList cmbTarget;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList cmbDoc;
		protected System.Web.UI.WebControls.Button btnGen;
		protected System.Web.UI.WebControls.Label lblCount;
		protected System.Web.UI.WebControls.Button btnCheck;
		protected System.Web.UI.WebControls.Button btnUncheck;
		protected System.Web.UI.WebControls.DataGrid dgRecipients;
		protected System.Web.UI.WebControls.DropDownList cmbCtype;
		protected System.Web.UI.WebControls.DataGrid dgGuardians;
		protected System.Web.UI.WebControls.Button btnClose;
		private cc.cUser pUser;
		string prop = "";

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
					prop = Request.QueryString["prop"];
					Session["mergeprop"] = prop;
					pop_lists();
					get_recipients();
					setchecks(true);
				}
				prop = Session["mergeprop"].ToString();
				
			}
		}
		
		private void pop_lists()
		{
			popcorr();
			poprecip();
			popdocs();
		}

		private void setvisible(bool vis)
		{
			this.btnGen.Visible=vis;
			this.cmbDoc.Visible=vis;
			this.dgGuardians.Visible=vis;
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
			switch(this.cmbTarget.SelectedValue)
			{
				case "2" :
					foreach(DataGridItem dgi in this.dgRecipients.Items)
					{
						CheckBox chkBox = (CheckBox)dgi.FindControl("chk");
						chkBox.Checked = check;
					}
					break;
				case "1" :
					foreach(DataGridItem dgi in this.dgGuardians.Items)
					{
						CheckBox chkBox = (CheckBox)dgi.FindControl("gchk");
						chkBox.Checked = check;
					}
					break;
			}

		}

		private void poprecip()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.Utils us = new Camelot.classes.Utils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "cget_recipient_types";

			rdr = cmd.ExecuteReader();
			
		
			this.cmbTarget.Items.Clear();
			this.cmbTarget.DataSource = rdr;
			this.cmbTarget.DataTextField = "description";
			this.cmbTarget.DataValueField = "type_id";
			this.cmbTarget.DataBind();

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
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
			this.cmbTarget.SelectedIndexChanged += new System.EventHandler(this.cmbTarget_SelectedIndexChanged);
			this.cmbCtype.SelectedIndexChanged += new System.EventHandler(this.cmbCtype_SelectedIndexChanged);
			this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
			this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
			this.btnUncheck.Click += new System.EventHandler(this.btnUncheck_Click);
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

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

			recip_type = this.cmbTarget.SelectedValue;
			corr_type = this.cmbCtype.SelectedValue;
			doc_id = this.cmbDoc.SelectedValue;

			if(recip_type=="1")
			{
				foreach(DataGridItem dgi in this.dgGuardians.Items)
				{
					CheckBox chkBox = (CheckBox)dgi.FindControl("gchk");
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
					Response.Write("<script>window.showModalDialog('emailInd.aspx?corr_type=" + corr_type + "&doc_id=" + doc_id + "&recip_type=" + recip_type + "&prop=" + prop + "','corresp','dialogHeight: 700px; dialogWidth: 900px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
				}
				else if(this.cmbCtype.SelectedValue == "3")
				{
					Response.Write("<script>window.showModalDialog('emailmerge.aspx?doc_id=" + doc_id + "&recip_type=" + recip_type + "&prop=" + prop + "','emailmerge','dialogHeight: 850px; dialogWidth: 800px; dialogTop: 0px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
				}
				else if(this.cmbCtype.SelectedValue == "2")
				{
					Response.Write("<script>window.showModalDialog('mailmerge.aspx?doc_id=" + doc_id + "&recip_type=" + recip_type + "&prop=" + prop + "','mailmerge','dialogHeight: 400px; dialogWidth: 700px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
				}
			}
			else
			{
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

				if(this.cmbCtype.SelectedValue == "0" || this.cmbCtype.SelectedValue == "1")
				{
					Response.Write("<script>window.showModalDialog('emailInd.aspx?corr_type=" + corr_type + "&doc_id=" + doc_id + "&recip_type=" + recip_type + "&prop=" + prop + "','corresp','dialogHeight: 700px; dialogWidth: 900px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
				}
				else if(this.cmbCtype.SelectedValue == "3")
				{
					Response.Write("<script>window.showModalDialog('emailmerge.aspx?doc_id=" + doc_id + "&recip_type=" + recip_type + "&prop=" + prop + "' ,'emailmerge','dialogHeight: 850px; dialogWidth: 800px; dialogTop: 0px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
				}
				else if(this.cmbCtype.SelectedValue == "2")
				{
					Response.Write("<script>window.showModalDialog('mailmerge.aspx?doc_id=" + doc_id + "&recip_type=" + recip_type + "&prop=" + prop + "','mailmerge','dialogHeight: 400px; dialogWidth: 700px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
				}
			}
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.close();</script>");
		}

		private void cmbTarget_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			get_recipients();
			setchecks(true);
		}

		private void get_recipients()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_prop_corr_recipients";

			cmd.Parameters.Add(
				new SqlParameter("@target", this.cmbTarget.SelectedValue));
			cmd.Parameters.Add(
				new SqlParameter("@PROP_id", prop));
			cmd.Parameters.Add(
				new SqlParameter("@GCORR", this.cmbCtype.SelectedValue));
			
			switch(this.cmbTarget.SelectedValue)
			{
				case "2":
					this.dgGuardians.DataSource=null;
					this.dgGuardians.Visible=false;
					this.dgRecipients.DataSource = null;
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
					break;
				case "1":
					this.dgRecipients.Visible=false;
					this.dgRecipients.DataSource=null;
					this.dgGuardians.DataSource = null;
					this.dgGuardians.DataSource = cmd.ExecuteReader();
					this.dgGuardians.DataBind();
					this.dgGuardians.Visible = true;
					this.lblCount.Text = "Number of Recipients found : " + this.dgGuardians.Items.Count;
					if(this.dgGuardians.Items.Count > 0)
					{
						this.btnGen.Visible = true;
					}
					else
					{
						this.btnGen.Visible=false;
					}
					break;
			}
			this.lblCount.Visible=true;
			this.btnCheck.Visible=true;
			this.btnUncheck.Visible=true;

			
		}
	}
}

