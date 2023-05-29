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
	/// Summary description for propertyguardians.
	/// </summary>
	public class propertyguardians : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList cmbFind;
		protected System.Web.UI.WebControls.TextBox txtFind;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.DataGrid dgProps;
		protected System.Web.UI.WebControls.Label LblProp;
		protected System.Web.UI.WebControls.DataGrid dgGuard;
		protected System.Web.UI.HtmlControls.HtmlInputButton Button1;

		Camelot.classes.cProperty lprop;
		Camelot.classes.cCompany lcomp = new cCompany();
		Camelot.classes.cGuardian lguard = new Camelot.classes.cGuardian();
		protected System.Web.UI.WebControls.DataGrid dgSGuard;
		Camelot.classes.cUser pUser;

		private void InitializeComponent()
		{
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.Load += new System.EventHandler(this.Page_Load);
			this.Button1.ServerClick += new System.EventHandler(this.Button1_ServerClick);
		}
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			bool oktogo;
			Camelot.classes.Utils pUtil = new Camelot.classes.Utils();
			pUser = (Camelot.classes.cUser)Session["curUser"];
			oktogo = pUtil.valid_user(pUser);
			Session["insp_files"] = null;

			if(!oktogo)
			{
				Response.Redirect("../logon.aspx");
			}
			else
			{
				lguard.Guardian_ID = "";
				Session["curGuardian"] = lguard;
				lprop= (Camelot.classes.cProperty)Session["curProperty"];
				bool vis = false;
				if(lprop.Property_ID==null)
				{
					vis = false;
				}
				else
				{
					vis = true;
					getGuardians(Convert.ToInt32(lprop.Property_ID));
				}
				setvisible(vis);
				LblProp.Text = lprop.Property_Name;
			}
			
		}

		private void getGuardians(int propid)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_current_property_residents";

			cmd.Parameters.Add(
				new SqlParameter("@prop_id", propid));
			
			dgGuard.DataSource = cmd.ExecuteReader();
			dgGuard.DataBind();
			dgGuard.Visible= true;
			conn.Close();
			conn.Dispose();
		}

		private void getProperties()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			string txt=this.txtFind.Text.Replace("'","''");

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;

			cmd.CommandText = "get_properties";

			cmd.Parameters.Add(
				new SqlParameter("@search", cmbFind.SelectedItem.Value));
			cmd.Parameters.Add(
				new SqlParameter("@crit", txt));

			rdr = cmd.ExecuteReader();
			dgProps.DataSource = rdr;
			dgProps.DataBind();
			dgProps.Visible= true;
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}


		private void getSGuardians()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			string txt = this.txtFind.Text.Replace("'","''");

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_search_guardians";

			cmd.Parameters.Add(
				new SqlParameter("@search", cmbFind.SelectedItem.Value));
			cmd.Parameters.Add(
				new SqlParameter("@crit", txt));

			dgSGuard.DataSource = cmd.ExecuteReader();
			dgSGuard.DataBind();
			dgSGuard.Visible=true;
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		private void setvisible(bool vis)
		{
			dgProps.Visible=!vis;
			dgSGuard.Visible=!vis;
			dgGuard.Visible = vis;
			if(pUser.Permission=="1")
			{
				Button1.Visible = true;
			}
			else
			{
				Button1.Visible=false;
			}
		}
		public void set_prop(Object sender, DataGridCommandEventArgs e)
		{
			lprop= (Camelot.classes.cProperty)Session["curProperty"];
			lprop.Property_ID = e.Item.Cells[2].Text;
			lprop.Property_Name = e.Item.Cells[1].Text;
			lcomp=(Camelot.classes.cCompany)Session["curCompany"];
			lcomp.Company_ID = e.Item.Cells[3].Text;
			lcomp.Company_Name = e.Item.Cells[5].Text;
			Session["curCompany"] = lcomp;
			Session["curProperty"] = lprop;
			Response.Redirect("propertyguardians.aspx");
		}

		public void dgGuard_ItemDataBound(Object sender, DataGridItemEventArgs e)
		{
			if(e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
			{
				LinkButton fButton = (LinkButton)e.Item.Cells[0].Controls[0];
				fButton.Attributes.Add("onclick", "javascript:window.showModalDialog('guardian.aspx?gid=" + DataBinder.Eval(e.Item.DataItem, "resident_id") + "','contdets','dialogHeight: 700px; dialogWidth: 900px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');");
			}
		}

		public void set_guard(Object sender, DataGridCommandEventArgs e)
		{
			lprop.Property_ID = e.Item.Cells[2].Text;
			lprop.Property_Name = e.Item.Cells[5].Text;
			lcomp.Company_ID = e.Item.Cells[3].Text;
			lcomp.Company_Name = e.Item.Cells[4].Text;
			Session["CurProperty"] = lprop;
			Session["CurCompany"] = lcomp;
			Response.Write("<script>window.showModalDialog('guardian.aspx?gid=" + e.Item.Cells[1].Text + "','guards','dialogHeight: 700px; dialogWidth: 900px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");	
			Response.Write("<script>self.document.location.href = 'propertyguardians.aspx';</script>");
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
		
		#endregion

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			lprop= (Camelot.classes.cProperty)Session["curProperty"];
			lprop.Property_ID = null;
			Session["curProperty"] = lprop;

			bool vis = false;
			setvisible(vis);
			dgProps.Visible=vis;
			LblProp.Visible=false;
			
			if(txtFind.Text!="")
			{
				if(cmbFind.SelectedItem.Value=="FIRSTNAME" || cmbFind.SelectedItem.Value=="LASTNAME")
				{
					getSGuardians();
				}
				else
				{
					getProperties();		
				}
			}
		}

		private void Button1_ServerClick(object sender, System.EventArgs e)
		{
			Session["guard_edit"] = true;
			Session["guard_save"] = false;
			Session["guard_new"] = true;
			Response.Write("<script>window.showModalDialog('new_guardian.aspx?gid=','guards','dialogHeight:700px; dialogWidth: 900px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");	
			Response.Write("<script>self.document.location.href = 'propertyguardians.aspx';</script>");
		}
	}
}
