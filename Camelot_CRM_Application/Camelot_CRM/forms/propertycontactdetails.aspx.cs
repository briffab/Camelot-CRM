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
	/// Summary description for propertycontactdetails.
	/// </summary>
	public class propertycontactdetails : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblfacdesc;
		protected System.Web.UI.WebControls.Label LabelName;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label lblJob;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.ListBox lbTypes;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblWkTel;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label lblEmail;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtnotes;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Label lblFax;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label lblMob;
		protected System.Web.UI.WebControls.Button btnClose;
		Camelot.classes.cContact lcont;
		Camelot.classes.cProperty lprop;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblComp;
		protected System.Web.UI.WebControls.Button btnRemove;
		Camelot.classes.cUser pUser;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			bool oktogo;
			Camelot.classes.Utils pUtil = new Camelot.classes.Utils();
			pUser = (Camelot.classes.cUser)Session["curUser"];
			lprop = (Camelot.classes.cProperty)Session["curProperty"];
			oktogo = pUtil.valid_user(pUser);
			if(!oktogo)
			{
				Response.Redirect("../logon.aspx");
			}
			else
			{
				lcont=(Camelot.classes.cContact)Session["curCont"];
				string err=Request.QueryString["err"];
			
			{
				string cont = Request.QueryString["cid"];
				if(cont != null)
				{
					lcont.Contact_ID = cont;
				}
			}
			
				Response.Expires = 0;
				Response.Cache.SetNoStore();
				Response.AppendHeader("Pragma", "no-cache");
			
			
				bool edit = (bool)Session["cont_edit"];
				setenabled(edit);
			
				
				if(edit)
				{
					if(!(bool)Session["cont_save"] && (lcont.Contact_ID!=null && lcont.Contact_ID!=""))
					{
						pop_cont(lcont.Contact_ID);
					}
			
					btnUpdate.Visible = true;
					btnCancel.Visible = true;
					btnEdit.Visible = false;
					btnClose.Visible=false;
					btnRemove.Visible=false;
				}
				else
				{
					if(!(bool)Session["cont_save"] && (lcont.Contact_ID!=null && lcont.Contact_ID!=""))
					{
						pop_cont(lcont.Contact_ID);
						
					}
					btnUpdate.Visible = false;
					btnCancel.Visible = false;
					if(pUser.Permission=="1")
					{
						btnEdit.Visible = true;
						btnRemove.Visible=true;
					}
					else
					{
						btnEdit.Visible=false;
						btnRemove.Visible=false;
					}
					btnClose.Visible=true;
				}
				Session["curCont"] = lcont;
				this.txtnotes.Enabled = false;
			}
		}

		private void pop_cont(string cont_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.saveUtils su = new Camelot.classes.saveUtils();
			

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_Pcontact";

			cmd.Parameters.Add(
				new SqlParameter("@cont_id", cont_id));
			cmd.Parameters.Add(
				new SqlParameter("@prop_id", lprop.Property_ID));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				LabelName.Text = rdr["name"].ToString();
				lblComp.Text = rdr["comp"].ToString();
				lblJob.Text = rdr["JT"].ToString();
				lblWkTel.Text = rdr["wktel"].ToString();
				lblFax.Text = rdr["fax"].ToString();
				lblMob.Text = rdr["mobile"].ToString();
				lblEmail.Text = rdr["email"].ToString();
				txtnotes.Text = rdr["notes"].ToString();
			}
			rdr.NextResult();			
			pop_conttype(rdr);
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			lcont.Contact_Name = LabelName.Text;
			Session["curContact"] = lcont;
		}

		private void pop_conttype(SqlDataReader rs)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.Utils us = new Camelot.classes.Utils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_conttypes";

			rdr = cmd.ExecuteReader();

			lbTypes.DataSource = rdr;
			lbTypes.DataTextField = "description";
			lbTypes.DataValueField = "contact_type";
			lbTypes.DataBind();
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

			while(rs.Read())
			{
				foreach(ListItem lbi in lbTypes.Items)
				{
					if(lbi.Value == rs["contact_type"].ToString())
					{
						lbi.Selected=true;
					}
				}
			
			}
		}

		private void RemCont(string cont, string prop)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();			

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "rem_objcont";

			cmd.Parameters.Add(
				new SqlParameter("@cont_id", cont));
			cmd.Parameters.Add(
				new SqlParameter("@prop_id", prop));

			cmd.ExecuteNonQuery();

			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
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
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnRemove_Click(object sender, System.EventArgs e)
		{
			RemCont(lcont.Contact_ID, lprop.Property_ID);
			Response.Write("<script>window.close();</script>");
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.close();</script>");
		}

		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			setenabled(true);
			btnUpdate.Visible = true;
			btnCancel.Visible = true;
			btnEdit.Visible = false;
			btnClose.Visible=false;
			btnRemove.Visible=false;
			Session["cont_edit"] = true;
			Session["cont_save"] = true;
			Session["cont_new"] = false;
		}

		private void setenabled(bool edit)
		{
			this.lbTypes.Enabled=edit;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Session["cont_edit"] = false;
			Session["cont_save"] = false;
			Session["cont_new"] = false;
			
			Response.Redirect("propertycontactdetails.aspx");
			
		}
		private void saveCtypes(string cont, string prop)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "del_OBJCONT";
			cmd.Parameters.Add(
				new SqlParameter("@cont_id", cont));
			cmd.Parameters.Add(
				new SqlParameter("@prop_id", prop));

			cmd.ExecuteNonQuery();
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

			foreach(ListItem li in this.lbTypes.Items)
			{
				if(li.Selected)
				{
					saveCtype(prop, cont, li.Value.ToString());
				}
			}
		}


		private void saveCtype(string prop, string cont, string type)
		{
			pUser = (Camelot.classes.cUser)Session["curUser"];
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "add_OBJCONT";

			cmd.Parameters.Add(
				new SqlParameter("@cont_id", cont));
			cmd.Parameters.Add(
				new SqlParameter("@prop_id", prop));
			cmd.Parameters.Add(
				new SqlParameter("@CONT_TYPE", type));
			cmd.ExecuteNonQuery();
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

		}
		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			saveCtypes(lcont.Contact_ID, lprop.Property_ID);
			Session["cont_edit"] = false;
			Session["cont_save"] = false;
			Session["cont_new"] = false;
			Response.Redirect("propertycontactdetails.aspx");
		}
	}
}
