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
	public class reolvedincidents : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList cmbFind;
		protected System.Web.UI.WebControls.TextBox txtFind;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.Button BtnGo;
		protected System.Web.UI.WebControls.DataGrid dgPfac;
		protected System.Web.UI.WebControls.DataGrid dgProps;
		protected System.Web.UI.WebControls.DataGrid dgIncs;
		protected System.Web.UI.HtmlControls.HtmlInputButton Button1;
		Camelot.classes.cIncident linc = new cIncident();
		protected System.Web.UI.WebControls.Label LblProp;
		Camelot.classes.cUser pUser;
		private int sort = 0;
	
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
					linc.Incident_ID = "";
					Session["curIncident"] = linc;
					getIncidents();	
					Session["sort"] = sort;
				}
				sort = Convert.ToInt32(Session["sort"]);
			}
			
		}

		public void SortIncs(Object sender, DataGridSortCommandEventArgs e)
		{
			switch(e.SortExpression)
			{
				case "rep_date" :
					sort = 0;
					break;
				case "inc" :
					sort =1;
					break;
				case "urg" :
					sort = 2;
					break;
				case "status" :
					sort = 3;
					break;
				case "last_action" :
					sort = 4;
					break;
				case "act_date" :
					sort = 5;
					break;
				case "inc_type" :
					sort = 6;
					break;
				case "res_date" :
					sort = 7;
					break;
			}

			Session["sort"] = sort;

			getIncidents();


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
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

		private void getIncidents()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_all_resolved_Incidents";
			
			cmd.Parameters.Add(
				new SqlParameter("@SORT", sort));

			dgIncs.DataSource = cmd.ExecuteReader();
			dgIncs.DataBind();
			dgIncs.Visible= true;
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		public void dgIncs_ItemDataBound(Object sender, DataGridItemEventArgs e)
		{
			if(e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
			{
				LinkButton fButton = (LinkButton)e.Item.Cells[0].Controls[0];
				fButton.Attributes.Add("onclick", "javascript:window.showModalDialog('incidentdetails.aspx?inc=" + DataBinder.Eval(e.Item.DataItem, "inc") + "','incdets','dialogHeight: 750px; dialogWidth: 950px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');self.document.location.href = 'property_incidents.aspx';");
			}
		}

		private void set_cells()
		{
			foreach(DataGridItem dgi in dgIncs.Items)
			{
				string dt = dgi.Cells[7].Text;
				if(Convert.ToDateTime(dt) < DateTime.Now)
				{
					dgi.Cells[0].ForeColor=System.Drawing.Color.Red;
				}
			}

		}
	}
}
