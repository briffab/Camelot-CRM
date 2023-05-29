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
using cc = Camelot.classes;
using System.IO;


namespace Camelot.forms
{
	/// <summary>
	/// Summary description for reports.
	/// </summary>
	public class reports : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblreport;
		protected System.Web.UI.WebControls.TextBox txtDateFom;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.Button btnReport;
		protected System.Web.UI.WebControls.DropDownList cmbReport;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.Label lblMes;
		protected System.Web.UI.WebControls.Label lblAcc;
		protected System.Web.UI.WebControls.Label lblFromStar;
		protected System.Web.UI.WebControls.Label lblToStar;
		protected System.Web.UI.WebControls.Label lblFrom;
		protected System.Web.UI.WebControls.Label lblTo;
		protected System.Web.UI.WebControls.DropDownList cmbAccman;
		protected System.Web.UI.WebControls.DropDownList cmbProps;
		protected System.Web.UI.WebControls.Label Label1;
		Camelot.classes.cUser pUser;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			bool oktogo;
			Camelot.classes.Utils pUtil = new Camelot.classes.Utils();
			pUser = (Camelot.classes.cUser)Session["curUser"];
			oktogo = pUtil.valid_user(pUser);
			hidestar();
			Session["insp_files"] = null;

			if(!oktogo)
			{
				Response.Redirect("../logon.aspx");
			}
			else
			{
				if(!Page.IsPostBack)
				{
					pop_reports();
					pop_accman();
					popprops();
				}
			}
			hideTxt();
			enable();
		}


		private void hideTxt()
		{
			this.txtDateTo.Enabled=false;
			this.txtDateFrom.Enabled=false;
			this.cmbAccman.Enabled=false;
			this.cmbProps.Enabled=false;
		}

		private void hidestar()
		{
			lblFromStar.Visible = false;
			lblToStar.Visible = false;
		}

		private void pop_reports()
		{
			Camelot.classes.Reports lreps = (cc.Reports)Session["Reports"];
			cmbReport.Items.Clear();
			cmbReport.Items.Add("");
			foreach(cc.Report rt in lreps)
			{
				cmbReport.Items.Add(rt.Report_Name);
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
			this.cmbReport.SelectedIndexChanged += new System.EventHandler(this.cmbReport_SelectedIndexChanged);
			this.cmbProps.SelectedIndexChanged += new System.EventHandler(this.cmbProps_SelectedIndexChanged);
			this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnReport_Click(object sender, System.EventArgs e)
		{
			string rep="";
			string dto="";
			string dfrom="";
			string acc="";
			string prop="";

			

			Camelot.classes.Reports lreps = (cc.Reports)Session["Reports"];
			Camelot.classes.Employees lemps = (cc.Employees)Session["emps"];

			foreach(cc.Report rt in lreps)
			{
				if(this.cmbReport.SelectedValue == rt.Report_Name)
				{
					rep = rt.Report_ID;
				}
			}

			if(this.cmbAccman.SelectedValue=="All")
			{
				acc="0";
			}
			else
			{
				
				foreach(cc.Employee emp in lemps)
				{
				
					if(this.cmbAccman.SelectedValue == emp.Emp_Name)
					{
						acc=emp.Emp_ID;
					}
				}
			}

			prop = this.cmbProps.SelectedValue;

			
			dto = this.txtDateTo.Text;
			dfrom = this.txtDateFrom.Text;
			
			Response.Write("<script>window.showModalDialog('ReportViewer.aspx?rep_id=" + rep + "&dto=" + dto + "&dfrom=" + dfrom + "&acc=" + acc + "&prop=" + prop + "','reports','dialogHeight: 700px; dialogWidth: 900px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
		}

		private void pop_accman()
		{
			cc.Employees lemps = (cc.Employees)Session["Emps"];
			cc.cAcc_Mans laccs = (cc.cAcc_Mans)Session["Accmans"];
			this.cmbAccman.Items.Clear();
			this.cmbAccman.Items.Add("All");

			foreach(cc.cAccMan a in laccs)
			{
				foreach(cc.Employee e in lemps)
				{
					if(e.Emp_ID == a.Acc_Man)
					{
						this.cmbAccman.Items.Add(e.Emp_Name);
					}
				}
			}

			this.cmbAccman.SelectedIndex = -1;
		}

		private void enable()
		{
			Camelot.classes.Reports lreps = (cc.Reports)Session["Reports"];
			foreach(cc.Report rt in lreps)
			{
				if(this.cmbReport.SelectedValue == rt.Report_Name)
				{
					if(rt.Dates == "False")
					{
						this.txtDateFrom.Enabled = false;
						this.txtDateTo.Enabled = false;
					}
					else
					{
						this.txtDateFrom.Enabled = true;
						this.txtDateTo.Enabled = true;
					}
					if(rt.AccMan=="False")
					{
						this.cmbAccman.Enabled=false;
					}
					else
					{
						this.cmbAccman.Enabled=true;
					}
					if(rt.Property=="False")
					{
						this.cmbProps.Enabled =false;
					}
					else
					{
						this.cmbProps.Enabled =true;
					}

				}
			}
		}

		private void popprops()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.Utils us = new Camelot.classes.Utils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_rpt_properties";

			rdr = cmd.ExecuteReader();
			
		
			this.cmbProps.Items.Clear();
			this.cmbProps.DataSource = rdr;
			this.cmbProps.DataTextField = "object_name";
			this.cmbProps.DataValueField = "object_ID";
			this.cmbProps.DataBind();
				
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		private void cmbReport_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			enable();
		}

		private void cmbProps_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
