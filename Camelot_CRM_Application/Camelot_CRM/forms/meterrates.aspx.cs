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
	/// Summary description for meterrates.
	/// </summary>
	public class meterrates : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ListBox lbCRates;
		protected System.Web.UI.WebControls.Button btnMto;
		protected System.Web.UI.WebControls.Button btnMfrom;
		protected System.Web.UI.WebControls.Label Lblmeter;
		protected System.Web.UI.WebControls.Button btnClose;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.ListBox lbARates;
		Camelot.classes.cMeter lmet;
		protected System.Web.UI.WebControls.Label lblPost;
		protected System.Web.UI.WebControls.Button btnAddRate;
		protected System.Web.UI.WebControls.TextBox txtRate;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		Camelot.classes.cUser pUser;
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			bool oktogo;
			Camelot.classes.Utils pUtil = new Camelot.classes.Utils();
			pUser = (Camelot.classes.cUser)Session["curUser"];
			oktogo = pUtil.valid_user(pUser);

			this.btnClose.Attributes.Add("OnClick","Done();");

			if(!oktogo)
			{
				Response.Write("<script>window.close();</script>");
			}
			else
			{
				lmet=(Camelot.classes.cMeter)Session["curMeter"];
				if(!Page.IsPostBack)
				{	
					if(lmet.Meter_ID==null || lmet.Meter_ID=="")
					{
						string met = Request.QueryString["met"];
						lmet.Meter_ID = met;
					}
					getmeterrates();
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
			this.btnAddRate.Click += new System.EventHandler(this.btnAddRate_Click);
			this.btnMto.Click += new System.EventHandler(this.btnMto_Click);
			this.btnMfrom.Click += new System.EventHandler(this.btnMfrom_Click);
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.close();</script>");
		}

		private void getmeterrates()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.saveUtils us = new Camelot.classes.saveUtils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_non_meter_rates";

			cmd.Parameters.Add(
				new SqlParameter("@met_id", lmet.Meter_ID));

			rdr = cmd.ExecuteReader();
			this.lbARates.Items.Clear();
			this.lbARates.DataSource =rdr;
			this.lbARates.DataValueField = "rate_id" ;
			this.lbARates.DataTextField = "rate_desc";
			this.lbARates.DataBind();

			rdr.NextResult();
			this.lbCRates.Items.Clear();
			this.lbCRates.DataSource =rdr;
			this.lbCRates.DataValueField = "rate_id" ;
			this.lbCRates.DataTextField = "rate_desc";
			this.lbCRates.DataBind();

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			this.Lblmeter.Text = lmet.Meter_Location;
		}

		private void btnMto_Click(object sender, System.EventArgs e)
		{
			foreach(ListItem li in this.lbARates.Items)
			{
				if(li.Selected)
				{
					this.lbCRates.Items.Add(li);
				}
			}

			foreach(ListItem li in this.lbCRates.Items)
			{
				this.lbARates.Items.Remove(li);
			}
		}

		private void btnMfrom_Click(object sender, System.EventArgs e)
		{
			foreach(ListItem li in this.lbCRates.Items)
			{
				if(li.Selected)
				{
					this.lbARates.Items.Add(li);
				}
			}

			foreach(ListItem li in this.lbARates.Items)
			{
				this.lbCRates.Items.Remove(li);
			}
		}

		private void btnAddRate_Click(object sender, System.EventArgs e)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			Camelot.classes.saveUtils us = new Camelot.classes.saveUtils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "ADD_METER_RATE";

			cmd.Parameters.Add(
				new SqlParameter("@rate_desc", this.txtRate.Text));
			cmd.Parameters.Add(
				new SqlParameter("@met_type", lmet.Meter_Type.ToString()));

			cmd.ExecuteNonQuery();

			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			this.txtRate.Text = "";
			getmeterrates();
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			
			deleterates();

			foreach(ListItem li in this.lbCRates.Items)
			{
				savemeterrate(li.Value, lmet.Meter_ID);
			}
			//Response.Write("<script>parent.location.reload(true);</script>");
			Response.Write("<script>window.close();</script>");
			
		}

		private void deleterates()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			Camelot.classes.saveUtils us = new Camelot.classes.saveUtils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "DELETE_METER_RATES";

			cmd.Parameters.Add(
				new SqlParameter("@met_id", lmet.Meter_ID));
			
			cmd.ExecuteNonQuery();

			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		private void savemeterrate(string r_id, string m_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			Camelot.classes.saveUtils us = new Camelot.classes.saveUtils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "INSERT_METER_RATE";

			cmd.Parameters.Add(
				new SqlParameter("@rate_id", r_id));
			cmd.Parameters.Add(
				new SqlParameter("@met_id", m_id));

			cmd.ExecuteNonQuery();

			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}
	}
}
