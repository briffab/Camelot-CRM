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
	/// Summary description for recipients.
	/// </summary>
	public class recipients : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.TextBox txtName;
		protected System.Web.UI.WebControls.Button btnClose;
		protected System.Web.UI.WebControls.DropDownList cmbRecs;
		protected System.Web.UI.WebControls.Button btnOK;
		protected System.Web.UI.WebControls.DataGrid dgGuards;
		cc.cUser pUser = new Camelot.classes.cUser();

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
				pop_recs();
			}
		}
			
		private void pop_recs()
		{
			int rec = Convert.ToInt32(this.cmbRecs.SelectedValue);

			switch(rec)
			{
				case 0:
					pop_cam();
					break;
				case 1:
					pop_conts();
					break;
				case 2:
					pop_guard();
					break;
			}
		}

		private void pop_guard()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			ArrayList Guards = new ArrayList();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_guardian_recipients";
	
			this.dgGuards.DataSource = cmd.ExecuteReader();
			this.dgGuards.DataBind();

			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		private void pop_cam()
		{

		}

		private void pop_conts()
		{
            
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
			this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
			this.cmbRecs.SelectedIndexChanged += new System.EventHandler(this.cmbRecs_SelectedIndexChanged);
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.close()</script>");
		}

		private void cmbRecs_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			pop_recs();
		}

		protected void txtName_TextChanged(object sender, System.EventArgs e)
		{
			this.dgGuards.SelectedIndex = 25;
		}
	}
}
