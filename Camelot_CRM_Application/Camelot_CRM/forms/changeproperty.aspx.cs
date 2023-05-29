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
	/// Summary description for changeowner.
	/// </summary>
	public class changeproperty : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label lblFCompany;
		protected System.Web.UI.WebControls.TextBox txtCompany;
		protected System.Web.UI.WebControls.Button btnCserch;
		protected System.Web.UI.WebControls.ListBox lbCompanies;
		protected System.Web.UI.WebControls.Label lblCompany;
		protected System.Web.UI.WebControls.TextBox txtSCompany;
		protected System.Web.UI.WebControls.Label lblCompID;
		protected System.Web.UI.WebControls.TextBox txtCompID;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtEffDate;
		protected System.Web.UI.WebControls.Button btnCancel;
		Camelot.classes.cProperty lprop;
		Camelot.classes.cUser pUser;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.TextBox txtProperty;
		protected System.Web.UI.WebControls.ListBox lbProperties;
		protected System.Web.UI.WebControls.Label lblProperty;
		protected System.Web.UI.WebControls.TextBox txtSProp;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtRoom;
		protected System.Web.UI.WebControls.Label Label25;
		protected System.Web.UI.WebControls.CheckBox chkhead;
		protected System.Web.UI.WebControls.TextBox txtPropID;
		Camelot.classes.cGuardian lguard = new cGuardian();
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			pop_prop("");
			hideErr();

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
			this.btnCserch.Click += new System.EventHandler(this.btnCserch_Click);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnCserch_Click(object sender, System.EventArgs e)
		{
			pop_prop(txtProperty.Text);
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.close();</script>");
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			saveproperty();
		}

		private void saveproperty()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			pUser = (Camelot.classes.cUser)Session["curUser"];
			lguard= (Camelot.classes.cGuardian)Session["curGuardian"];
			lprop=(Camelot.classes.cProperty)Session["curProperty"];
			Camelot.classes.saveUtils su = new Camelot.classes.saveUtils();
			bool oktosave = true;
			string Msg = "";
			int cnt = 0;


			if(txtPropID.Text=="")
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
				Label15.Visible=true;
			}

			if(!su.IsDate(txtEffDate.Text))
			{
				oktosave=false;
				cnt++;
				if(Msg!="")
				{
					Msg = Msg + ", Effective Date";
				}
				else
				{
					Msg = "Effective Date";
				}
				Label14.Visible=true;
			}

			if(oktosave)
			{
				conn.ConnectionString = (string)Session["Connection"];
				conn.Open();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "change_property";

				cmd.Parameters.Add(
					new SqlParameter("@OPROP_ID", lprop.Property_ID));
				cmd.Parameters.Add(
					new SqlParameter("@NPROP_ID", txtPropID.Text));
				cmd.Parameters.Add(
					new SqlParameter("@GUARD_ID", lguard.Guardian_ID));
				cmd.Parameters.Add(
					new SqlParameter("@STAT_EFF", DateTime.Parse(su.getdate(txtEffDate.Text))));
				cmd.Parameters.Add(
					new SqlParameter("@record_modifier", pUser.ID));
				cmd.Parameters.Add(
					new SqlParameter("@main", chkhead.Checked));
				cmd.Parameters.Add(
					new SqlParameter("@ROOM", txtRoom.Text));
				cmd.ExecuteNonQuery();

				
				cmd.Dispose();
				conn.Close();
				conn.Dispose();

				Session["CurProperty"] = lprop;
				Response.Write("<script>window.close();</script>");
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

		private void hideErr()
		{
			lblMessage.Visible = false;
			Label14.Visible=false;
			Label15.Visible=false;
		}

		private void pop_prop(string comp)
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
				new SqlParameter("@SEARCH", comp));

			rdr = cmd.ExecuteReader();

			lbProperties.DataSource = rdr;
			lbProperties.DataTextField = "prop_dets";
			lbProperties.DataValueField = "prop_id";
			lbProperties.DataBind();
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}
	}
}
