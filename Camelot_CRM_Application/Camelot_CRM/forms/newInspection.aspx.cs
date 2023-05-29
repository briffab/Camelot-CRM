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
	public class NewInspection : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblPropInsp;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.HtmlControls.HtmlTableCell Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.Label lblDateStar;
		protected System.Web.UI.WebControls.DropDownList cmbPropInsp;
		Camelot.classes.Utils Utils = new Camelot.classes.Utils();
		Camelot.classes.cInspection linsp = new cInspection();
		Camelot.classes.cProperty lprop;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.DataGrid dgMets;
		protected System.Web.UI.WebControls.ListBox lbInRep;
		protected System.Web.UI.WebControls.Button btnMto;
		protected System.Web.UI.WebControls.Button btnMfrom;
		protected System.Web.UI.WebControls.ListBox lbNotRep;
		protected System.Web.UI.WebControls.TextBox txtOther;
		protected System.Web.UI.WebControls.Button btnNote;
		protected System.Web.UI.WebControls.Label lblInspStar;
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
				lprop = (Camelot.classes.cProperty)Session["curProperty"];
				lblTitle.Text = lprop.Property_Name;
				if(!Page.IsPostBack)
				{
					pop_meters(lprop.Property_ID);
					pop_propinsp(Convert.ToString(pUser.ID));
					pop_comments();
					hideErr();
					
					Response.Expires = 0;
					Response.Cache.SetNoStore();
					Response.AppendHeader("Pragma", "no-cache");
			
					bool edit = (bool)Session["insp_edit"];
			
					setenabled(edit);

					if(edit)
					{
						btnUpdate.Visible = true;
						btnCancel.Visible = true;
					}
				}
			}
		}


		private void pop_comments()
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
				new SqlParameter("@INSP", "0"));

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


		public void dgmets_ItemDataBound(Object sender, DataGridItemEventArgs e)
		{
			if(e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
			{
				LinkButton fButton = (LinkButton)e.Item.Cells[0].Controls[0];
				fButton.Attributes.Add("onclick", "javascript:window.showModalDialog('meterdetails.aspx?met=" + DataBinder.Eval(e.Item.DataItem, "met") + "','metdets','dialogHeight: 485px; dialogWidth: 900px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');");
			}
		}
		private void hideErr()
		{
			lblDateStar.Visible=false;
			this.lblInspStar.Visible = false;
		}

		private void setenabled(bool edit)
		{
			cmbPropInsp.Enabled = edit;
			txtDate.Enabled = edit;
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
			this.btnNote.Click += new System.EventHandler(this.btnNote_Click);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Session["insp_edit"] = false;
			Session["insp_save"] = false;
			Response.Write("<script>window.close();</script>");
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			saveinsp();
			Session["insp_edit"] = false;
			Session["insp_save"] = false;
			Response.Write("<script>window.close();</script>");
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

			if(this.cmbPropInsp.SelectedItem.Text == "")
			{
				oktosave=false;
				cnt++;
				if(Msg!="")
				{
					Msg = Msg + ", Property Inspector";
				}
				else
				{
					Msg = "Property Inspector";
				}
				this.lblInspStar.Visible=true;
			}
			
			if(oktosave)
			{
				SqlConnection conn = new SqlConnection();
				SqlCommand cmd =  new SqlCommand();
				SqlDataReader rdr = null;
				linsp= (Camelot.classes.cInspection)Session["curInspection"];
				pUser = (Camelot.classes.cUser)Session["curUser"];
				int emp = get_employeeid(cmbPropInsp.SelectedItem.Text);

				conn.ConnectionString = (string)Session["Connection"];
				conn.Open();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "add_inspection";

				cmd.Parameters.Add(
					new SqlParameter("@prop_id", lprop.Property_ID));
				cmd.Parameters.Add(
					new SqlParameter("@DATE", su.setdate(txtDate.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@inspector", emp));
				cmd.Parameters.Add(
					new SqlParameter("@REPORT_COMMENTS", this.txtOther.Text));

				rdr = cmd.ExecuteReader();

				while(rdr.Read())
				{
					linsp.Inspection_ID = rdr.GetValue(0).ToString();
				}

				Session["currInsp"] = linsp;

				cmd.Dispose();
				conn.Close();
				conn.Dispose();
			
				foreach(DataGridItem dgi in dgMets.Items)
				{							   
					string met_id = dgi.Cells[2].Text;
					int rate_id = Convert.ToInt32(dgi.Cells[3].Text);
					TextBox reading = (TextBox)dgi.FindControl("txtRead");
					string rdate = su.setdate(txtDate.Text);

					add_reading(linsp.Inspection_ID,met_id,rate_id,reading.Text, rdate, emp);
				}

				foreach(ListItem li in this.lbInRep.Items)
				{
					savecomment(li.Value);
				}

				Response.Write("<script>window.close();</script>");

				Session["insp_edit"] = false;
				Session["insp_save"] = false;
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

		private void add_reading(string insp_id, string met_id, int rate_id, string read, string rdate, int insp)
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
				new SqlParameter("@read_id", "0"));
			cmd.Parameters.Add(
				new SqlParameter("@met_id", met_id));
			cmd.Parameters.Add(
				new SqlParameter("@rate_id", rate_id));
			cmd.Parameters.Add(
				new SqlParameter("@reading", read));
			cmd.Parameters.Add(
				new SqlParameter("@insp", insp));
			cmd.Parameters.Add(
				new SqlParameter("@readdate", su.setdate(rdate)));
			cmd.Parameters.Add(
				new SqlParameter("@insp_id", insp_id));
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
			cmd.CommandText = "get_new_inspection_meters";

			cmd.Parameters.Add(
				new SqlParameter("@prop", insp));

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
	}
}
