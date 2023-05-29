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
	/// Summary description for propertycontacthistory.
	/// </summary>
	public class companycontacthistory : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList cmbFind;
		protected System.Web.UI.WebControls.TextBox txtFind;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.DataGrid dgProps;
		protected System.Web.UI.WebControls.Label LblProp;
		Camelot.classes.cCompany lcomp = new cCompany();
		Camelot.classes.cCorr lcorr = new Camelot.classes.cCorr();
		protected System.Web.UI.HtmlControls.HtmlInputButton btnCorr;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnEmail;
		protected System.Web.UI.WebControls.DataGrid dgCorrs;
		protected System.Web.UI.WebControls.DataGrid dgComps;
		protected System.Web.UI.WebControls.Label lblComp;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnRec;
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
				lcorr.Corr_ID = "";
				Session["curCorr"] = lcorr;
				lcomp= (Camelot.classes.cCompany)Session["curCompany"];
				bool vis = false;
				if(lcomp.Company_ID==null)
				{
					vis = false;
				}
				else
				{
					vis = true;
					getCorrs(Convert.ToInt32(lcomp.Company_ID));
				}
				setvisible(vis);
				lblComp.Text = lcomp.Company_Name;
			}
			if (!Page.IsClientScriptBlockRegistered("send"))
			{		
				string title="Property Correspondence";
				string height="700";
				string width="800";	
				string comp = lcomp.Company_ID;
			 
				// use next line for direct with <base target="_self"> between <Head> and </HEAD> 
				string scrp="<script>var rc = new Array(0,0);function doSIt(){rc= window.showModalDialog('companycorrespondence.aspx?Title="+title + "&comp=" + comp + "','','dialogHeight:"+height+" px;dialogWidth:"+width+" px;');"+"\n";
				scrp+="__doPostBack('','');}</script>";

				Page.RegisterStartupScript("send",scrp);			
				this.btnCorr.Attributes.Add("onClick","doSIt();");
			}

			if (!Page.IsClientScriptBlockRegistered("receive"))
			{		
				string title="Received Correspondence";
				string height="400";
				string width="800";	
				string comp = lcomp.Company_ID;
			 
				// use next line for direct with <base target="_self"> between <Head> and </HEAD> 
				string scrp="<script>var rc = new Array(0,0);function doRIt(){rc= window.showModalDialog('compcorrreceived.aspx?Title="+title + "&comp=" + comp + "','','dialogHeight:"+height+" px;dialogWidth:"+width+" px;');"+"\n";
				scrp+="__doPostBack('','');}</script>";

				Page.RegisterStartupScript("receive",scrp);			
				this.btnRec.Attributes.Add("onClick","doRIt();");
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
			this.btnCorr.ServerClick += new System.EventHandler(this.btnCorr_ServerClick);
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

		private void getCompanies()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			string txt = this.txtFind.Text.Replace("'","''");

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
			dgCorrs.Visible=false;
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		private void getCorrs(int compid)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_company_corr";

			cmd.Parameters.Add(
				new SqlParameter("@comp_id", compid));
			
			dgCorrs.DataSource = cmd.ExecuteReader();
			dgCorrs.DataBind();
			dgCorrs.Visible= true;
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		

		private void setvisible(bool vis)
		{
			dgComps.Visible=!vis;
			dgCorrs.Visible = vis;
			if(pUser.Permission=="1")
			{
				btnCorr.Visible = vis;
				this.btnRec.Visible = vis;
			}
			else
			{
				btnCorr.Visible = false;
				this.btnRec.Visible = false;
			}
		}

		public void dgCorrs_ItemDataBound(Object sender, DataGridItemEventArgs e)
		{
			if(e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
			{
				LinkButton fButton = (LinkButton)e.Item.Cells[1].Controls[0];
				string type = (string)DataBinder.Eval(e.Item.DataItem, "type");
				if(type == "Email" || type == "Email Merged Document")
				{
					fButton.Attributes.Add("onclick", "javascript:window.showModalDialog('ecorrdetail.aspx?corr=" + DataBinder.Eval(e.Item.DataItem, "corr_id") + "','contdets','dialogHeight: 850px; dialogWidth: 800px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');");
				}
				else
				{
					fButton.Attributes.Add("onclick", "javascript:window.showModalDialog('corrdetail.aspx?corr=" + DataBinder.Eval(e.Item.DataItem, "corr_id") + "','contdets','dialogHeight: 515px; dialogWidth: 800px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');");
				}
			}
		}

		public void set_comp(Object sender, DataGridCommandEventArgs e)
		{
			lcomp=(Camelot.classes.cCompany)Session["curCompany"];
			lcomp.Company_ID = e.Item.Cells[1].Text;
			lcomp.Company_Name = e.Item.Cells[0].Text;
			Session["curCompany"] = lcomp;
			Response.Redirect("companycontacthistory.aspx");
		}

		private void btnCorr_ServerClick(object sender, System.EventArgs e)
		{
		
		}
	}
}
