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
	/// Summary description for companycontacts.
	/// </summary>
	public class companycontacts : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList cmbFind;
		protected System.Web.UI.WebControls.TextBox txtFind;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.DataGrid dgComps;
		protected System.Web.UI.WebControls.DataGrid dgConts;
		protected System.Web.UI.HtmlControls.HtmlInputButton Button1;
		Camelot.classes.cCompany lcomp = new cCompany();
		Camelot.classes.cContact lcont = new cContact();
		protected System.Web.UI.WebControls.Label lblComp;
		Camelot.classes.cUser pUser;
		ArrayList props = new ArrayList();
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			bool oktogo;
			Camelot.classes.Utils pUtil = new Camelot.classes.Utils();
			lcomp= (Camelot.classes.cCompany)Session["curCompany"];
			pUser = (Camelot.classes.cUser)Session["curUser"];
			oktogo = pUtil.valid_user(pUser);
			Session["insp_files"] = null;

			if(!oktogo)
			{
				Response.Redirect("../logon.aspx");
			}
			else
			{
				if(!Page.IsPostBack)
				{
					lcont.Contact_ID = "";
					Session["curCont"] = lcont;
					lcomp= (Camelot.classes.cCompany)Session["curCompany"];
					bool vis = false;
					if(lcomp.Company_ID==null)
					{
						vis = false;
					}
					else
					{
						vis = true;
						getconts(Convert.ToInt32(lcomp.Company_ID));
					}
					setvisible(vis);
				
					if(pUser.AccMan!="True")
					{
						this.dgConts.Columns[4].Visible=false;
					}
				}	
			}
			lblComp.Text = lcomp.Company_Name;
		}

		public void dgConts_ItemDataBound(Object sender, DataGridItemEventArgs e)
		{
			
			if(e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
			{
				LinkButton fButton = (LinkButton)e.Item.Cells[0].Controls[0];
				string compname = (string)DataBinder.Eval(e.Item.DataItem, "company_name");
				compname = compname.Replace("'","");
				fButton.Attributes.Add("onclick", "javascript:window.showModalDialog('contactdetails.aspx?cid=" + DataBinder.Eval(e.Item.DataItem, "contact_id") + "&comp_id=" + DataBinder.Eval(e.Item.DataItem, "company_id") + "&comp=" + compname + "','metdets','dialogHeight: 500px; dialogWidth: 900px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');");
		
			}
		}


		private void  delete_cont(string cont_id)
		{
			int oktodel = 0;
			Camelot.classes.del_cont dc = new del_cont();
			oktodel = check_corr(cont_id);
			if(oktodel==0)
			{
				dc.Cont_ID = cont_id;
				dc.Con = (string)Session["Connection"];
				dc.del_contact();
			}
			else
			{
				if(oktodel==1)
				{
					Response.Write("<script>window.showModalDialog('delcont.aspx?cont=" + cont_id + "','delcont','dialogHeight: 150px; dialogWidth: 400px; dialogTop: 200px; dialogLeft:200px; edge: Raised; center: yes; help: No; resizable: No; status: No;');self.document.location.href = 'companycontacts.aspx';</script>");
				}
				else
				{
					string mes = "This contact is assigned to properties :\\n";
					foreach(string prop in this.props)
					{
						mes = mes + prop + "\\n";
					}
					Response.Write("<script>alert('" + mes + "');</script>");
				}
			}
		
			getconts(Convert.ToInt32(lcomp.Company_ID));
		}

		private int check_corr(string cont_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			int ok = 0;

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "check_cont_corr";

			cmd.Parameters.Add(
				new SqlParameter("@cont", cont_id));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				if(Convert.ToInt32(rdr["cnt"].ToString()) > 0)
				{
					ok = 1;
				}
			}

			rdr.NextResult();
			while(rdr.Read())
			{
				if(Convert.ToInt32(rdr["cnt"].ToString()) > 0)
				{
					ok = 2;
					rdr.NextResult();
					while(rdr.Read())
					{
						props.Add(rdr["object_name"].ToString());
					}
				}
			}
			return ok;
		}

		public void dgConts_delete(Object sender, DataGridCommandEventArgs e)
		{
			delete_cont(e.Item.Cells[1].Text);
		}

		public void set_comp(Object sender, DataGridCommandEventArgs e)
		{
			lcomp=(Camelot.classes.cCompany)Session["curCompany"];
			lcomp.Company_ID = e.Item.Cells[1].Text;
			lcomp.Company_Name = e.Item.Cells[2].Text;
			Session["curCompany"] = lcomp;
			Response.Redirect("companycontacts.aspx");
		}

		public void set_cont(Object sender, DataGridCommandEventArgs e)
		{
			lcomp=(Camelot.classes.cCompany)Session["curCompany"];
			lcomp.Company_ID = e.Item.Cells[5].Text;
			lcomp.Company_Name = e.Item.Cells[4].Text;
			Session["curCompany"] = lcomp;
		}

		private void setvisible(bool vis)
		{
			dgComps.Visible=!vis;
			dgConts.Visible = vis;
			if(pUser.Permission=="1")
			{
				Button1.Visible = vis;
			}
			else
			{
				Button1.Visible=false;
			}
		}


		private void getContacts()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			string txt = this.txtFind.Text;

			txt = txt.Replace("'","''");
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_scontacts";

			cmd.Parameters.Add(
				new SqlParameter("@search", cmbFind.SelectedItem.Value));
			cmd.Parameters.Add(
				new SqlParameter("@crit", txt));

			this.dgConts.DataSource = cmd.ExecuteReader();
			this.dgConts.DataBind();
			this.dgConts.Visible= true;
			this.dgComps.Visible=false;
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		private void getCompanies()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			string txt = this.txtFind.Text;

			txt = txt.Replace("'","''");
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_companies";

			cmd.Parameters.Add(
				new SqlParameter("@search", cmbFind.SelectedItem.Value));
			cmd.Parameters.Add(
				new SqlParameter("@crit", txt));

			dgComps.DataSource = cmd.ExecuteReader();
			dgComps.DataBind();
			dgComps.Visible= true;
			dgConts.Visible=false;
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		private void getconts(int comp_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_company_contacts";

			cmd.Parameters.Add(
				new SqlParameter("@comp_id", comp_id));
			
			dgConts.DataSource = cmd.ExecuteReader();
			dgConts.DataBind();
			dgConts.Visible= true;
			
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
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.Button1.ServerClick += new System.EventHandler(this.Button1_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			lcomp= (Camelot.classes.cCompany)Session["curCompany"];
			lcomp.Company_ID = null;
			Session["curCompany"] = lcomp;

			bool vis = false;
			setvisible(vis);
			lblComp.Visible=false;
			
			if(txtFind.Text!="")
			{
				if(cmbFind.SelectedItem.Value=="firstname" || cmbFind.SelectedItem.Value=="lastname")
				{
					getContacts();
				}
				else
				{
					getCompanies();
				}
			}
		}

		private void Button1_ServerClick(object sender, System.EventArgs e)
		{
			Session["cont_edit"] = true;
			Session["cont_save"] = false;
			Session["cont_new"] = true;
			Response.Write("<script>window.showModalDialog('contactdetails.aspx?src=comp','contdets','dialogHeight: 500px; dialogWidth: 900px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
			Response.Write("<script>self.document.location.href = 'companycontacts.aspx';</script>");
		}
	}
}
