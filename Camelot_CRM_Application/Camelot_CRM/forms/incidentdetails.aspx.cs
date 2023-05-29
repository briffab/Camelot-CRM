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
	/// Summary description for incidentdetails.
	/// </summary>
	public class incidentdetails : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblfactype;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label lblUpBy;
		protected System.Web.UI.WebControls.Label lblUby;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button btnClose;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.DataGrid dgAction;
		protected System.Web.UI.WebControls.DropDownList cmbinctype;
		protected System.Web.UI.WebControls.DropDownList cmbincsource;
		protected System.Web.UI.WebControls.DropDownList cmbUrg;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.TextBox txtPhone;
		protected System.Web.UI.WebControls.TextBox txtDesc;
		protected System.Web.UI.WebControls.Label Label25;
		protected System.Web.UI.WebControls.Label Label26;
		protected System.Web.UI.WebControls.TextBox txtPRes;
		protected System.Web.UI.WebControls.Button btnCancel;
		Camelot.classes.Utils Utils = new Camelot.classes.Utils();
		Camelot.classes.cIncident linc;
		Camelot.classes.cAction lact = new cAction();
		string lprop;
		string lcomp;
		protected System.Web.UI.WebControls.TextBox txtWkPhone;
		protected System.Web.UI.WebControls.TextBox txtMobile;
		protected System.Web.UI.WebControls.Label lblResDate;
		protected System.Web.UI.WebControls.Label lblIncDate;
		protected System.Web.UI.WebControls.Button btnAction;
		protected System.Web.UI.WebControls.TextBox txtName;
		protected System.Web.UI.WebControls.DropDownList cmbName;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.DropDownList cmbProp;
		protected System.Web.UI.WebControls.Label lblUrgStar;
		protected System.Web.UI.WebControls.Label lblPropStar;
		protected System.Web.UI.WebControls.Label lblIncStar;
		protected System.Web.UI.WebControls.Label lblSrcStar;
		protected System.Web.UI.WebControls.Label lblNameStar;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.CheckBox chkWeb;
		Camelot.classes.cUser pUser;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			bool oktogo;
			Camelot.classes.Utils pUtil = new Camelot.classes.Utils();
			pUser = (Camelot.classes.cUser)Session["curUser"];
			oktogo = pUtil.valid_user(pUser);

			if(Page.IsPostBack)
			{
				if(lprop == null)
				{
					lprop = this.cmbProp.SelectedValue;
					lcomp = get_company(lprop);
				}
			}
			else
			{
				hideErr();
			}

			if(!oktogo)
			{
				Response.Redirect("../logon.aspx");
			}
			else
			{
				lact.Action_ID = "";
				Session["act"] = lact;
				linc=(Camelot.classes.cIncident)Session["curIncident"];
				string err=Request.QueryString["err"];
			
				if(linc.Incident_ID==null || linc.Incident_ID=="")
				{
					string inc = Request.QueryString["inc"];
					linc.Incident_ID = inc;
				}
			
				Response.Expires = 0;
				Response.Cache.SetNoStore();
				Response.AppendHeader("Pragma", "no-cache");
			
			
				bool edit = (bool)Session["inc_edit"];
				bool inew = (bool)Session["inc_new"];
									
				setenabled(edit);
				if(inew)
				{
					if(!(bool)Session["inc_save"])
					{
						lprop = Request.QueryString["prop"];
						lcomp = Request.QueryString["comp"];
						pop_combos();
						btnUpdate.Visible = true;
						btnCancel.Visible = true;
						btnEdit.Visible = false;
						btnClose.Visible=false;
						linc.Incident_ID = "";
						Session["inc_save"] = true;
						this.lblIncDate.Text = Convert.ToString(DateTime.Now);
						this.cmbName.Visible = false;
						this.btnAction.Visible = false;
						this.cmbProp.SelectedValue = lprop;
					}
				}
				else
				{
					if(edit)
					{
						if(!(bool)Session["inc_save"] && (linc.Incident_ID!=null && linc.Incident_ID!=""))
						{
							pop_inc(linc.Incident_ID);
						}
				
						btnUpdate.Visible = true;
						btnCancel.Visible = true;
						btnEdit.Visible = false;
						btnClose.Visible=false;
					}
					else
					{
						if(!(bool)Session["inc_save"] && (linc.Incident_ID!=null && linc.Incident_ID!=""))
						{
							pop_inc(linc.Incident_ID);
						}
						btnUpdate.Visible = false;
						btnCancel.Visible = false;
						if(pUser.Permission=="1")
						{
							btnEdit.Visible = true;
						}
						else
						{
							btnEdit.Visible=false;
						}
						btnClose.Visible=true;
					}
				}
				Session["curIncident"] = linc;
				
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
			this.cmbName.SelectedIndexChanged += new System.EventHandler(this.cmbName_SelectedIndexChanged);
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.cmbUrg.SelectedIndexChanged += new System.EventHandler(this.cmbUrg_SelectedIndexChanged);
			this.cmbProp.SelectedIndexChanged += new System.EventHandler(this.cmbProp_SelectedIndexChanged);
			this.cmbinctype.SelectedIndexChanged += new System.EventHandler(this.cmbinctype_SelectedIndexChanged);
			this.cmbincsource.SelectedIndexChanged += new System.EventHandler(this.cmbincsource_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Session["inc_edit"] = false;
			Session["inc_save"] = false;
			Session["inc_new"] = false;
			Response.Write("<script>window.close();</script>");
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			bool inew = (bool)Session["inc_new"];
			Session["inc_edit"] = false;
			Session["inc_save"] = false;
			Session["inc_new"] = false;
			if(inew)
			{
				Response.Write("<script>window.close();</script>");
			}
			else
			{
				Response.Redirect("incidentdetails.aspx");
			}
		}

		private void setenabled(bool edit)
		{
			this.cmbUrg.Enabled=edit;
			this.cmbinctype.Enabled=edit;
			this.cmbincsource.Enabled=edit;
			this.cmbProp.Enabled=edit;
			this.txtName.Enabled=edit;
			this.cmbName.Enabled=edit;
			this.txtEmail.Enabled=edit;
			this.txtPhone.Enabled=edit;
			this.txtMobile.Enabled=edit;
			this.txtWkPhone.Enabled=edit;
			this.txtDesc.Enabled=edit;
			this.txtPRes.Enabled=edit;
			this.chkWeb.Enabled=edit;
		}

		private void pop_combos()
		{
			pop_types("");
			pop_source("","","");
			pop_urgs("");
			popprops(lprop);
		}

		private void getIncActions(string inc_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_Incident_actions";

			cmd.Parameters.Add(
				new SqlParameter("@inc_id", inc_id));
			
			dgAction.DataSource = cmd.ExecuteReader();
			dgAction.DataBind();
			dgAction.Visible= true;
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		private void pop_types(string typ)
		{
			
			Incident_Types inct = (Incident_Types)Session["Itypes"];
			int ind =0;
			this.cmbinctype.Items.Clear();
			this.cmbinctype.Items.Add("");
			foreach(cInc_type it in inct)
			{
				this.cmbinctype.Items.Add(it.Incident_Type);
				if(it.Inc_ID == typ)
				{
					ind = this.cmbinctype.Items.Count-1;
				}
			}
			this.cmbinctype.SelectedIndex = ind;
			
		}

		private void pop_source(string src, string name, string name_id)
		{
			
			cInc_Srcs incs = (cInc_Srcs)Session["Isrcs"];
			int ind =0;
			int src_type = 0;
			this.cmbincsource.Items.Clear();
			this.cmbincsource.Items.Add("");
			foreach(cInc_src isrc in incs)
			{
				this.cmbincsource.Items.Add(isrc.Incident_Source);
				if(isrc.Src_ID == src)
				{
					ind = this.cmbincsource.Items.Count-1;
					src_type = Convert.ToInt32(isrc.Source_Type);
				}
			}
			this.cmbincsource.SelectedIndex = ind;

			if(src_type!=0)
			{
				if(src_type==4)
				{
					this.cmbName.Items.Clear();
					this.cmbName.Visible=false;
					this.txtName.Visible=true;
					this.txtName.Text = name;
				}
				else
				{
					pop_names(src_type, name_id);
					this.txtName.Text="";
					this.txtName.Visible=false;
					this.cmbName.Visible=true;
				}
			}
		}

		private void pop_names(int src, string name_id)
		{
			
			switch(src)
			{
				case 1:
					popconts(lcomp, name_id);
					break;
				case 2:
					pop_staff(name_id);
					break;
				case 3:
					if(lprop=="0")
					{
						pop_staff(name_id);
					}
					else
					{
						popguards(lprop, name_id);
					}
					break;
			}			
		}

		private void popconts(string comp, string name_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.Utils us = new Camelot.classes.Utils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_company_contacts_complaints";

			cmd.Parameters.Add(
				new SqlParameter("@comp_id", comp));
			rdr = cmd.ExecuteReader();
			
			cmbName.Items.Clear();
			cmbName.DataSource = rdr;
			cmbName.DataTextField = "CNAME";
			cmbName.DataValueField = "CONTACT_ID";
			cmbName.DataBind();
				
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

			if(name_id!="0")
			{
				cmbName.SelectedValue = name_id;
			}
			else
			{
				if(this.cmbName.Items.Count > 0)
				{
					this.cmbName.SelectedIndex = 0;
					popcontact(Convert.ToInt32(this.cmbName.SelectedValue));
				}
			}
		}

		private void popguards(string prop, string name_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.Utils us = new Camelot.classes.Utils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_property_guardians_complaints";

			cmd.Parameters.Add(
				new SqlParameter("@prop_id", prop));

			cmd.Parameters.Add(
				new SqlParameter("@name_id", name_id));

			rdr = cmd.ExecuteReader();
			
		
			cmbName.Items.Clear();
			cmbName.DataSource = rdr;
			cmbName.DataTextField = "GNAME";
			cmbName.DataValueField = "resident_ID";
			cmbName.DataBind();
				
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

			if(name_id!="0" && name_id != "")
			{
				cmbName.SelectedValue = name_id;
			}
			else
			{
				if(this.cmbName.Items.Count > 0)
				{
					this.cmbName.SelectedIndex = 0;
					popguard(Convert.ToInt32(this.cmbName.SelectedValue));
				}

			}
		}

		private void popprops(string prop)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.Utils us = new Camelot.classes.Utils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_all_properties";

			rdr = cmd.ExecuteReader();
			
		
			this.cmbProp.Items.Clear();
			this.cmbProp.DataSource = rdr;
			this.cmbProp.DataTextField = "object_name";
			this.cmbProp.DataValueField = "object_ID";
			this.cmbProp.DataBind();
				
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

			this.cmbProp.SelectedValue = prop;


		}
		

		private void pop_urgs(string urg)
		{
			
			cInc_urgs urgs = (cInc_urgs)Session["IUrgs"];
			int ind =0;
			this.cmbUrg.Items.Clear();
			this.cmbUrg.Items.Add("");
			foreach(cInc_urg iurg in urgs)
			{
				this.cmbUrg.Items.Add(iurg.Incident_Urgency);
				if(iurg.Urg_ID == urg)
				{
					ind = this.cmbUrg.Items.Count-1;
				}
			}
			this.cmbUrg.SelectedIndex = ind;
		}

		private void pop_staff(string emp_id)
		{
			Employees lemps = (Employees)Session["Emps"];
			int ind =0;
			cmbName.Items.Clear();
			cmbName.Items.Add("");
			foreach(Employee e in lemps)
			{
				cmbName.Items.Add(e.Emp_Name);
				if(e.Emp_ID == emp_id)
				{
					ind = cmbName.Items.Count-1;
				}
			}
			cmbName.SelectedIndex = ind;
		}


		private void pop_inc(string inc_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.saveUtils us = new Camelot.classes.saveUtils();
			string inctype = "";
			string incurg = "";
			string incsrc = "";
			string name= "";
			string name_id = "";
			
			
			
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_incident";

			cmd.Parameters.Add(
				new SqlParameter("@inc_id", inc_id));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				inctype = rdr["complaint_type"].ToString();
				this.lblIncDate.Text = rdr["complaint_date"].ToString();
				this.lblResDate.Text= rdr["resolution_date"].ToString();
				incsrc = rdr["complaint_source"].ToString();
				incurg = rdr["urgency"].ToString();
				name = rdr["c_name"].ToString();
				name_id = rdr["name_id"].ToString();
				lcomp = rdr["company_id"].ToString();
				lprop = rdr["object_id"].ToString();
				this.txtPhone.Text = rdr["direct_phone"].ToString();
				this.txtMobile.Text = rdr["mobile_phone"].ToString();
				this.txtWkPhone.Text = rdr["phone"].ToString();
				this.txtDesc.Text = rdr["description"].ToString();
				this.txtPRes.Text = rdr["solution"].ToString();
				this.txtEmail.Text = rdr["email"].ToString();
				this.lblUby.Text = get_employeename(Convert.ToInt32(rdr["record_manager"]));
				this.chkWeb.Checked = Convert.ToBoolean(rdr["show_owner"]);
		}
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

			Session["iProp"] = lprop;
			
			pop_types(inctype);
			pop_source(incsrc, name, name_id);
			pop_urgs(incurg);
			popprops(lprop);
			getIncActions(inc_id);
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

		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			setenabled(true);
			btnUpdate.Visible = true;
			btnCancel.Visible = true;
			btnEdit.Visible = false;
			btnClose.Visible=false;
			Session["inc_edit"] = true;
			Session["inc_save"] = true;
			Session["inc_new"] = false;
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			saveincident();
		}


		private void hideErr()
		{	
			this.lblMessage.Text="";
			this.lblMessage.Visible = false;
			this.lblUrgStar.Visible = false;
			this.lblIncStar.Visible = false;
			this.lblNameStar.Visible = false;
			this.lblSrcStar.Visible = false;
			this.lblPropStar.Visible=false;
		}

		private void saveincident()
		{
			Camelot.classes.saveUtils su = new saveUtils();
			string name = "";
			int id = 0;
			int src = 0;
			cInc_Srcs incs = (cInc_Srcs)Session["Isrcs"];
			bool oktosave = true;
			string Msg = "";
			int cnt = 0;

			if(this.cmbUrg.SelectedItem.Text=="")
			{
				oktosave=false;
				cnt++;
				if(Msg!="")
				{
					Msg = Msg + ", Urgency";
				}
				else
				{
					Msg = "Urgency";
				}
				this.lblUrgStar.Visible=true;
			}
			else
			{
				this.lblUrgStar.Visible=false;
			}


			if(this.cmbName.SelectedValue == "" && this.txtName.Text=="")
			{
				oktosave=false;
				cnt++;
				if(Msg!="")
				{
					Msg = Msg + ", Reporters Name";
				}
				else
				{
					Msg = "Reporters Name";
				}

				this.lblNameStar.Visible=true;
			}
			else
			{
				this.lblNameStar.Visible=false;
			}

			if(this.cmbProp.SelectedItem.Text=="")
			{
				oktosave=false;
				cnt++;
				if(Msg!="")
				{
					Msg = Msg + ", Property";
				}
				else
				{
					Msg = "Property";
				}

				this.lblPropStar.Visible=true;
			}
			else
			{
				this.lblPropStar.Visible=false;
			}

			if(this.cmbincsource.SelectedItem.Text=="")
			{
				oktosave=false;
				cnt++;
				if(Msg!="")
				{
					Msg = Msg + ", Incident Source";
				}
				else
				{
					Msg= "Incident Source";
				}

				this.lblSrcStar.Visible=true;
			}
			else
			{
				this.lblSrcStar.Visible=false;
			}

			if(this.cmbinctype.SelectedItem.Text=="")
			{
				oktosave=false;
				cnt++;
				if(Msg!="")
				{
					Msg = Msg + ", Incident Type";
				}
				else
				{
					Msg = "Incident Type";
				}
				this.lblIncStar.Visible=true;
			}
			else
			{
				this.lblIncStar.Visible=false;
			}
			
			if(oktosave)
			{

				foreach(cInc_src ic in incs)
				{
					if(ic.Incident_Source == this.cmbincsource.SelectedItem.Text)
					{
						src = Convert.ToInt32(ic.Source_Type);
						break;
					}
				}

				if(src==4)
				{
					name = this.txtName.Text;
				}
				else
				{
					name = this.cmbName.SelectedItem.Text;
					if(src==2)
					{
						id=get_employeeid(this.cmbName.SelectedValue);
					}
					else
					{
						id = Convert.ToInt32(this.cmbName.SelectedValue.ToString());
					}
				}

			
				SqlConnection conn = new SqlConnection();
				SqlCommand cmd =  new SqlCommand();
				linc= (Camelot.classes.cIncident)Session["curIncident"];
				pUser = (Camelot.classes.cUser)Session["curUser"];

				conn.ConnectionString = (string)Session["Connection"];
				conn.Open();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "update_incident";

				cmd.Parameters.Add(
					new SqlParameter("@prop_id", this.cmbProp.SelectedValue));
				cmd.Parameters.Add(
					new SqlParameter("@comp_id", lcomp));
				cmd.Parameters.Add(
					new SqlParameter("@inc_id", linc.Incident_ID));
				cmd.Parameters.Add(
					new SqlParameter("@inc_type", get_inctypeid(this.cmbinctype.SelectedItem.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@src_type", get_incsrcid(this.cmbincsource.SelectedItem.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@urg_type", get_incurgid(this.cmbUrg.SelectedItem.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@startdate", DateTime.Parse(su.setdate(this.lblIncDate.Text))));
				cmd.Parameters.Add(
					new SqlParameter("@resdate", DateTime.Parse(su.setdate(this.lblResDate.Text))));
				cmd.Parameters.Add(
					new SqlParameter("@cname", name));
				cmd.Parameters.Add(
					new SqlParameter("@name_id", id));
				cmd.Parameters.Add(
					new SqlParameter("@dphone", this.txtPhone.Text));
				cmd.Parameters.Add(
					new SqlParameter("@mobile", this.txtMobile.Text));
				cmd.Parameters.Add(
					new SqlParameter("@wkphone", this.txtWkPhone.Text));
				cmd.Parameters.Add(
					new SqlParameter("@email", this.txtEmail.Text));
				cmd.Parameters.Add(
					new SqlParameter("@desc", this.txtDesc.Text));
				cmd.Parameters.Add(
					new SqlParameter("@sol", this.txtPRes.Text));
				cmd.Parameters.Add(
					new SqlParameter("@record_manager", pUser.ID));
				cmd.Parameters.Add(
					new SqlParameter("@web", this.chkWeb.Checked));
				cmd.ExecuteNonQuery();
		
				cmd.Dispose();
				conn.Close();
				conn.Dispose();
	
				bool inew = (bool)Session["inc_new"];
				Session["inc_edit"] = false;
				Session["inc_save"] = false;
				Session["inc_new"] = false;
				if(inew)
				{
					Response.Write("<script>parent.location.reload(true);</script>");
					Response.Write("<script>window.close();</script>");
				}
				else
				{
					Response.Redirect("incidentdetails.aspx");
				}
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

		public int get_inctypeid(string inc)
		{
			int id = 0;
			Incident_Types incs = (Incident_Types)Session["Itypes"];
			
			foreach(cInc_type it in incs)
			{
				if(it.Incident_Type == inc)
				{
					id = Convert.ToInt32(it.Inc_ID);
					break;
				}
			}
			return id;
		}

		public int get_incsrcid(string inc)
		{
			int id = 0;
			cInc_Srcs incs = (cInc_Srcs)Session["Isrcs"];
			
			foreach(cInc_src ic in incs)
			{
				if(ic.Incident_Source == inc)
				{
					id = Convert.ToInt32(ic.Src_ID);
					break;
				}
			}
			return id;
		}

		public int get_incurgid(string inc)
		{
			int id = 0;
			cInc_urgs incs = (cInc_urgs)Session["Iurgs"];
			
			foreach(cInc_urg ig in incs)
			{
				if(ig.Incident_Urgency == inc)
				{
					id = Convert.ToInt32(ig.Urg_ID);
					break;
				}
			}
			return id;
		}

		public void set_resdate(string inc)
		{
			int time = 0;
			cInc_urgs incs = (cInc_urgs)Session["Iurgs"];
			
			foreach(cInc_urg ig in incs)
			{
				if(ig.Incident_Urgency == inc)
				{
					time = Convert.ToInt32(ig.Urg_Time);
					break;
				}
			}
			
			if(this.lblIncDate.Text=="")
			{
				this.lblIncDate.Text=Convert.ToString(DateTime.Now);
			}

			this.lblResDate.Text = Convert.ToString(Convert.ToDateTime(this.lblIncDate.Text).AddHours(time));
		}

		private void cmbUrg_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			set_resdate(this.cmbUrg.SelectedItem.Text);
		}

		public void dgAction_ItemDataBound(Object sender, DataGridItemEventArgs e)
		{
			if(e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
			{
				LinkButton fButton = (LinkButton)e.Item.Cells[0].Controls[0];
				fButton.Attributes.Add("onclick", "javascript:window.showModalDialog('incident_action.aspx?act=" + DataBinder.Eval(e.Item.DataItem, "action_id") + "','actdets','dialogHeight: 375px; dialogWidth: 800px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');");
			}
		}

		private void btnAction_Click(object sender, System.EventArgs e)
		{
			Session["act_edit"] = true;
			Session["act_save"] = false;
			Session["act_new"] = true;
			Response.Write("<script>window.showModalDialog('incident_action.aspx?act=','newact','dialogHeight: 375px; dialogWidth: 800px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
		}

		
		private void cmbincsource_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int id= 0;
			int src = 0;

			cInc_Srcs incs = (cInc_Srcs)Session["Isrcs"];
			
			this.txtEmail.Text="";
			this.txtPhone.Text="";
			this.txtWkPhone.Text = "";
			this.txtMobile.Text="";

			foreach(cInc_src ic in incs)
			{
				if(ic.Incident_Source == this.cmbincsource.SelectedValue)
				{
					id = Convert.ToInt32(ic.Src_ID);
					src = Convert.ToInt32(ic.Source_Type);
					break;
				}
			}

			if(src==3 && lprop =="0")
			{
				this.lblMessage.Text = "There are no guardians for this property please select a different source";
				this.cmbincsource.SelectedIndex = 1;
			}
			else
			{
				if(src==4)
				{
					this.cmbName.Items.Clear();
					this.cmbName.Visible = false;
					this.txtName.Visible=true;
				}
				else
				{
					this.txtName.Text="";
					this.txtName.Visible = false;
					this.cmbName.Visible=true;
					pop_names(src, "0");
				}
			}
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

		private void cmbName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
			this.txtEmail.Text="";
			this.txtPhone.Text="";
			this.txtWkPhone.Text = "";
			this.txtMobile.Text="";

			cInc_Srcs incs = (cInc_Srcs)Session["Isrcs"];
			int src=0;
			foreach(cInc_src ic in incs)
			{
				if(ic.Incident_Source == this.cmbincsource.SelectedValue)
				{
					src = Convert.ToInt32(ic.Source_Type);
					break;
				}
			}
		
			switch(src)
			{
				case 1:
					popcdets(src, Convert.ToInt32(this.cmbName.SelectedValue));
					break;
				case 2:
					popcdets(src,this.get_employeeid(this.cmbName.SelectedValue));
					break;
				case 3:
					popcdets(src, Convert.ToInt32(this.cmbName.SelectedValue));
					break;
			}

		}

		private void popcdets(int src, int id)
		{
			switch(src)
			{
				case 1:
					popcontact(id);
					break;
				case 2:
					popstaff(id);
					break;
				case 3:
					popguard(id);
					break;
			}
		}

		private void popcontact(int id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_complaint_contact";

			cmd.Parameters.Add(
				new SqlParameter("@cont_id", id));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				this.txtPhone.Text = rdr["phone"].ToString();
				this.txtMobile.Text = rdr["mobile"].ToString();
				this.txtWkPhone.Text = rdr["WKphone"].ToString();
				this.txtEmail.Text = rdr["email"].ToString();
			}
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

		}

		private void popguard(int id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_complaint_guardian";

			cmd.Parameters.Add(
				new SqlParameter("@guard_id", id));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				this.txtPhone.Text = rdr["direct_phone"].ToString();
				this.txtMobile.Text = rdr["mobile"].ToString();
				this.txtWkPhone.Text = rdr["WKphone"].ToString();
				this.txtEmail.Text = rdr["email"].ToString();
			}
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		private void popstaff(int id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_complaint_employee";

			cmd.Parameters.Add(
				new SqlParameter("@EMP_id", id));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				this.txtEmail.Text = rdr["email"].ToString();
			}
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		private void cmbProp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int id= 0;
			int src = 0;

			cInc_Srcs incs = (cInc_Srcs)Session["Isrcs"];
			
			this.txtEmail.Text="";
			this.txtPhone.Text="";
			this.txtWkPhone.Text = "";
			this.txtMobile.Text="";

			lprop = this.cmbProp.SelectedValue;
			Session["iProp"] = lprop;

			if(lprop == "0")
			{
				int c = 0;
				foreach(ListItem li in this.cmbincsource.Items)
				{
					this.cmbincsource.Items[c].Selected = false;
					c++;
				}
				this.cmbincsource.Items[1].Selected = true;
			}

			foreach(cInc_src ic in incs)
			{
				if(ic.Incident_Source == this.cmbincsource.SelectedValue)
				{
					id = Convert.ToInt32(ic.Src_ID);
					src = Convert.ToInt32(ic.Source_Type);
					break;
				}
			}
			
			if(src==4)
			{
				this.cmbName.Items.Clear();
				this.cmbName.Visible = false;
				this.txtName.Visible=true;
			}
			else
			{
				this.txtName.Text="";
				this.txtName.Visible = false;
				this.cmbName.Visible=true;
				pop_names(src, "0");
			}
		}

		private void cmbinctype_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private string get_company(string prop_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			string comp = "";

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_property_company";

			cmd.Parameters.Add(
				new SqlParameter("@prop_id", prop_id));
			
			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				comp = rdr.GetValue(0).ToString();
			}
			
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			return comp;
		}
	}
}
