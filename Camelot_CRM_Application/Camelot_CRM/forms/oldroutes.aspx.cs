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

namespace Camelot.forms
{
	/// <summary>
	/// Summary description for activeroutes.
	/// </summary>
	public class oldroutes : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgRoutes;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				get_routes();
			}
		}

		private void get_routes()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;

			cmd.CommandText = "get_routes_old";

			this.dgRoutes.DataSource = cmd.ExecuteReader();
			this.dgRoutes.DataBind();
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}


		public void Print(Object sender, DataGridCommandEventArgs e) 
		{
			if(e.CommandName=="Print")
			{
				Response.Write("<script>window.showModalDialog('printroute.aspx?route_id=" + DataBinder.Eval(e.Item.DataItem, "route_id") + "','appdets','dialogHeight: 500px; dialogWidth: 950px; dialogTop: 50px; dialogLeft:150px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
			}
		}


		public void dgRoutes_ItemDataBound(Object sender, DataGridItemEventArgs e)
		{
			if(e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
			{
				LinkButton fButton = (LinkButton)e.Item.Cells[0].Controls[0];
				fButton.Attributes.Add("onclick", "javascript:window.showModalDialog('routedetails.aspx?route_id=" + DataBinder.Eval(e.Item.DataItem, "route_id") + "','appdets','dialogHeight: 750px; dialogWidth: 950px; dialogTop: 50px; dialogLeft:150px; edge: Raised; center: No; help: No; resizable: No; status: No;');self.document.location.href = 'activeroutes.aspx';");
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
