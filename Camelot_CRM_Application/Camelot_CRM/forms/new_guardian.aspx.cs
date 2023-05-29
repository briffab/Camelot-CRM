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
	public class new_guardian : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblfacdesc;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label lblUpBy;
		protected System.Web.UI.WebControls.Label lblUby;
		protected System.Web.UI.WebControls.Label lblUpOn;
		protected System.Web.UI.WebControls.Label lblUDate;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Button btnClose;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Button btnCancel;
		Camelot.classes.Utils Utils = new Camelot.classes.Utils();
		Camelot.classes.cGuardian lguard;
		Camelot.classes.cProperty lprop;
		Camelot.classes.cCompany lcomp;
		protected System.Web.UI.WebControls.DropDownList cmbmettype;
		protected System.Web.UI.WebControls.TextBox txtloc;
		protected System.Web.UI.WebControls.TextBox txtmetsn;
		protected System.Web.UI.WebControls.TextBox txtreaddate;
		protected System.Web.UI.WebControls.TextBox txtreading;
		protected System.Web.UI.WebControls.DropDownList cmbsupp;
		protected System.Web.UI.WebControls.CheckBox chkUse;
		protected System.Web.UI.WebControls.Label lblfactype;
		protected System.Web.UI.WebControls.DropDownList cmbtitle;
		protected System.Web.UI.WebControls.TextBox txtfname;
		protected System.Web.UI.WebControls.TextBox txtlname;
		protected System.Web.UI.WebControls.TextBox txtwktel;
		protected System.Web.UI.WebControls.TextBox txtmobile;
		protected System.Web.UI.WebControls.TextBox txtfax;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.TextBox txtDOB;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.TextBox txtNat;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.TextBox txtHmTel;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.TextBox txtPtel;
		protected System.Web.UI.WebControls.TextBox txtwkmobile;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.TextBox txtHmemail;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.TextBox txtPemail;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.DropDownList cmbStat;
		protected System.Web.UI.WebControls.TextBox txtRent;
		protected System.Web.UI.WebControls.TextBox txtpbu;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.TextBox txtpbr;
		protected System.Web.UI.WebControls.Label Label22;
		protected System.Web.UI.WebControls.Label Label23;
		protected System.Web.UI.WebControls.TextBox txtHmmobile;
		protected System.Web.UI.WebControls.TextBox txtPmobile;
		protected System.Web.UI.WebControls.Label Label24;
		protected System.Web.UI.WebControls.DropDownList cmbSex;
		protected System.Web.UI.WebControls.TextBox txtwkEmail;
		protected System.Web.UI.WebControls.TextBox txtfire;
		protected System.Web.UI.WebControls.TextBox txtins;
		protected System.Web.UI.WebControls.Label Label25;
		protected System.Web.UI.WebControls.CheckBox chkhead;
		protected System.Web.UI.WebControls.Button btnBank;
		protected System.Web.UI.WebControls.Label Label26;
		protected System.Web.UI.WebControls.TextBox txtDtStart;
		protected System.Web.UI.WebControls.Label Label27;
		protected System.Web.UI.WebControls.TextBox txtDtFinished;
		protected System.Web.UI.WebControls.Label Label28;
		protected System.Web.UI.WebControls.TextBox txtRoom;
		protected System.Web.UI.WebControls.Label Label29;
		protected System.Web.UI.WebControls.Label Label30;
		protected System.Web.UI.WebControls.Label Label31;
		protected System.Web.UI.WebControls.Label Label33;
		protected System.Web.UI.WebControls.Label Label34;
		protected System.Web.UI.WebControls.Label Label35;
		protected System.Web.UI.WebControls.Label Label36;
		protected System.Web.UI.WebControls.Label lblFProp;
		protected System.Web.UI.WebControls.TextBox txtProp;
		protected System.Web.UI.WebControls.Button btnPserch;
		protected System.Web.UI.WebControls.ListBox lbProperties;
		protected System.Web.UI.WebControls.Label lblProp;
		protected System.Web.UI.WebControls.TextBox txtSCProp;
		protected System.Web.UI.WebControls.Label lblPropID;
		protected System.Web.UI.WebControls.TextBox txtPropID;
		protected System.Web.UI.WebControls.TextBox txtSProp;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtSal;
		protected System.Web.UI.WebControls.TextBox txtpref;
		protected System.Web.UI.WebControls.TextBox txtinit;
		Camelot.classes.cUser pUser;
			

		private void Page_Load(object sender, System.EventArgs e)
		{
			bool oktogo;
			string sss;
			Camelot.classes.Utils pUtil = new Camelot.classes.Utils();
			pUser = (Camelot.classes.cUser)Session["curUser"];
			oktogo = pUtil.valid_user(pUser);
			lprop = (Camelot.classes.cProperty)Session["curProperty"];

			if(!oktogo)
			{
				Response.Redirect("../logon.aspx");
			}
			else
			{
				hideErr();
				sss = Request.QueryString["src"];
				if(sss!=null)
				{
					Session["src"]=sss;
				}
				lguard=(Camelot.classes.cGuardian)Session["curGuardian"];
				string err=Request.QueryString["err"];
			
			{
				string guard = Request.QueryString["gid"];
				if(guard != null)
				{
					lguard.Guardian_ID = guard;
				}
			}
			
				Response.Expires = 0;
				Response.Cache.SetNoStore();
				Response.AppendHeader("Pragma", "no-cache");
			
			
				bool edit = (bool)Session["guard_edit"];
				bool cnew = (bool)Session["guard_new"];
									
				setenabled(edit);
			
				if(cnew)
				{
					if(!(bool)Session["guard_save"])
					{
						pop_combos();
						btnUpdate.Visible = true;
						btnCancel.Visible = true;
						btnBank.Visible = false;
						btnEdit.Visible = false;
						btnClose.Visible=false;
						lguard.Guardian_ID = "";
						Session["guard_save"] = true;
						pop_prop("");
					}
				}
				else
				{
					if(edit)
					{
						if(!(bool)Session["guard_save"] && (lguard.Guardian_ID!=null && lguard.Guardian_ID!=""))
						{
							pop_guard(lguard.Guardian_ID, lprop.Property_ID);
						}
				
						btnUpdate.Visible = true;
						btnCancel.Visible = true;
						btnEdit.Visible = false;
						btnClose.Visible=false;
					}
					else
					{
						if(!(bool)Session["guard_save"] && (lguard.Guardian_ID!=null && lguard.Guardian_ID!=""))
						{
							pop_guard(lguard.Guardian_ID, lprop.Property_ID);
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
				Session["curGuardian"] = lguard;
			}
			lprop= (Camelot.classes.cProperty)Session["curProperty"];
			if(!Page.IsPostBack)
			{
				if(lprop.Property_ID!=null)
				{
					txtSProp.Text = lprop.Property_Name;
					txtPropID.Text = lprop.Property_ID;
				}
				else
				{
					txtSProp.Text = "No Property";
					txtPropID.Text = "0";
				}
			}

		}
		private void pop_guard(string guard_id, string prop_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.Utils us = new Camelot.classes.Utils();
			string stat = "";
			string sex = "";

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_guardian";

			cmd.Parameters.Add(
				new SqlParameter("@guard_id", guard_id));

			cmd.Parameters.Add(
				new SqlParameter("@prop_id", prop_id));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				lblTitle.Text = rdr["guardian"].ToString();
				cmbtitle.SelectedItem.Text = rdr["title"].ToString();
				txtfname.Text = rdr["firstname"].ToString();
				txtinit.Text = rdr["initialS"].ToString();
				txtlname.Text = rdr["lastname"].ToString();
				txtDOB.Text = rdr["dob"].ToString();
				txtNat.Text = rdr["nationality"].ToString();
				txtHmTel.Text = rdr["private_phone"].ToString();
				txtwktel.Text = rdr["phone"].ToString();
				txtPtel.Text = rdr["parent_phone"].ToString();
				txtwkmobile.Text = rdr["mobile"].ToString();
				txtHmmobile.Text = rdr["private_mobile"].ToString();
				txtPmobile.Text = rdr["parent_mobile"].ToString();
				txtfax.Text = rdr["fax"].ToString();
				txtwkEmail.Text = rdr["email"].ToString();
				txtHmemail.Text = rdr["private_email"].ToString();
				txtPemail.Text = rdr["parent_email"].ToString();
				stat = rdr["resident_status_id"].ToString();
				lblUby.Text = get_employeename(Convert.ToInt32(rdr["record_modifier"]));
				lblUDate.Text = rdr["Date_modified"].ToString();
				txtRent.Text = rdr["rent"].ToString();
				txtpbu.Text = rdr["rent_break"].ToString();
				txtpbr.Text = rdr["break_reason"].ToString();
				txtfire.Text = rdr["firepack"].ToString();
				txtins.Text = rdr["insurance"].ToString();
				chkhead.Checked = (bool)rdr["main"];
				sex = rdr["gender"].ToString();
				txtRoom.Text = rdr["room"].ToString();
				txtDtStart.Text = String.Format(rdr["date_from"].ToString(),"0:dd MMMM yyyy");
				txtDtFinished.Text = String.Format(rdr["date_to"].ToString(),"0:dd MMMM yyyy");
			}
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			
			lguard.Guardian_Name = lblTitle.Text;
			pop_status(stat);
			pop_sex(sex);

		}

		public void pop_sex(string sex)
		{
			if(sex=="1")
			{
				cmbSex.SelectedIndex = 0;
			}
			else
			{
				cmbSex.SelectedIndex=1;
			}
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
		

		private void pop_status(string statid)
		{
			Guard_stats stats = (Guard_stats)Session["Gstats"];
			int ind =0;
			cmbStat.Items.Clear();
			cmbStat.Items.Add("");
			foreach(Guard_stat st in stats)
			{
				cmbStat.Items.Add(st.Description);
				if(st.Status_ID == statid)
				{
					ind = cmbStat.Items.Count-1;
				}
			}
			cmbStat.SelectedIndex = ind;
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
			this.btnPserch.Click += new System.EventHandler(this.btnPserch_Click);
			this.lbProperties.SelectedIndexChanged += new System.EventHandler(this.lbProperties_SelectedIndexChanged);
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			this.btnBank.Click += new System.EventHandler(this.btnBank_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void setenabled(bool edit)
		{
			cmbStat.Enabled = edit;
			cmbtitle.Enabled=edit;
			txtfname.Enabled=edit;
			txtinit.Enabled=edit;
			txtlname.Enabled=edit;
			cmbSex.Enabled=edit;
			txtDOB.Enabled=edit;
			txtNat.Enabled=edit;
			txtwktel.Enabled=edit;
			txtHmTel.Enabled=edit;
			txtPtel.Enabled=edit;
			txtfax.Enabled=edit;
			txtwkmobile.Enabled=edit;
			txtHmmobile.Enabled=edit;
			txtPmobile.Enabled=edit;
			txtfax.Enabled=edit;
			txtwkEmail.Enabled=edit;
			txtHmemail.Enabled=edit;
			txtPemail.Enabled=edit;
			txtRent.Enabled=edit;
			txtpbu.Enabled=edit;
			txtpbr.Enabled=edit;
			txtfire.Enabled=edit;
			txtins.Enabled=edit;
			chkhead.Enabled=edit;
			txtDtStart.Enabled=edit;
			txtDtFinished.Enabled=edit;
			txtRoom.Enabled=edit;

		}
		
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			setenabled(true);
			btnUpdate.Visible = true;
			btnCancel.Visible = true;
			btnEdit.Visible = false;
			btnClose.Visible=false;
			Session["guard_edit"] = true;
			Session["guard_save"] = true;
			Session["guard_new"] = false;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			bool mnew = (bool)Session["guard_new"];
			Session["guard_edit"] = false;
			Session["guard_save"] = false;
			Session["guard_new"] = false;
			if(mnew)
			{
				Response.Write("<script>window.close();</script>");
			}
			else
			{
				Response.Redirect("guardian.aspx");
			}
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Session["guard_edit"] = false;
			Session["guard_save"] = false;
			Session["guard_new"] = false;
			Response.Write("<script>window.close();</script>");
		}

		
		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			saveguard();
		}

		private void saveguard()
		{
			string guard;
			bool oktosave = true;
			string Msg = "";
			int cnt = 0;
			Camelot.classes.saveUtils su = new saveUtils();


			if(txtlname.Text == "")
			{
				oktosave=false;
				cnt++;
				if(Msg!="")
				{
					Msg = Msg + ", Last Name";
				}
				else
				{
					Msg = "Last Name";
				}
				Label29.Visible=true;
			}

			if(!su.IsDate(su.setdate(txtDOB.Text)))
			{
				oktosave=false;
				cnt++;
				if(Msg!="")
				{
					Msg = Msg + ", Date of Birth";
				}
				else
				{
					Msg = "Date of Birth";
				}
				Label36.Visible=true;
			}

			if(!su.IsDate(su.setdate(txtDtStart.Text)))
			{
				oktosave=false;
				cnt++;
				if(Msg!="")
				{
					Msg = Msg + ", Date Started";
				}
				else
				{
					Msg = "Date Started";
				}
				Label30.Visible=true;
			}

			if(!su.IsDate(su.setdate(txtDtFinished.Text)))
			{
				oktosave=false;
				cnt++;
				if(Msg!="")
				{
					Msg = Msg + ", Date Finished";
				}
				else
				{
					Msg = "Date Finished";
				}
				Label31.Visible=true;
			}

			if(!su.IsDate(su.setdate(txtpbu.Text)))
			{
				oktosave=false;
				cnt++;
				if(Msg!="")
				{
					Msg = Msg + ", Payment Break";
				}
				else
				{
					Msg = "Payment Break";
				}
				Label33.Visible=true;
			}

			if(!su.IsDate(su.setdate(txtfire.Text)))
			{
				oktosave=false;
				cnt++;
				if(Msg!="")
				{
					Msg = Msg + ", Fire Pack";
				}
				else
				{
					Msg = "Fire Pack";
				}
				Label34.Visible=true;
			}

			if(oktosave)
			{
				lcomp=(Camelot.classes.cCompany)Session["curCompany"];
				SqlConnection conn = new SqlConnection();
				SqlCommand cmd =  new SqlCommand();
				lguard= (Camelot.classes.cGuardian)Session["curGuardian"];
				if(lguard.Guardian_ID == null)
				{
					guard = "0";
				}
				else
				{
					guard = lguard.Guardian_ID;
				}
				pUser = (Camelot.classes.cUser)Session["curUser"];

				conn.ConnectionString = (string)Session["Connection"];
				conn.Open();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "update_guardian";

				cmd.Parameters.Add(
					new SqlParameter("@prop_id", txtPropID.Text));
				cmd.Parameters.Add(
					new SqlParameter("@Guard_ID", guard));
				cmd.Parameters.Add(
					new SqlParameter("@status_id", get_status_id(cmbStat.SelectedItem.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@title", cmbtitle.SelectedItem.Text));
				cmd.Parameters.Add(
					new SqlParameter("@firstname", su.ToTitle(txtfname.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@initials", txtinit.Text));
				cmd.Parameters.Add(
					new SqlParameter("@lastname", su.ToTitle(txtlname.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@PREFIX", this.txtpref.Text));
				cmd.Parameters.Add(
					new SqlParameter("@salutation", this.txtSal.Text));
				cmd.Parameters.Add(
					new SqlParameter("@dob", su.setdate(txtDOB.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@nat", su.ToTitle(txtNat.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@sex", cmbSex.SelectedItem.Value));
				cmd.Parameters.Add(
					new SqlParameter("@wktel", txtwktel.Text));
				cmd.Parameters.Add(
					new SqlParameter("@hmtel", txtHmTel.Text));
				cmd.Parameters.Add(
					new SqlParameter("@ptel", txtPtel.Text));
				cmd.Parameters.Add(
					new SqlParameter("@mobile", txtwkmobile.Text));
				cmd.Parameters.Add(
					new SqlParameter("@hmmob", txtHmmobile.Text));
				cmd.Parameters.Add(
					new SqlParameter("@pmob", txtPmobile.Text));
				cmd.Parameters.Add(
					new SqlParameter("@fax", txtfax.Text));
				cmd.Parameters.Add(
					new SqlParameter("@email", txtwkEmail.Text));
				cmd.Parameters.Add(
					new SqlParameter("@hmemail", txtHmemail.Text));
				cmd.Parameters.Add(
					new SqlParameter("@pemail", txtPemail.Text));
				cmd.Parameters.Add(
					new SqlParameter("@record_modifier", pUser.ID));
				cmd.Parameters.Add(
					new SqlParameter("@rent", txtRent.Text));
				cmd.Parameters.Add(
					new SqlParameter("@break", su.setdate(txtpbu.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@reason", txtpbr.Text));
				cmd.Parameters.Add(
					new SqlParameter("@fire", su.setdate(txtfire.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@ins", txtins.Text));
				cmd.Parameters.Add(
					new SqlParameter("@main", chkhead.Checked));
				cmd.Parameters.Add(
					new SqlParameter("@date_from", su.setdate(txtDtStart.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@date_to", su.setdate(txtDtFinished.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@room", txtRoom.Text));
				cmd.ExecuteNonQuery();
			
				cmd.Dispose();
				conn.Close();
				conn.Dispose();
			
				bool cnew = (bool)Session["guard_new"];
				Session["guard_edit"] = false;
				Session["guard_save"] = false;
				Session["guard_new"] = false;
				if(cnew)
				{
					lprop.Property_ID = txtPropID.Text;
					lprop.Property_Name = txtSProp.Text;
					Response.Write("<script>parent.location.reload(true);</script>");
					Response.Write("<script>window.close();</script>");
				}
				else
				{
					Response.Redirect("guardian.aspx");
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

		public int get_status_id(string stat)
		{
			int id = 0;
			Guard_stats stats = (Guard_stats)Session["Gstats"];
			
			foreach(Guard_stat st in stats)
			{
				if(st.Description == stat)
				{
					id = Convert.ToInt32(st.Status_ID);
					break;
				}
			}
			return id;
		}

		

		
		private void pop_combos()
		{
			pop_status("");
			pop_titles();		
	
		}

		private void pop_titles()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_titles";

			this.cmbtitle.DataSource = cmd.ExecuteReader();
			this.cmbtitle.DataTextField = "TITLE";
			this.cmbtitle.DataValueField = "TID";
			this.cmbtitle.DataBind();
		
			cmd.Dispose();
			conn.Dispose();
		}

		private void btnBank_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.showModalDialog('bankdetails.aspx?src=guard','bank','dialogHeight: 400px; dialogWidth: 650px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
		}

		private void hideErr()
		{
			lblMessage.Visible = false;
			Label29.Visible=false;
			Label30.Visible=false;
			Label31.Visible=false;
			Label33.Visible=false;
			Label34.Visible=false;
			Label35.Visible=false;
			Label36.Visible=false;
		}

		private void btnPserch_Click(object sender, System.EventArgs e)
		{
			pop_prop(txtProp.Text);
		}

		private void pop_prop(string prop)
		{

			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.Utils us = new Camelot.classes.Utils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "find_properties";

			cmd.Parameters.Add(
				new SqlParameter("@SEARCH", prop));

			rdr = cmd.ExecuteReader();

			lbProperties.DataSource = rdr;
			lbProperties.DataTextField = "prop_dets";
			lbProperties.DataValueField = "prop_id";
			lbProperties.DataBind();
				
			rdr.Close();
			cmd.Dispose();
			conn.Close();
		}

		private void lbProperties_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}