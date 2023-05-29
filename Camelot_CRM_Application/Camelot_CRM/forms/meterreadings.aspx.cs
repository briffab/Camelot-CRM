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
	/// Summary description for meterreadings.
	/// </summary>
	public class meterreadings : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgMets;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnAdd;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnClose;
		Camelot.classes.cMeter lmet = new cMeter();
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
				lmet.Meter_ID = "";
				string read = Request.QueryString["read"];
				if(read=="" || read==null)
				{
					lmet = (Camelot.classes.cMeter)Session["curMeter"];
				}
				else
				{
					lmet.Meter_ID = read;
				}
				if(lmet.Meter_ID!=null)
			
				{
					lblTitle.Text = lmet.Meter_Location;
					getReadings(Convert.ToInt32(lmet.Meter_ID));
				}
			}
			if(pUser.Permission=="1")
			{
				btnAdd.Visible=true;
			}
			else
			{
				btnAdd.Visible=false;
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
			this.dgMets.SelectedIndexChanged += new System.EventHandler(this.dgMets_SelectedIndexChanged);
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			this.btnAdd.ServerClick += new System.EventHandler(this.btnAdd_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAdd_ServerClick(object sender, System.EventArgs e)
		{
			Session["read_edit"] = true;
			Session["read_save"] = false;
			Session["read_new"] = true;
			Response.Write("<script>window.showModalDialog('meterreading.aspx?met=','metr','dialogHeight: 485px; dialogWidth: 800px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
			Response.Write("<script>self.document.location.href = 'meterreadings.aspx';</script>");
		}

		private void getReadings(int metid)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_readings";

			cmd.Parameters.Add(
				new SqlParameter("@metid", metid));
			
			dgMets.DataSource = cmd.ExecuteReader();
			dgMets.DataBind();
			dgMets.Visible= true;
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		public void dgmets_ItemDataBound(Object sender, DataGridItemEventArgs e)
		{
			if(e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
			{
				LinkButton fButton = (LinkButton)e.Item.Cells[0].Controls[0];
				fButton.Attributes.Add("onclick", "javascript:window.showModalDialog('meterreading.aspx?read=" + DataBinder.Eval(e.Item.DataItem, "reading_id") + "','metdets','dialogHeight: 485px; dialogWidth: 800px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');");
			}
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.close();</script>");
		}

		private void dgMets_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
