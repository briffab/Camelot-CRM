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
	/// Summary description for applicantdetails.
	/// </summary>
	public class placed_applicantdetails_ire : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblfactype;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label lblfacdesc;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Button btnClose;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtFname;
		protected System.Web.UI.WebControls.TextBox txtLname;
		protected System.Web.UI.WebControls.DropDownList cmbGender;
		protected System.Web.UI.WebControls.TextBox txtAddr1;
		protected System.Web.UI.WebControls.TextBox txtAddr2;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.TextBox txtAddr3;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.TextBox txtPcode;
		protected System.Web.UI.WebControls.TextBox txtTown;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.TextBox txtCounty;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.TextBox txtPhone;
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.TextBox txtWkPhone;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.TextBox txtMbPhone;
		protected System.Web.UI.WebControls.Label Label22;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.TextBox txtDOB;
		protected System.Web.UI.WebControls.TextBox txtNat;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label23;
		protected System.Web.UI.WebControls.TextBox txtOccup;
		protected System.Web.UI.WebControls.Label Label24;
		protected System.Web.UI.WebControls.Label Label25;
		protected System.Web.UI.WebControls.TextBox txtRem;
		protected System.Web.UI.WebControls.Label Label26;
		protected System.Web.UI.WebControls.TextBox txtWTlive;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.DropDownList cmbTrans;
		protected System.Web.UI.WebControls.DropDownList cmbPets;
		protected System.Web.UI.WebControls.TextBox txtAddr4;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label lblApp;
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
		protected System.Web.UI.WebControls.CheckBox chkOut;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.TextBox txtNotes;

		private Camelot.classes.cUser pUser;
		protected System.Web.UI.WebControls.Label Label29;
		protected System.Web.UI.WebControls.Label Label30;
		protected System.Web.UI.WebControls.TextBox txtRel;
		protected System.Web.UI.WebControls.TextBox txtEth;
		protected System.Web.UI.WebControls.DropDownList cmbCrim;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtEmpl;
		protected System.Web.UI.WebControls.CheckBox chkED;
		private string app_con;
			
		private void Page_Load(object sender, System.EventArgs e)
		{
			string app_id;
			bool oktogo;
			Camelot.classes.Utils pUtil = new Camelot.classes.Utils();
			pUser = (Camelot.classes.cUser)Session["curUser"];
			oktogo = pUtil.valid_user(pUser);
			app_con =Session["app_con"].ToString();
			

			if(!oktogo)
			{
				Response.Redirect("../logon.aspx");
			}
			else
			{
				if(!Page.IsPostBack)
				{
					Session["app_edit"] = false;
					Session["app_save"] = false;
					Session["app_new"] = false;
					setvisible(true);
					hideErr();
					app_id = Session["app_id"].ToString();
					if(app_id == null || app_id == "")
					{
						app_id = Request.QueryString["app_id"];
						Session["app_id"] = app_id;
					}
					pop_app(app_id);
					setenabled(false);
				}
				else
				{
					bool placed = (bool)Session["place_app"];
					if(placed)
					{
						close_page();
					}
				}
			}
		}

		private void pop_app(string app_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.saveUtils us = new Camelot.classes.saveUtils();
	
			string gen ="";
			string trans ="";
			string pets ="";
			string crim ="";
			
			conn.ConnectionString = app_con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_applicant";

			cmd.Parameters.Add(
				new SqlParameter("@app_id", app_id));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				this.txtWTlive.Text = rdr["wtlive"].ToString();
				this.txtLname.Text = rdr["sname"].ToString();
				this.txtFname.Text = rdr["fname"].ToString();
				gen = rdr["gender"].ToString();
				this.txtAddr1.Text = rdr["addr1"].ToString();
				this.txtAddr2.Text = rdr["addr2"].ToString();
				this.txtAddr3.Text = rdr["addr3"].ToString();
				this.txtAddr4.Text = rdr["addr4"].ToString();
				this.txtPcode.Text = rdr["pcode"].ToString();
				this.txtTown.Text = rdr["town"].ToString();
				this.txtCounty.Text = rdr["county"].ToString();
				this.txtPhone.Text = rdr["phone"].ToString();
				this.txtWkPhone.Text = rdr["wkphone"].ToString();
				this.txtMbPhone.Text = rdr["mbphone"].ToString();
				this.txtEmail.Text = rdr["email"].ToString();
				this.txtDOB.Text = us.getdate(rdr["dob"].ToString());
				this.txtNat.Text = rdr["nationality"].ToString();
				this.txtOccup.Text = rdr["occup"].ToString();
				this.txtEmpl.Text = rdr["employment"].ToString();
				trans = rdr["trans"].ToString();
				pets = rdr["pets"].ToString();
				crim = rdr["criminal"].ToString();
				this.txtRel.Text = rdr["religion"].ToString();
				this.txtEth.Text = rdr["ethnic"].ToString();
				this.txtRem.Text = rdr["remarks"].ToString();
				this.lblApp.Text = rdr["date_entered"].ToString();
				this.chkPhoto.Checked = Convert.ToBoolean(rdr["photo_id"]);
				this.chkApp.Checked = Convert.ToBoolean(rdr["applic_form"]);
				this.chkLic.Checked = Convert.ToBoolean(rdr["License"]);
				this.chkBank.Checked = Convert.ToBoolean(rdr["bank_util"]);
				this.chkRef.Checked = Convert.ToBoolean(rdr["ref"]);
				this.chkBook.Checked = Convert.ToBoolean(rdr["booklet"]);
				this.chkSO.Checked = Convert.ToBoolean(rdr["stand"]);
				this.chkOut.Checked = Convert.ToBoolean(rdr["inout"]);
				this.txtNotes.Text = rdr["notes"].ToString();
				this.txtDate.Text = us.getdate(rdr["out_date"].ToString());

			}

			pop_combos(gen, trans, pets,crim);
			set_app();
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

			

		}

		private void hideErr()
		{
			this.Label16.Visible = false;
			this.Label30.Visible = false;
		}

		private void pop_combos(string gen, string trans, string pets, string crim)
		{
			int ind = 0;
			int cnt = 0;
			foreach(ListItem li in this.cmbGender.Items)
			{
				if(li.Value == gen)
				{
					ind = cnt;
				}
				cnt++;
			}
			this.cmbGender.SelectedIndex = ind;

			ind = 0;
			cnt = 0;
			foreach(ListItem li in this.cmbTrans.Items)
			{
				if(li.Value == trans)
				{
					ind = cnt;
				}
				cnt++;
			}
			this.cmbTrans.SelectedIndex = ind;

			ind = 0;
			cnt = 0;
			foreach(ListItem li in this.cmbPets.Items)
			{
				if(li.Value == pets)
				{
					ind = cnt;
				}
				cnt++;
			}
			this.cmbPets.SelectedIndex = ind;

			ind = 0;
			cnt = 0;
			foreach(ListItem li in this.cmbCrim.Items)
			{
				if(li.Value == crim)
				{
					ind = cnt;
				}
				cnt++;
			}
			this.cmbCrim.SelectedIndex = ind;
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
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Session["app_edit"] = false;
			Session["app_save"] = false;
			Session["app_id"] = "";
			Response.Write("<script>window.close();</script>");
		}

		private void close_page()
		{
			Session["app_edit"] = false;
			Session["app_save"] = false;
			Session["app_id"] = "";
			Response.Write("<script>window.close();</script>");
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Session["app_edit"] = false;
			Session["app_save"] = false;
			Response.Redirect("placed_applicatdetails_ire.aspx");
			
		}

		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			setenabled(true);
			setvisible(false);
			Session["app_edit"] = true;
			Session["app_save"] = true;
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			hideErr();
			savedetails();
		}

		private void savedetails()
		{
			bool oktosave = true;
			string Msg = "";
			int cnt = 0;
			Camelot.classes.saveUtils su = new saveUtils();

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
				Label16.Visible=true;
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
			if(!su.IsDate(su.setdate(txtDate.Text)))
			{
				oktosave=false;
				cnt++;
				if(Msg!="")
				{
					Msg = Msg + ", Date for Outlook";
				}
				else
				{
					Msg = "Date for Outlook";
				}
				Label30.Visible=true;
			}

			if(oktosave)
			{
				SqlConnection conn = new SqlConnection();
				SqlCommand cmd =  new SqlCommand();
				Camelot.classes.saveUtils us = new Camelot.classes.saveUtils();
			
			
				conn.ConnectionString = app_con;
				conn.Open();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "save_applicant";

				cmd.Parameters.Add(
					new SqlParameter("@app_id", Session["app_id"].ToString()));
				cmd.Parameters.Add(
					new SqlParameter("@sname", this.txtLname.Text));
				cmd.Parameters.Add(
					new SqlParameter("@fname", this.txtFname.Text));
				cmd.Parameters.Add(
					new SqlParameter("@gender", this.cmbGender.SelectedValue));
				cmd.Parameters.Add(
					new SqlParameter("@addr1", this.txtAddr1.Text));
				cmd.Parameters.Add(
					new SqlParameter("@addr2", this.txtAddr2.Text));
				cmd.Parameters.Add(
					new SqlParameter("@addr3", this.txtAddr3.Text));
				cmd.Parameters.Add(
					new SqlParameter("@addr4", this.txtAddr4.Text));
				cmd.Parameters.Add(
					new SqlParameter("@pcode", this.txtPcode.Text));
				cmd.Parameters.Add(
					new SqlParameter("@town", this.txtTown.Text));
				cmd.Parameters.Add(
					new SqlParameter("@county", this.txtCounty.Text));
				cmd.Parameters.Add(
					new SqlParameter("@phone", this.txtPhone.Text));
				cmd.Parameters.Add(
					new SqlParameter("@wkphone", this.txtWkPhone.Text));
				cmd.Parameters.Add(
					new SqlParameter("@mbphone", this.txtMbPhone.Text));
				cmd.Parameters.Add(
					new SqlParameter("@email", this.txtEmail.Text));
				cmd.Parameters.Add(
					new SqlParameter("@dob", DateTime.Parse(su.setdate(this.txtDOB.Text))));
				cmd.Parameters.Add(
					new SqlParameter("@nat", this.txtNat.Text));
				cmd.Parameters.Add(
					new SqlParameter("@live", this.txtWTlive.Text));
				cmd.Parameters.Add(
					new SqlParameter("@occup", this.txtOccup.Text));
				cmd.Parameters.Add(
					new SqlParameter("@employment", this.txtEmpl.Text));
				cmd.Parameters.Add(
					new SqlParameter("@trans", this.cmbTrans.SelectedValue));
				cmd.Parameters.Add(
					new SqlParameter("@pets", this.cmbPets.SelectedValue));
				cmd.Parameters.Add(
					new SqlParameter("@criminal", this.cmbCrim.SelectedValue));
				cmd.Parameters.Add(
					new SqlParameter("@religion", this.txtRel.Text));
				cmd.Parameters.Add(
					new SqlParameter("@ethnic", this.txtEth.Text));
				cmd.Parameters.Add(
					new SqlParameter("@REM", this.txtRem.Text));
				cmd.Parameters.Add(
					new SqlParameter("@photo", this.chkPhoto.Checked));
				cmd.Parameters.Add(
					new SqlParameter("@app", this.chkApp.Checked));
				cmd.Parameters.Add(
					new SqlParameter("@lic", this.chkLic.Checked));
				cmd.Parameters.Add(
					new SqlParameter("@bank", this.chkBank.Checked));
				cmd.Parameters.Add(
					new SqlParameter("@ref", this.chkRef.Checked));
				cmd.Parameters.Add(
					new SqlParameter("@book", this.chkBook.Checked));
				cmd.Parameters.Add(
					new SqlParameter("@stand", this.chkSO.Checked));
				cmd.Parameters.Add(
					new SqlParameter("@EXEC_DES", this.chkED.Checked));
				cmd.Parameters.Add(
					new SqlParameter("@Notes", this.txtNotes.Text));
				cmd.Parameters.Add(
					new SqlParameter("@outdate", DateTime.Parse(su.setdate(this.txtDate.Text))));
				cmd.Parameters.Add(
					new SqlParameter("@out", this.chkOut.Checked));


				cmd.ExecuteNonQuery();

				/*	if(this.chkOut.Checked)
					{
						Camelot.classes.add_calendar ad = new add_calendar();
						ad.add_cal();
					}
				*/
				Session["app_edit"] = false;
				Session["app_save"] = false;
				Response.Redirect("applicantdetails_uk.aspx");
				
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

		private void setenabled(bool edit)
		{
			this.txtWTlive.Enabled = edit;
			this.txtFname.Enabled = edit;
			this.txtLname.Enabled = edit;
			this.cmbGender.Enabled = edit;
			this.txtAddr1.Enabled = edit;
			this.txtAddr2.Enabled = edit;
			this.txtAddr3.Enabled = edit;
			this.txtAddr4.Enabled = edit;
			this.txtPcode.Enabled = edit;
			this.txtTown.Enabled = edit;
			this.txtCounty.Enabled = edit;
			this.txtPhone.Enabled = edit;
			this.txtWkPhone.Enabled = edit;
			this.txtMbPhone.Enabled = edit;
			this.txtEmail.Enabled = edit;
			this.txtDOB.Enabled = edit;
			this.cmbTrans.Enabled = edit;
			this.cmbPets.Enabled = edit;
			this.cmbCrim.Enabled = edit;
			this.txtOccup.Enabled = edit;
			this.txtEmpl.Enabled = edit;
			this.txtEth.Enabled = edit;
			this.txtRel.Enabled = edit;
			this.txtRem.Enabled = edit;
			this.txtNat.Enabled = edit;
			this.chkApp.Enabled = edit;
			this.chkPhoto.Enabled = edit;
			this.chkRef.Enabled = edit;
			this.chkBank.Enabled = edit;
			this.chkLic.Enabled = edit;
			this.chkBook.Enabled = edit;
			this.chkSO.Enabled = edit;
			this.txtNotes.Enabled = edit;
			this.chkOut.Enabled = edit;
			this.txtDate.Enabled = edit;
			this.chkED.Enabled=edit;
		}

		private void setvisible(bool vis)
		{
			this.btnCancel.Visible = !vis;
			this.btnUpdate.Visible = !vis;
			this.btnEdit.Visible = vis;
			this.btnClose.Visible = vis;
		}

		private void chkOut_CheckedChanged(object sender, System.EventArgs e)
		{
			if(!this.chkOut.Checked)
			{
				this.txtDate.Text = "";
			}
		}

		private void btnPlace_Click(object sender, System.EventArgs e)
		{
			

		}

		private void set_app()
		{
			Camelot.classes.cApplicant app = new cApplicant();
			app.App_id = Session["app_id"].ToString();
			app.sName = this.txtLname.Text;
			app.fName = this.txtFname.Text;
			app.Gender = this.cmbGender.SelectedValue;
			app.Addr1 = this.txtAddr1.Text;
			app.Addr2 = this.txtAddr2.Text;
			app.Addr3 = this.txtAddr3.Text;
			app.Addr4 = this.txtAddr4.Text;
			app.Pcode = this.txtPcode.Text;
			app.Town = this.txtTown.Text;
			app.County = this.txtCounty.Text;
			app.Phone = this.txtPhone.Text;
			app.Wkphone = this.txtWkPhone.Text;
			app.Mbphone = this.txtMbPhone.Text;
			app.Email = this.txtEmail.Text;
			app.DOB= this.txtDOB.Text;
			app.Nat = this.txtNat.Text;
			app.WTlive = this.txtWTlive.Text;
			app.Occup = this.txtOccup.Text;
			app.Employment = this.txtEmpl.Text;
			app.Trans = this.cmbTrans.SelectedValue;
			app.Pets = this.cmbPets.SelectedValue;
			app.Criminal = this.cmbCrim.SelectedValue;
			app.Religion = this.txtRel.Text;
			app.Ethnic=this.txtEth.Text;			
			app.Remarks = this.txtRem.Text;
			app.Date = this.lblApp.Text;
			app.Photo = Convert.ToInt32(this.chkPhoto.Checked);
			app.Applic = Convert.ToInt32(this.chkApp.Checked);
			app.Lic = Convert.ToInt32(this.chkLic.Checked);
			app.Bank = Convert.ToInt32(this.chkBank.Checked);
			app.Ref = Convert.ToInt32(this.chkRef.Checked);
			app.Book = Convert.ToInt32(this.chkBook.Checked);
			app.Stand = Convert.ToInt32(this.chkSO.Checked);
			app.Notes = Convert.ToString(this.txtNotes.Text);
			app.InOut = Convert.ToInt32(this.chkOut.Checked);
			app.OutDate = Convert.ToString(this.txtDate.Text);

			Session["app"] = app;
		}
	}
}
