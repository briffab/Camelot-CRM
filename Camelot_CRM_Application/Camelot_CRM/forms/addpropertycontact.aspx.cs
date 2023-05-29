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

namespace Camelot
{
	/// <summary>
	/// Summary description for meterdetails.
	/// </summary>
	public class addpropertycontact : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.TextBox txtnotes;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Button btnClose;
		Camelot.classes.Utils Utils = new Camelot.classes.Utils();
		Camelot.classes.cProperty lprop;
		Camelot.classes.cCompany lcomp = new cCompany();
		protected System.Web.UI.WebControls.DropDownList cmbmettype;
		protected System.Web.UI.WebControls.TextBox txtloc;
		protected System.Web.UI.WebControls.TextBox txtmetsn;
		protected System.Web.UI.WebControls.TextBox txtreaddate;
		protected System.Web.UI.WebControls.TextBox txtreading;
		protected System.Web.UI.WebControls.DropDownList cmbsupp;
		protected System.Web.UI.WebControls.CheckBox chkUse;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label lblfacdesc;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.ListBox lbTypes;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.Label LabelName;
		protected System.Web.UI.WebControls.Label lblWkTel;
		protected System.Web.UI.WebControls.Label lblEmail;
		protected System.Web.UI.WebControls.Label lblMobile;
		protected System.Web.UI.WebControls.Label lblJob;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList cmbcontact;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblStatus;
		protected System.Web.UI.WebControls.ListBox lbCompanies;
		protected System.Web.UI.WebControls.TextBox txtFCompany;
		protected System.Web.UI.WebControls.Label Label6;
		Camelot.classes.cUser pUser;
			

		private void Page_Load(object sender, System.EventArgs e)
		{
			bool oktogo;
			Camelot.classes.Utils pUtil = new Camelot.classes.Utils();
			lcomp=(Camelot.classes.cCompany)Session["curCompany"];
			pUser = (Camelot.classes.cUser)Session["curUser"];
			oktogo = pUtil.valid_user(pUser);
			if(!oktogo)
			{
				Response.Redirect("../logon.aspx");
			}
			setvisible(false);
		}

		private void setvisible(bool vis)
		{
			LabelName.Visible=vis;
			lblWkTel.Visible=vis;
			lblMobile.Visible=vis;
			lblEmail.Visible=vis;
			lblJob.Visible=vis;
			txtnotes.Visible=vis;
			lbTypes.Visible=vis;
			txtnotes.Enabled=false;
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.lbCompanies.SelectedIndexChanged += new System.EventHandler(this.lbCompanies_SelectedIndexChanged);
			this.cmbcontact.SelectedIndexChanged += new System.EventHandler(this.cmbcontact_SelectedIndexChanged);
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.close();</script>");
		}


		public int get_cont_type(string cont)
		{
			int id = 0;
			cont_types conts = (cont_types)Session["ContTypes"];
			
			foreach(cont_type ct in conts)
			{
				if(ct.Description == cont)
				{
					id = Convert.ToInt32(ct.C_TypeID);
					break;
				}
			}
			return id;
		}

		private void pop_comp(string comp)
		{

			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.Utils us = new Camelot.classes.Utils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "find_companies";

			cmd.Parameters.Add(
				new SqlParameter("@SEARCH", comp));

			rdr = cmd.ExecuteReader();
			
			lbCompanies.Items.Clear();
			lbCompanies.DataSource = rdr;
			lbCompanies.DataTextField = "comp_dets";
			lbCompanies.DataValueField = "comp_id";
			lbCompanies.DataBind();
				
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			lprop = (Camelot.classes.cProperty)Session["curProperty"];
			string cont = cmbcontact.SelectedValue.ToString();
			string comp = lbCompanies.SelectedValue.ToString();
			add_cont(cont, lprop.Property_ID);
			popconts(comp, lprop.Property_ID);
		}

