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
	/// property page, if no property is in session show search list only
	/// </summary>
	public class new_property : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtFind;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.TextBox txtAddress1;
		protected System.Web.UI.WebControls.Label lblPost;
		protected System.Web.UI.WebControls.Label lblArea;
		protected System.Web.UI.WebControls.Label lblCounty;
		protected System.Web.UI.WebControls.Label lblCountry;
		protected System.Web.UI.WebControls.Label lblProptype;
		protected System.Web.UI.WebControls.Label lblRegMan;
		protected System.Web.UI.WebControls.Label lblMaxOcc;
		protected System.Web.UI.WebControls.Label lblStatus;
		protected System.Web.UI.WebControls.Label lblStatEff;
		protected System.Web.UI.WebControls.Label lblAccMan;
		protected System.Web.UI.WebControls.Label lblPropMan;
		protected System.Web.UI.WebControls.Label lblPropInsp;
		protected System.Web.UI.WebControls.Image imgMainPhoto;
		protected System.Web.UI.WebControls.TextBox txtAddress2;
		protected System.Web.UI.WebControls.TextBox txtAddress3;
		protected System.Web.UI.WebControls.TextBox txtTown;
		protected System.Web.UI.WebControls.TextBox txtPost;
		protected System.Web.UI.WebControls.DropDownList cmbArea;
		protected System.Web.UI.WebControls.DropDownList cmbPropType;
		protected System.Web.UI.WebControls.DropDownList cmbRegMan;
		protected System.Web.UI.WebControls.TextBox txtMaxOcc;
		protected System.Web.UI.WebControls.DropDownList cmbPropMan;
		protected System.Web.UI.WebControls.DropDownList cmbPropInsp;
		protected System.Web.UI.WebControls.Label lblUby;
		protected System.Web.UI.WebControls.Label lblUDate;
		protected System.Web.UI.WebControls.DropDownList cmbStatus;
		protected System.Web.UI.WebControls.TextBox txtStatEff;
		protected System.Web.UI.WebControls.Label lblTown;
		protected System.Web.UI.WebControls.DropDownList cmbAccMan;
		protected System.Web.UI.WebControls.DropDownList cmbGuardMan;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Label lblDtStart;
		protected System.Web.UI.WebControls.Label lblDtStop;
		protected System.Web.UI.WebControls.Label lblGuardMan;
		protected System.Web.UI.WebControls.DropDownList cmbFind;
		protected System.Web.UI.WebControls.Button BtnGo;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.TextBox txtCounty;
		protected System.Web.UI.WebControls.TextBox txtDtStart;
		protected System.Web.UI.WebControls.TextBox txtDtStop;
		protected System.Web.UI.WebControls.TextBox txtCountry;
		Camelot.classes.cProperty lprop;
		Camelot.classes.cCompany lcomp = new cCompany();
		protected System.Web.UI.WebControls.TextBox txtCompany;
		protected System.Web.UI.WebControls.Button btnCserch;
		protected System.Web.UI.WebControls.ListBox lbCompanies;
		protected System.Web.UI.WebControls.Label lblFCompany;
		protected System.Web.UI.WebControls.Label lblCompany;
		protected System.Web.UI.WebControls.Label lblSCompany;
		protected System.Web.UI.WebControls.TextBox txtCompID;
		protected System.Web.UI.WebControls.TextBox txtSCompany;
		protected System.Web.UI.WebControls.Label lblCompID;
		protected System.Web.UI.WebControls.TextBox txtName;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblStatstar;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblstartstar;
		protected System.Web.UI.WebControls.Label lblstopstar;
		protected System.Web.UI.WebControls.Label lblSCompID;
		protected System.Web.UI.WebControls.Label lblStatusStar;
		protected System.Web.UI.WebControls.TextBox txtMfee;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtLfee;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblPropName;
		protected System.Web.UI.WebControls.TextBox txtKey;
		protected System.Web.UI.WebControls.TextBox txtCalam;
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
				setvisible(true);
				setenabled(true);
				
				if(!Page.IsPostBack)
				{
					pop_accman("");
					pop_propman("");
					pop_propinsp("");
					pop_guardman("");
					pop_area("");
					pop_regman("");
					pop_proptype("");
					pop_status("");
					pop_comp("");
					//txtSCompany.Enabled=false;
					//txtCompID.Enabled=false;
					lcomp= (Camelot.classes.cCompany)Session["curCompany"];
					if(lcomp.Company_ID!=null)
					{
						txtSCompany.Text = lcomp.Company_Name;
						txtCompID.Text = lcomp.Company_ID;
					}
					else
					{
						txtSCompany.Text = "No Company";
						txtCompID.Text = "0";
					}
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
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.cmbPropType.SelectedIndexChanged += new System.EventHandler(this.cmbPropType_SelectedIndexChanged);
			this.cmbRegMan.SelectedIndexChanged += new System.EventHandler(this.cmbRegMan_SelectedIndexChanged);
			this.btnCserch.Click += new System.EventHandler(this.btnCserch_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		public string get_employeename(int emp)
		{
			string name = "";
			Employees lemps = (Employees)Session["Emps"];
			
			foreach(Employee em in lemps)
			{
				if(Convert.ToInt32(em.Emp_ID) == emp)
				{
					name = em.Emp_Name;
					break;
				}
			}
			return name;
		}

		private void pop_area(string areaid)
		{
			Areas larea = (Areas)Session["Areas"];
			int ind =0;
			cmbArea.Items.Clear();
			cmbArea.Items.Add("");
			foreach(Area ar in larea)
			{
				cmbArea.Items.Add(ar.Description);
				if(ar.Area_ID == areaid)
				{
					ind = cmbArea.Items.Count-1;
				}
			}
			cmbArea.SelectedIndex = ind;
		}

		private void pop_proptype(string typeid)
		{
			O_Types ltypes = (O_Types)Session["OTypes"];
			int ind =0;
			cmbPropType.Items.Clear();
			cmbPropType.Items.Add("");
			foreach(O_Type ot in ltypes)
			{
				cmbPropType.Items.Add(ot.Description);
				if(ot.O_TypeID == typeid)
				{
					ind = cmbPropType.Items.Count-1;
				}
			}
			cmbPropType.SelectedIndex = ind;
		}

		private void pop_regman(string regid)
		{
			Employees lemps = (Employees)Session["Emps"];
			int ind =0;
			cmbRegMan.Items.Clear();
			cmbRegMan.Items.Add("");
			foreach(Employee e in lemps)
			{
				cmbRegMan.Items.Add(e.Emp_Name);
				if(e.Emp_ID == regid)
				{
					ind = cmbRegMan.Items.Count-1;
				}
			}
			cmbRegMan.SelectedIndex = ind;
		}

		private void pop_accman(string regid)
		{
			Employees lemps = (Employees)Session["Emps"];
			cAcc_Mans laccs = (cAcc_Mans)Session["Accmans"];
			int ind =0;
			cmbAccMan.Items.Clear();
			cmbAccMan.Items.Add("");

			foreach(cAccMan a in laccs)
			{
				foreach(Employee e in lemps)
				{
					if(e.Emp_ID == a.Acc_Man)
					{
						cmbAccMan.Items.Add(e.Emp_Name);
						if(e.Emp_ID == regid)
						{
							ind = cmbAccMan.Items.Count-1;
						}
					}
				}
			}
		}

		private void pop_propman(string regid)
		{
			Employees lemps = (Employees)Session["Emps"];
			int ind =0;
			cmbPropMan.Items.Clear();
			cmbPropMan.Items.Add("");
			foreach(Employee e in lemps)
			{
				cmbPropMan.Items.Add(e.Emp_Name);
				if(e.Emp_ID == regid)
				{
					ind = cmbPropMan.Items.Count-1;
				}
			}
			cmbPropMan.SelectedIndex = ind;
		}

		private void pop_propinsp(string regid)
		{
			Employees lemps = (Employees)Session["Emps"];
			int ind =0;
			cmbPropInsp.Items.Clear();
			cmbPropInsp.Items.Add("");
			foreach(Employee e in lemps)
			{
				cmbPropInsp.Items.Add(e.Emp_Name);
				if(e.Emp_ID == regid)
				{
					ind = cmbPropInsp.Items.Count-1;
				}
			}
			cmbPropInsp.SelectedIndex = ind;
		}

		private void pop_guardman(string regid)
		{
			Employees lemps = (Employees)Session["Emps"];
			int ind =0;
			cmbGuardMan.Items.Clear();
			cmbGuardMan.Items.Add("");
			foreach(Employee e in lemps)
			{
				cmbGuardMan.Items.Add(e.Emp_Name);
				if(e.Emp_ID == regid)
				{
					ind = cmbGuardMan.Items.Count-1;
				}
			}
			cmbGuardMan.SelectedIndex = ind;
		}

		private void pop_status(string statid)
		{
			Object_stats lstats = (Object_stats)Session["Stats"];
			int ind =0;
			cmbStatus.Items.Clear();
			cmbStatus.Items.Add("");
			foreach(Object_stat o in lstats)
			{
				cmbStatus.Items.Add(o.Description);
				if(o.Status_ID == statid)
				{
					ind = cmbStatus.Items.Count-1;
				}
			}
			cmbStatus.SelectedIndex = ind;
		}

	

		private void setvisible(bool vis)
		{
			lblTown.Visible = vis;
			lblPost.Visible = vis;
			lblCounty.Visible = vis;
			lblArea.Visible = vis;
			lblCountry.Visible = vis;
			lblProptype.Visible = vis;
			lblRegMan.Visible = vis;
			lblMaxOcc.Visible= vis;
			lblStatus.Visible = vis;
			lblStatEff.Visible = vis;
			lblAccMan.Visible = vis;
			lblPropMan.Visible = vis;
			lblPropInsp.Visible = vis;
			lblGuardMan.Visible = vis;
			txtAddress1.Visible = vis;
			txtAddress2.Visible = vis;
			txtAddress3.Visible = vis;
			txtTown.Visible = vis;
			txtPost.Visible = vis;
			txtCounty.Visible = vis;
			cmbArea.Visible = vis;
			txtCountry.Visible = vis;
			cmbPropType.Visible = vis;
			cmbRegMan.Visible = vis;
			txtMaxOcc.Visible = vis;
			cmbStatus.Visible = vis;
			txtStatEff.Visible = vis;
			cmbAccMan.Visible = vis;
			cmbPropMan.Visible = vis;
			cmbPropInsp.Visible = vis;
			cmbGuardMan.Visible = vis;
			btnUpdate.Visible = vis;
			btnCancel.Visible = vis;
			lblDtStart.Visible = vis;
			lblDtStop.Visible = vis;
			txtDtStart.Visible = vis;
			txtDtStop.Visible = vis;
			lblTitle.Visible = vis;
			lblStatstar.Visible = !vis;
			lblstartstar.Visible = !vis;
			lblstopstar.Visible = !vis;
			lblStatusStar.Visible = !vis;
			lblPropName.Visible = !vis;
		}

		private void setenabled(bool edit)
		{
			txtAddress1.Enabled = edit;
			txtAddress2.Enabled = edit;
			txtAddress3.Enabled = edit;
			txtTown.Enabled = edit;
			txtPost.Enabled = edit;
			txtCounty.Enabled = edit;
			cmbArea.Enabled = edit;
			txtCountry.Enabled = edit;
			cmbPropType.Enabled = edit;
			cmbRegMan.Enabled = edit;
			txtMaxOcc.Enabled = edit;
			cmbStatus.Enabled = edit;
			txtStatEff.Enabled = edit;
			cmbAccMan.Enabled = edit;
			cmbPropMan.Enabled = edit;
			cmbPropInsp.Enabled = edit;
			cmbGuardMan.Enabled = edit;
			txtDtStart.Enabled = edit;
			txtDtStop.Enabled = edit;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Session["prop_edit"] = false;
			Session["prop_save"] = false;
			Session["prop_new"] = false;
			Response.Write("<script>window.close();</script>");
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			string t="";
			t=txtCompID.Text;
			saveproperty();
		}

		private void saveproperty()
		{
			bool oktosave = true;
			Camelot.classes.saveUtils su = new Camelot.classes.saveUtils();

			
			if(txtName.Text=="")
			{
				oktosave=false;
				lblPropName.Visible=true;
			}
			if(cmbStatus.SelectedIndex==0)
			{
				oktosave=false;
				lblStatusStar.Visible=true;
			}

			if(!su.IsDate(su.setdate(txtStatEff.Text)))
			{
				oktosave = false;
				lblStatstar.Visible=true;
			}
			if(!su.IsDate(su.setdate(txtDtStart.Text)))
			{
				oktosave = false;
				lblstartstar.Visible = true;
			}
			if(!su.IsDate(su.setdate(txtDtStop.Text)))
			{
				oktosave = false;
				lblstopstar.Visible=true;
			}

			if(oktosave)
			{
				SqlConnection conn = new SqlConnection();
				SqlCommand cmd =  new SqlCommand();
				SqlDataReader rdr = null;
				lprop= (Camelot.classes.cProperty)Session["curProperty"];
				pUser = (Camelot.classes.cUser)Session["curUser"];
			

				conn.ConnectionString = (string)Session["Connection"];
				conn.Open();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "add_property";

				cmd.Parameters.Add(
					new SqlParameter("@NAME", txtName.Text));
				cmd.Parameters.Add(
					new SqlParameter("@housename", txtAddress1.Text));
				cmd.Parameters.Add(
					new SqlParameter("@key_number", this.txtKey.Text));
				cmd.Parameters.Add(
					new SqlParameter("@streetname", txtAddress2.Text));
				cmd.Parameters.Add(
					new SqlParameter("@address4", txtAddress3.Text));
				cmd.Parameters.Add(
					new SqlParameter("@CITY", txtTown.Text));
				cmd.Parameters.Add(
					new SqlParameter("@COUNTY", txtCounty.Text));
				cmd.Parameters.Add(
					new SqlParameter("@postalcode", txtPost.Text));
				cmd.Parameters.Add(
					new SqlParameter("@country", txtCountry.Text));
				cmd.Parameters.Add(
					new SqlParameter("@area_id", get_areaid(cmbArea.SelectedItem.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@region_manager", get_employeeid(cmbRegMan.SelectedItem.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@MAX_NR_RESIDENTS", txtMaxOcc.Text));
				cmd.Parameters.Add(
					new SqlParameter("@status_id", get_status(cmbStatus.SelectedItem.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@object_type", get_object(cmbPropType.SelectedItem.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@M_FEE", txtMfee.Text));
				cmd.Parameters.Add(
					new SqlParameter("@L_FEE", txtLfee.Text));
				cmd.Parameters.Add(
					new SqlParameter("@STAT_EFF", DateTime.Parse(su.setdate(txtStatEff.Text))));
				cmd.Parameters.Add(
					new SqlParameter("@DATE_STOPPED", DateTime.Parse(su.setdate(txtDtStop.Text))));
				cmd.Parameters.Add(
					new SqlParameter("@DATE_STARTED", DateTime.Parse(su.setdate(txtDtStart.Text))));
				cmd.Parameters.Add(
					new SqlParameter("@account_manager", get_employeeid(cmbAccMan.SelectedItem.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@property_manager", get_employeeid(cmbPropMan.SelectedItem.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@property_inspector", get_employeeid(cmbPropInsp.SelectedItem.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@guardian_manager", get_employeeid(cmbGuardMan.SelectedItem.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@record_modifier", pUser.ID));
				cmd.Parameters.Add(
					new SqlParameter("@COMP_ID", txtCompID.Text));
				cmd.Parameters.Add(
					new SqlParameter("@calam_limit", su.setMoney(this.txtCalam.Text)));
				rdr = cmd.ExecuteReader();

				while(rdr.Read())
				{
					lprop.Property_ID = rdr.GetValue(0).ToString();
					lprop.Property_Name = rdr.GetValue(1).ToString();
					lcomp.Company_ID = txtCompID.Text;
					lcomp.Company_Name = txtSCompany.Text;
					Session["curProperty"] = lprop;
					Session["curCompany"] = lcomp;
				}
				
				rdr.Close();
				cmd.Dispose();
				conn.Close();
				
				Session["prop_edit"] = false;
				Session["prop_save"] = false;
				Session["prop_new"] = false;
				
				Response.Write("<script>parent.location.reload(true);</script>");
				Response.Write("<script>window.close();</script>");
			}
			else
			{
				lblMessage.Text="Status Required or Incorrect Date Format";
				lblMessage.Visible=true;
			}
			
		}

		

		private void cmbPropType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
			Session["prop_save"] = true;
		}

		private void cmbRegMan_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session["prop_save"] = true;
		}
		public int get_areaid(string area)
		{
			int id = 0;
			Areas larea = (Areas)Session["Areas"];
			
			foreach(Area ar in larea)
			{
				if(ar.Description == area)
				{
					id = Convert.ToInt32(ar.Area_ID);
					break;
				}
			}
			return id;
		}

		public int get_employeeid(string emp)
		{
			int id = 0;
			Employees lemps = (Employees)Session["Emps"];
			
			foreach(Employee em in lemps)
			{
				if(em.Emp_Name == emp)
				{
					id = Convert.ToInt32(em.Emp_ID);
					break;
				}
			}
			return id;
		}


		public int get_status(string stat)
		{
			int id = 0;
			Object_stats stats = (Object_stats)Session["Stats"];
			
			foreach(Object_stat st in stats)
			{
				if(st.Description == stat)
				{
					id = Convert.ToInt32(st.Status_ID);
					break;
				}
			}
			return id;
		}
		
		public int get_object(string prop)
		{
			int id = 0;
			O_Types ltypes = (O_Types)Session["OTypes"];
			
			foreach(O_Type tp in ltypes)
			{
				if(tp.Description == prop)
				{
					id = Convert.ToInt32(tp.O_TypeID);
					break;
				}
			}
			return id;
		}

		public void set_prop(Object sender, DataGridCommandEventArgs e)
		{
			lprop= (Camelot.classes.cProperty)Session["curProperty"];
			lprop.Property_ID = e.Item.Cells[2].Text;
			lprop.Property_Name = e.Item.Cells[1].Text;
			lcomp=(Camelot.classes.cCompany)Session["curCompany"];
			lcomp.Company_ID = e.Item.Cells[3].Text;
			Session["curCompany"] = lcomp;
			Session["curProperty"] = lprop;
			Response.Redirect("property.aspx");
		}

		
			

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["prop_edit"] = true;
			Session["prop_save"] = false;
			Session["prop_new"] = true;
			Response.Write("<script>window.showModalDialog('new_property.aspx?fac=','newprop','dialogHeight: 485px; dialogWidth: 800px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
		}

		private void btnCserch_Click(object sender, System.EventArgs e)
		{
			pop_comp(txtCompany.Text);
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

			lbCompanies.DataSource = rdr;
			lbCompanies.DataTextField = "comp_dets";
			lbCompanies.DataValueField = "comp_id";
			lbCompanies.DataBind();
				
			rdr.Close();
			cmd.Dispose();
			conn.Close();
		}
	}
}
