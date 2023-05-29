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
	public class propertycontacthistory : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList cmbFind;
		protected System.Web.UI.WebControls.TextBox txtFind;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.DataGrid dgProps;
		protected System.Web.UI.WebControls.Label LblProp;
		Camelot.classes.cProperty lprop;
		Camelot.classes.cCompany lcomp = new cCompany();
		Camelot.classes.cCorr lcorr = new Camelot.classes.cCorr();
		protected System.Web.UI.HtmlControls.HtmlInputButton btnCorr;
		protected System.Web.UI.WebControls.DataGrid dgCorrs;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnRec;
		Camelot.classes.cUser pUser;
		
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			bool oktogo;
			Camelot.classes.Utils pUtil = new Camelot.classes.Utils();
			pUser = (Camelot.classes.cUser)Session["curUser"];
			oktogo = pUtil.valid_user(pUser);
			lprop = (Camelot.classes.cProperty)Session["curProperty"];
			Session["insp_files"] = null;

			if (!Page.IsClientScriptBlockRegistered("send"))
			{		
				string title="Property Correspondence";
				string height="700";
				string width="800";	
				string prop = lprop.Property_ID;
			 
				// use next line for direct with <base target="_self"> between <Head> and </HEAD> 
				string scrp="<script>var rc = new Array(0,0);function doSIt(){rc= window.showModalDialog('propertcorrespondnce.aspx?Title="+title + "&prop=" + prop + "','','dialogHeight:"+height+" px;dialogWidth:"+width+" px;');"+"\n";
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
				string scrp="<script>var rc = new Array(0,0);function doRIt(){rc= window.showModalDialog('propcorrreceived.aspx?Title="+title + "&comp=" + comp + "','','dialogHeight:"+height+" px;dialogWidth:"+width+" px;');"+"\n";
				scrp+="__doPostBack('','');}</script>";

				Page.RegisterStartupScript("receive",scrp);			
				this.btnRec.Attributes.Add("onClick","doRIt();");
			}

			if(!oktogo)
			{
				Response.Redirect("../logon.aspx");
			}
			else
			{
				lcorr.Corr_ID = "";
				Session["curCorr"] = lcorr;
				lprop= (Camelot.classes.cProperty)Session["curProperty"];
				bool vis = false;
				if(lprop.Property_ID==null)
				{
					vis = false;
				}
				else
				{
					vis = true;
					getCorrs(Convert.ToInt32(lprop.Property_ID));
				}
				setvisible(vis);
				LblProp.Text = lprop.Property_Name;
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
			this.btnCorr.ServerClick += new System.EventHandler(this.btnCorr_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			lprop= (Camelot.classes.cProperty)Session["curProperty"];
			lprop.Property_ID = null;
			Session["curProperty"] = lprop;

			bool vis = false;
			setvisible(vis);
			dgProps.Visible=vis;
			LblProp.Visible=false;
			
			if(txtFind.Text!="")
			{
				getProperties();		
			}
		}

		private void getCorrs(int prop_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_property_corr";

			cmd.Parameters.Add(
				new SqlParameter("@prop_id", prop_id));
			
			dgCorrs.DataSource = cmd.ExecuteReader();
			dgCorrs.DataBind();
			dgCorrs.Visible= true;
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		public void set_prop(Object sender, DataGridCommandEventArgs e)
		{
			lprop= (Camelot.classes.cProperty)Session["curProperty"];
			lprop.Property_ID = e.Item.Cells[2].Text;
			lprop.Property_Name = e.Item.Cells[1].Text;
			lcomp=(Camelot.classes.cCompany)Session["curCompany"];
			lcomp.Company_ID = e.Item.Cells[3].Text;
			lcomp.Company_Name = e.Item.Cells[5].Text;
			Session["curCompany"] = lcomp;
			Session["curProperty"] = lprop;
			Response.Redirect("propertycontacthistory.aspx");
		}

		private void getProperties()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			string txt=this.txtFind.Text.Replace("'","''");

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;

			cmd.CommandText = "get_properties";

			cmd.Parameters.Add(
				new SqlParameter("@search", cmbFind.SelectedItem.Value));
			cmd.Parameters.Add(
				new SqlParameter("@crit", txt));

			rdr = cmd.ExecuteReader();
			dgProps.DataSource = rdr;
			dgProps.DataBind();
			dgProps.Visible= true;
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}


		private void setvisible(bool vis)
		{
			dgProps.Visible=!vis;
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
					fButton.Attributes.Add("onclick", "javascript:window.showModalDialog('corrdetail.aspx?corr=" + DataBinder.Eval(e.Item.DataItem, "corr_id") + "','contdets','dialogHeight: 500px; dialogWidth: 800px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');");
				}
			}
		}

		private void btnCorr_ServerClick(object sender, System.EventArgs e)
		{
		
		}
	}
}
