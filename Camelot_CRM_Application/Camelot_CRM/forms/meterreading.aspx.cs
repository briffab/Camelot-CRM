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
	/// Summary description for meterreading.
	/// </summary>
	public class meterreading : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.Label lbldate;
		Camelot.classes.cMeter lmet;
		protected System.Web.UI.WebControls.DataGrid dgRates;
		protected System.Web.UI.WebControls.Label Label1;
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
				hideErr();
				string err=Request.QueryString["err"];
				lmet = (Camelot.classes.cMeter)Session["curMeter"];
			}
			this.lblTitle.Text = lmet.Meter_Location;
			if(!Page.IsPostBack)
			{
				pop_rates();
			}
		}
		

		private void pop_rates()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			Camelot.classes.Utils us = new Camelot.classes.Utils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_meter_rates";

			cmd.Parameters.Add(
				new SqlParameter("@met_id", lmet.Meter_ID));

			this.dgRates.DataSource = cmd.ExecuteReader();
			this.dgRates.DataBind();

			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

				private void hideErr()
		{
			lblMessage.Visible = false;
			Label11.Visible=false;
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
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

	
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.close();</script>");
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			savereading();
		}

		private void savereading()
		{
			bool oktosave = true;
			string Msg = "";
			int cnt = 0;
			Camelot.classes.saveUtils su = new saveUtils();

						
			if(!su.IsDate(txtDate.Text))
			{
				oktosave=false;
				cnt++;
				if(Msg!="")
				{
					Msg = Msg + ", Reading Date";
				}
				else
				{
					Msg = "Reading Date";
				}
				Label11.Visible=true;
			}
		
			if(oktosave)
			{
				foreach(DataGridItem dgi in dgRates.Items)
				{							   
					int id = Convert.ToInt32(dgRates.DataKeys[dgi.ItemIndex].ToString());
					TextBox reading = (TextBox)dgi.FindControl("txtReading");

					saveratereading(id,reading.Text);
				}
			
				bool mnew = (bool)Session["read_new"];
				Session["read_edit"] = false;
				Session["read_save"] = false;
				Session["read_new"] = false;
				
				
				Response.Write("<script>parent.location.reload(true);</script>");
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

		private void saveratereading(int rate_id, string read)
		{

			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			lmet= (Camelot.classes.cMeter)Session["curMeter"];
			pUser = (Camelot.classes.cUser)Session["curUser"];

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "insert_meter_readings";

			cmd.Parameters.Add(
				new SqlParameter("@met_id", lmet.Meter_ID));
			cmd.Parameters.Add(
				new SqlParameter("@date", DateTime.Parse(txtDate.Text)));
			cmd.Parameters.Add(
				new SqlParameter("@read", read));
			cmd.Parameters.Add(
				new SqlParameter("@rate", rate_id));
			cmd.Parameters.Add(
				new SqlParameter("@insp_id", pUser.ID));
			
			cmd.ExecuteNonQuery();
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}
	}
}
