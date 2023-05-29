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
using System.IO;

namespace Camelot
{
	/// <summary>
	/// property page, if no property is in session show search list only
	/// </summary>
	public class property : System.Web.UI.Page
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
		protected System.Web.UI.WebControls.Label lblPercOcc;
		protected System.Web.UI.WebControls.Label lblStatus;
		protected System.Web.UI.WebControls.Label lblStatEff;
		protected System.Web.UI.WebControls.Label lblAccMan;
		protected System.Web.UI.WebControls.Label lblPropMan;
		protected System.Web.UI.WebControls.Label lblPropInsp;
		protected System.Web.UI.WebControls.Label lblUpBy;
		protected System.Web.UI.WebControls.Label lblUpOn;
		protected System.Web.UI.WebControls.Image imgMainPhoto;
		protected System.Web.UI.WebControls.TextBox txtAddress2;
		protected System.Web.UI.WebControls.TextBox txtAddress3;
		protected System.Web.UI.WebControls.TextBox txtAddress4;
		protected System.Web.UI.WebControls.TextBox txtTown;
		protected System.Web.UI.WebControls.TextBox txtPost;
		protected System.Web.UI.WebControls.DropDownList cmbArea;
		protected System.Web.UI.WebControls.DropDownList cmbPropType;
		protected System.Web.UI.WebControls.DropDownList cmbRegMan;
		protected System.Web.UI.WebControls.TextBox txtMaxOcc;
		protected System.Web.UI.WebControls.TextBox txtCurrOcc;
		protected System.Web.UI.WebControls.TextBox txtPercOcc;
		protected System.Web.UI.WebControls.DropDownList cmbPropMan;
		protected System.Web.UI.WebControls.DropDownList cmbPropInsp;
		protected System.Web.UI.WebControls.Label lblUby;
		protected System.Web.UI.WebControls.Label lblUDate;
		protected System.Web.UI.WebControls.DropDownList cmbStatus;
		protected System.Web.UI.WebControls.TextBox txtStatEff;
		protected System.Web.UI.WebControls.Label lblAddress;
		protected System.Web.UI.WebControls.Label lblTown;
		protected System.Web.UI.WebControls.DropDownList cmbAccMan;
		protected System.Web.UI.WebControls.DropDownList cmbGuardMan;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Label lblCurrOcc;
		protected System.Web.UI.WebControls.Label lblDtStart;
		protected System.Web.UI.WebControls.Label lblDtStop;
		protected System.Web.UI.WebControls.Label lblGuardMan;
		protected System.Web.UI.WebControls.DropDownList cmbFind;
		protected System.Web.UI.WebControls.Button BtnGo;
		protected System.Web.UI.WebControls.TextBox txtCounty;
		protected System.Web.UI.WebControls.TextBox txtDtStart;
		protected System.Web.UI.WebControls.TextBox txtDtStop;
		protected System.Web.UI.WebControls.TextBox txtCountry;
		Camelot.classes.cProperty lprop;
		Camelot.classes.cCompany lcomp = new cCompany();
		protected System.Web.UI.WebControls.DataGrid dgProps;
		protected System.Web.UI.HtmlControls.HtmlInputButton Button1;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.Button btnChange;
		Camelot.classes.cUser pUser;
		protected System.Web.UI.WebControls.Image imgMainPhot;
		protected System.Web.UI.WebControls.Label lblStatusStar;
		protected System.Web.UI.WebControls.Label lblStatstar;
		protected System.Web.UI.WebControls.Label lblPropStar;
		protected System.Web.UI.WebControls.Label lblstartstar;
		protected System.Web.UI.WebControls.Label lblstopstar;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnHist;
		protected System.Web.UI.WebControls.TextBox txtMfee;
		protected System.Web.UI.WebControls.TextBox txtLfee;
		protected System.Web.UI.WebControls.Label lblMF;
		protected System.Web.UI.WebControls.Label lblLF;
		protected System.Web.UI.WebControls.Label lblPropID;
		protected System.Web.UI.WebControls.TextBox txtPropID;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtKey;
		protected System.Web.UI.WebControls.TextBox txtCalam;
		protected System.Web.UI.WebControls.Label lblKey;
		protected System.Web.UI.WebControls.Label lblCalam;
		public string defUrl;
		
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			bool oktogo;
			Camelot.classes.Utils pUtil = new Camelot.classes.Utils();
			pUser = (Camelot.classes.cUser)Session["curUser"];
			oktogo = pUtil.valid_user(pUser);
			hideErr();
			Session["ptype"] = "1";
			Session["insp_files"] = null;

