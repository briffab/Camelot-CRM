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
	/// Summary description for inspection.
	/// </summary>
	public class inspection : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label lblMessage;
		Camelot.classes.Utils Utils = new Camelot.classes.Utils();
		Camelot.classes.cInspection linsp = new cInspection();
		protected System.Web.UI.WebControls.Button btnClose;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.DataGrid dgMets;
		protected System.Web.UI.WebControls.Label lblPropInsp;
		protected System.Web.UI.WebControls.DropDownList cmbPropInsp;
		protected System.Web.UI.HtmlControls.HtmlTableCell Label2;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.Label lblDateStar;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.ListBox lbInRep;
		protected System.Web.UI.WebControls.Button btnMto;
		protected System.Web.UI.WebControls.Button btnMfrom;
		protected System.Web.UI.WebControls.ListBox lbNotRep;
		protected System.Web.UI.WebControls.TextBox txtOther;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Button btnNote;
		protected System.Web.UI.WebControls.Label lblDateSent;
		protected System.Web.UI.HtmlControls.HtmlTableCell Td1;
		protected System.Web.UI.WebControls.Button btnOwner;
		protected System.Web.UI.WebControls.Button btnView;
		Camelot.classes.cUser pUser;
		Camelot.classes.cProperty lprop = null;
		private ArrayList cRecips = new ArrayList();
		private ArrayList cRecipEmail = new ArrayList();
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			bool oktogo;
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
				if(!Page.IsPostBack)
				{

					hideErr();
					string insp = Request.QueryString["insp"];
					linsp.Inspection_ID = insp;
					Session["curInspection"] = linsp;

					Response.Expires = 0;
					Response.Cache.SetNoStore();
					Response.AppendHeader("Pragma", "no-cache");
			
					bool edit = (bool)Session["insp_edit"];
			
					setenabled(edit);

					if(edit)
					{
						if(!(bool)Session["insp_save"] && (linsp.Inspection_ID!=null && linsp.Inspection_ID!=""))
						{
							pop_insp(linsp.Inspection_ID);
						}
				
						btnUpdate.Visible = true;
						btnCancel.Visible = true;
						btnEdit.Visible = false;
						btnClose.Visible=false;
					}
					else
					{
						if(!(bool)Session["insp_save"] && (linsp.Inspection_ID!=null && linsp.Inspection_ID!=""))
						{
							pop_insp(linsp.Inspection_ID);
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
				else
				{
					linsp = (Camelot.classes.cInspection)Session["curInspection"];
				}
			}
		}

		private void pop_insp(string insp)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.saveUtils us = new Camelot.classes.saveUtils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_inspection";

			cmd.Parameters.Add(
				new SqlParameter("@insp", insp));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				lblTitle.Text = rdr["object_name"].ToString();
				txtDate.Text = rdr["date_check"].ToString();
				this.txtOther.Text = rdr["report_comment"].ToString();
				pop_propinsp(rdr["inspector"].ToString());
			}
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

			pop_meters(insp);
			pop_comments(insp);


		}

		private void pop_comments(string insp)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.saveUtils us = new Camelot.classes.saveUtils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_inspection_comments";

			cmd.Parameters.Add(
				new SqlParameter("@INSP", insp));

			rdr = cmd.ExecuteReader();
			
			this.lbInRep.Items.Clear();
			this.lbInRep.DataSource =rdr;
			this.lbInRep.DataValueField = "id" ;
			this.lbInRep.DataTextField = "text";
			this.lbInRep.DataBind();

			rdr.NextResult();
			this.lbNotRep.Items.Clear();
			this.lbNotRep.DataSource =rdr;
			this.lbNotRep.DataValueField = "id" ;
			this.lbNotRep.DataTextField = "text";
			this.lbNotRep.DataBind();

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

		}

		private void hideErr()
		{
			lblDateStar.Visible=false;
			lblMessage.Visible=false;
		}

		private void setenabled(bool edit)
		{
			cmbPropInsp.Enabled = edit;
			txtDate.Enabled = edit;
			this.lbInRep.Enabled=edit;
			this.lbNotRep.Enabled = edit;
			this.txtOther.Enabled=edit;
			this.btnMfrom.Enabled=edit;
			this.btnMto.Enabled=edit;
			dgMets.Enabled = edit;
		}




		private void pop_propinsp(string inspid)
		{
			Employees lemps = (Employees)Session["Emps"];
			int ind =0;
			cmbPropInsp.Items.Clear();
			cmbPropInsp.Items.Add("");
			foreach(Employee e in lemps)
			{
				cmbPropInsp.Items.Add(e.Emp_Name);
				if(e.Emp_ID == inspid)
				{
					ind = cmbPropInsp.Items.Count-1;
				}
			}
			cmbPropInsp.SelectedIndex = ind;
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
			this.btnMto.Click += new System.EventHandler(this.btnMto_Click);
			this.btnMfrom.Click += new System.EventHandler(this.btnMfrom_Click);
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			this.btnNote.Click += new System.EventHandler(this.btnNote_Click);
			this.btnOwner.Click += new System.EventHandler(this.btnOwner_Click);
			this.btnView.Click += new System.EventHandler(this.btnView_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Session["insp_edit"] = false;
			Session["insp_save"] = false;
			Response.Write("<script>window.close();</script>");
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Session["insp_edit"] = false;
			Session["insp_save"] = false;
			setenabled(false);
			btnUpdate.Visible = false;
			btnOwner.Visible = true;
			btnCancel.Visible = false;
			btnEdit.Visible = true;
			btnClose.Visible= true;
			pop_insp(linsp.Inspection_ID);
			hideErr();
		}

		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			setenabled(true);
			btnUpdate.Visible = true;
			btnCancel.Visible = true;
			btnEdit.Visible = false;
			btnClose.Visible=false;
			this.btnOwner.Visible=false;
			Session["insp_edit"] = true;
			Session["insp_save"] = true;
			pop_meters(linsp.Inspection_ID);
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			saveinsp();
		}

		private void saveinsp()
		{
			bool oktosave = true;
			string Msg = "";
			int cnt = 0;
			Camelot.classes.saveUtils su = new saveUtils();
			
			if(!su.IsDate(su.setdate(txtDate.Text)))
			{
				oktosave=false;
				cnt++;
				if(Msg!="")
				{
					Msg = Msg + ", Inspection Date";
				}
				else
				{
					Msg = "Inspection Date";
				}
				lblDateStar.Visible=true;
			}
			
			if(oktosave)
			{
				SqlConnection conn = new SqlConnection();
				SqlCommand cmd =  new SqlCommand();
				linsp= (Camelot.classes.cInspection)Session["curInspection"];
				pUser = (Camelot.classes.cUser)Session["curUser"];
				int emp = get_employeeid(cmbPropInsp.SelectedItem.Text);

				conn.ConnectionString = (string)Session["Connection"];
				conn.Open();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "update_inspection";

				cmd.Parameters.Add(
					new SqlParameter("@insp_id", linsp.Inspection_ID));
				cmd.Parameters.Add(
					new SqlParameter("@DATE", su.setdate(txtDate.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@inspector", emp));
				cmd.Parameters.Add(
					new SqlParameter("@rep_comm", this.txtOther.Text));
				cmd.ExecuteNonQuery();
				
				cmd.Dispose();
				conn.Close();
				conn.Dispose();
			
				foreach(DataGridItem dgi in dgMets.Items)
				{							   
					int rdid = Convert.ToInt32(dgMets.DataKeys[dgi.ItemIndex].ToString());
					int metid = Convert.ToInt32(dgi.Cells[2].Text);
					int rid = Convert.ToInt32(dgi.Cells[3].Text);
					TextBox reading = (TextBox)dgi.FindControl("txtRead");
					string rdate = su.setdate(txtDate.Text);

					update_reading(rdid,metid,rid,reading.Text, rdate, emp);
				}

				
				deletecomments();

				foreach(ListItem li in this.lbInRep.Items)
				{
					savecomment(li.Value);
				}

				Session["insp_edit"] = false;
				Session["insp_save"] = false;
				setenabled(false);
				btnUpdate.Visible = false;
				btnCancel.Visible = false;
				btnEdit.Visible = true;
				btnOwner.Visible = true;
				btnClose.Visible= true;
				pop_insp(linsp.Inspection_ID);
				hideErr();
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

		private void deletecomments()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			Camelot.classes.saveUtils us = new Camelot.classes.saveUtils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "delete_COMMENTs";

			cmd.Parameters.Add(
				new SqlParameter("@insp", linsp.Inspection_ID));
			
			cmd.ExecuteNonQuery();

			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		private void savecomment(string comm)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			Camelot.classes.saveUtils us = new Camelot.classes.saveUtils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "INSERT_INSP_COMMENT";

			cmd.Parameters.Add(
				new SqlParameter("@insp", linsp.Inspection_ID));
			cmd.Parameters.Add(
				new SqlParameter("@comm_id", comm));
			
			cmd.ExecuteNonQuery();

			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		private void update_reading(int rdid, int metid, int rid, string read, string rdate, int insp)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			pUser = (Camelot.classes.cUser)Session["curUser"];
			Camelot.classes.saveUtils su = new saveUtils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "update_meterreading";

			cmd.Parameters.Add(
				new SqlParameter("@read_id", rdid));
			cmd.Parameters.Add(
				new SqlParameter("@met_id", metid));
			cmd.Parameters.Add(
				new SqlParameter("@rate_id", rid));
			cmd.Parameters.Add(
				new SqlParameter("@reading", read));
			cmd.Parameters.Add(
				new SqlParameter("@insp", insp));
			cmd.Parameters.Add(
				new SqlParameter("@readdate", su.setdate(rdate)));
			cmd.Parameters.Add(
				new SqlParameter("@insp_id", linsp.Inspection_ID));
			cmd.ExecuteNonQuery();
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

		private void pop_meters(string insp)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_inspection_meters";

			cmd.Parameters.Add(
				new SqlParameter("@insp", insp));

			dgMets.DataSource = cmd.ExecuteReader();
			dgMets.DataBind();
			dgMets.Visible= true;
		
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		private void btnNote_Click(object sender, System.EventArgs e)
		{
			Session["note_edit"] = true;
			Session["note_save"] = false;
			Session["note_new"] = true;
			Response.Write("<script>window.showModalDialog('propertynotedetails.aspx?note=','note','dialogHeight: 485px; dialogWidth: 800px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
		}

		private void btnMto_Click(object sender, System.EventArgs e)
		{
			foreach(ListItem li in this.lbInRep.Items)
			{
				if(li.Selected)
				{
					this.lbNotRep.Items.Add(li);
				}
			}

			foreach(ListItem li in this.lbNotRep.Items)
			{
				this.lbInRep.Items.Remove(li);
			}
		}

		private void btnMfrom_Click(object sender, System.EventArgs e)
		{
			foreach(ListItem li in this.lbNotRep.Items)
			{
				if(li.Selected)
				{
					this.lbInRep.Items.Add(li);
				}
			}

			foreach(ListItem li in this.lbInRep.Items)
			{
				this.lbNotRep.Items.Remove(li);
			}
		}

		private void btnOwner_Click(object sender, System.EventArgs e)
		{
			string email = "";

			email = get_email();
			if(email == "0")
			{
				Response.Write("<script>alert('This property has no contact to receive the report !')</script>");
			}
			else if(email == "1")
			{
				Response.Write("<script>alert('The report recipient has no email address so the report should be saved and printed !')</script>");
				Response.Write("<script>window.showModalDialog('insp_rep.aspx?action=send','note','dialogHeight: 485px; dialogWidth: 800px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
			}
			else
			{
				Response.Write("<script>window.showModalDialog('emailinsp.aspx?=" + linsp.Inspection_ID + "','note','dialogHeight: 700px; dialogWidth: 800px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
			}
		}

		private void btnView_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.showModalDialog('insp_rep.aspx?action=view','note','dialogHeight: 485px; dialogWidth: 800px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
		}

		private string get_email()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			string email = "";

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_inspection_email";

			cmd.Parameters.Add(
				new SqlParameter("@prop_id", lprop.Property_ID));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				email = rdr.GetValue(0).ToString();
			}

			if(email == "2")
			{
				rdr.NextResult();
				while(rdr.Read())
				{
					cRecips.Add(rdr.GetValue(0).ToString());
					cRecipEmail.Add(rdr.GetValue(1).ToString());
				}
				Session["iRecips"] = cRecips;
				Session["iRecipEmail"] = cRecipEmail;
				Session["iProp"]= lprop.Property_ID;
			}

			return email;

		}
	}
}
