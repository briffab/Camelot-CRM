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
	/// Summary description for outstandinginvoices.
	/// </summary>
	public class paidinvoices : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList cmbFind;
		protected System.Web.UI.WebControls.TextBox txtFind;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.DataGrid dgComps;
		protected System.Web.UI.WebControls.Label lblComp;
		protected System.Web.UI.WebControls.DataGrid dgInvoices;
		protected System.Web.UI.HtmlControls.HtmlInputButton Button1;
		Camelot.classes.cCompany lcomp = new cCompany();
		Camelot.classes.cUser pUser;
		Camelot.classes.cInvoice linvoice = new cInvoice();
	
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
				linvoice.Invoice_ID = "";
				Session["curInvoice"] = linvoice;
				lcomp= (Camelot.classes.cCompany)Session["curCompany"];
				bool vis = false;
				if(lcomp.Company_ID==null)
				{
					vis = false;
				}
				else
				{
					vis = true;
					getinvoices(Convert.ToInt32(lcomp.Company_ID));
				}
				setvisible(vis);
				lblComp.Text = lcomp.Company_Name;
			}
		}

		private void setvisible(bool vis)
		{
			dgComps.Visible=!vis;
			dgInvoices.Visible = vis;
		}

		public void set_comp(Object sender, DataGridCommandEventArgs e)
		{
			lcomp=(Camelot.classes.cCompany)Session["curCompany"];
			lcomp.Company_ID = e.Item.Cells[1].Text;
			lcomp.Company_Name = e.Item.Cells[0].Text;
			Session["curCompany"] = lcomp;
			Response.Redirect("paidinvoices.aspx");
		}

		private void getinvoices(int comp_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_paid_company_invoices";

			cmd.Parameters.Add(
				new SqlParameter("@comp_id", comp_id));
			
			dgInvoices.DataSource = cmd.ExecuteReader();
			dgInvoices.DataBind();
			dgInvoices.Visible= true;
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		private void getCompanies()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_companies";

			cmd.Parameters.Add(
				new SqlParameter("@search", cmbFind.SelectedItem.Value));
			cmd.Parameters.Add(
				new SqlParameter("@crit", txtFind.Text));

			dgComps.DataSource = cmd.ExecuteReader();
			dgComps.DataBind();
			dgComps.Visible= true;
			dgInvoices.Visible=false;
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}
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
				getCompanies();		
			}
		}

		public void dgInvoices_ItemDataBound(Object sender, DataGridItemEventArgs e)
		{
			if(e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
			{
				LinkButton fButton = (LinkButton)e.Item.Cells[0].Controls[0];
				fButton.Attributes.Add("onclick", "javascript:window.showModalDialog('invoicedetails.aspx?inv=" + DataBinder.Eval(e.Item.DataItem, "invoiceid") + "','metdets','dialogHeight: 650px; dialogWidth: 900px; dialogTop: 75px; dialogLeft:75px; edge: Raised; center: No; help: No; resizable: No; status: No;');");
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
			this.Load += new System.EventHandler(this.Page_Load);
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

		}
		#endregion
	}
}
