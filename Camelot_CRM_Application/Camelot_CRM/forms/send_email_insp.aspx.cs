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
using CC = Camelot.classes;
using cde = CrystalDecisions.CrystalReports.Engine;
using cd = CrystalDecisions.Shared;
using System.IO;
using System.Web.Mail;

namespace Camelot.forms
{
	/// <summary>
	/// Summary description for send_emailmerge.
	/// </summary>
	public class send_emailinsp : System.Web.UI.Page
	{
		
		private CC.cFiles files = new Camelot.classes.cFiles();
		Camelot.classes.cUser pUser;
		string from = "";
		string to = "";
		string cc = "";
		string bcc = "";
		string subj = "";
		string body = "";
		CC.cProperty lprop = null;
		ArrayList recs = new ArrayList();
		string pdfFile = "";
		string rec_type = "";
		CC.cInspection linsp = null;

		cr.insp_rep crp;
		cde.Sections crSecs;
		cde.ReportObjects crRepObs;
		cde.SubreportObject crSubrepOb;
		cde.ReportDocument crSubrepDoc;

		private void Page_Load(object sender, System.EventArgs e)
		{
			rec_type = "3";
			lprop = (CC.cProperty)Session["curProperty"];
			recs = (ArrayList)Session["iRecip"];
			
			if( Request.ContentType.IndexOf( "multipart/form-data" ) < 0 )
				return;

			string strFilename = "";
			pUser = (Camelot.classes.cUser)Session["curUser"];
		
			
			for( int i = 0; i < Request.Files.Count; i++ )
			{
				HttpPostedFile myFile = Request.Files[i];
				int nFileLen = myFile.ContentLength; 
				if( nFileLen > 0 )
				{
					// Allocate a buffer for reading of the file
					byte[] myData = new byte[nFileLen];

					// Read uploaded file from the Stream
					myFile.InputStream.Read(myData, 0, nFileLen);

					// Create a name for the file to store
					strFilename = "c:\\inetpub\\wwwroot\\camelot_crm\\email\\" + Path.GetFileName(myFile.FileName);
					CC.cFile file = new Camelot.classes.cFile();
					file.File = strFilename;
					file.Size = nFileLen.ToString();
					file.Data = myData;
					myFile.SaveAs(strFilename);
					files.Add(file);
				}
				//Response.Write( strFilename + "\r\n" );
			}

			from = pUser.Email;
			cc= Request["cc"];
			bcc = Request["bcc"];
			subj = Request["subject"];
			body = Request["body"];
			send_inspection();
		}