		private void add_cont(string cont, string prop)
		{
			pUser = (Camelot.classes.cUser)Session["curUser"];
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "add_property_contact";

			cmd.Parameters.Add(
				new SqlParameter("@cont", cont));
			cmd.Parameters.Add(
				new SqlParameter("@prop", prop));
			cmd.Parameters.Add(
				new SqlParameter("@recman", pUser.ID));
			cmd.ExecuteNonQuery();
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			saveCtypes(cont, prop);
		}


		private void saveCtypes(string cont, string prop)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "del_OBJCONT";
			cmd.Parameters.Add(
				new SqlParameter("@cont_id", cont));
			cmd.Parameters.Add(
				new SqlParameter("@prop_id", prop));

			cmd.ExecuteNonQuery();
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

			foreach(ListItem li in this.lbTypes.Items)
			{
				if(li.Selected)
				{
					saveCtype(prop, cont, li.Value.ToString());
				}
			}
		}


		private void saveCtype(string prop, string cont, string type)
		{
			pUser = (Camelot.classes.cUser)Session["curUser"];
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "add_OBJCONT";

			cmd.Parameters.Add(
				new SqlParameter("@cont_id", cont));
			cmd.Parameters.Add(
				new SqlParameter("@prop_id", prop));
			cmd.Parameters.Add(
				new SqlParameter("@CONT_TYPE", type));
			cmd.ExecuteNonQuery();
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			pop_comp(txtFCompany.Text);
			setvisible(false);
		}

		private void lbCompanies_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(lbCompanies.SelectedIndex != -1)
			{
				string itm = lbCompanies.SelectedValue.ToString();
				lprop = (Camelot.classes.cProperty)Session["curProperty"];
				popconts(itm, lprop.Property_ID);
			}
		}

		private void popconts(string comp, string prop)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.Utils us = new Camelot.classes.Utils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_property_company_contacts";

			cmd.Parameters.Add(
				new SqlParameter("@comp_id", comp));
			cmd.Parameters.Add(
				new SqlParameter("@prop_id", prop));
			rdr = cmd.ExecuteReader();
			
			cmbcontact.Items.Clear();
			cmbcontact.DataSource = rdr;
			cmbcontact.DataTextField = "CNAME";
			cmbcontact.DataValueField = "CONTACT_ID";
			cmbcontact.DataBind();
				
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

			string cont = cmbcontact.SelectedValue.ToString();
			pop_cont(cont,comp);
		}

		private void cmbcontact_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string cont = cmbcontact.SelectedValue.ToString();
			string comp = lbCompanies.SelectedValue.ToString();
			pop_cont(cont,comp);
		}

		private void pop_cont(string cont_id, string comp_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.Utils us = new Camelot.classes.Utils();
			string stat = "";

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_contact";

			cmd.Parameters.Add(
				new SqlParameter("@cont_id", cont_id));
			cmd.Parameters.Add(
				new SqlParameter("@comp_id", comp_id));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				LabelName.Text = rdr["firstname"].ToString() + " " + rdr["lastname"].ToString();
				lblWkTel.Text = rdr["wktel"].ToString();
				lblMobile.Text = rdr["mobile"].ToString();
				lblEmail.Text = rdr["email"].ToString();
				lblJob.Text = rdr["job_title"].ToString();
				txtnotes.Text = rdr["notes"].ToString();
				stat = rdr["status_id"].ToString();
			}
			rdr.NextResult();
			pop_conttype(rdr);
			setvisible(true);

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		private void pop_conttype(SqlDataReader rs)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.Utils us = new Camelot.classes.Utils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_conttypes";

			rdr = cmd.ExecuteReader();

			lbTypes.DataSource = rdr;
			lbTypes.DataTextField = "description";
			lbTypes.DataValueField = "contact_type";
			lbTypes.DataBind();
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

			while(rs.Read())
			{
				foreach(ListItem lbi in lbTypes.Items)
				{
					if(lbi.Value == rs["contact_type"].ToString())
					{
						lbi.Selected=true;
					}
				}
			
			}
		}

		
	}
}