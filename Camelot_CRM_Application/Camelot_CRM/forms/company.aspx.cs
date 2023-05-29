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
	public class company : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtFind;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.TextBox txtAddress1;
		protected System.Web.UI.WebControls.Label lblPost;
		protected System.Web.UI.WebControls.Label lblArea;
		protected System.Web.UI.WebControls.Label lblCounty;
		protected System.Web.UI.WebControls.Label lblCountry;
		protected System.Web.UI.WebControls.Label lblAccMan;
		protected System.Web.UI.WebControls.Label lblUpBy;
		protected System.Web.UI.WebControls.Label lblUpOn;
		protected System.Web.UI.WebControls.TextBox txtAddress2;
		protected System.Web.UI.WebControls.TextBox txtAddress3;
		protected System.Web.UI.WebControls.TextBox txtAddress4;
		protected System.Web.UI.WebControls.TextBox txtTown;
		protected System.Web.UI.WebControls.TextBox txtPost;
		protected System.Web.UI.WebControls.DropDownList cmbArea;
		protected System.Web.UI.WebControls.Label lblUby;
		protected System.Web.UI.WebControls.Label lblUDate;
		protected System.Web.UI.WebControls.Label lblAddress;
		protected System.Web.UI.WebControls.Label lblTown;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblNamestar;
		protected System.Web.UI.WebControls.DropDownList cmbAccMan;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnAddProp;
		protected System.Web.UI.WebControls.Button btnAddComp;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.DropDownList cmbFind;
		protected System.Web.UI.WebControls.Button BtnGo;
		protected System.Web.UI.WebControls.TextBox txtCounty;
		protected System.Web.UI.WebControls.TextBox txtCountry;
		Camelot.classes.cProperty lprop;
		Camelot.classes.cCompany lcomp = new cCompany();
		protected System.Web.UI.WebControls.DataGrid dgProps;
		protected System.Web.UI.WebControls.DataGrid dgComps;
		protected System.Web.UI.WebControls.DropDownList cmbCompType;
		protected System.Web.UI.WebControls.DropDownList cmbSalesMan;
		protected System.Web.UI.WebControls.TextBox txtTel;
		protected System.Web.UI.WebControls.TextBox txtFax;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.TextBox txtWeb;
		protected System.Web.UI.WebControls.TextBox txtCompName;
		protected System.Web.UI.WebControls.Label lblStatus;
		protected System.Web.UI.WebControls.DropDownList cmbStatus;
		protected System.Web.UI.WebControls.Label lblStatEff;
		protected System.Web.UI.WebControls.Label lblCompName;
		protected System.Web.UI.WebControls.TextBox txtStatEff;
		protected System.Web.UI.WebControls.Label lblComptype;
		protected System.Web.UI.WebControls.Label lblTel;
		protected System.Web.UI.WebControls.Label lblFax;
		protected System.Web.UI.WebControls.Label lblEmail;
		protected System.Web.UI.WebControls.Label lblWeb;
		protected System.Web.UI.WebControls.Label lblSalesMan;
		protected System.Web.UI.WebControls.Button btnBank;
		protected System.Web.UI.WebControls.Label lblDateStar;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnDel;
		Camelot.classes.cUser pUser;
		protected System.Web.UI.WebControls.Button btnVisit;
		ArrayList props = new ArrayList();
		
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			bool oktogo;
			Camelot.classes.Utils pUtil = new Camelot.classes.Utils();
			pUser = (Camelot.classes.cUser)Session["curUser"];
			oktogo = pUtil.valid_user(pUser);
			Session["insp_files"] = null;

			if(!oktogo)
			{
				Response.Redirect("../logon.aspx");
			}
			else
			{
				lcomp= (Camelot.classes.cCompany)Session["curCompany"];
				bool edit = (bool)Session["comp_edit"];
				bool vis = false;
				if(lcomp.Company_ID==null || lcomp.Company_ID.Equals("0"))
				{
					vis = false;
				}
				else
				{
					vis = true;
				}
				hideError();
				setvisible(vis);
				setenabled(edit);
				
				if(vis)
				{
					if(!(bool)Session["comp_save"])
					{
						pop_comp(lcomp.Company_ID);
						pop_props(lcomp.Company_ID);
					}
					if(edit)
					{
						btnUpdate.Visible = true;
						btnCancel.Visible = true;
						btnEdit.Visible = false;
						btnAddComp.Visible = false;
						btnAddProp.Visible=false;
					}
					else
					{
						btnUpdate.Visible = false;
						btnCancel.Visible = false;
						if(pUser.Permission=="1")
						{
							btnEdit.Visible = true;
							btnAddComp.Visible = true;
							btnAddProp.Visible=true;
						}
					}
				}
			}
			if(pUser.AccMan!="True")
			{
				this.dgComps.Columns[5].Visible=false;
			}
			if(!Page.IsPostBack)
			{
				if((string)Session["cCrit"]!= null)
				{
					int ind = 0;
					int cnt = 0;
					foreach(ListItem li in this.cmbFind.Items)
					{
						if(li.Value == (string)Session["cCrit"])
						{
							ind = cnt;
						}
						cnt++;
					}
					this.cmbFind.SelectedIndex = ind;
				}
				if((string)Session["cFind"]!= null)
				{
					this.txtFind.Text = Session["cFind"].ToString();
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
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.btnAddComp.Click += new System.EventHandler(this.btnAddComp_Click);
			this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
			this.btnVisit.Click += new System.EventHandler(this.btnVisit_Click);
			this.btnBank.Click += new System.EventHandler(this.btnBank_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.btnAddProp.Click += new System.EventHandler(this.btnAddProp_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		
		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			lcomp= (Camelot.classes.cCompany)Session["curCompany"];
			lcomp.Company_ID = null;
			Session["curCompany"] = lcomp;

			bool vis = false;
			setvisible(vis);
			
			if(txtFind.Text!="")
			{
				getCompanies();		
			}
		}
		
		private void btnBank_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.showModalDialog('bankdetails.aspx?src=comp','bank','dialogHeight: 400px; dialogWidth: 650px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
		}

		private void getCompanies()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			string txt = this.txtFind.Text.Replace("'","''");
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_companies";

			cmd.Parameters.Add(
				new SqlParameter("@search", cmbFind.SelectedItem.Value));
			cmd.Parameters.Add(
				new SqlParameter("@crit", txt));

			dgComps.DataSource = cmd.ExecuteReader();
			dgComps.DataBind();
			setvisible(false);
			dgComps.Visible= true;
			dgProps.Visible=false;
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			Session["cCrit"] = this.cmbFind.SelectedItem.Value;
			Session["cFind"] = txt;
		}

		
		private void delete_comp(string comp)
		{
			int oktodel = 0;
			oktodel = check_comp(comp);
			if(oktodel==0)
			{
				SqlConnection conn = new SqlConnection();
				SqlCommand cmd =  new SqlCommand();
			
				conn.ConnectionString = (string)Session["connection"];;
				conn.Open();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "del_comp";

				cmd.Parameters.Add(
					new SqlParameter("@comp", comp));

				cmd.ExecuteNonQuery();

				this.getCompanies();
			}
			else
			{
				if(oktodel==2)
				{
					string mes = "This contact is assigned to propertie(s) :\\n";
					foreach(string prop in this.props)
					{
						mes = mes + prop + "\\n";
					}
					Response.Write("<script>alert('" + mes + "');</script>");
				}
				else
				{
					Response.Write("<script>alert('Please remove all contacts before deleteing a company');</script>");
				}
			}
		}


		private int check_comp(string comp)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			int ok = 0;

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "check_comp_cont";

			cmd.Parameters.Add(
				new SqlParameter("@comp", comp));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				if(Convert.ToInt32(rdr["cnt"].ToString()) > 0)
				{
					ok = 1;
				}
			}

			rdr.NextResult();
			while(rdr.Read())
			{
				if(Convert.ToInt32(rdr["cnt"].ToString()) > 0)
				{
					rdr.NextResult();
					while(rdr.Read())
					{
						props.Add(rdr["object_name"].ToString());
					}
					ok = 2;
				}
			}
			return ok;
		}


		private void pop_props(string comp_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_company_properties";

			cmd.Parameters.Add(
				new SqlParameter("@comp_id", comp_id));

			dgProps.DataSource = cmd.ExecuteReader();
			dgProps.DataBind();
			dgProps.Visible= true;
		
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		private void pop_comp(string comp_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			bool edit = (bool)Session["prop_edit"];
			Camelot.classes.Utils us = new Camelot.classes.Utils();
			Camelot.classes.saveUtils su = new saveUtils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_company";

			cmd.Parameters.Add(
				new SqlParameter("@comp_id", comp_id));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				txtCompName.Text = rdr["company_name"].ToString();
				txtAddress1.Text = rdr["housename"].ToString();
				txtAddress2.Text = rdr["streetname"].ToString();
				txtAddress3.Text = rdr["address4"].ToString();
				txtAddress4.Text = rdr["address5"].ToString();
				txtTown.Text = rdr["CITY"].ToString();
				txtPost.Text = rdr["postalcode"].ToString();
				txtCounty.Text = rdr["COUNTY"].ToString();
				pop_area(rdr["area_id"].ToString());
				txtCountry.Text = rdr["country"].ToString();
				txtTel.Text = rdr["general_phone"].ToString();
				txtFax.Text = rdr["general_fax"].ToString();
				txtEmail.Text = rdr["general_email"].ToString();
				txtWeb.Text = rdr["general_website"].ToString();
				pop_comptype(rdr["company_type"].ToString());
				pop_status(rdr["status_id"].ToString());
				txtStatEff.Text = su.getdate(rdr["status_effective"].ToString());
				lblUby.Text = get_employeename(Convert.ToInt32(rdr["record_modifier"]));
				DateTime dt = DateTime.Parse(rdr["Date_modified"].ToString());
				lblUDate.Text = dt.ToString("d");
				pop_accman(rdr["account_manager"].ToString());
				pop_salesman(rdr["sales_manager"].ToString());

			}
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

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

		private void pop_comptype(string typeid)
		{
			C_Types ltypes = (C_Types)Session["CTypes"];
			int ind =0;
			cmbCompType.Items.Clear();
			cmbCompType.Items.Add("");
			foreach(C_Type ct in ltypes)
			{
				cmbCompType.Items.Add(ct.Description);
				if(ct.C_TypeID == typeid)
				{
					ind = cmbCompType.Items.Count-1;
				}
			}
			cmbCompType.SelectedIndex = ind;
		}

		
		private void pop_accman(string regid)
		{
			Employees lemps = (Employees)Session["Emps"];
			int ind =0;
			cmbAccMan.Items.Clear();
			cmbAccMan.Items.Add("");
			foreach(Employee e in lemps)
			{
				cmbAccMan.Items.Add(e.Emp_Name);
				if(e.Emp_ID == regid)
				{
					ind = cmbAccMan.Items.Count-1;
				}
			}
			cmbAccMan.SelectedIndex = ind;
		}

		private void pop_salesman(string regid)
		{
			Employees lemps = (Employees)Session["Emps"];
			int ind =0;
			cmbSalesMan.Items.Clear();
			cmbSalesMan.Items.Add("");
			foreach(Employee e in lemps)
			{
				cmbSalesMan.Items.Add(e.Emp_Name);
				if(e.Emp_ID == regid)
				{
					ind = cmbSalesMan.Items.Count-1;
				}
			}
			cmbSalesMan.SelectedIndex = ind;
		}

				

		private void pop_status(string statid)
		{
			Comp_stats lstats = (Comp_stats)Session["Cstats"];
			int ind =0;
			cmbStatus.Items.Clear();
			cmbStatus.Items.Add("");
			foreach(Comp_stat o in lstats)
			{
				cmbStatus.Items.Add(o.Description);
				if(o.Status_ID == statid)
				{
					ind = cmbStatus.Items.Count-1;
				}
			}
			cmbStatus.SelectedIndex = ind;
		}

		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			setenabled(true);
			btnUpdate.Visible = true;
			this.btnDel.Visible=false;
			this.btnBank.Visible=false;
			btnCancel.Visible = true;
			btnEdit.Visible = false;
			btnAddComp.Visible=false;
			btnAddProp.Visible=false;
			this.btnVisit.Visible=false;
			dgProps.Visible = false;
			Session["comp_edit"] = true;
			Session["comp_save"] = true;
			//			Response.Redirect("property.aspx");
		}

		private void setvisible(bool vis)
		{
			lblCompName.Visible = vis;
			lblAddress.Visible = vis;
			lblTown.Visible = vis;
			lblPost.Visible = vis;
			lblCounty.Visible = vis;
			lblArea.Visible = vis;
			lblCountry.Visible = vis;
			lblComptype.Visible = vis;
			lblStatus.Visible = vis;
			lblStatEff.Visible = vis;
			lblAccMan.Visible = vis;
			lblSalesMan.Visible = vis;
			lblUpBy.Visible = vis;
			lblUpOn.Visible = vis;
			lblTel.Visible=vis;
			lblFax.Visible=vis;
			lblEmail.Visible=vis;
			lblWeb.Visible=vis;
			txtTel.Visible=vis;
			txtFax.Visible=vis;
			txtEmail.Visible=vis;
			txtWeb.Visible=vis;
			txtAddress1.Visible = vis;
			txtAddress2.Visible = vis;
			txtAddress3.Visible = vis;
			txtAddress4.Visible = vis;
			txtTown.Visible = vis;
			txtPost.Visible = vis;
			txtCounty.Visible = vis;
			cmbArea.Visible = vis;
			txtCountry.Visible = vis;
			cmbCompType.Visible = vis;
			cmbStatus.Visible = vis;
			txtStatEff.Visible = vis;
			txtCompName.Visible = vis;
			cmbAccMan.Visible = vis;
			cmbSalesMan.Visible = vis;
			lblUby.Visible = vis;
			lblUDate.Visible = vis;
			btnUpdate.Visible = vis;
			btnCancel.Visible = vis;
			this.btnVisit.Visible=vis;
			btnAddProp.Visible=vis;
			this.btnBank.Visible=vis;
			if(pUser.Permission=="1")
			{
				btnEdit.Visible = vis;
			}
			else
			{
				btnEdit.Visible = false;
			}
			if(pUser.AccMan=="True")
			{
				this.btnDel.Visible=vis;
			}
			else
			{
				this.btnDel.Visible=false;
			}

			dgComps.Visible=false;
		}

		private void setenabled(bool edit)
		{
			txtCompName.Enabled = edit;
			txtAddress1.Enabled = edit;
			txtAddress2.Enabled = edit;
			txtAddress3.Enabled = edit;
			txtAddress4.Enabled = edit;
			txtTown.Enabled = edit;
			txtPost.Enabled = edit;
			txtCounty.Enabled = edit;
			cmbArea.Enabled = edit;
			txtCountry.Enabled = edit;
			cmbCompType.Enabled = edit;
			cmbStatus.Enabled = edit;
			txtStatEff.Enabled = edit;
			cmbAccMan.Enabled = edit;
			cmbSalesMan.Enabled = edit;
			txtTel.Enabled = edit;
			txtFax.Enabled = edit;
			txtEmail.Enabled = edit;
			txtWeb.Enabled = edit;
			
			cmbFind.Enabled = !edit;
			txtFind.Enabled = !edit;
			btnSearch.Enabled = !edit;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Session["comp_edit"] = false;
			Session["comp_save"] = false;
			Response.Redirect("company.aspx");
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			savecompany();
			Session["comp_edit"] = false;
			Session["comp_save"] = false;
			Response.Redirect("company.aspx");
		}

		private void savecompany()
		{
			Camelot.classes.saveUtils su = new saveUtils();
			bool oktosave = true;
			
			
			if(txtCompName.Text=="")
			{
				oktosave = false;
				lblNamestar.Visible = true;;
			}
			if(!su.IsDate(su.setdate(txtStatEff.Text)))
			{
				oktosave=false;
				lblDateStar.Visible = true;
			}
		
			if(oktosave)
			{
				SqlConnection conn = new SqlConnection();
				SqlCommand cmd =  new SqlCommand();
				lcomp= (Camelot.classes.cCompany)Session["curCompany"];
				pUser = (Camelot.classes.cUser)Session["curUser"];

				conn.ConnectionString = (string)Session["Connection"];
				conn.Open();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "update_company";

				cmd.Parameters.Add(
					new SqlParameter("@comp_id", lcomp.Company_ID));
				cmd.Parameters.Add(
					new SqlParameter("@compname", su.ToTitle(txtCompName.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@housename", su.ToTitle(txtAddress1.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@streetname", su.ToTitle(txtAddress2.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@address4", su.ToTitle(txtAddress3.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@address5", su.ToTitle(txtAddress4.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@CITY", su.ToTitle(txtTown.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@COUNTY", su.ToTitle(txtCounty.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@postalcode", su.ToUpper(txtPost.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@country", su.ToTitle(txtCountry.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@area_id", get_areaid(cmbArea.SelectedItem.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@status_id", get_status(cmbStatus.SelectedItem.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@company_type", get_comp_type(cmbCompType.SelectedItem.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@STAT_EFF", su.setdate(txtStatEff.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@TEL", txtTel.Text));
				cmd.Parameters.Add(
					new SqlParameter("@fax", txtFax.Text));
				cmd.Parameters.Add(
					new SqlParameter("@email", txtEmail.Text));
				cmd.Parameters.Add(
					new SqlParameter("@web", txtWeb.Text));
				cmd.Parameters.Add(
					new SqlParameter("@account_manager", get_employeeid(cmbAccMan.SelectedItem.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@sales_manager", get_employeeid(cmbSalesMan.SelectedItem.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@record_modifier", pUser.ID));
				cmd.ExecuteNonQuery();
				
				cmd.Dispose();
				conn.Close();
				conn.Dispose();
				}
				else
				{
					lblMessage.Text="Company Name required or Incorrect Date Format";
					lblMessage.Visible=true;
				}
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
			Comp_stats stats = (Comp_stats)Session["Cstats"];
			
			foreach(Comp_stat st in stats)
			{
				if(st.Description == stat)
				{
					id = Convert.ToInt32(st.Status_ID);
					break;
				}
			}
			return id;
		}
		
		public int get_comp_type(string comp)
		{
			int id = 0;
			C_Types ltypes = (C_Types)Session["CTypes"];
			
			foreach(C_Type tp in ltypes)
			{
				if(tp.Description == comp)
				{
					id = Convert.ToInt32(tp.C_TypeID);
					break;
				}
			}
			return id;
		}

		public void set_comp(Object sender, DataGridCommandEventArgs e)
		{
			if(e.CommandName=="Delete")
			{
				delete_comp(e.Item.Cells[1].Text);
				this.getCompanies();
			}
			else
			{
				lcomp=(Camelot.classes.cCompany)Session["curCompany"];
				lcomp.Company_ID = e.Item.Cells[1].Text;
				lcomp.Company_Name = e.Item.Cells[2].Text;
				Session["curCompany"] = lcomp;
				Response.Redirect("company.aspx");
			}
		}

	
		public void set_prop(Object sender, DataGridCommandEventArgs e)
		{
			lprop= (Camelot.classes.cProperty)Session["curProperty"];
			lprop.Property_ID = e.Item.Cells[2].Text;
			lprop.Property_Name = e.Item.Cells[1].Text;
			
			Session["curProperty"] = lprop;
			Response.Redirect("property.aspx");
		}

		private void btnAddProp_Click(object sender, System.EventArgs e)
		{
			Session["prop_edit"] = true;
			Session["prop_save"] = false;
			Session["prop_new"] = true;
			Response.Write("<script>window.showModalDialog('new_property.aspx?fac=','newprop','dialogHeight: 600px; dialogWidth: 900px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
		}

		private void btnAddComp_Click(object sender, System.EventArgs e)
		{
			Session["comp_edit"] = true;
			Session["comp_save"] = false;
			Session["comp_new"] = true;
			Response.Write("<script>window.showModalDialog('new_company.aspx?fac=','newprop','dialogHeight: 500px; dialogWidth:800px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
			Response.Write("<script>self.document.location.href = 'company.aspx';</script>");
		}

		private void hideError()
		{
			lblNamestar.Visible = false;
			lblMessage.Visible = false;
			lblDateStar.Visible = false;
		}

		private void btnDel_Click(object sender, System.EventArgs e)
		{
			delete_comp(lcomp.Company_ID);
		}

		private void btnVisit_Click(object sender, System.EventArgs e)
		{
			Session["visitaddr"] = "view";
			Response.Write("<script>window.showModalDialog('companyaddress.aspx','addr','dialogHeight: 550px; dialogWidth: 650px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
		}
	}
}
