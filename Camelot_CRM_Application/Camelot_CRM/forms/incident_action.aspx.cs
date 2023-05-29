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
	/// Summary description for incident_action.
	/// </summary>
	public class incident_action : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnClose;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.TextBox txtDesc;
		protected System.Web.UI.WebControls.Label lblDate;
		protected System.Web.UI.WebControls.DropDownList cmbStatus;
		protected System.Web.UI.WebControls.DropDownList cmbAccount;
		protected System.Web.UI.WebControls.DropDownList cmbResp;
		protected System.Web.UI.WebControls.Label lblUpBy;
		protected System.Web.UI.WebControls.Label lblUby;
		protected System.Web.UI.WebControls.Button btnCancel;
		Camelot.classes.Utils Utils = new Camelot.classes.Utils();
		Camelot.classes.cAction lact;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.CheckBox chkWeb;
		protected System.Web.UI.WebControls.DropDownList cmbAct;
		protected System.Web.UI.WebControls.TextBox txt;
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
				lact=(Camelot.classes.cAction)Session["curAction"];
				string err=Request.QueryString["err"];
			
				if(lact.Action_ID==null || lact.Action_ID=="")
				{
					string act = Request.QueryString["act"];
					lact.Action_ID = act;
				}
			
				Response.Expires = 0;
				Response.Cache.SetNoStore();
				Response.AppendHeader("Pragma", "no-cache");
			
			
				bool edit = (bool)Session["act_edit"];
				bool anew = (bool)Session["act_new"];
									
				setenabled(edit);
				if(anew)
				{
					if(!(bool)Session["act_save"])
					{
						pop_combos();
						btnUpdate.Visible = true;
						btnCancel.Visible = true;
						btnEdit.Visible = false;
						btnClose.Visible=false;
						lact.Action_ID = "";
						Session["act_save"] = true;
						this.lblDate.Text = Convert.ToString(DateTime.Now);
					}
				}
				else
				{
					if(edit)
					{
						if(!(bool)Session["act_save"] && (lact.Action_ID!=null && lact.Action_ID!=""))
						{
							pop_act(lact.Action_ID);
						}
				
						btnUpdate.Visible = true;
						btnCancel.Visible = true;
						btnEdit.Visible = false;
						btnClose.Visible=false;
					}
					else
					{
						if(!(bool)Session["act_save"] && (lact.Action_ID!=null && lact.Action_ID!=""))
						{
							pop_act(lact.Action_ID);
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
				Session["curAction"] = lact;
			}
		}

		private void setenabled(bool edit)
		{
			this.cmbStatus.Enabled=edit;
			this.txtDesc.Enabled=edit;
			this.cmbAct.Enabled=edit;
			this.cmbResp.Enabled=edit;
			this.chkWeb.Enabled=edit;
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
			Session["act_edit"] = false;
			Session["act_save"] = false;
			Session["act_new"] = false;
			lact.Action_ID = "";
			Session["act"] = lact;
			Response.Write("<script>window.close();</script>");
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			bool anew = (bool)Session["act_new"];
			Session["act_edit"] = false;
			Session["act_save"] = false;
			Session["act_new"] = false;
			if(anew)
			{
				lact.Action_ID = "";
				Session["act"] = lact;
				Response.Write("<script>window.close();</script>");
			}
			else
			{
				Response.Redirect("incident_action.aspx");
			}
		}

		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			setenabled(true);
			btnUpdate.Visible = true;
			btnCancel.Visible = true;
			btnEdit.Visible = false;
			btnClose.Visible=false;
			Session["act_edit"] = true;
			Session["act_save"] = true;
			Session["act_new"] = false;
		}

		private void pop_combos()
		{
			pop_status("");
			pop_resp("");
			pop_actions();
		}


		private void pop_actions()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_actions";

			this.cmbAct.DataSource = cmd.ExecuteReader();
			this.cmbAct.DataTextField = "DESCRIPTION";
			this.cmbAct.DataValueField = "COMPLAINT_ACTION_ID";
			this.cmbAct.DataBind();
		}


		private void pop_status(string stat)
		{
			
			inc_stats stats = (inc_stats)Session["Istats"];
			int ind =0;
			this.cmbStatus.Items.Clear();
			this.cmbStatus.Items.Add("");
			foreach(inc_stat istat in stats)
			{
				this.cmbStatus.Items.Add(istat.Description);
				if(istat.Status_ID == stat)
				{
					ind = this.cmbStatus.Items.Count-1;
				}
			}
			this.cmbStatus.SelectedIndex = ind;
		}

		private void pop_resp(string rid)
		{
			Employees lemps = (Employees)Session["Emps"];
			int ind =0;
			this.cmbResp.Items.Clear();
			this.cmbResp.Items.Add("");
			foreach(Employee e in lemps)
			{
				this.cmbResp.Items.Add(e.Emp_Name);
				if(e.Emp_ID == rid)
				{
					ind = this.cmbResp.Items.Count-1;
				}
			}
			this.cmbResp.SelectedIndex = ind;
		}

		private void pop_act(string act_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.saveUtils us = new Camelot.classes.saveUtils();
			string act_stat = "";
			string resp = "";
			string act = "";
			
			pop_actions();
			
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_action";

			cmd.Parameters.Add(
				new SqlParameter("@act_id", act_id));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				this.lblDate.Text = rdr["date_entered"].ToString();
				act_stat = rdr["status_code"].ToString();
				act = rdr["action_undertaken"].ToString();
				this.txtDesc.Text = rdr["description"].ToString();
				resp = rdr["responsible"].ToString();
				this.lblUby.Text = get_employeename(Convert.ToInt32(rdr["record_manager"]));
				this.chkWeb.Checked = Convert.ToBoolean(rdr["show_owner"]);
			}
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

			if(act != "")
			{
				this.cmbAct.SelectedValue = act;
			}
			pop_status(act_stat);
			pop_resp(resp);
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
			inc_stats stats = (inc_stats)Session["Istats"];
			
			foreach(inc_stat st in stats)
			{
				if(st.Description == stat)
				{
					id = Convert.ToInt32(st.Status_ID);
					break;
				}
			}
			return id;
		}

		private void saveaction()
		{
			Camelot.classes.saveUtils su = new saveUtils();

			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			pUser = (Camelot.classes.cUser)Session["curUser"];
			lact=(Camelot.classes.cAction)Session["curAction"];
			Camelot.classes.cIncident linc = (Camelot.classes.cIncident)Session["curIncident"];

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "update_action";

			cmd.Parameters.Add(
				new SqlParameter("@inc_id", linc.Incident_ID));
			cmd.Parameters.Add(
				new SqlParameter("@act_id", lact.Action_ID));
			cmd.Parameters.Add(
				new SqlParameter("@date", DateTime.Parse(this.lblDate.Text)));
			cmd.Parameters.Add(
				new SqlParameter("@status", get_status(this.cmbStatus.SelectedItem.Text)));
			cmd.Parameters.Add(
				new SqlParameter("@action", this.cmbAct.SelectedValue));
			cmd.Parameters.Add(
				new SqlParameter("@desc", this.txtDesc.Text));
			cmd.Parameters.Add(
				new SqlParameter("@resp", get_employeeid(this.cmbResp.SelectedItem.Text)));
			cmd.Parameters.Add(
				new SqlParameter("@record_manager", pUser.ID));
			cmd.Parameters.Add(
				new SqlParameter("@web", this.chkWeb.Checked));
			cmd.ExecuteNonQuery();
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		
			bool anew = (bool)Session["act_new"];
			Session["act_edit"] = false;
			Session["act_save"] = false;
			Session["act_new"] = false;
			if(anew)
			{
				Response.Write("<script>parent.location.reload(true);</script>");
				lact.Action_ID = "";
				Session["act"] = lact;
				Response.Write("<script>window.close();</script>");
			}
			else
			{
				Response.Redirect("incident_action.aspx");
			}
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			saveaction();
		}

	}
}


