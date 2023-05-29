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
	public class insp_rep_NL : System.Web.UI.Page
	{
		protected CrystalDecisions.Web.CrystalReportViewer CRv;
		cc.cInspection linsp = new Camelot.classes.cInspection();
		string action = "";
		string ex = "";
		string pdfFile = "";
		string hpdf = "";

		cr.insp_rep_NL crp;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Button btnExport;
		cde.ReportDocument crSubrepDoc;

		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Expires = 0;
			Response.Cache.SetNoStore();
			Response.AppendHeader("Pragma", "no-cache");
			cc.cProperty lprop = new Camelot.classes.cProperty();

			lprop = (cc.cProperty)Session["curProperty"];
			linsp = (cc.cInspection)Session["curInspection"];
			
			action = Request.QueryString["action"].ToString();

			try
			{
				SqlConnection conn = new SqlConnection();
				SqlCommand cmd =  new SqlCommand();
				SqlDataReader rdr = null;
				SqlDataAdapter sqla = new SqlDataAdapter();
				SqlDataAdapter sqlb = new SqlDataAdapter();
				DataSet ds = new DataSet();
				string cname = "";
				string insp = "";
				string insp_date = "";
				string comp = "";
				string addr1 = "";
				string addr2 = "";
				string prop = "";
				string prop_name = "";
				string prop_id = "";
				string fname = "";
				string pref = "";
				string lastname = "";
				string city = "";
				string title = "";
				string para = "";
				string inits = "";
				string salute = "";
				string post = "";

				conn.ConnectionString = (string)Session["Connection"];
				conn.Open();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "insp_rep_NL";

				cmd.Parameters.Add(
					new SqlParameter("@insp_id", linsp.Inspection_ID));

				rdr = cmd.ExecuteReader();

				while(rdr.Read())
				{
					prop_id = rdr["object_id"].ToString();
					prop_name = rdr["object_name"].ToString();
					comp = rdr["company_name"].ToString();
					insp_date=rdr["insp_date"].ToString();
					addr1=rdr["addr1"].ToString();
					addr2 = rdr["addr2"].ToString();
					city= rdr["city"].ToString();
					fname = rdr["firstname"].ToString();
					lastname = rdr["lastname"].ToString();
					title = rdr["title"].ToString();
					pref = rdr["prefix"].ToString();
					inits = rdr["initials"].ToString();
					insp = rdr["insp"].ToString();
					salute = rdr["salutation"].ToString();
					post = rdr["postalcode"].ToString();
				}

				rdr.Close();
				cmd.Dispose();

				if( lprop.Property_ID == null)
				{
					lprop.Property_ID = prop_id;
					lprop.Property_Name = prop_name;
				}

				if(title != "" && title != null)
				{
					cname =  title + " ";
				}

				if(inits != "" && inits != null)
				{
					cname = cname + inits + " ";
				}

				if(lastname != "" && lastname != null)
				{
					cname = cname + lastname;
				}

				cname = "T.a.v " + cname;
				crp = new Camelot.Reports.insp_rep_NL();

				cde.TextObject txt = (cde.TextObject)crp.ReportDefinition.ReportObjects["txtComp"];
				txt.Text = comp;
				txt = (cde.TextObject)crp.ReportDefinition.ReportObjects["txtRecip"];
				txt.Text = cname;
				txt = (cde.TextObject)crp.ReportDefinition.ReportObjects["txtAddr1"];
				txt.Text = addr1;
				txt = (cde.TextObject)crp.ReportDefinition.ReportObjects["txtAddr2"];
				txt.Text = addr2;

				txt = (cde.TextObject)crp.ReportDefinition.ReportObjects["txtTitle"];
				txt.Text = salute;
			
				para = "Naar aanleiding van de controleronde op " + insp_date + " van het pand aan de " + prop_name + " te " + city + ", zend ik u hierbij het pandcontrole rapport.";
				
				txt = (cde.TextObject)crp.ReportDefinition.ReportObjects["txtPara1"];
				txt.Text = para;
				
				para = "Ik hoop u hiermee voldoende te hebben geinformeerd. Voor vragen of een verdere toelichting kunt u contact opnemen met ondergetekende.";
				
				txt = (cde.TextObject)crp.ReportDefinition.ReportObjects["txtPara2"];
				txt.Text = para;

				para = "Met vriendelijke groet,";

				txt = (cde.TextObject)crp.ReportDefinition.ReportObjects["txtPara3"];
				txt.Text = para;

				para = "Camelot Beheer";
				txt = (cde.TextObject)crp.ReportDefinition.ReportObjects["txtPara4"];
				txt.Text = para;
				
				txt = (cde.TextObject)crp.ReportDefinition.ReportObjects["txtInsp"];
				txt.Text = insp;
					
				txt = (cde.TextObject)crp.ReportDefinition.ReportObjects["txtPara5"];
				txt.Text = "Regiobeheer";

				
				this.CRv.ReportSource = crp;
				
				crSubrepDoc = crp.OpenSubreport("insp_prop_NL.rpt");
				cmd.Parameters.Clear();
				sqla.Dispose();
				cmd.CommandText = "get_insp_prop_nl";
				cmd.Parameters.Add(
					new SqlParameter("@prop_id", lprop.Property_ID));
				sqla.SelectCommand = cmd;
				sqla.Fill(ds,"prop");
				crSubrepDoc.SetDataSource(ds);

				crSubrepDoc = crp.OpenSubreport("insp_rep_comm.rpt");	
				cmd.Parameters.Clear();
				sqla.Dispose();
				cmd.CommandText = "get_inspection_comment";
				cmd.Parameters.Add(
					new SqlParameter("@insp_id", linsp.Inspection_ID));
				sqla.SelectCommand = cmd;
				sqla.Fill(ds,"Detail");
				crSubrepDoc.SetDataSource(ds);
				
				crSubrepDoc = crp.OpenSubreport("insp_guard_NL.rpt");	
				cmd.Parameters.Clear();
				sqla.Dispose();
				cmd.CommandText = "get_insp_report_guardians_NL";
				cmd.Parameters.Add(
					new SqlParameter("@prop_id", lprop.Property_ID));
				sqla.SelectCommand = cmd;
				sqla.Fill(ds,"guard");
				crSubrepDoc.SetDataSource(ds);

				crSubrepDoc = crp.OpenSubreport("insp_meters_NL.rpt");
				cmd.Parameters.Clear();
				sqla.Dispose();
				cmd.CommandText = "get_inspection_report_meters";
				cmd.Parameters.Add(
				new SqlParameter("@insp_id", linsp.Inspection_ID));
				sqla.SelectCommand = cmd;
				sqla.Fill(ds,"meters");
				crSubrepDoc.SetDataSource(ds);
							
				crSubrepDoc = crp.OpenSubreport("insp_inc.rpt");
				cmd.Parameters.Clear();
				sqla.Dispose();
				cmd.CommandText = "get_insp_report_incidents_NL";
				cmd.Parameters.Add(
				new SqlParameter("@prop_id", lprop.Property_ID));
				sqla.SelectCommand = cmd;
				sqla.Fill(ds,"incident");
				crSubrepDoc.SetDataSource(ds);

				crSubrepDoc = crp.OpenSubreport("insp_res_inc.rpt");
				cmd.Parameters.Clear();
				sqlb.Dispose();
				cmd.CommandText = "get_insp_report_res_incidents_NL";
				cmd.Parameters.Add(
				new SqlParameter("@prop_id", lprop.Property_ID));
				cmd.Parameters.Add(
				new SqlParameter("@insp_id", linsp.Inspection_ID));
				sqlb.SelectCommand = cmd;
				sqlb.Fill(ds,"res_incs");
				crSubrepDoc.SetDataSource(ds);


				this.CRv.RefreshReport();

				//				this.crp.PrintOptions.PrinterName=Session["printer"].ToString();
				//				this.crp.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Lower;
				//				this.crp.PrintToPrinter(1,false,0,0);

				
				ex = prop_name.Replace("."," ") + "_inspection.pdf";
				pdfFile = "c:/inetpub/wwwroot/camelot_crm/man_reports/" + ex;
				hpdf = "http://ntsbs01/camelot_crm/man_reports/" + ex;
				cd.ExportOptions eXop = crp.ExportOptions;

				eXop.ExportFormatType = ExportFormatType.PortableDocFormat;
				eXop.ExportDestinationType = ExportDestinationType.DiskFile;
				eXop.DestinationOptions = new DiskFileDestinationOptions();
				 //Set the disk file options.
				DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions();
				( ( DiskFileDestinationOptions )crp.ExportOptions.DestinationOptions ).DiskFileName = pdfFile;
				crp.Export();
				crp.Close();
				
				if(action=="send")
				{
					set_rep_sent();
				}

				Response.Write("<script>window.open('" + hpdf + "');</script>");
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
				new SqlParameter("@insp_id", linsp.Inspection_ID));
			
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

		private void btnExport_Click(object sender, System.EventArgs e)
		{
			savepdf();
			crp.Close();
		}

		private void savepdf()
		{
			ex = ex.Substring(0,ex.Length-4);
			ex = ex + ".pdf";
			string sfile = "c:/inetpub/wwwroot/camelot_crm/man_reports/" + ex;
			string hfile = "http://ntsbs01/camelot_crm/man_reports/" + ex;
			cd.ExportOptions eXop = crp.ExportOptions;

			eXop.ExportFormatType = cd.ExportFormatType.PortableDocFormat;
			eXop.ExportDestinationType = cd.ExportDestinationType.DiskFile;
			eXop.DestinationOptions = new cd.DiskFileDestinationOptions();
			// Set the disk file options.
			cd.DiskFileDestinationOptions diskOpts = new cd.DiskFileDestinationOptions();
			( ( cd.DiskFileDestinationOptions )crp.ExportOptions.DestinationOptions ).DiskFileName = sfile;
			crp.Export();

			Response.Write("<script>window.open('" + hfile + "');</script>");
			Response.Write("<script>window.close();</script>");
		}
	}
}
