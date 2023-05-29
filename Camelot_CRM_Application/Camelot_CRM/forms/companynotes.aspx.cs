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
using Camelot.classes;

namespace Camelot
{
	/// <summary>
	/// Summary description for property_metilities.
	/// </summary>
	public class companynotes : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList cmbFind;
		protected System.Web.UI.WebControls.TextBox txtFind;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.ListBox lstProps;
		protected System.Web.UI.WebControls.Button BtnGo;
		Camelot.classes.cCompany lcomp = new cCompany();
		protected System.Web.UI.HtmlControls.HtmlInputButton Button1;
		protected System.Web.UI.WebControls.DataGrid dgFacs;
		protected System.Web.UI.WebControls.DataGrid dgMets;
		Camelot.classes.cNote lnote = new cNote();
		protected System.Web.UI.WebControls.Label lblComp;
		protected System.Web.UI.WebControls.DataGrid dgComps;
		protected System.Web.UI.WebControls.DataGrid dgNotes;
		Camelot.classes.cUser pUser;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			bool oktogo;
			Camelot.classes.Utils pUtil = new Camelot.classes.Utils();
			pUser = (Camelot.classes.cUser)Session["curUser"];
			oktogo = pUtil.valid_user(pUser);
			Session["insp_files"] = null;

			if(!oktogo)
			{
				Response.Redirect("../logon.aspx");
			}
			else
			{
				lnote.Note_ID = "";
				Session["curNote"] = lnote;
				lcomp= (Camelot.classes.cCompany)Session["curCompany"];
				bool vis = false;
				if(lcomp.Company_ID==null)
				{
					vis = false;
				}
				else
				{
					vis = true;
					getnotes(Convert.ToInt32(lcomp.Company_ID));
				}
				setvisible(vis);
				lblComp.Text = lcomp.Company_Name;
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
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.dgComps.SelectedIndexChanged += new System.EventHandler(this.dgComps_SelectedIndexChanged);
			this.dgNotes.SelectedIndexChanged += new System.EventHandler(this.dgNotes_SelectedIndexChanged);
			this.Button1.ServerClick += new System.EventHandler(this.Button1_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			lcomp= (Camelot.classes.cCompany)Session["curCompany"];
			lcomp.Company_ID = null;
			Session["curCompany"] = lcomp;

			bool vis = false;
			setvisible(vis);
			lblComp.Visible=false;
			
			if(txtFind.Text!="")
			{
				getCompanies();		
			}
		}




		private void setvisible(bool vis)
		{
			dgComps.Visible=!vis;
			dgNotes.Visible = vis;
			if(pUser.Permission=="1")
			{
				Button1.Visible = vis;
			}
			else
			{
				Button1.Visible=false;
			}
		}

			
		public void set_comp(Object sender, DataGridCommandEventArgs e)
		{
			lcomp=(Camelot.classes.cCompany)Session["curCompany"];
			lcomp.Company_ID = e.Item.Cells[1].Text;
			lcomp.Company_Name = e.Item.Cells[0].Text;
			Session["curCompany"] = lcomp;
			Response.Redirect("companynotes.aspx");
		}

		
		public void dgNotes_ItemDataBound(Object sender, DataGridItemEventArgs e)
		{
			if(e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
			{
				LinkButton fButton = (LinkButton)e.Item.Cells[0].Controls[0];
				fButton.Attributes.Add("onclick", "javascript:window.showModalDialog('notedetails.aspx?note=" + DataBinder.Eval(e.Item.DataItem, "note_id") + "','metdets','dialogHeight: 485px; dialogWidth: 800px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');");
			}
		}

		private void Button1_ServerClick(object sender, System.EventArgs e)
		{
			Session["note_edit"] = true;
			Session["note_save"] = false;
			Session["note_new"] = true;
			Response.Write("<script>window.showModalDialog('notedetails.aspx?note=','note','dialogHeight: 485px; dialogWidth: 800px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
			Response.Write("<script>self.document.location.href = 'companynotes.aspx';</script>");
		}


		private void getCompanies()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			string txt=this.txtFind.Text.Replace("'","''");
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_companies";

			cmd.Parameters.Add(
				new SqlParameter("@search", cmbFind.SelectedItem.Value));
			cmd.Parameters.Add(
				new SqlParameter("@crit", txt));

			dgComps.DataSource = cmd.ExecuteReader();
			dgComps.DataBind();
			dgComps.Visible= true;
			dgNotes.Visible=false;
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		private void getnotes(int comp_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_company_notes";

			cmd.Parameters.Add(
				new SqlParameter("@comp_id", comp_id));
			
			dgNotes.DataSource = cmd.ExecuteReader();
			dgNotes.DataBind();
			dgNotes.Visible= true;
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		private void dgComps_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void dgNotes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}		
	}


}
