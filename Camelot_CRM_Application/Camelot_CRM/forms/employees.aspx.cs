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
	/// Summary description for employees.
	/// </summary>
	public class employees : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label LblProp;
		protected System.Web.UI.WebControls.DataGrid dgEmps;
		protected System.Web.UI.HtmlControls.HtmlInputButton Button1;
		private cc.cUser pUser;
	
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
					
				getEmployees();	
				
			}
		}

		private void getEmployees()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_employees";

			dgEmps.DataSource = cmd.ExecuteReader();
			dgEmps.DataBind();
			dgEmps.Visible= true;
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		public void dgEmps_ItemDataBound(Object sender, DataGridItemEventArgs e)
		{
			if(e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
			{
				LinkButton fButton = (LinkButton)e.Item.Cells[1].Controls[0];
				fButton.Attributes.Add("onclick", "javascript:window.showModalDialog('employeedetails.aspx?emp=" + DataBinder.Eval(e.Item.DataItem, "employee_id") + "','empdeys','dialogHeight: 750px; dialogWidth: 950px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');self.document.location.href = 'property_incidents.aspx';");
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
