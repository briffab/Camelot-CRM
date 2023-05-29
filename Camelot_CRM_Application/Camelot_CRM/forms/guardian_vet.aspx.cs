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
	/// Summary description for guardian_vet.
	/// </summary>
	public class guardian_vet : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.CheckBox chkApp;
		protected System.Web.UI.WebControls.CheckBox chkPhoto;
		protected System.Web.UI.WebControls.CheckBox chkRef;
		protected System.Web.UI.WebControls.CheckBox chkBank;
		protected System.Web.UI.WebControls.CheckBox chkLic;
		protected System.Web.UI.WebControls.CheckBox chkBook;
		protected System.Web.UI.WebControls.CheckBox chkSO;
		protected System.Web.UI.WebControls.Label Label27;
		protected System.Web.UI.WebControls.Label Label31;
		protected System.Web.UI.WebControls.Label Label28;
		protected System.Web.UI.WebControls.TextBox txtNotes;
		protected System.Web.UI.WebControls.CheckBox chkOut;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.Label Label30;
		protected System.Web.UI.WebControls.Button btnClose;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Button btnCancel;
		Camelot.classes.cUser pUser;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Button btnScan;
		protected System.Web.UI.WebControls.CheckBox chkED;
		Camelot.classes.cGuardian lguard;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			bool oktogo;
			Camelot.classes.Utils pUtil = new Camelot.classes.Utils();
			pUser = (Camelot.classes.cUser)Session["curUser"];
			oktogo = pUtil.valid_user(pUser);

            if(!oktogo)
			{
				
				Response.Write("<script>window.close();</script>");
			}
			else
			{
				if (!Page.IsClientScriptBlockRegistered("Vet"))
				{		
					string title="Vetting Scans";
					string height="500";
					string width="630";	

					// use next line for direct with <base target="_self"> between <Head> and </HEAD> 
					string scrp="<script>var rc = new Array(0,0);function doIt(){rc= window.showModalDialog('vettingscans.aspx?Title="+title + "','','dialogHeight:"+height+" px;dialogWidth:"+width+" px;');"+"\n";
					scrp+="__doPostBack('','');}</script>";

					Page.RegisterStartupScript("Vet",scrp);			
					this.btnScan.Attributes.Add("onClick","doIt();");
				}
				
				lguard=(Camelot.classes.cGuardian)Session["curGuardian"];
				hideErr();
				string err=Request.QueryString["err"];

				if(lguard.Guardian_ID==null || lguard.Guardian_ID=="")
				{
					string guard = Request.QueryString["guard"];
					lguard.Guardian_ID = guard;
					Session["curGuardian"] = lguard;
				}
			
				Response.Expires = 0;
				Response.Cache.SetNoStore();
				Response.AppendHeader("Pragma", "no-cache");
			
			
				bool edit = (bool)Session["vet_edit"];
			
				setenabled(edit);
			
				if(edit)
				{
					if(!(bool)Session["vet_save"] && (lguard.Guardian_ID!=null && lguard.Guardian_ID!=""))
					{
						pop_vet(lguard.Guardian_ID);
					}
			
					btnUpdate.Visible = true;
					btnCancel.Visible = true;
					btnEdit.Visible = false;
					btnClose.Visible=false;
				}
				else
				{
					if(!(bool)Session["vet_save"] && (lguard.Guardian_ID!=null && lguard.Guardian_ID!=""))
					{
						pop_vet(lguard.Guardian_ID);
					}
					btnUpdate.Visible = false;
					btnCancel.Visible = false;
					if(pUser.Permission=="1")
					{
						btnEdit.Visible = true;
					}
					else
					{
						btnEdit.Visible = false;
					}
					btnClose.Visible=true;
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
			this.chkOut.CheckedChanged += new System.EventHandler(this.chkOut_CheckedChanged);
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Session["vet_edit"] = false;
			Session["vet_save"] = false;
			Response.Write("<script>window.close();</script>");
		}

		private void pop_vet(string guard)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.Utils us = new Camelot.classes.Utils();
			Camelot.classes.saveUtils su = new Camelot.classes.saveUtils();
			
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_guardian_vet";

			cmd.Parameters.Add(
				new SqlParameter("@guard", guard));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				lblTitle.Text = rdr["guardian"].ToString();
				this.chkApp.Checked = Convert.ToBoolean(rdr["applic_form"].ToString());
				this.chkBank.Checked = Convert.ToBoolean(rdr["bank_util"].ToString());
				this.chkBook.Checked = Convert.ToBoolean(rdr["booklet"].ToString());
				this.chkLic.Checked = Convert.ToBoolean(rdr["license"].ToString());
				this.chkOut.Checked = Convert.ToBoolean(rdr["inout"].ToString());
				this.chkPhoto.Checked = Convert.ToBoolean(rdr["photo_id"].ToString());
				this.chkRef.Checked = Convert.ToBoolean(rdr["ref"].ToString());
				this.chkSO.Checked = Convert.ToBoolean(rdr["stand"].ToString());
				this.chkED.Checked = Convert.ToBoolean(rdr["exec_des"].ToString());
				this.txtNotes.Text = rdr["vnotes"].ToString();
				this.txtDate.Text = su.getdate(rdr["out_date"].ToString());
			}
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			
		}

		private void hideErr()
		{
			this.Label30.Visible = false;
		}

		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			setenabled(true);
			btnUpdate.Visible = true;
			btnCancel.Visible = true;
			btnEdit.Visible = false;
			btnClose.Visible=false;
			Session["vet_edit"] = true;
			Session["vet_save"] = true;
		}

		private void setenabled(bool edit)
		{
			this.chkApp.Enabled = edit;
			this.chkBank.Enabled = edit;
			this.chkBook.Enabled = edit;
			this.chkLic.Enabled = edit;
			this.chkOut.Enabled = edit;
			this.chkPhoto.Enabled = edit;
			this.chkRef.Enabled = edit;
			this.chkSO.Enabled = edit;
			this.chkED.Enabled = edit;
			this.txtDate.Enabled = edit;
			this.txtNotes.Enabled = edit;		
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Session["vet_edit"] = false;
			Session["vet_save"] = false;
			Response.Redirect("guardian_vet.aspx");
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			save_vet(lguard.Guardian_ID);
		}

		private void save_vet(string guard)
		{
			
			bool oktosave = true;
			string Msg = "";
			int cnt = 0;
			Camelot.classes.saveUtils su = new Camelot.classes.saveUtils();

			if(!su.IsDate(su.setdate(this.txtDate.Text)))
			{
				oktosave=false;
				cnt++;
				if(Msg!="")
				{
					Msg = Msg + ", Place in Outlook Date";
				}
				else
				{
					Msg = "Place in Outlook Date";
				}
				Label30.Visible=true;
			}
			if(this.chkOut.Checked && this.txtDate.Text == "")
			{
				oktosave=false;
				cnt++;
				if(Msg!="")
				{
					Msg = Msg + ", A date for Outlook must be provided";
				}
				else
				{
					Msg = "A date for Outlook must be provided";
				}
				Label30.Visible=true;
			}

			if(oktosave)
			{
				SqlConnection conn = new SqlConnection();
				SqlCommand cmd =  new SqlCommand();
				
				pUser = (Camelot.classes.cUser)Session["curUser"];

				conn.ConnectionString = (string)Session["Connection"];
				conn.Open();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "update_vetting";

				cmd.Parameters.Add(
					new SqlParameter("@GUARD", guard));
				cmd.Parameters.Add(
					new SqlParameter("@PHOTO", this.chkPhoto.Checked));
				cmd.Parameters.Add(
					new SqlParameter("@APP", this.chkApp.Checked));
				cmd.Parameters.Add(
					new SqlParameter("@LIC", this.chkLic.Checked));
				cmd.Parameters.Add(
					new SqlParameter("@BANK", this.chkBank.Checked));
				cmd.Parameters.Add(
					new SqlParameter("@REF", this.chkRef.Checked));
				cmd.Parameters.Add(
					new SqlParameter("@BOOK", this.chkBook.Checked));
				cmd.Parameters.Add(
					new SqlParameter("@STAND", this.chkSO.Checked));
				cmd.Parameters.Add(
					new SqlParameter("@EXEC_DES", this.chkED.Checked));
				cmd.Parameters.Add(
					new SqlParameter("@NOTES", this.txtNotes.Text));
				cmd.Parameters.Add(
					new SqlParameter("@INOUT", this.chkOut.Checked));
				cmd.Parameters.Add(
					new SqlParameter("@OUTDATE", DateTime.Parse(su.setdate(this.txtDate.Text))));

				cmd.ExecuteNonQuery();

				cmd.Dispose();
				conn.Close();
				conn.Dispose();

				Session["vet_edit"] = false;
				Session["vet_save"] = false;
				Response.Redirect("guardian_vet.aspx");
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

		private void chkOut_CheckedChanged(object sender, System.EventArgs e)
		{
			if(!this.chkOut.Checked)
			{
				this.txtDate.Text="";
			}
		}

		private void btnScan_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
