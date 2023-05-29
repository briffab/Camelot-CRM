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

namespace Camelot.forms
{
	/// <summary>
	/// Summary description for guardiancorrespondence.
	/// </summary>
	public class guardiancorrespondence : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DataGrid dgCorrs;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnCorr;
	
		private Camelot.classes.cUser pUser;
		protected System.Web.UI.WebControls.Label lblGuard;
		private Camelot.classes.cGuardian pGuard;
		protected System.Web.UI.WebControls.Button btnClose;
		private Camelot.classes.cCorr lcorr = new cCorr();

		private void Page_Load(object sender, System.EventArgs e)
		{
			bool oktogo;
			Camelot.classes.Utils pUtil = new Camelot.classes.Utils();
			pUser = (Camelot.classes.cUser)Session["curUser"];
			oktogo = pUtil.valid_user(pUser);
			pGuard = (Camelot.classes.cGuardian)Session["curGuardian"];

			if (!Page.IsClientScriptBlockRegistered("send"))
			{		
				string title="Guardian Correspondence";
				string height="700";
				string width="800";	
				string guard = pGuard.Guardian_ID;
			 
				// use next line for direct with <base target="_self"> between <Head> and </HEAD> 
				string scrp="<script>var rc = new Array(0,0);function doRIt(){rc= window.showModalDialog('guardcorr.aspx?Title="+title + "&guard=" + guard + "','','dialogHeight:"+height+" px;dialogWidth:"+width+" px;');"+"\n";
				scrp+="__doPostBack('','');}</script>";

				Page.RegisterStartupScript("send",scrp);			
				this.btnCorr.Attributes.Add("onClick","doRIt();");
			}

			if(!oktogo)
			{
				Response.Redirect("../logon.aspx");
			}
			else
			{
				lcorr.Corr_ID = "";
				Session["curCorr"] = lcorr;
				getCorrs();
				this.lblGuard.Text = pGuard.Guardian_Name;
			}
		}

		private void getCorrs()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_guardian_corr";

			cmd.Parameters.Add(
				new SqlParameter("@guard_id", pGuard.Guardian_ID));
			
			dgCorrs.DataSource = cmd.ExecuteReader();
			dgCorrs.DataBind();
			dgCorrs.Visible= true;
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
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
					fButton.Attributes.Add("onclick", "javascript:window.showModalDialog('corrdetail.aspx?corr=" + DataBinder.Eval(e.Item.DataItem, "corr_id") + "','contdets','dialogHeight: 485px; dialogWidth: 800px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');");
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
			this.btnCorr.ServerClick += new System.EventHandler(this.btnCorr_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.close();</script>");
		}

		private void btnCorr_ServerClick(object sender, System.EventArgs e)
		{
		
		}
	}
}
