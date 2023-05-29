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
	public class Notedetails : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label Label5;
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
		Camelot.classes.cNote lnote;
		Camelot.classes.cCompany lcomp;
		Camelot.classes.cContacts lconts = new cContacts();
		protected System.Web.UI.WebControls.Label lblDate;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.Label lblDateStar;
		protected System.Web.UI.WebControls.DropDownList cmbContact;
		protected System.Web.UI.WebControls.TextBox txtDesc;
		protected System.Web.UI.WebControls.CheckBox chkOutlook;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtShortDesc;
		Camelot.classes.cUser pUser;

		private void Page_Load(object sender, System.EventArgs e)
		{
			bool oktogo;
			lcomp=(Camelot.classes.cCompany)Session["curCompany"];
			lconts = Utils.get_Comp_Contacts(Session["con"].ToString(),lcomp.Company_ID);
			Camelot.classes.Utils pUtil = new Camelot.classes.Utils();
			pUser = (Camelot.classes.cUser)Session["curUser"];
			oktogo = pUtil.valid_user(pUser);

			if(!oktogo)
			{
				Response.Redirect("../logon.aspx");
			}
			else
			{
				lnote=(Camelot.classes.cNote)Session["curNote"];
				hideErr();
				string err=Request.QueryString["err"];
			
				if(lnote.Note_ID==null || lnote.Note_ID=="" || lnote.Note_ID=="0")
				{
					string note = Request.QueryString["note"];
					lnote.Note_ID = note;
				}
			
				Response.Expires = 0;
				Response.Cache.SetNoStore();
				Response.AppendHeader("Pragma", "no-cache");
			
			
				bool edit = (bool)Session["note_edit"];
				bool nnew = (bool)Session["note_new"];
									
				setenabled(edit);
			
				if(nnew)
				{
					lnote.Note_ID = "0";
					Session["curNote"] = lnote;
					if(!(bool)Session["note_save"])
					{
						pop_combos();
						btnUpdate.Visible = true;
						btnCancel.Visible = true;
						btnEdit.Visible = false;
						btnClose.Visible=false;
			
						Session["note_save"] = true;
					}
				}
				else
				{
					if(edit)
					{
						if(!(bool)Session["note_save"] && (lnote.Note_ID!=null && lnote.Note_ID!=""))
						{
							pop_note(lnote.Note_ID);
						}
				
						btnUpdate.Visible = true;
						btnCancel.Visible = true;
						btnEdit.Visible = false;
						btnClose.Visible=false;
					}
					else
					{
						if(!(bool)Session["note_save"] && (lnote.Note_ID!=null && lnote.Note_ID!=""))
						{
							pop_note(lnote.Note_ID);
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
			}

		}
		private void pop_note(string note_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.saveUtils us = new Camelot.classes.saveUtils();
			string cont = "";

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_company_note";

			cmd.Parameters.Add(
				new SqlParameter("@note_id", note_id));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				lblTitle.Text = rdr["date"].ToString();
				txtDate.Text = rdr["date"].ToString();
				txtDesc.Text = rdr["description"].ToString();
				cont = rdr["CONTACT_ID"].ToString();
				lblUby.Text = get_employeename(Convert.ToInt32(rdr["record_manager"]));
				lblUDate.Text = us.getdate(rdr["Date_entered"].ToString());
				chkOutlook.Checked = (bool)rdr["saved_in_outlook"];
			}
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			pop_contacts(cont);

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

		private void pop_contacts(string cont)
		{
			int ind =0;
			cmbContact.Items.Clear();
			cmbContact.Items.Add("");
			foreach(cContact ct in lconts)
			{
				cmbContact.Items.Add(ct.Contact_Name);
				if(ct.Contact_ID == cont)
				{
					ind = cmbContact.Items.Count-1;
				}
			}
			cmbContact.SelectedIndex = ind;
			
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

		private void setenabled(bool edit)
		{
			txtDate.Enabled=edit;
			txtDesc.Enabled=edit;
			cmbContact.Enabled=edit;
			chkOutlook.Enabled=edit;
		}
		
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			setenabled(true);
			btnUpdate.Visible = true;
			btnCancel.Visible = true;
			btnEdit.Visible = false;
			btnClose.Visible=false;
			Session["note_edit"] = true;
			Session["note_save"] = true;
			Session["note_new"] = false;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			bool nnew = (bool)Session["note_new"];
			Session["note_edit"] = false;
			Session["note_save"] = false;
			Session["note_new"] = false;
			if(nnew)
			{
				Response.Write("<script>window.close();</script>");
			}
			else
			{
				Response.Redirect("notedetails.aspx");
			}
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Session["note_edit"] = false;
			Session["note_save"] = false;
			Session["note_new"] = false;
			Response.Write("<script>window.close();</script>");
		}

		
		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			savenote();
		}

		private void savenote()
		{
			bool oktosave = true;
			string Msg = "";
			int cnt = 0;
			Camelot.classes.saveUtils su = new saveUtils();

						
			if(!su.IsDate(txtDate.Text))
			{
				oktosave=false;
				cnt++;
				if(Msg!="")
				{
					Msg = Msg + ", Date";
				}
				else
				{
					Msg = "Date";
				}
				lblDateStar.Visible=true;
			}
			
			if(oktosave)
			{
				SqlConnection conn = new SqlConnection();
				SqlCommand cmd =  new SqlCommand();
				pUser = (Camelot.classes.cUser)Session["curUser"];
				lnote = (Camelot.classes.cNote)Session["curNote"];

				conn.ConnectionString = (string)Session["Connection"];
				conn.Open();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "update_company_note";

				cmd.Parameters.Add(
					new SqlParameter("@comp_id", lcomp.Company_ID));
				cmd.Parameters.Add(
					new SqlParameter("@note_id", lnote.Note_ID));
				cmd.Parameters.Add(
					new SqlParameter("@date", DateTime.Parse(su.setdate(txtDate.Text))));
				cmd.Parameters.Add(
					new SqlParameter("@contact_id", get_contact(cmbContact.SelectedItem.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@desc", txtDesc.Text));
				cmd.Parameters.Add(
					new SqlParameter("@record_manager", pUser.ID));
				cmd.Parameters.Add(
					new SqlParameter("@inoutlook", su.getCheck(chkOutlook.Checked)));
				cmd.ExecuteNonQuery();
				
				cmd.Dispose();
				conn.Close();
				conn.Dispose();
			
				bool nnew = (bool)Session["note_new"];
				Session["note_edit"] = false;
				Session["note_save"] = false;
				Session["note_new"] = false;
				if(nnew)
				{
					Response.Write("<script>parent.location.reload(true);</script>");
					Response.Write("<script>window.close();</script>");
				}
				else
				{
					Response.Redirect("notedetails.aspx");
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

		public int get_contact(string cont)
		{
			int id = 0;
			
			foreach(cContact ct in lconts)
			{
				if(ct.Contact_Name == cont)
				{
					id = Convert.ToInt32(ct.Contact_ID);
					break;
				}
			}
			return id;
		}

		
		private void pop_combos()
		{
			pop_contacts("");
		}

		private void hideErr()
		{
			lblMessage.Visible = false;
			lblDateStar.Visible=false;
		}
	}
}