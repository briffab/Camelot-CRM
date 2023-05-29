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
	/// Summary description for companyaddress.
	/// </summary>
	public class residentaddress : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblAddress;
		protected System.Web.UI.WebControls.TextBox txtAddress1;
		protected System.Web.UI.WebControls.TextBox txtAddress2;
		protected System.Web.UI.WebControls.TextBox txtAddress3;
		protected System.Web.UI.WebControls.TextBox txtAddress4;
		protected System.Web.UI.WebControls.Label lblTown;
		protected System.Web.UI.WebControls.TextBox txtTown;
		protected System.Web.UI.WebControls.Label lblPost;
		protected System.Web.UI.WebControls.TextBox txtPost;
		protected System.Web.UI.WebControls.Label lblCounty;
		protected System.Web.UI.WebControls.TextBox txtCounty;
		protected System.Web.UI.WebControls.Label lblArea;
		protected System.Web.UI.WebControls.DropDownList cmbArea;
		protected System.Web.UI.WebControls.Label lblCountry;
		protected System.Web.UI.WebControls.TextBox txtCountry;
		protected System.Web.UI.WebControls.Button btnClose;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Button btnCancel;
		cc.cGuardian lguard = new Camelot.classes.cGuardian();
		Camelot.classes.cUser pUser;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblUpd;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblUpdDate;
		Camelot.classes.Utils Utils = new Camelot.classes.Utils();
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			bool oktogo;
			Camelot.classes.Utils pUtil = new Camelot.classes.Utils();
			lguard=(Camelot.classes.cGuardian)Session["curGuardian"];
			pUser = (Camelot.classes.cUser)Session["curUser"];
			oktogo = pUtil.valid_user(pUser);
			if(!oktogo)
			{
				Response.Redirect("../logon.aspx");
			}
			else			
			{
				
				if(!Page.IsPostBack)
				{
					setenabled(false);
					this.lblTitle.Text = lguard.Guardian_Name;
					pop_area("");
					popaddr();
					btnUpdate.Visible = false;
					btnCancel.Visible = false;
					btnEdit.Visible = true;
					btnClose.Visible=true;
				}
			}
		}

		private void popaddr()
		{

			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.Utils us = new Camelot.classes.Utils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_other_address";

			cmd.Parameters.Add(
				new SqlParameter("@guard", lguard.Guardian_ID));
			

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				this.txtAddress1.Text = rdr["housename"].ToString();
				this.txtAddress2.Text = rdr["streetname"].ToString();
				this.txtAddress3.Text = rdr["address4"].ToString();
				this.txtAddress4.Text = rdr["address5"].ToString();
				this.txtTown.Text = rdr["city"].ToString();
				this.txtPost.Text = rdr["postalcode"].ToString();
				this.txtCounty.Text = rdr["county"].ToString();
				this.txtCountry.Text = rdr["country"].ToString();
				this.pop_area(rdr["area_id"].ToString());
				this.lblUpd.Text = rdr["name"].ToString();
				this.lblUpdDate.Text = rdr["entered"].ToString();
			}
		}

		private void pop_area(string areaid)
		{
			cc.Areas larea = (cc.Areas)Session["Areas"];
			int ind =0;
			cmbArea.Items.Clear();
			cmbArea.Items.Add("");
			foreach(cc.Area ar in larea)
			{
				cmbArea.Items.Add(ar.Description);
				if(ar.Area_ID == areaid)
				{
					ind = cmbArea.Items.Count-1;
				}
			}
			cmbArea.SelectedIndex = ind;
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
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Session["visitaddr"] = "view";
			Response.Write("<script>window.close();</script>");
		}

		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			setenabled(true);
			btnUpdate.Visible = true;
			btnCancel.Visible = true;
			btnEdit.Visible = false;
			btnClose.Visible=false;
			Session["visitaddr"] = "visit";
		}

		private void setenabled(bool en)
		{
			this.txtAddress1.Enabled=en;
			this.txtAddress2.Enabled=en;
			this.txtAddress3.Enabled=en;
			this.txtAddress4.Enabled=en;
			this.txtCountry.Enabled=en;
			this.txtCounty.Enabled=en;
			this.txtPost.Enabled=en;
			this.txtTown.Enabled=en;
			this.cmbArea.Enabled=en;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			setenabled(false);
			btnUpdate.Visible = false;
			btnCancel.Visible = false;
			btnEdit.Visible = true;
			btnClose.Visible=true;
			Session["visitaddr"] = "view";
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			saveaddress();
		}

		private void saveaddress()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			Camelot.classes.Utils us = new Camelot.classes.Utils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "save_second_address";

			cmd.Parameters.Add(
				new SqlParameter("@guard", lguard.Guardian_ID));
			
			cmd.Parameters.Add(
				new SqlParameter("@addr1", this.txtAddress1.Text));
			cmd.Parameters.Add(
				new SqlParameter("@addr2", this.txtAddress2.Text));
			cmd.Parameters.Add(
				new SqlParameter("@addr3", this.txtAddress3.Text));
			cmd.Parameters.Add(
				new SqlParameter("@addr4", this.txtAddress4.Text));
			cmd.Parameters.Add(
				new SqlParameter("@country", this.txtCountry.Text));
			cmd.Parameters.Add(
				new SqlParameter("@county", this.txtCounty.Text));
			cmd.Parameters.Add(
				new SqlParameter("@post", this.txtPost.Text));
			cmd.Parameters.Add(
				new SqlParameter("@city", this.txtTown.Text));
			cmd.Parameters.Add(
				new SqlParameter("@employ", pUser.ID));
			cmd.Parameters.Add(
				new SqlParameter("@area", get_areaid(this.cmbArea.SelectedItem.Text)));

			cmd.ExecuteNonQuery();

			setenabled(false);
			this.btnCancel.Visible=false;
			this.btnUpdate.Visible=false;
			this.btnClose.Visible=true;
			this.btnEdit.Visible=true;


		}

		public int get_areaid(string area)
		{
			int id = 0;
			cc.Areas larea = (cc.Areas)Session["Areas"];
			
			foreach(cc.Area ar in larea)
			{
				if(ar.Description == area)
				{
					id = Convert.ToInt32(ar.Area_ID);
					break;
				}
			}
			return id;
		}
	}
}
