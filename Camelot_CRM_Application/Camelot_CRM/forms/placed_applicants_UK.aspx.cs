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
	/// Summary description for applications_NL.
	/// </summary>
	public class placed_applications_UK : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgApplicants;
		private int sort = 0;
		private string app_con = "server=192.168.75.1;integrated security=false;uid=sa;pwd=sa;database=registration_uk;";
		//private string app_con = "server=FUJI;integrated security=false;uid=sa;pwd=fvzappa3;database=registration_uk;";

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				get_applicants();
				Session["sort"] = sort;
			}
			sort = Convert.ToInt32(Session["sort"]);
			Session["app_con"] = app_con;
		}

		private void get_applicants()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();

			conn.ConnectionString = app_con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;

			cmd.CommandText = "get_placed_applicants";

			cmd.Parameters.Add(
				new SqlParameter("@SORTO", sort));

			
			this.dgApplicants.DataSource = cmd.ExecuteReader();
			this.dgApplicants.DataBind();
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			set_cells();
		}

		public void dgApplicants_ItemDataBound(Object sender, DataGridItemEventArgs e)
		{
			if(e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
			{
				LinkButton fButton = (LinkButton)e.Item.Cells[3].Controls[0];
				fButton.Attributes.Add("onclick", "javascript:window.showModalDialog('placed_applicatdetails_uk.aspx?app_id=" + DataBinder.Eval(e.Item.DataItem, "app_id") + "','appdets','dialogHeight: 750px; dialogWidth: 950px; dialogTop: 50px; dialogLeft:150px; edge: Raised; center: No; help: No; resizable: No; status: No;');");
			}
		}

		public void SortApps(Object sender, DataGridSortCommandEventArgs e)
		{
			switch(e.SortExpression)
			{
				case "date" :
					sort = 0;
					break;
				case "location" :
					sort =1;
					break;
				case "name" :
					sort = 2;
					break;
				case "dob" :
					sort = 3;
					break;
				case "crim" :
					sort = 4;
					break;
			}

			Session["sort"] = sort;

			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = app_con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;

			cmd.CommandText = "get_placed_applicants";

			cmd.Parameters.Add(
				new SqlParameter("@sorto", sort));

			rdr = cmd.ExecuteReader();
			this.dgApplicants.DataSource = null;
			this.dgApplicants.DataSource = rdr;
			this.dgApplicants.DataBind();
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();	
			set_cells();


		}

		public void dgApp_delete(Object sender, DataGridCommandEventArgs e)
		{
			delete_app(e.Item.Cells[0].Text);
			get_applicants();

		}

		private void delete_app(string app_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();

			conn.ConnectionString = app_con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;

			cmd.CommandText = "del_applicants";

			cmd.Parameters.Add(
				new SqlParameter("@app_id", app_id));

			cmd.ExecuteNonQuery();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();	
		}

		private void set_cells()
		{
			foreach(DataGridItem dgi in this.dgApplicants.Items)
			{
				string dt = dgi.Cells[8].Text;
				if(dt=="Yes")
				{
					dgi.Cells[8].ForeColor=System.Drawing.Color.Red;
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
