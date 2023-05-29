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
	/// Summary description for Bankdetails.
	/// </summary>
	public class Bankdetails : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.TextBox txtAccount;
		protected System.Web.UI.WebControls.TextBox txtAName;
		protected System.Web.UI.WebControls.TextBox txtDDate;
		protected System.Web.UI.WebControls.Label lblAddress;
		protected System.Web.UI.WebControls.TextBox txtAddress1;
		protected System.Web.UI.WebControls.TextBox txtAddress2;
		protected System.Web.UI.WebControls.TextBox txtAddress3;
		protected System.Web.UI.WebControls.Label lblTown;
		protected System.Web.UI.WebControls.TextBox txtTown;
		protected System.Web.UI.WebControls.Label lblPost;
		protected System.Web.UI.WebControls.TextBox txtPost;
		protected System.Web.UI.WebControls.Label lblCounty;
		protected System.Web.UI.WebControls.TextBox txtCounty;
		protected System.Web.UI.WebControls.TextBox txtSortCode;
		protected System.Web.UI.WebControls.Button btnClose;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Label lblMessage;
		Camelot.classes.Utils Utils = new Camelot.classes.Utils();
		Camelot.classes.cGuardian lguard;
		Camelot.classes.cCompany lcomp;
		protected System.Web.UI.WebControls.Label Label29;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		Camelot.classes.cUser pUser;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			bool oktogo;
			string sss;
			Camelot.classes.Utils pUtil = new Camelot.classes.Utils();
			pUser = (Camelot.classes.cUser)Session["curUser"];
			oktogo = pUtil.valid_user(pUser);
			if(!oktogo)
			{
				Response.Redirect("../logon.aspx");
			}
			else
			{
				sss = Request.QueryString["src"];
				if(sss==null)
				{
					sss=Session["src"].ToString();
				}
				if(sss!=null)
				{
					bool edit = (bool)Session["bank_edit"];
					Session["src"]=sss;			
					setenabled(edit);
						
					if(edit)
					{
						if(sss=="guard")
						{
							lguard=(Camelot.classes.cGuardian)Session["curGuardian"];
							if(!(bool)Session["bank_save"] && (lguard.Guardian_ID!=null && lguard.Guardian_ID!=""))
							{
								popguardbank(lguard.Guardian_ID,lguard.Guardian_Name);
							}
						}
						else
						{
							lcomp=(Camelot.classes.cCompany)Session["curCompany"];
							if(!(bool)Session["bank_save"] && (lcomp.Company_ID!=null && lcomp.Company_ID!=""))
							{
								popcompbank(lcomp.Company_ID, lcomp.Company_Name);
							}
						}
							
						Session["bank_save"]=true;
						btnUpdate.Visible = true;
						btnCancel.Visible = true;
						btnEdit.Visible = false;
						btnClose.Visible=false;
					}
					else
					{
						if(sss=="guard")
						{
							lguard=(Camelot.classes.cGuardian)Session["curGuardian"];
							if(!(bool)Session["bank_save"] && (lguard.Guardian_ID!=null && lguard.Guardian_ID!=""))
							{
								popguardbank(lguard.Guardian_ID, lguard.Guardian_Name);
							}
						}
						else
						{
							lcomp=(Camelot.classes.cCompany)Session["curCompany"];
							if(!(bool)Session["bank_save"] && (lcomp.Company_ID!=null && lcomp.Company_ID!=""))
							{
								popcompbank(lcomp.Company_ID, lcomp.Company_Name);
							}
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
						hideError();
					}
				}
			}
		}

		private void popguardbank(string guard_id, string guard_name)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.Utils us = new Camelot.classes.Utils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_guardian_bank";

			cmd.Parameters.Add(
				new SqlParameter("@guard_id", guard_id));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				lblTitle.Text = guard_name;
				txtSortCode.Text = rdr["sortcode"].ToString();
				txtAccount.Text = rdr["accountnumber"].ToString();
				txtAName.Text = rdr["accountname"].ToString();
				txtAddress1.Text = rdr["housenumber"].ToString();
				txtAddress2.Text = rdr["streetname"].ToString();
				txtAddress3.Text = rdr["address4"].ToString();
				txtTown.Text = rdr["city"].ToString();
				txtPost.Text = rdr["postalcode"].ToString();
				txtCounty.Text = rdr["county"].ToString();
				txtDDate.Text = rdr["debit_day"].ToString();
			}

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

		}

		private void popcompbank(string comp_id, string comp_name)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.Utils us = new Camelot.classes.Utils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_company_bank";

			cmd.Parameters.Add(
				new SqlParameter("@comp_id", comp_id));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				lblTitle.Text = comp_name;
				txtSortCode.Text = rdr["sortcode"].ToString();
				txtAccount.Text = rdr["accountnumber"].ToString();
				txtAName.Text = rdr["accountname"].ToString();
				txtAddress1.Text = rdr["housenumber"].ToString();
				txtAddress2.Text = rdr["streetname"].ToString();
				txtAddress3.Text = rdr["address4"].ToString();
				txtTown.Text = rdr["city"].ToString();
				txtPost.Text = rdr["postalcode"].ToString();
				txtCounty.Text = rdr["county"].ToString();
				txtDDate.Text = rdr["debit_day"].ToString();
			}

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

		}

		private void setenabled(bool edit)
		{
			
			txtSortCode.Enabled = edit;
			txtAccount.Enabled = edit;
			txtAName.Enabled = edit;
			txtAddress1.Enabled = edit;
			txtAddress2.Enabled = edit;
			txtAddress3.Enabled = edit;
			txtTown.Enabled = edit;
			txtPost.Enabled = edit;
			txtCounty.Enabled = edit;
			txtDDate.Enabled = edit;
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
			Session["bank_edit"] = false;
			Session["bank_save"] = false;
			Response.Write("<script>window.close();</script>");
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Session["bank_edit"] = false;
			Session["bank_save"] = false;
			Response.Redirect("bankdetails.aspx");
		}

		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			/*setenabled(true);
			btnCancel.Visible = true;
			btnUpdate.Visible = true;
			btnEdit.Visible = false;
			btnClose.Visible=false;*/
			Session["bank_edit"] = true;
			Session["bank_save"] = false;
			Response.Redirect("bankdetails.aspx");
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			string sss;
			sss = Session["src"].ToString();
			bool oktosave=true;

			if(!char.IsNumber(Convert.ToChar(txtDDate.Text)) || Convert.ToInt32(txtDDate.Text) >31)
			{
				oktosave=false;
				Label29.Visible=true;
			}
			if(!char.IsNumber(Convert.ToChar(txtSortCode.Text)))
			{
				oktosave=false;
				Label2.Visible=true;
			}
			if(!char.IsNumber(Convert.ToChar(txtAccount.Text)))
			{
				oktosave=false;
				Label1.Visible=true;
			}
			if(oktosave)
			{
				if(sss!=null)
				{
					if(sss=="guard")
					{
						saveguardbank();
					}
					else
					{
						savecompbank();
					}
				}
				Response.Redirect("bankdetails.aspx");
			}
			else
			{
				lblMessage.Text = "Some data is in the wrong format or incorrect";
				lblMessage.Visible=true;
			}
		}

		private void saveguardbank()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "update_guardian_bank";

			cmd.Parameters.Add(
				new SqlParameter("@guard_id", lguard.Guardian_ID));
			cmd.Parameters.Add(
				new SqlParameter("@sortcode", txtSortCode.Text));
			cmd.Parameters.Add(
				new SqlParameter("@account", txtAccount.Text));
			cmd.Parameters.Add(
				new SqlParameter("@aname", txtAName.Text));
			cmd.Parameters.Add(
				new SqlParameter("@dday", txtDDate.Text));
			cmd.Parameters.Add(
				new SqlParameter("@address1", txtAddress1.Text));
			cmd.Parameters.Add(
				new SqlParameter("@address2", txtAddress2.Text));
			cmd.Parameters.Add(
				new SqlParameter("@address3", txtAddress3.Text));
			cmd.Parameters.Add(
				new SqlParameter("@city", txtTown.Text));
			cmd.Parameters.Add(
				new SqlParameter("@postcode", txtPost.Text));
			cmd.Parameters.Add(
				new SqlParameter("@county", txtCounty.Text));
			
			cmd.ExecuteNonQuery();
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			
			Session["bank_edit"] = false;
			Session["bank_save"] = false;
		}

		private void savecompbank()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "update_COMPANY_bank";

			cmd.Parameters.Add(
				new SqlParameter("@comp_id", lcomp.Company_ID));
			cmd.Parameters.Add(
				new SqlParameter("@sortcode", txtSortCode.Text));
			cmd.Parameters.Add(
				new SqlParameter("@account", txtAccount.Text));
			cmd.Parameters.Add(
				new SqlParameter("@aname", txtAName.Text));
			cmd.Parameters.Add(
				new SqlParameter("@dday", txtDDate.Text));
			cmd.Parameters.Add(
				new SqlParameter("@address1", txtAddress1.Text));
			cmd.Parameters.Add(
				new SqlParameter("@address2", txtAddress2.Text));
			cmd.Parameters.Add(
				new SqlParameter("@address3", txtAddress3.Text));
			cmd.Parameters.Add(
				new SqlParameter("@city", txtTown.Text));
			cmd.Parameters.Add(
				new SqlParameter("@postcode", txtPost.Text));
			cmd.Parameters.Add(
				new SqlParameter("@county", txtCounty.Text));
			
			cmd.ExecuteNonQuery();
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			
			Session["bank_edit"] = false;
			Session["bank_save"] = false;
		}
	
		private void hideError()
		{
			Label1.Visible=false;
			Label2.Visible=false;
			Label29.Visible=false;
		}
	}
}