		private string gen_report()
		{
			Response.Expires = 0;
			Response.Cache.SetNoStore();
			Response.AppendHeader("Pragma", "no-cache");
			CC.cProperty lprop = new Camelot.classes.cProperty();

			lprop = (CC.cProperty)Session["curProperty"];
			linsp = (CC.cInspection)Session["curInspection"];

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

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "insp_rep";

			cmd.Parameters.Add(
				new SqlParameter("@insp_id", linsp.Inspection_ID));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				insp=rdr["INSPECTOR"].ToString();
				prop = rdr["property"].ToString();
				prop_name = rdr["object_name"].ToString();
				comp = rdr["company_name"].ToString();
				insp_date=rdr["insp_date"].ToString();
				cliaddr=rdr["caddress"].ToString();
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
			
			//this.CRv.ReportSource = crp;

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
								new SqlParameter("@insp_id", linsp.Inspection_ID));

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
								new SqlParameter("@insp_id", linsp.Inspection_ID));

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
								new SqlParameter("@insp_id", linsp.Inspection_ID));

							sqlb.SelectCommand = cmd;

							sqlb.Fill(ds,"res_incs");

							crSubrepDoc.SetDataSource(ds);
						}
					}
				}
			}

			//this.CRv.RefreshReport();

			//				this.crp.PrintOptions.PrinterName=Session["printer"].ToString();
			//				this.crp.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Lower;
			//				this.crp.PrintToPrinter(1,false,0,0);

				
			string ex = prop_name.Replace("."," ") + "_inspection.pdf";
			pdfFile = "c:/inetpub/wwwroot/camelot_crm/man_reports/" + ex;
	
			cd.ExportOptions eXop = crp.ExportOptions;

			eXop.ExportFormatType = ExportFormatType.PortableDocFormat;
			eXop.ExportDestinationType = ExportDestinationType.DiskFile;
			eXop.DestinationOptions = new DiskFileDestinationOptions();
			// Set the disk file options.
			DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions();
			( ( DiskFileDestinationOptions )crp.ExportOptions.DestinationOptions ).DiskFileName = pdfFile;
			crp.Export();
			crp.Close();

			return pdfFile;
		}

		private void send_inspection()
		{
			CC.Utils uts = new Camelot.classes.Utils();
			MailMessage message = new MailMessage();
			try
			{
				if(files != null)
				{
					foreach(CC.cFile file in files)
					{
						MailAttachment attach = new MailAttachment(file.File);
						message.Attachments.Add(attach);
					}
				}

				string insp_rep = gen_report();
				MailAttachment att = new MailAttachment(insp_rep);
				message.Attachments.Add(att);
				att = null;


				message.From = from;			
		
				if(message.From == null)
				{
					message.From = "info@camelotproperty.com";
				}
				message.To = uts.validate_emails(to);
				message.Cc = uts.validate_emails(cc);
				message.Bcc = uts.validate_emails(bcc) + pUser.Email;
				message.Subject = subj;
				message.Body = body;
				message.BodyFormat = MailFormat.Text;
				message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", "2225"); 
				SmtpMail.SmtpServer = "192.168.75.1";
				//SmtpMail.SmtpServer="localhost";
				SmtpMail.Send(message);				
				Response.Flush();
				message = null;
				save_email(pdfFile);
				Response.Write("<script>alert('email Sent')</script>");
			}
			catch(Exception ex)
			{
				while( ex.InnerException != null )
				{
					Response.Write("--------------------------------");
					Response.Write("The following InnerException reported: " + ex.InnerException.ToString() );
					ex = ex.InnerException;
				}
				Response.Write("<script>alert('email failed');</script>");
				message = null;
			}
		}

		private void save_email(string pdfFile)
		{
			int corr_id;
			int email_id;
			int att_id;
			
			ArrayList to_recip = new ArrayList();
			ArrayList cc_recip = new ArrayList();
			ArrayList bcc_recip = new ArrayList();
					
			if(to != null)
			{
				string tto = to;
				while(tto.Length > 0)
				{
					if(tto.IndexOf(";",0,tto.Length) != 0 && tto.IndexOf(";",0,tto.Length) != -1)
					{
						to_recip.Add(tto.Substring(1,tto.IndexOf(";",0,tto.Length)));
						tto = tto.Substring(tto.IndexOf(";",0,tto.Length)+1,tto.Length - (tto.IndexOf(";",0,tto.Length)+1));
					}
					else
					{
						tto = tto.Trim();
						if(tto.Length > 0)
						{
							to_recip.Add(tto);
							tto = "";
						}
					}
				}
			}

			if(cc != null)
			{
				string tcc = cc;
				while(tcc.Length > 0)
				{
					if(tcc.IndexOf(";",0,tcc.Length) != 0 && tcc.IndexOf(";",0,tcc.Length) != -1)
					{
						cc_recip.Add(tcc.Substring(0,tcc.IndexOf(";",0,tcc.Length)));
						tcc = tcc.Substring(tcc.IndexOf(";",0,tcc.Length)+1,tcc.Length - (tcc.IndexOf(";",0,tcc.Length)+1));
					}
					else
					{
						tcc = tcc.Trim();
						if(tcc.Length > 0)
						{
							cc_recip.Add(tcc);
							tcc = "";
						}
					}
				}
			}

			if(bcc != null)
			{
				string tbcc = bcc;
				while(tbcc.Length > 0)
				{
					if(tbcc.IndexOf(";",0,tbcc.Length) != 0 && tbcc.IndexOf(";",0,tbcc.Length) != -1)
					{
						bcc_recip.Add(tbcc.Substring(0,tbcc.IndexOf(";",0,tbcc.Length)));
						tbcc = tbcc.Substring(tbcc.IndexOf(";",0,tbcc.Length)+1,tbcc.Length - (tbcc.IndexOf(";",0,tbcc.Length)+1));
					}
					else
					{
						tbcc = tbcc.Trim();
						if(tbcc.Length > 0)
						{
							bcc_recip.Add(tbcc);
							tbcc = "";
						}
					}
				}
			}


			if(to_recip.Count + cc_recip.Count + bcc_recip.Count > 0)
			{
				corr_id = save_corr(to_recip, cc_recip, bcc_recip);
				email_id = save_corr_email();
				save_email_recip(email_id, to_recip, cc_recip, bcc_recip);
				foreach(CC.cFile file in files)
				{
					att_id = save_att(file.File);
					save_corr_att(att_id, email_id);
				}

				att_id = save_att(pdfFile);
				save_corr_att(att_id, email_id);

				save_email_corr(email_id, corr_id);
			}
		}

		private void save_corr_att(int att, int email)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
	
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "insert_email_document";

			cmd.Parameters.Add(
				new SqlParameter("@email_id", email));
			cmd.Parameters.Add(
				new SqlParameter("@doc_id", att));

			cmd.ExecuteNonQuery();

		}

		private void save_email_corr(int email, int corr)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
	
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "insert_correspondence_email";

			cmd.Parameters.Add(
				new SqlParameter("@email_id", email));
			cmd.Parameters.Add(
				new SqlParameter("@corr", corr));

			cmd.ExecuteNonQuery();

		}

		private int save_corr(ArrayList to_recip,ArrayList cc_recip,ArrayList bcc_recip)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			int bulk = 0;
			int corr_id =0;

			if(to_recip.Count + cc_recip.Count + bcc_recip.Count > 1)
			{
				bulk = 1;
			}

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "insert_correspondence";

			cmd.Parameters.Add(
				new SqlParameter("@C_TYPE", "1"));
			cmd.Parameters.Add(
				new SqlParameter("@target", "2"));
			cmd.Parameters.Add(
				new SqlParameter("@PROP_id", lprop.Property_ID));
			cmd.Parameters.Add(
				new SqlParameter("@COMP_id", "0"));
			cmd.Parameters.Add(
				new SqlParameter("@bulk", bulk));
			cmd.Parameters.Add(
				new SqlParameter("@dir", "1"));
			cmd.Parameters.Add(
				new SqlParameter("@sender", pUser.Name));

			rdr = cmd.ExecuteReader();
			while(rdr.Read())
			{
				corr_id = Convert.ToInt32(rdr.GetValue(0));
			}

			return corr_id;

		}

		private int save_att(string attach)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			int att_id =0;
			int fsize;
			FileInfo ifile = new FileInfo(attach);
			FileStream final = ifile.OpenRead();
			fsize = Convert.ToInt32(ifile.Length);
			byte[] bfinal = new byte[fsize];
			final.Read(bfinal,0,fsize);
			string strFilename = Path.GetFileName(ifile.Name);

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "insert_corr_doc";

			cmd.Parameters.Add(
				new SqlParameter("@MERGE_FILE", bfinal));

			cmd.Parameters.Add(
				new SqlParameter("@FILESIZE",fsize));

			cmd.Parameters.Add(
				new SqlParameter("@FILENAME",strFilename));

			rdr = cmd.ExecuteReader();
			while(rdr.Read())
			{
				att_id = Convert.ToInt32(rdr.GetValue(0));
			}

			return att_id;
		}


		private int save_corr_email()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			int email_id = 0;
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "insert_corr_email";

			cmd.Parameters.Add(
				new SqlParameter("@subject",subj));

			cmd.Parameters.Add(
				new SqlParameter("@body",body));

			rdr = cmd.ExecuteReader();
			while(rdr.Read())
			{
				email_id = Convert.ToInt32(rdr.GetValue(0));
			}

			return email_id;

		}

		private void save_email_recip(int email, ArrayList to, ArrayList cc, ArrayList Bcc)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
	
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "insert_email_recipient";

			foreach(string recip in to)
			{
				cmd.Parameters.Clear();
				cmd.Parameters.Add(
					new SqlParameter("@email_id", email));
				cmd.Parameters.Add(
					new SqlParameter("@email", recip));
				cmd.Parameters.Add(
					new SqlParameter("@to_type", "0"));

				cmd.ExecuteNonQuery();
			}

			foreach(string recip in cc)
			{
				cmd.Parameters.Clear();
				cmd.Parameters.Add(
					new SqlParameter("@email_id", email));
				cmd.Parameters.Add(
					new SqlParameter("@email", recip.Trim()));
				cmd.Parameters.Add(
					new SqlParameter("@to_type", "1"));

				cmd.ExecuteNonQuery();
			}

			foreach(string recip in Bcc)
			{
				cmd.Parameters.Clear();
				cmd.Parameters.Add(
					new SqlParameter("@email_id", email));
				cmd.Parameters.Add(
					new SqlParameter("@email", recip.Trim()));
				cmd.Parameters.Add(
					new SqlParameter("@to_type", "2"));

				cmd.ExecuteNonQuery();
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
		}
		#endregion
	}
}