			if(!oktogo)
			{
				Response.Redirect("../logon.aspx");
			}
			else
			{
				lprop= (Camelot.classes.cProperty)Session["curProperty"];
				bool edit = (bool)Session["prop_edit"];
				bool vis = false;
				if(lprop.Property_ID==null || lprop.Property_ID.Equals("0"))
				{
					vis = false;
				}
				else
				{
					vis = true;
				}
				setvisible(vis);
				setenabled(edit);
				
				if(vis)
				{
					if(!(bool)Session["prop_save"])
					{
						pop_prop(lprop.Property_ID);
					}
					if(edit)
					{
						btnUpdate.Visible = true;
						btnCancel.Visible = true;
						btnHist.Visible = false;
						btnEdit.Visible = false;
					}
					else
					{
						btnUpdate.Visible = false;
						btnCancel.Visible = false;
						if(pUser.Permission=="1")
						{
							btnEdit.Visible = true;
							btnAdd.Visible = true;
							btnChange.Visible= true;
						}
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
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.btnHist.Click += new System.EventHandler(this.btnHist_Click);
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		
		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			lprop= (Camelot.classes.cProperty)Session["curProperty"];
			lprop.Property_ID = null;
			Session["curProperty"] = lprop;

			bool vis = false;
			setvisible(vis);
			
			if(txtFind.Text!="")
			{
				getProperties();		
			}
		}

		private void getProperties()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			string txt=this.txtFind.Text.Replace("'","''");

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;

			cmd.CommandText = "get_properties";

			cmd.Parameters.Add(
				new SqlParameter("@search", cmbFind.SelectedItem.Value));
			cmd.Parameters.Add(
				new SqlParameter("@crit", txt));

			rdr = cmd.ExecuteReader();
			dgProps.DataSource = rdr;
			dgProps.DataBind();
			dgProps.Visible= true;
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		private void pop_prop(string prop_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			bool edit = (bool)Session["prop_edit"];
			Camelot.classes.saveUtils su = new Camelot.classes.saveUtils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_property";

			cmd.Parameters.Add(
				new SqlParameter("@prop_id", prop_id));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				this.txtPropID.Text= rdr["property_id"].ToString();
				this.txtKey.Text = rdr["key_number"].ToString();
				this.txtCalam.Text = rdr["calam_limit"].ToString();
				txtAddress1.Text = rdr["object_name"].ToString();
				txtAddress2.Text = rdr["housename"].ToString();
				txtAddress3.Text = rdr["streetname"].ToString();
				txtAddress4.Text = rdr["address4"].ToString();
				txtTown.Text = rdr["CITY"].ToString();
				txtPost.Text = rdr["postalcode"].ToString();
				txtCounty.Text = rdr["COUNTY"].ToString();
				pop_area(rdr["area_id"].ToString());
				txtCountry.Text = rdr["country"].ToString();
				pop_proptype(rdr["object_type"].ToString());
				pop_regman(rdr["region_manager"].ToString());
				txtMaxOcc.Text = rdr["max_nr_residents"].ToString();
				txtCurrOcc.Text = rdr["act_nr"].ToString();
				txtPercOcc.Text = rdr["perc_occ"].ToString();
				pop_status(rdr["status_id"].ToString());
				txtStatEff.Text = su.getdate(rdr["stat_eff"].ToString());
				txtDtStop.Text = su.getdate(rdr["DATE_STOPPED"].ToString());
				txtDtStart.Text = su.getdate(rdr["DATE_STARTED"].ToString());
				txtMfee.Text = rdr["monthly_fee"].ToString();
				txtLfee.Text = rdr["lic_fee"].ToString();
				lblUby.Text = get_employeename(Convert.ToInt32(rdr["record_modifier"]));
				DateTime dt = DateTime.Parse(rdr["Date_modified"].ToString());
				lblUDate.Text = dt.ToString("d");
				pop_accman(rdr["account_manager"].ToString());
				pop_propman(rdr["property_manager"].ToString());
				pop_propinsp(rdr["property_inspector"].ToString());
				pop_guardman(rdr["guardian_manager"].ToString());

			}
			pop_pic(lprop.Property_ID);
			rdr.NextResult();
			while(rdr.Read())
			{
				lcomp.Company_ID = rdr["company_id"].ToString();
				lcomp.Company_Name = rdr["company_name"].ToString();
			}

			Session["curCompany"] = lcomp;
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

			cmbAccMan.SelectedIndex = ind;
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

		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			setenabled(true); 
			btnUpdate.Visible = true;
			btnCancel.Visible = true;
			btnEdit.Visible = false;
			btnAdd.Visible=false;
			btnHist.Visible = false;
			btnChange.Visible=false;
			Session["prop_edit"] = true;
			Session["prop_save"] = true;
//			Response.Redirect("property.aspx");
		}

		private void setvisible(bool vis)
		{
			lblAddress.Visible = vis;
			this.lblKey.Visible = vis;
			this.lblCalam.Visible = vis;
			this.txtKey.Visible = vis;
			this.txtCalam.Visible= vis;
			lblTown.Visible = vis;
			lblPost.Visible = vis;
			lblCounty.Visible = vis;
			lblArea.Visible = vis;
			lblCountry.Visible = vis;
			lblProptype.Visible = vis;
			lblRegMan.Visible = vis;
			lblMaxOcc.Visible= vis;
			lblCurrOcc.Visible = vis;
			lblPercOcc.Visible = vis;
			lblStatus.Visible = vis;
			lblStatEff.Visible = vis;
			lblAccMan.Visible = vis;
			lblPropMan.Visible = vis;
			lblPropInsp.Visible = vis;
			lblGuardMan.Visible = vis;
			lblUpBy.Visible = vis;
			lblUpOn.Visible = vis;
			txtAddress1.Visible = vis;
			txtAddress2.Visible = vis;
			txtAddress3.Visible = vis;
			txtAddress4.Visible = vis;
			txtTown.Visible = vis;
			txtPost.Visible = vis;
			txtCounty.Visible = vis;
			cmbArea.Visible = vis;
			txtCountry.Visible = vis;
			cmbPropType.Visible = vis;
			cmbRegMan.Visible = vis;
			txtMaxOcc.Visible = vis;
			txtCurrOcc.Visible = vis;
			txtPercOcc.Visible = vis;
			cmbStatus.Visible = vis;
			txtStatEff.Visible = vis;
			cmbAccMan.Visible = vis;
			cmbPropMan.Visible = vis;
			cmbPropInsp.Visible = vis;
			cmbGuardMan.Visible = vis;
			lblUby.Visible = vis;
			lblUDate.Visible = vis;
			imgMainPhoto.Visible = vis;
			btnUpdate.Visible = vis;
			btnCancel.Visible = vis;
			btnChange.Visible = vis;
			lblDtStart.Visible = vis;
			lblDtStop.Visible = vis;
			txtDtStart.Visible = vis;
			txtDtStop.Visible = vis;
			lblMF.Visible = vis;
			lblLF.Visible = vis;
			btnHist.Visible = vis;
			txtMfee.Visible=vis;
			txtLfee.Visible=vis;
			lblPropID.Visible=vis;
			txtPropID.Visible=vis;
			if(pUser.Permission=="1")
			{
				btnEdit.Visible = vis;
			}else
			{
				btnEdit.Visible = false;
			}
			dgProps.Visible=false;
		}

		private void hideErr()
		{
			lblStatstar.Visible = false;
			lblstartstar.Visible =false;
			lblstopstar.Visible = false;
			lblStatusStar.Visible = false;
			lblPropStar.Visible=false;
		}

		private void setenabled(bool edit)
		{
			this.txtKey.Enabled= edit;
			this.txtCalam.Enabled = edit;
			txtAddress1.Enabled = edit;
			txtAddress2.Enabled = edit;
			txtAddress3.Enabled = edit;
			txtAddress4.Enabled = edit;
			txtTown.Enabled = edit;
			txtPost.Enabled = edit;
			txtCounty.Enabled = edit;
			cmbArea.Enabled = edit;
			txtCountry.Enabled = edit;
			cmbPropType.Enabled = edit;
			cmbRegMan.Enabled = edit;
			txtMaxOcc.Enabled = edit;
			txtCurrOcc.Enabled = edit;
			txtPercOcc.Enabled = edit;
			cmbStatus.Enabled = edit;
			txtStatEff.Enabled = edit;
			cmbAccMan.Enabled = edit;
			cmbPropMan.Enabled = edit;
			cmbPropInsp.Enabled = edit;
			cmbGuardMan.Enabled = edit;
			txtDtStart.Enabled = edit;
			txtDtStop.Enabled = edit;
			txtMfee.Enabled = edit;
			txtLfee.Enabled = edit;
			txtPropID.Enabled = edit;
			
			cmbFind.Enabled = !edit;
			txtFind.Enabled = !edit;
			btnSearch.Enabled = !edit;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Session["prop_edit"] = false;
			Session["prop_save"] = false;
			Response.Redirect("property.aspx");
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			saveproperty();
		}

		private void saveproperty()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			bool oktosave=true;
			lprop= (Camelot.classes.cProperty)Session["curProperty"];
			pUser = (Camelot.classes.cUser)Session["curUser"];
			Camelot.classes.saveUtils su = new Camelot.classes.saveUtils();


			if(txtAddress1.Text=="")
			{
				oktosave=false;
				lblPropStar.Visible=true;
			}
			if(cmbStatus.SelectedIndex==0)
			{
				oktosave=false;
				lblStatusStar.Visible=true;
			}

			if(!su.IsDate(su.setdate(txtStatEff.Text)) || this.txtStatEff.Text == "")
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
				conn.ConnectionString = (string)Session["Connection"];
				conn.Open();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "update_property";

				cmd.Parameters.Add(
					new SqlParameter("@prop_id", lprop.Property_ID));
				cmd.Parameters.Add(
					new SqlParameter("@property_id", txtPropID.Text));
				cmd.Parameters.Add(
					new SqlParameter("@key_number", this.txtKey.Text));
				cmd.Parameters.Add(
					new SqlParameter("@OBJECT_NAME", su.ToTitle(txtAddress1.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@housename", su.ToTitle(txtAddress2.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@streetname", su.ToTitle(txtAddress3.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@address4", su.ToTitle(txtAddress4.Text)));
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
					new SqlParameter("@region_manager", get_employeeid(cmbRegMan.SelectedItem.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@MAX_NR_RESIDENTS", txtMaxOcc.Text));
				cmd.Parameters.Add(
					new SqlParameter("@status_id", get_status(cmbStatus.SelectedItem.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@object_type", get_object(cmbPropType.SelectedItem.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@M_FEE", su.setMoney(txtMfee.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@L_FEE", su.setMoney(txtLfee.Text)));
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
					new SqlParameter("@calam_limit", su.setMoney(this.txtCalam.Text)));
				cmd.ExecuteNonQuery();
				cmd.Dispose();
				conn.Close();
				conn.Dispose();

				lprop.Property_Name = txtAddress1.Text;
				Session["currProperty"] = lprop;
				Session["prop_edit"] = false;
				Session["prop_save"] = false;
				Response.Redirect("property.aspx");
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
			lcomp.Company_Name = e.Item.Cells[5].Text;
			Session["curCompany"] = lcomp;
			Session["curProperty"] = lprop;
			Response.Redirect("property.aspx");
		}

		private void dgProps_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
			

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["prop_edit"] = true;
			Session["prop_save"] = false;
			Session["prop_new"] = true;
			Response.Write("<script>window.showModalDialog('new_property.aspx?fac=','newprop','dialogHeight: 600px; dialogWidth: 900px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
			Response.Write("<script>self.document.location.href = 'property.aspx';</script>");

		}

		private void btnChange_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.showModalDialog('changeowner.aspx?fac=','newprop','dialogHeight: 400px; dialogWidth: 800px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
		}

		private void pop_pic(string prop)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_def_photos";

			cmd.Parameters.Add(
				new SqlParameter("@P_ID", lprop.Property_ID));
			cmd.Parameters.Add(
				new SqlParameter("@type", 1));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				byte[] img= new byte[0];
				img =  (byte[])rdr["photo"];
				string file = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + rdr["fileName"].ToString();

				FileStream fs = new FileStream(Server.MapPath("\\camelot_crm\\photos\\" + file), System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write, System.IO.FileShare.ReadWrite);
				fs.Write(img,0,(int)rdr["filesize"]);
				fs.Close();
				
				defUrl= "\\camelot_crm\\photos\\" + file;
			}
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			if(defUrl==null)
			{
				defUrl= "\\camelot_crm\\images\\cam_logo.gif";
			}
			imgMainPhoto.ImageUrl = defUrl;
		}

		private void btnHist_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.showModalDialog('property_stat_hist.aspx','prophist','dialogHeight: 350px; dialogWidth: 450px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
			Response.Write("<script>self.document.location.href = 'property.aspx';</script>");
		}
		
	}
}
