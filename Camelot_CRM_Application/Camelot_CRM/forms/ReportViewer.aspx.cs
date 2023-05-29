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
using cr = Camelot.Reports;
using System.Data.SqlClient;
using cc = Camelot.classes;
using cde = CrystalDecisions.CrystalReports.Engine;
using cd = CrystalDecisions.Shared;

namespace Camelot.forms
{
	/// <summary>
	/// Summary description for ReportViewer.
	/// </summary>
	public class ReportViewer : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList cmbExport;
		protected System.Web.UI.WebControls.Button btnExport;
		protected CrystalDecisions.Web.CrystalReportViewer CRv;

		string ex = "";
		string sfile = "";
		string hfile = "";
		string dto = "";
		string dfrom = "";
		string acc = "";
		string rep_id = "";
		string prop = "";

		protected System.Web.UI.WebControls.Button btnClose;

		
		public cde.ReportDocument crp = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Expires = 0;
			Response.Cache.SetNoStore();
			Response.AppendHeader("Pragma", "no-cache");
	
			rep_id = Request.QueryString["rep_id"];
			dto = Request.QueryString["dto"];
			dfrom = Request.QueryString["dfrom"];
			acc = Request.QueryString["acc"];
			prop = Request.QueryString["prop"];

			show_report();
		}

		private void show_report()
		{
			switch(rep_id)
			{
				case "1":
                    show_vetting();
					break;
				case "2":
					show_no_vetting();
					break;
				case "3":
					show_all_vetting();
					break;
				case "4":
					show_open_incidents();
					break;
				case "5":
					show_props_by_stat();
					break;
				case "6":
					show_calamity();
					break;
				case "7":
					show_empty_spaces();
					break;
				case "8":
					show_prospect_status();
					break;
			}

		}


		private void show_vetting()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataAdapter sqla = new SqlDataAdapter();
			SqlDataAdapter sqlb = new SqlDataAdapter();
			SqlDataReader rdr = null;
			DataSet ds = new DataSet();
			cr.vetting vet = new Camelot.Reports.vetting();

			string accman = "";
			string cnt = "";

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			
			cmd.CommandText = "rpt_vetting_details";

			cmd.Parameters.Add(
				new SqlParameter("@acc", acc));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				accman = rdr.GetValue(0).ToString();
			}

			rdr.NextResult();
			while(rdr.Read())
			{
				cnt = rdr.GetValue(0).ToString();
			}
			
			rdr.Close();
			cmd.Dispose();

			cmd.Parameters.Clear();
			cmd.CommandText = "rpt_vetting";

			cmd.Parameters.Add(
				new SqlParameter("@acc", acc));

			sqla.SelectCommand = cmd;

			sqla.Fill(ds,"vetting_details");
			
			vet = new cr.vetting();

			vet.SetDataSource(ds);

			cde.TextObject txt = (cde.TextObject)vet.ReportDefinition.ReportObjects["AccountMan"];
			txt.Text = accman;
			txt = (cde.TextObject)vet.ReportDefinition.ReportObjects["RecCount"];
			txt.Text = cnt;
			

			this.CRv.ReportSource = vet;

			this.CRv.RefreshReport();

			ex = System.DateTime.Now.Hour.ToString() + "_" + System.DateTime.Now.Minute.ToString() + "_" + System.DateTime.Now.Second.ToString() + "_" + System.DateTime.Now.Day.ToString() + "_" + System.DateTime.Now.Month.ToString() + "_" + System.DateTime.Now.Year.ToString() + "_" + vet.ResourceName;

			crp = vet;

		}

		private void show_props_by_stat()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataAdapter sqla = new SqlDataAdapter();
			SqlDataReader rdr = null;
			DataSet ds = new DataSet();
			cr.prop_by_stat pbs = new Camelot.Reports.prop_by_stat();

			string cnt = "";
			string accman = "";

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			
			cmd.CommandText = "rpt_props_by_status_details";

			cmd.Parameters.Add(
				new SqlParameter("@accman", acc));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				accman = rdr.GetValue(0).ToString();
			}

			rdr.NextResult();

			while(rdr.Read())
			{
				cnt = rdr.GetValue(0).ToString();
			}
			
			rdr.Close();
			cmd.Dispose();

			cmd.Parameters.Clear();
			cmd.CommandText = "rpt_props_by_status";
			cmd.Parameters.Add(
				new SqlParameter("@accman", acc));

			sqla.SelectCommand = cmd;

			sqla.Fill(ds,"properties");
			
			pbs = new Camelot.Reports.prop_by_stat();
			
			pbs.SetDataSource(ds);

			cde.TextObject txt = (cde.TextObject)pbs.ReportDefinition.ReportObjects["accman"];
			txt.Text = accman;
			txt = (cde.TextObject)pbs.ReportDefinition.ReportObjects["Reccnt"];
			txt.Text = cnt;
			

			this.CRv.ReportSource = pbs;

			this.CRv.RefreshReport();

			ex = System.DateTime.Now.Day.ToString() + "_" + System.DateTime.Now.Month.ToString() + "_" + System.DateTime.Now.Year.ToString() + "_" + pbs.ResourceName;

			crp = pbs;

		}

		private void show_no_vetting()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataAdapter sqla = new SqlDataAdapter();
			SqlDataAdapter sqlb = new SqlDataAdapter();
			SqlDataReader rdr = null;

			DataSet ds = new DataSet();
			cr.no_vetting nvet;

			string accman = "";
			string cnt = "";

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			
			cmd.CommandText = "rpt_no_vetting_details";

			cmd.Parameters.Add(
				new SqlParameter("@acc", acc));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				accman = rdr.GetValue(0).ToString();
			}

			rdr.NextResult();
			while(rdr.Read())
			{
				cnt = rdr.GetValue(0).ToString();
			}

			rdr.Close();
			cmd.Dispose();
			cmd.Parameters.Clear();
			cmd.CommandText = "rpt_no_vetting";

			cmd.Parameters.Add(
				new SqlParameter("@acc", acc));

			sqla.SelectCommand = cmd;

			sqla.Fill(ds,"vetting_details");
			
			nvet = new cr.no_vetting();

			nvet.SetDataSource(ds);

			cde.TextObject txt = (cde.TextObject)nvet.ReportDefinition.ReportObjects["AccountMan"];
			txt.Text = accman;
			txt = (cde.TextObject)nvet.ReportDefinition.ReportObjects["RecCount"];
			txt.Text = cnt;

			this.CRv.ReportSource = nvet;

			this.CRv.RefreshReport();

			ex = System.DateTime.Now.Day.ToString() + "_" + System.DateTime.Now.Month.ToString() + "_" + System.DateTime.Now.Year.ToString() + "_" + nvet.ResourceName;

			crp = nvet;
		}

		private void show_all_vetting()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataAdapter sqla = new SqlDataAdapter();
			SqlDataAdapter sqlb = new SqlDataAdapter();
			SqlDataReader rdr = null;

			DataSet ds = new DataSet();
			cr.All_vetting avet;

			string accman = "";
			string cnt = "";

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			
			cmd.CommandText = "rpt_all_vetting_details";

			cmd.Parameters.Add(
				new SqlParameter("@acc", acc));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				accman = rdr.GetValue(0).ToString();
			}

			rdr.NextResult();
			while(rdr.Read())
			{
				cnt = rdr.GetValue(0).ToString();
			}

			rdr.Close();
			cmd.Dispose();
			cmd.Parameters.Clear();

			cmd.CommandText = "rpt_all_vetting";

			cmd.Parameters.Add(
				new SqlParameter("@acc", acc));

			sqla.SelectCommand = cmd;

			sqla.Fill(ds,"vetting_details");
			
			avet = new cr.All_vetting();

			avet.SetDataSource(ds);

			cde.TextObject txt = (cde.TextObject)avet.ReportDefinition.ReportObjects["AccountMan"];
			txt.Text = accman;
			txt = (cde.TextObject)avet.ReportDefinition.ReportObjects["RecCount"];
			txt.Text = cnt;

			this.CRv.ReportSource = avet;

			this.CRv.RefreshReport();

			ex = System.DateTime.Now.Day.ToString() + "_" + System.DateTime.Now.Month.ToString() + "_" + System.DateTime.Now.Year.ToString() + "_" + avet.ResourceName;

			crp = avet;
		}

		private void show_open_incidents()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataAdapter sqla = new SqlDataAdapter();
			SqlDataAdapter sqlb = new SqlDataAdapter();
			SqlDataReader rdr = null;
			DataSet ds = new DataSet();
			cr.open_incidents oInc = new Camelot.Reports.open_incidents();

			string accman = "";
			string cnt = "";
			string prop_name = "";

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			
			cmd.CommandText = "rpt_all_open_incidents_details";

			cmd.Parameters.Add(
				new SqlParameter("@acc", acc));

			cmd.Parameters.Add(
				new SqlParameter("@prop", prop));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				accman = rdr.GetValue(0).ToString();
			}

			rdr.NextResult();

			while(rdr.Read())
			{
				prop_name = rdr.GetValue(0).ToString();
			}

			rdr.NextResult();

			while(rdr.Read())
			{
				cnt = rdr.GetValue(0).ToString();
			}
			
			rdr.Close();
			cmd.Dispose();

			cmd.Parameters.Clear();
			cmd.CommandText = "rpt_all_open_incidents";

			cmd.Parameters.Add(
				new SqlParameter("@acc", acc));

			cmd.Parameters.Add(
				new SqlParameter("@prop", prop));

			sqla.SelectCommand = cmd;

			sqla.Fill(ds,"incdetails");
			
			oInc = new Camelot.Reports.open_incidents();

			oInc.SetDataSource(ds);

			cde.TextObject txt = (cde.TextObject)oInc.ReportDefinition.ReportObjects["AccountMan"];
			txt.Text = accman;
			txt = (cde.TextObject)oInc.ReportDefinition.ReportObjects["Property"];
			txt.Text = prop_name;
			txt = (cde.TextObject)oInc.ReportDefinition.ReportObjects["RecCount"];
			txt.Text = cnt;
			

			this.CRv.ReportSource = oInc;

			this.CRv.RefreshReport();

			ex = System.DateTime.Now.Day.ToString() + "_" + System.DateTime.Now.Month.ToString() + "_" + System.DateTime.Now.Year.ToString() + "_" + oInc.ResourceName;

			crp = oInc;
		}

		private void show_calamity()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataAdapter sqla = new SqlDataAdapter();
			DataSet ds = new DataSet();
			cr.Calamity cal = new Camelot.Reports.Calamity();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			
			cmd.CommandText = "rpt_calamity";

			sqla.SelectCommand = cmd;

			sqla.Fill(ds,"details");
			
			cal = new Camelot.Reports.Calamity();
			
			cal.SetDataSource(ds);

			this.CRv.ReportSource = cal;

			this.CRv.RefreshReport();

			ex = System.DateTime.Now.Day.ToString() + "_" + System.DateTime.Now.Month.ToString() + "_" + System.DateTime.Now.Year.ToString() + "_" + cal.ResourceName;

			crp = cal;
		}

		private void show_empty_spaces()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataAdapter sqla = new SqlDataAdapter();
			SqlDataAdapter sqlb = new SqlDataAdapter();
			SqlDataReader rdr = null;
			DataSet ds = new DataSet();
			cr.empty_spaces emp = new Camelot.Reports.empty_spaces();

			string accman = "";

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			
			cmd.CommandText = "rpt_empty_spaces_details";

			cmd.Parameters.Add(
				new SqlParameter("@accman", acc));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				accman = rdr.GetValue(0).ToString();
			}

			rdr.Close();
			cmd.Dispose();

			cmd.Parameters.Clear();
			cmd.CommandText = "rpt_empty_spaces";

			cmd.Parameters.Add(
				new SqlParameter("@accman", acc));

			sqla.SelectCommand = cmd;

			sqla.Fill(ds,"details");
			
			emp = new Camelot.Reports.empty_spaces();

			emp.SetDataSource(ds);

			cde.TextObject txt = (cde.TextObject)emp.ReportDefinition.ReportObjects["accman"];
			txt.Text = accman;			

			this.CRv.ReportSource = emp;

			this.CRv.RefreshReport();

			ex = System.DateTime.Now.Hour.ToString() + "_" + System.DateTime.Now.Minute.ToString() + "_" + System.DateTime.Now.Second.ToString() + "_" + System.DateTime.Now.Day.ToString() + "_" + System.DateTime.Now.Month.ToString() + "_" + System.DateTime.Now.Year.ToString() + "_" + emp.ResourceName;

			crp = emp;

		}

		private void show_prospect_status()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataAdapter sqla = new SqlDataAdapter();
			SqlDataAdapter sqlb = new SqlDataAdapter();
			SqlDataReader rdr = null;
			DataSet ds = new DataSet();
			cr.prospect_status pros = new Camelot.Reports.prospect_status();

			string accman = "";
			string cnt = "";

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			
			cmd.CommandText = "rpt_prospect_status_details";

			cmd.Parameters.Add(
				new SqlParameter("@accman", acc));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				accman = rdr.GetValue(0).ToString();
			}

			rdr.NextResult();

			while(rdr.Read())
			{
				cnt = rdr.GetValue(0).ToString();
			}
			
			rdr.Close();
			cmd.Dispose();

			cmd.Parameters.Clear();
			cmd.CommandText = "rpt_prospect_status";

			cmd.Parameters.Add(
				new SqlParameter("@accman", acc));

			sqla.SelectCommand = cmd;

			sqla.Fill(ds,"prospects_stats");
			
			pros = new Camelot.Reports.prospect_status();

			pros.SetDataSource(ds);

			cde.TextObject txt = (cde.TextObject)pros.ReportDefinition.ReportObjects["accman"];
			txt.Text = accman;
			txt = (cde.TextObject)pros.ReportDefinition.ReportObjects["cnt"];
			txt.Text = cnt;
			

			this.CRv.ReportSource = pros;

			this.CRv.RefreshReport();

			ex = System.DateTime.Now.Day.ToString() + "_" + System.DateTime.Now.Month.ToString() + "_" + System.DateTime.Now.Year.ToString() + "_" + pros.ResourceName;

			crp = pros;

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
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.close();</script>");
		}

		private void btnExport_Click(object sender, System.EventArgs e)
		{
			string expType = "";

			expType = this.cmbExport.SelectedValue;

			switch(expType)
			{
				case "0":
					savepdf();
					break;
				case "1":
					savertf();
					break;
				case "2":
					savedoc();
					break;
				case "3":
					savexls();
					break;
			}

			Response.Write("<script>window.open('" + hfile + "');</script>");
		}

	
		private void savepdf()
		{
			ex = ex.Substring(0,ex.Length-4);
			ex = ex + ".pdf";
			sfile = "c:/inetpub/wwwroot/camelot_crm/man_reports/" + ex;
			hfile = "http://ntsbs01/camelot_crm/man_reports/" + ex;
			cd.ExportOptions eXop = crp.ExportOptions;

			eXop.ExportFormatType = cd.ExportFormatType.PortableDocFormat;
			eXop.ExportDestinationType = cd.ExportDestinationType.DiskFile;
			eXop.DestinationOptions = new cd.DiskFileDestinationOptions();
			// Set the disk file options.
			cd.DiskFileDestinationOptions diskOpts = new cd.DiskFileDestinationOptions();
			( ( cd.DiskFileDestinationOptions )crp.ExportOptions.DestinationOptions ).DiskFileName = sfile;
			crp.Export();
		}

		private void savertf()
		{
			ex = ex.Substring(0,ex.Length-4);
			ex = ex + ".rtf";
			sfile = "c:/inetpub/wwwroot/camelot_crm/man_reports/" + ex;
			hfile = "http://ntsbs01/camelot_crm/man_reports/" + ex;
			cd.ExportOptions eXop = crp.ExportOptions;

			eXop.ExportFormatType = cd.ExportFormatType.RichText;
			eXop.ExportDestinationType = cd.ExportDestinationType.DiskFile;
			eXop.DestinationOptions = new cd.DiskFileDestinationOptions();
			// Set the disk file options.
			cd.DiskFileDestinationOptions diskOpts = new cd.DiskFileDestinationOptions();
			( ( cd.DiskFileDestinationOptions )crp.ExportOptions.DestinationOptions ).DiskFileName = sfile;
			crp.Export();
		}

		private void savedoc()
		{
			ex = ex.Substring(0,ex.Length-4);
			ex = ex + ".doc";
			sfile = "c:/inetpub/wwwroot/camelot_crm/man_reports/" + ex;
			hfile = "http://ntsbs01/camelot_crm/man_reports/" + ex;
			cd.ExportOptions eXop = crp.ExportOptions;

			eXop.ExportFormatType = cd.ExportFormatType.WordForWindows;
			eXop.ExportDestinationType = cd.ExportDestinationType.DiskFile;
			eXop.DestinationOptions = new cd.DiskFileDestinationOptions();
			// Set the disk file options.
			cd.DiskFileDestinationOptions diskOpts = new cd.DiskFileDestinationOptions();
			( ( cd.DiskFileDestinationOptions )crp.ExportOptions.DestinationOptions ).DiskFileName = sfile;
			crp.Export();
		}

		private void savexls()
		{
			ex = ex.Substring(0,ex.Length-4);
			ex = ex + ".xls";
			sfile = "c:/inetpub/wwwroot/camelot_crm/man_reports/" + ex;
			hfile = "http://ntsbs01/camelot_crm/man_reports/" + ex;
			cd.ExportOptions eXop = crp.ExportOptions;

			eXop.ExportFormatType = cd.ExportFormatType.Excel;
			eXop.ExportDestinationType = cd.ExportDestinationType.DiskFile;
			eXop.DestinationOptions = new cd.DiskFileDestinationOptions();
			// Set the disk file options.
			cd.DiskFileDestinationOptions diskOpts = new cd.DiskFileDestinationOptions();
			( ( cd.DiskFileDestinationOptions )crp.ExportOptions.DestinationOptions ).DiskFileName = sfile;
			crp.Export();
		}
	}
}
