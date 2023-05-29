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
	/// Summary description for property_facilities.
	/// </summary>
	public class inspections : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList cmbFind;
		protected System.Web.UI.WebControls.TextBox txtFind;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.Button BtnGo;
		protected System.Web.UI.WebControls.DataGrid dgPfac;
		protected System.Web.UI.WebControls.DataGrid dgProps;
		Camelot.classes.cProperty lprop;
		Camelot.classes.cCompany lcomp = new cCompany();
		protected System.Web.UI.HtmlControls.HtmlInputButton Button1;
		Camelot.classes.cFacility lfac = new cFacility();
		protected System.Web.UI.WebControls.Label LblProp;
		protected System.Web.UI.WebControls.DataGrid dgInps;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnPrint;
		Camelot.classes.cUser pUser;
	
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
				lfac.Facility_ID = "";
				Session["curfac"] = lfac;
				lprop= (Camelot.classes.cProperty)Session["curProperty"];
				bool vis = false;
				if(lprop.Property_ID==null)
				{
					vis = false;
				}
				else
				{
					vis = true;
				}
				setvisible(vis);
				getInspections(Convert.ToInt32(lprop.Property_ID));
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
			this.btnPrint.ServerClick += new System.EventHandler(this.btnPrint_ServerClick);
			this.Button1.ServerClick += new System.EventHandler(this.Button1_ServerClick);
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

		private void getInspections(int propid)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_Inspections";

			cmd.Parameters.Add(
				new SqlParameter("@propid", propid));
			
			dgInps.DataSource = cmd.ExecuteReader();
			dgInps.DataBind();
			dgInps.Visible= true;
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		private void getProperties()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
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

			dgProps.DataSource = cmd.ExecuteReader();
			dgProps.DataBind();
			dgProps.Visible= true;
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}


		private void setvisible(bool vis)
		{
			dgProps.Visible=!vis;
			dgInps.Visible = vis;
			if(pUser.Permission=="1")
			{
				Button1.Visible = vis;
				this.btnPrint.Visible = vis;
			}
			else
			{
				Button1.Visible=false;
			}
		}

		
        public void set_prop(Object sender, DataGridCommandEventArgs e)
		{
			lprop= (Camelot.classes.cProperty)Session["curProperty"];
			lprop.Property_ID = e.Item.Cells[2].Text;
			lprop.Property_Name = e.Item.Cells[1].Text;
			lcomp=(Camelot.classes.cCompany)Session["curCompany"];
			lcomp.Company_ID = e.Item.Cells[3].Text;
			Session["curCompany"] = lcomp;
			Session["curProperty"] = lprop;
			Response.Redirect("inspections.aspx");
		}

		
		public void dgInps_ItemDataBound(Object sender, DataGridItemEventArgs e)
		{
			if(e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
			{
				LinkButton fButton = (LinkButton)e.Item.Cells[0].Controls[0];
				fButton.Attributes.Add("onclick", "javascript:window.showModalDialog('inspection.aspx?insp=" + DataBinder.Eval(e.Item.DataItem, "object_check_id") + "','inspdets','dialogHeight: 700px; dialogWidth: 950px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');self.document.location.href = 'property_facilities.aspx';");
			}
		}

		private void Button1_ServerClick(object sender, System.EventArgs e)
		{
			Session["insp_edit"] = true;
			Session["insp_save"] = false;
			Response.Write("<script>window.showModalDialog('newinspection.aspx','inspdets','dialogHeight: 700px; dialogWidth: 1000px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
		}

		private void btnPrint_ServerClick(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.open('blankinspection.aspx','inspdets','dialogHeight: 700px; dialogWidth: 800x; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
			Response.Write("<script>self.document.location.href = 'inspections.aspx';</script>");
		}
	}


}
