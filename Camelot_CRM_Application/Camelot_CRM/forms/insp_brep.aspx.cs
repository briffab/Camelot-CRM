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
using CrystalDecisions.Shared;
using cr = Camelot.Reports;
using System.Data.SqlClient;
using cc = Camelot.classes;
using cde = CrystalDecisions.CrystalReports.Engine;
using cd = CrystalDecisions.Shared;

namespace Camelot.forms
{
	/// <summary>
	/// Summary description for insp_rep.
	/// </summary>
	public class insp_brep : System.Web.UI.Page
	{
		protected CrystalDecisions.Web.CrystalReportViewer CRv;
		cc.cProperty lprop = new Camelot.classes.cProperty();
		string pdfFile = "";
		string hpdf = "";
		string linsp = "";
		string action = "";

		cr.insp_rep crp;
		cde.Sections crSecs;
		cde.ReportObjects crRepObs;
		cde.SubreportObject crSubrepOb;
		cde.ReportDocument crSubrepDoc;

		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Expires = 0;
			Response.Cache.SetNoStore();
			Response.AppendHeader("Pragma", "no-cache");
			cc.cProperty lprop = new Camelot.classes.cProperty();
			
			linsp = Request.QueryString["insp"];

			action = Request.QueryString["action"].ToString();

