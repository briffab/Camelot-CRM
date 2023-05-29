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
	public class activeroutes : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlInputButton Button1;
		protected System.Web.UI.WebControls.DataGrid dgRoutes;
		private Camelot.classes.cUser pUser;
		private Camelot.classes.cRoute lroute = new Camelot.classes.cRoute();
	
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
				lroute.Route_ID= "";
				Session["curRoute"] = lroute;

				if(!Page.IsPostBack)
				{
					get_routes();
				}
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

			cmd.CommandText = "get_routes_active";

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
				string route = "";
				route = e.Item.Cells[1].Text;

				Response.Write("<script>window.showModalDialog('routedate.aspx?route_id=" + route + "','appdets','dialogHeight: 200px; dialogWidth:600px; dialogTop: 250px; dialogLeft:250px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
			}
		}


		public void dgRoutes_ItemDataBound(Object sender, DataGridItemEventArgs e)
		{
			if(e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
			{
				LinkButton fButton = (LinkButton)e.Item.Cells[0].Controls[0];
				fButton.Attributes.Add("onclick", "javascript:window.showModalDialog('routedetails.aspx?route_id=" + DataBinder.Eval(e.Item.DataItem, "route_id") + "','appdets','dialogHeight: 600px; dialogWidth: 950px; dialogTop: 50px; dialogLeft:150px; edge: Raised; center: No; help: No; resizable: No; status: No;');self.document.location.href = 'activeroutes.aspx';");
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
			this.Button1.ServerClick += new System.EventHandler(this.Button1_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_ServerClick(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.showModalDialog('routedetails.aspx?route_id=0','appdets','dialogHeight: 600px; dialogWidth: 950px; dialogTop: 50px; dialogLeft:150px; edge: Raised; center: No; help: No; resizable: No; status: No;');self.document.location.href = 'activeroutes.aspx';</script>");
		}
	}
}
