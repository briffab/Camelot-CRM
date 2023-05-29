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
using cc = Camelot.classes;
using System.Data.SqlClient;

namespace Camelot.forms
{
	/// <summary>
	/// Summary description for routedate.
	/// </summary>
	public class routedate : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.Button btnCancel;
		private cc.cRoute lRoute;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			lRoute=(Camelot.classes.cRoute)Session["curRoute"];
			if(!Page.IsPostBack)
			{	
				if(lRoute.Route_ID==null || lRoute.Route_ID=="")
				{
					string route = Request.QueryString["route_id"];
					lRoute.Route_ID = route;
					hidErr();
				}
			}

		}

		private void hidErr()
		{
			this.Label14.Visible=false;
			this.lblMessage.Visible=false;
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
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			save_date();
			
		}

		private void save_date()
		{
			bool oktosave = true;
			string Msg = "";
			int cnt = 0;
			Camelot.classes.saveUtils su = new Camelot.classes.saveUtils();
			
			if(!su.IsDate(su.setdate(txtDate.Text)) || this.txtDate.Text == "")
			{
				oktosave=false;
				cnt++;
				if(Msg!="")
				{
					Msg = Msg + ", Inspection Date";
				}
				else
				{
					Msg = "Inspection Date";
				}
				Label14.Visible=true;
			}
			
			if(oktosave)
			{
				SqlConnection conn = new SqlConnection();
				SqlCommand cmd =  new SqlCommand();
				SqlDataReader rdr = null;

				conn.ConnectionString = (string)Session["Connection"];
				conn.Open();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "update_route_date";

				cmd.Parameters.Add(
					new SqlParameter("@route_id", lRoute.Route_ID));
				cmd.Parameters.Add(
					new SqlParameter("@DATE", su.setdate(txtDate.Text)));
				
				rdr = cmd.ExecuteReader();

				cmd.Dispose();
				conn.Close();
				conn.Dispose();	
			
				Response.Write("<script>window.open('blankroute.aspx?route_id=" + lRoute.Route_ID + "','appdets','dialogHeight: 500px; dialogWidth: 950px; dialogTop: 50px; dialogLeft:150px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
				Response.Write("<script>window.close();</script>");
				
			}
			else
			{
				if(cnt==1)
				{
					Msg ="The field " + Msg + " is";
				}
				else
				{
					Msg ="The fields " + Msg + " are";
				}
				Msg = Msg+ " incomplete or in the wrong format";
				lblMessage.Text = Msg;
				lblMessage.Visible=true;
			}
			


		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.close();</script>");
		}
	}
}
