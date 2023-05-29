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
	public class Contactdetails : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.Label Label9;
		Camelot.classes.Utils Utils = new Camelot.classes.Utils();
		Camelot.classes.cContact lcont;
		Camelot.classes.cProperty lprop;
		Camelot.classes.cCompany lcomp = new cCompany();
		protected System.Web.UI.WebControls.DropDownList cmbmettype;
		protected System.Web.UI.WebControls.TextBox txtloc;
		protected System.Web.UI.WebControls.TextBox txtmetsn;
		protected System.Web.UI.WebControls.TextBox txtreaddate;
		protected System.Web.UI.WebControls.TextBox txtreading;
		protected System.Web.UI.WebControls.DropDownList cmbsupp;
		protected System.Web.UI.WebControls.CheckBox chkUse;
		protected System.Web.UI.WebControls.Label lblfactype;
		protected System.Web.UI.WebControls.DropDownList cmbtitle;
		protected System.Web.UI.WebControls.Label lblfacdesc;
		protected System.Web.UI.WebControls.TextBox txtfname;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtlname;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtwktel;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtmobile;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtfax;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.TextBox txtemail;
		protected System.Web.UI.WebControls.Label lblLName;
		protected System.Web.UI.WebControls.Label lblStatus;
		protected System.Web.UI.WebControls.DropDownList cmbstatus;
		protected System.Web.UI.WebControls.Label lblStatusStar;
		protected System.Web.UI.WebControls.Button btnHist;
		protected System.Web.UI.WebControls.Label lblStatEff;
		protected System.Web.UI.WebControls.TextBox txtStatEff;
		protected System.Web.UI.WebControls.Label lblStatstar;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.CheckBox chkbulk;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtnotes;
		protected System.Web.UI.WebControls.Label lblUpBy;
		protected System.Web.UI.WebControls.Label lblUby;
		protected System.Web.UI.WebControls.Label lblUpOn;
		protected System.Web.UI.WebControls.Label lblUDate;
		protected System.Web.UI.WebControls.Button btnClose;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnNcancel;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.TextBox txtJob;
		protected System.Web.UI.WebControls.Button btnCorr;
		protected System.Web.UI.WebControls.TextBox txtpref;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtSal;
		protected System.Web.UI.WebControls.TextBox txtInit;
		Camelot.classes.cUser pUser;
			

		private void Page_Load(object sender, System.EventArgs e)
		{
			bool oktogo;
			string sss;
			Camelot.classes.Utils pUtil = new Camelot.classes.Utils();
			lcomp=(Camelot.classes.cCompany)Session["curCompany"];
			pUser = (Camelot.classes.cUser)Session["curUser"];
			oktogo = pUtil.valid_user(pUser);
			if(!oktogo)
			{
				Response.Redirect("../logon.aspx");
			}
			else
			{
				sss = Request.QueryString["src"];
				if(sss!=null)
				{
					Session["src"]=sss;
				}
				lcont=(Camelot.classes.cContact)Session["curCont"];
				string err=Request.QueryString["err"];
			
			{
				string cont = Request.QueryString["cid"];
				string comp_id = Request.QueryString["comp_id"];
				string comp = Request.QueryString["comp"];
				if(cont != null)
				{
					lcont.Contact_ID = cont;
				}

				if(comp_id != null)
				{
					lcomp.Company_ID = comp_id;
				}

				if(comp != null)
				{
					lcomp.Company_Name = comp;
				}
				if(comp_id != null && comp != null)
				{
					Session["curCompany"] = lcomp;
				}
			}
			
				Response.Expires = 0;
				Response.Cache.SetNoStore();
				Response.AppendHeader("Pragma", "no-cache");
			
			
				bool edit = (bool)Session["cont_edit"];
				bool cnew = (bool)Session["cont_new"];
									
				setenabled(edit);
			
				if(cnew)
				{
					if(!(bool)Session["cont_save"])
					{
						pop_combos();
						btnUpdate.Visible = true;
						btnCancel.Visible = false;
						btnNcancel.Visible = true;
						btnEdit.Visible = false;
						this.btnCorr.Visible=false;
						btnClose.Visible=false;
						lcont.Contact_ID = "";
						Session["cont_save"] = true;
					}
				}
				else
				{
					if(edit)
					{
						if(!(bool)Session["cont_save"] && (lcont.Contact_ID!=null && lcont.Contact_ID!=""))
						{
							pop_cont(lcont.Contact_ID, lcomp.Company_ID);
						}
				
						btnUpdate.Visible = true;
						btnCancel.Visible = true;
						btnNcancel.Visible = false;
						btnEdit.Visible = false;
						this.btnCorr.Visible=false;
						btnClose.Visible=false;
					}
					else
					{
						if(!(bool)Session["cont_save"] && (lcont.Contact_ID!=null && lcont.Contact_ID!=""))
						{
							pop_cont(lcont.Contact_ID, lcomp.Company_ID);
							
						}
						btnUpdate.Visible = false;
						btnNcancel.Visible = false;
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
						this.btnCorr.Visible=true;
					}
				}
				Session["curCont"] = lcont;
				lblLName.Visible=false;
				this.lblStatstar.Visible=false;
				this.lblStatusStar.Visible = false;
			}
		}

		private void pop_cont(string cont_id, string comp_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.saveUtils su = new Camelot.classes.saveUtils();
			string stat = "";
			string title = "";

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
				lblTitle.Text = rdr["contact"].ToString();
				title = rdr["title"].ToString();
				txtfname.Text = rdr["firstname"].ToString();
				txtInit.Text = rdr["initialS"].ToString();
				this.txtSal.Text = rdr["salutation"].ToString();
				this.txtpref.Text = rdr["prefix"].ToString();
				txtlname.Text = rdr["lastname"].ToString();
				txtwktel.Text = rdr["wktel"].ToString();
				txtfax.Text = rdr["fax"].ToString();
				txtmobile.Text = rdr["mobile"].ToString();
				txtemail.Text = rdr["email"].ToString();
				this.txtJob.Text = rdr["job_title"].ToString();
				txtnotes.Text = rdr["notes"].ToString();
				stat = rdr["status_id"].ToString();
				txtStatEff.Text = su.getdate(rdr["stat_eff"].ToString());
				chkbulk.Checked = (bool)rdr["recieve_mail"];
				lblUby.Text = get_employeename(Convert.ToInt32(rdr["record_modifier"]));
				lblUDate.Text = rdr["Date_modified"].ToString();
			}
			rdr.NextResult();

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			lcont.Contact_Name = lblTitle.Text;
			Session["curContact"] = lcont;
			pop_status(stat);
			pop_titles(title);
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
			Cont_Stats stats = (Cont_Stats)Session["Costats"];
			int ind =0;
			cmbstatus.Items.Clear();
			cmbstatus.Items.Add("");
			foreach(Cont_stat st in stats)
			{
				cmbstatus.Items.Add(st.Description);
				if(st.Status_ID == statid)
				{
					ind = cmbstatus.Items.Count-1;
				}
			}
			cmbstatus.SelectedIndex = ind;
		}

		private void pop_titles(string tit)
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

			int cnt = 0;
			string ind = "";
			foreach(ListItem li in this.cmbtitle.Items)
			{
				if(li.Text == tit)
				{
					ind = li.Value;
				}
				cnt++;
			}

			this.cmbtitle.SelectedValue = ind;
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
			this.btnCorr.Click += new System.EventHandler(this.btnCorr_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.btnNcancel.Click += new System.EventHandler(this.btnNcancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void setenabled(bool edit)
		{
			cmbstatus.Enabled = edit;
			cmbtitle.Enabled=edit;
			txtfname.Enabled=edit;
			txtInit.Enabled=edit;
			txtlname.Enabled=edit;
			txtwktel.Enabled=edit;
			txtfax.Enabled=edit;
			txtmobile.Enabled=edit;
			txtemail.Enabled=edit;
			this.txtnotes.Enabled = edit;
			this.txtJob.Enabled=edit;
			this.txtStatEff.Enabled = edit;
			this.chkbulk.Enabled=edit;
			this.txtpref.Enabled=edit;
			this.txtSal.Enabled=edit;
		}
		
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			setenabled(true);
			btnUpdate.Visible = true;
			btnCancel.Visible = true;
			btnEdit.Visible = false;
			btnClose.Visible=false;
			Session["cont_edit"] = true;
			Session["cont_save"] = true;
			Session["cont_new"] = false;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			bool mnew = (bool)Session["met_new"];
			Session["cont_edit"] = false;
			Session["cont_save"] = false;
			Session["cont_new"] = false;
			if(mnew)
			{
				Response.Write("<script>window.close();</script>");
			}
			else
			{
				Response.Redirect("contactdetails.aspx");
			}
		}

		private void btnNcancel_Click(object sender, System.EventArgs e)
		{
			
			Session["cont_edit"] = false;
			Session["cont_save"] = false;
			Session["cont_new"] = false;
			Response.Write("<script>window.close();</script>");
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Session["cont_edit"] = false;
			Session["cont_save"] = false;
			Session["cont_new"] = false;
			Response.Write("<script>window.close();</script>");
		}

		
		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			savecont();
		}

		private void savecont()
		{
			string prop;
			string cont;
			lprop=(Camelot.classes.cProperty)Session["curProperty"];
			Camelot.classes.saveUtils su = new saveUtils();
			bool oktosave=true;

			if(txtlname.Text=="")
			{
				oktosave=false;
				lblLName.Visible=true;
			}
			if(cmbstatus.SelectedIndex==0)
			{
				oktosave=false;
				lblStatusStar.Visible=true;
			}

			if(!su.IsDate(su.setdate(txtStatEff.Text)) || txtStatEff.Text=="")
			{
				oktosave = false;
				lblStatstar.Visible=true;
			}
			if(oktosave)
			{
				if(lprop.Property_ID == null)
				{
					prop = "0";
				}
				else
				{
					prop = lprop.Property_ID;
				}
				lcomp=(Camelot.classes.cCompany)Session["curCompany"];
				SqlConnection conn = new SqlConnection();
				SqlDataReader rdr = null;
				SqlCommand cmd =  new SqlCommand();
				lcont= (Camelot.classes.cContact)Session["curCont"];
				if(lcont.Contact_ID == null)
				{
					cont = "0";
				}
				else
				{
					cont = lcont.Contact_ID;
				}
				pUser = (Camelot.classes.cUser)Session["curUser"];

				conn.ConnectionString = (string)Session["Connection"];
				conn.Open();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "update_contact";

				cmd.Parameters.Add(
					new SqlParameter("@prop_id", prop));
				cmd.Parameters.Add(
					new SqlParameter("@comp_id", lcomp.Company_ID));
				cmd.Parameters.Add(
					new SqlParameter("@contact_id", cont));
				cmd.Parameters.Add(
					new SqlParameter("@status_id", get_status_id(cmbstatus.SelectedItem.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@STAT_EFF", DateTime.Parse(su.setdate(txtStatEff.Text))));
				cmd.Parameters.Add(
					new SqlParameter("@title", cmbtitle.SelectedItem.Text));
				cmd.Parameters.Add(
					new SqlParameter("@firstname", su.ToTitle(txtfname.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@initials", txtInit.Text));
				cmd.Parameters.Add(
					new SqlParameter("@lastname", su.ToTitle(txtlname.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@PREFIX", this.txtpref.Text));
				cmd.Parameters.Add(
					new SqlParameter("@salutation", this.txtSal.Text));
				cmd.Parameters.Add(
					new SqlParameter("@wktel", txtwktel.Text));
				cmd.Parameters.Add(
					new SqlParameter("@fax", txtfax.Text));
				cmd.Parameters.Add(
					new SqlParameter("@mobile", txtmobile.Text));
				cmd.Parameters.Add(
					new SqlParameter("@email", txtemail.Text));
				cmd.Parameters.Add(
					new SqlParameter("@job_title", this.txtJob.Text));
				cmd.Parameters.Add(
					new SqlParameter("@notes", txtnotes.Text));
				cmd.Parameters.Add(
					new SqlParameter("@record_modifier", pUser.ID));
				cmd.Parameters.Add(
					new SqlParameter("@bulk", this.chkbulk.Checked));
				cmd.Parameters.Add(
					new SqlParameter("@src", Session["src"]));
				rdr = cmd.ExecuteReader();
			
				while(rdr.Read())
				{
					cont = rdr.GetValue(0).ToString();
				}
				rdr.Close();
				cmd.Dispose();
				conn.Close();
				conn.Dispose();

				bool cnew = (bool)Session["cont_new"];
				Session["cont_edit"] = false;
				Session["cont_save"] = false;
				Session["cont_new"] = false;
				if(cnew)
				{
					Response.Write("<script>parent.location.reload(true);</script>");
					Response.Write("<script>window.close();</script>");
				}
				else
				{
					Response.Redirect("contactdetails.aspx");
				}
			}
			else
			{
				lblMessage.Text="You must supply the correct information marked in red";
				lblMessage.Visible=true;
			}
		}

		public int get_status_id(string stat)
		{
			int id = 0;
			Cont_Stats stats = (Cont_Stats)Session["Costats"];
			
			foreach(Cont_stat st in stats)
			{
				if(st.Description == stat)
				{
					id = Convert.ToInt32(st.Status_ID);
					break;
				}
			}
			return id;
		}

		public int get_job_id(string jtd)
		{
			int id = 0;
			cJTitles jts = (cJTitles)Session["JTitles"];
			
			foreach(cJTitle jt in jts)
			{
				if(jt.Description == jtd)
				{
					id = Convert.ToInt32(jt.Title_ID);
					break;
				}
			}
			return id;
		}

		
		private void pop_combos()
		{
			pop_status("");
			pop_titles("");
	
		}

		private void btnHist_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.showModalDialog('contact_status_history.aspx','conthist','dialogHeight: 350px; dialogWidth: 450px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
		}

		private void btnCorr_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.showModalDialog('contactcorrespondence.aspx','guard','dialogHeight: 700px; dialogWidth: 900px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
		}
		
	}
}