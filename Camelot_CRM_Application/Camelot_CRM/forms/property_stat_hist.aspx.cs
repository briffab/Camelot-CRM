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
	/// Summary description for property_stat_hist.
	/// </summary>
	public class property_stat_hist : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgHist;
		protected System.Web.UI.WebControls.Button btnClose;
		private Camelot.classes.cProperty lprop = new Camelot.classes.cProperty();
		private Camelot.classes.cUser pUser;

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
				lprop = (Camelot.classes.cProperty)Session["curProperty"];
				if(lprop.Property_ID!=null)
			
				{
					getStats(Convert.ToInt32(lprop.Property_ID));
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.close();</script>");
		}

		private void getStats(int propid)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_statUS_HIST";

			cmd.Parameters.Add(
				new SqlParameter("@propid", propid));
			
			dgHist.DataSource = cmd.ExecuteReader();
			dgHist.DataBind();
			dgHist.Visible= true;
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}
	}
}