			try
			{
				SqlConnection conn = new SqlConnection();
				SqlCommand cmd =  new SqlCommand();
				SqlDataReader rdr = null;
				SqlDataAdapter sqla = new SqlDataAdapter();
				SqlDataAdapter sqlb = new SqlDataAdapter();
				DataSet ds = new DataSet();
				string insp = "";
				string insp_date = "";
				string comp = "";
				string circ = "";
				string cliaddr = "";
				string prop = "";
				string prop_name = "";
				string prop_id = "";

				conn.ConnectionString = (string)Session["Connection"];
				conn.Open();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "insp_rep";

				cmd.Parameters.Add(
					new SqlParameter("@insp_id",linsp));

				rdr = cmd.ExecuteReader();

				while(rdr.Read())
				{
					insp=rdr["INSPECTOR"].ToString();
					prop_id = rdr["object_id"].ToString();
					prop = rdr["property"].ToString();
					prop_name = rdr["object_name"].ToString();
					comp = rdr["company_name"].ToString();
					insp_date=rdr["insp_date"].ToString();
					cliaddr=rdr["caddress"].ToString();
				}

				if( lprop.Property_ID == null)
				{
					lprop.Property_ID = prop_id;
					lprop.Property_Name = prop_name;
				}

				rdr.NextResult();
				while(rdr.Read())
				{
					int cnt = 0;
					if(cnt==0)
					{
						circ = rdr["firstname"].ToString() + " " + rdr["lastname"].ToString();
					}
					else
					{
						circ = circ + "," + rdr["firstname"].ToString() + " " + rdr["lastname"].ToString();
					}
				}
				
				rdr.Close();
				cmd.Dispose();

				crp = new Camelot.Reports.insp_rep();

				cde.TextObject txt = (cde.TextObject)crp.ReportDefinition.ReportObjects["txtCompany"];
				txt.Text = comp;
				txt = (cde.TextObject)crp.ReportDefinition.ReportObjects["cAddress"];
				txt.Text = cliaddr;
				txt = (cde.TextObject)crp.ReportDefinition.ReportObjects["txtProp"];
				txt.Text = prop;
				txt = (cde.TextObject)crp.ReportDefinition.ReportObjects["txtInsp"];
				txt.Text = insp;
				txt = (cde.TextObject)crp.ReportDefinition.ReportObjects["txtInspdate"];
				txt.Text = insp_date;
				txt = (cde.TextObject)crp.ReportDefinition.ReportObjects["txtCirc"];
				txt.Text = circ;
			
				this.CRv.ReportSource = crp;

				crSecs = crp.ReportDefinition.Sections;

				foreach(cde.Section crSec in crSecs)
				{
					crRepObs = crSec.ReportObjects;

					foreach (cde.ReportObject crRepOb in crRepObs)
					{
						if (crRepOb.Kind == ReportObjectKind.SubreportObject)
						{
							crSubrepOb = (cde.SubreportObject)crRepOb;
							crSubrepDoc = crSubrepOb.OpenSubreport(crSubrepOb.SubreportName);
							if(crSubrepDoc.Name=="insp_rep_comm.rpt")
							{
								
								cmd.Parameters.Clear();
								sqla.Dispose();

								cmd.CommandText = "get_inspection_comment";

								cmd.Parameters.Add(
									new SqlParameter("@insp_id", linsp));

								sqla.SelectCommand = cmd;

								sqla.Fill(ds,"Detail");

								crSubrepDoc.SetDataSource(ds);
							}

							if(crSubrepDoc.Name=="insp_meters.rpt")
							{
								
								cmd.Parameters.Clear();
								sqla.Dispose();

								cmd.CommandText = "get_inspection_report_meters";

								cmd.Parameters.Add(
									new SqlParameter("@insp_id", linsp));

								sqla.SelectCommand = cmd;

								sqla.Fill(ds,"meters");

								crSubrepDoc.SetDataSource(ds);
							}
							
							if(crSubrepDoc.Name=="insp_inc.rpt")
							{
								
								cmd.Parameters.Clear();
								sqla.Dispose();

								cmd.CommandText = "get_insp_report_incidents";

								cmd.Parameters.Add(
									new SqlParameter("@prop_id", lprop.Property_ID));

								sqla.SelectCommand = cmd;

								sqla.Fill(ds,"incident");

								crSubrepDoc.SetDataSource(ds);
							}

							if(crSubrepDoc.Name=="insp_res_inc.rpt")
							{
								
								cmd.Parameters.Clear();
								sqlb.Dispose();

								cmd.CommandText = "get_insp_report_res_incidents";

								cmd.Parameters.Add(
									new SqlParameter("@prop_id", lprop.Property_ID));

								cmd.Parameters.Add(
									new SqlParameter("@insp_id", linsp));

								sqlb.SelectCommand = cmd;

								sqlb.Fill(ds,"res_incs");

								crSubrepDoc.SetDataSource(ds);
							}
						}
					}
				}

				this.CRv.RefreshReport();

				if(action == "print")
				{
					this.crp.PrintOptions.PrinterName=Session["printer"].ToString();
					//this.crp.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Lower;
					this.crp.PrintToPrinter(1,false,0,0);
				}
				else
				{
					string ex = prop_name.Replace("."," ") + "_inspection.pdf";
					pdfFile = "c:/inetpub/wwwroot/camelot_crm/man_reports/" + ex;
					hpdf = "http://ntsbs01/camelot_crm/man_reports/" + ex;
					cd.ExportOptions eXop = crp.ExportOptions;

					eXop.ExportFormatType = ExportFormatType.PortableDocFormat;
					eXop.ExportDestinationType = ExportDestinationType.DiskFile;
					eXop.DestinationOptions = new DiskFileDestinationOptions();
					// Set the disk file options.
					DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions();
					( ( DiskFileDestinationOptions )crp.ExportOptions.DestinationOptions ).DiskFileName = pdfFile;
					crp.Export();
					Response.Write("<script>window.open('" + hpdf + "');</script>");
				}
				crp.Close();
				Response.Write("<script>window.close();</script>");				
			}
			catch(Exception es)
			{
				Response.Write(es.Message);
			}

		}

	
		private void set_rep_sent()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
	
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "set_rep_sent";

			cmd.Parameters.Add(
				new SqlParameter("@insp_id", linsp));
			
			cmd.ExecuteNonQuery();

			cmd.Dispose();
			conn.Close();

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

		}
		#endregion
	}
}
