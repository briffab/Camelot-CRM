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
using cc = Camelot.classes;
using System.Data.SqlClient;

namespace Camelot.forms
{
	/// <summary>
	/// Summary description for placeGuard.
	/// </summary>
	public class placeGuard_ire : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lbldate;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Button btnPlace;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblGName;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.DropDownList cmbProp;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtRoom;
		
		private cc.cApplicant app;
		private string app_con;
		Camelot.classes.cUser pUser;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				pop_props();
				hideErr();
			}
			app_con  = Session["app_con"].ToString();
			app = (cc.cApplicant)Session["app"];
		}

		private void hideErr()
		{
			this.Label11.Visible = false;
		}

		private void pop_props()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			Camelot.classes.Utils us = new Camelot.classes.Utils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_placement_props";

			this.cmbProp.DataSource = cmd.ExecuteReader();
			cmbProp.DataTextField = "OBJECT_NAME";
			cmbProp.DataValueField = "OBJECT_ID";
			this.cmbProp.DataBind();
			
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
			this.cmbProp.SelectedIndexChanged += new System.EventHandler(this.cmbProp_SelectedIndexChanged);
			this.btnPlace.Click += new System.EventHandler(this.btnPlace_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnPlace_Click(object sender, System.EventArgs e)
		{
			save_guard();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Session["place_app"] = false;
			Response.Write("<script>window.close();</script>");
		}

		private void save_guard()
		{
			string guard = "";
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
					Msg = Msg + ", Date of Placement";
				}
				else
				{
					Msg = "Date of Placement";
				}
				Label11.Visible=true;
			}


			if(oktosave)
			{
				SqlConnection conn = new SqlConnection();
				SqlCommand cmd =  new SqlCommand();
				SqlDataReader rdr;
				
				pUser = (Camelot.classes.cUser)Session["curUser"];

				conn.ConnectionString = (string)Session["Connection"];
				conn.Open();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "update_guardian";

				cmd.Parameters.Add(
					new SqlParameter("@prop_id", this.cmbProp.SelectedValue));
				cmd.Parameters.Add(
					new SqlParameter("@Guard_ID", "0"));
				cmd.Parameters.Add(
					new SqlParameter("@status_id", "2"));
				cmd.Parameters.Add(
					new SqlParameter("@title", ""));
				cmd.Parameters.Add(
					new SqlParameter("@firstname", app.fName));
				cmd.Parameters.Add(
					new SqlParameter("@initials", ""));
				cmd.Parameters.Add(
					new SqlParameter("@lastname", app.sName));
				cmd.Parameters.Add(
					new SqlParameter("@dob", su.setdate(app.DOB)));
				cmd.Parameters.Add(
					new SqlParameter("@nat", su.ToTitle(app.Nat)));
				cmd.Parameters.Add(
					new SqlParameter("@sex", app.Gender));
				cmd.Parameters.Add(
					new SqlParameter("@wktel", app.Wkphone));
				cmd.Parameters.Add(
					new SqlParameter("@hmtel", app.Phone));
				cmd.Parameters.Add(
					new SqlParameter("@ptel", ""));
				cmd.Parameters.Add(
					new SqlParameter("@mobile", ""));
				cmd.Parameters.Add(
					new SqlParameter("@hmmob", app.Mbphone));
				cmd.Parameters.Add(
					new SqlParameter("@pmob", ""));
				cmd.Parameters.Add(
					new SqlParameter("@fax", ""));
				cmd.Parameters.Add(
					new SqlParameter("@email", ""));
				cmd.Parameters.Add(
					new SqlParameter("@hmemail", app.Email));
				cmd.Parameters.Add(
					new SqlParameter("@pemail", ""));
				cmd.Parameters.Add(
					new SqlParameter("@record_modifier", pUser.ID));
				cmd.Parameters.Add(
					new SqlParameter("@rent", ""));
				cmd.Parameters.Add(
					new SqlParameter("@break", ""));
				cmd.Parameters.Add(
					new SqlParameter("@reason", ""));
				cmd.Parameters.Add(
					new SqlParameter("@fire", ""));
				cmd.Parameters.Add(
					new SqlParameter("@ins", ""));
				cmd.Parameters.Add(
					new SqlParameter("@main", ""));
				cmd.Parameters.Add(
					new SqlParameter("@date_from", su.setdate(this.txtDate.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@date_to", su.setdate("")));
				cmd.Parameters.Add(
					new SqlParameter("@room", this.txtRoom.Text));
				
				rdr = cmd.ExecuteReader();

				while(rdr.Read())
				{
					guard = rdr.GetValue(0).ToString();
				}

				save_vet(guard);
				set_app_to_placed();
			
				cmd.Dispose();
				conn.Close();
				conn.Dispose();
			
				Session["place_app"] = true;
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

		private void save_vet(string guard)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			Camelot.classes.saveUtils su = new Camelot.classes.saveUtils();
				
			pUser = (Camelot.classes.cUser)Session["curUser"];

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "update_vetting";

			cmd.Parameters.Add(
				new SqlParameter("@GUARD", guard));
			cmd.Parameters.Add(
				new SqlParameter("@PHOTO", app.Photo));
			cmd.Parameters.Add(
				new SqlParameter("@APP", app.Applic));
			cmd.Parameters.Add(
				new SqlParameter("@LIC", app.Lic));
			cmd.Parameters.Add(
				new SqlParameter("@BANK", app.Bank));
			cmd.Parameters.Add(
				new SqlParameter("@REF", app.Ref));
			cmd.Parameters.Add(
				new SqlParameter("@BOOK", app.Book));
			cmd.Parameters.Add(
				new SqlParameter("@STAND", app.Stand));
			cmd.Parameters.Add(
				new SqlParameter("@EXEC_DES", app.Exec));
			cmd.Parameters.Add(
				new SqlParameter("@NOTES", app.Notes));
			cmd.Parameters.Add(
				new SqlParameter("@INOUT", app.InOut));
			cmd.Parameters.Add(
				new SqlParameter("@OUTDATE", DateTime.Parse(su.setdate(app.OutDate))));

			cmd.ExecuteNonQuery();

			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			
		}

		private void set_app_to_placed()
		{

			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
				
			conn.ConnectionString = app_con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "set_applicant_to_be_placed";

			cmd.Parameters.Add(
				new SqlParameter("@app_id", app.App_id));

			cmd.ExecuteNonQuery();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

		}

		private void cmbProp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}
	}
}
