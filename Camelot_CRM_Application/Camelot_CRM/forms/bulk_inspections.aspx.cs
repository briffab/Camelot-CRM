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
using System.IO;
using System.Web.Mail;

namespace Camelot.forms
{
	/// <summary>
	/// Summary description for bulk_inspections.
	/// </summary>
	public class bulk_inspections : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblReps;
		protected System.Web.UI.WebControls.Label lblnrecs;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtCC;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtBcc;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtSubject;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtBody;
		protected System.Web.UI.WebControls.Label lblCount;
		protected System.Web.UI.WebControls.Button btnCheck;
		protected System.Web.UI.WebControls.Button btnUncheck;
		protected System.Web.UI.WebControls.DataGrid dgInsps;
		protected System.Web.UI.WebControls.Button btnSend;
		protected System.Web.UI.WebControls.Label lbl;
		protected System.Web.UI.WebControls.ListBox lbAtts;
		protected System.Web.UI.WebControls.Button btnRem;
		protected System.Web.UI.WebControls.Button btnAll;
		Camelot.classes.cUser pUser;
		Camelot.classes.cFiles insp_files = null;
		string prop_id = "";
		string pdfFile = "";
		string linsp = "";
		cr.insp_rep crp;
		cde.Sections crSecs;
		cde.ReportObjects crRepObs;
		cde.SubreportObject crSubrepOb;
		cde.ReportDocument crSubrepDoc;
		
		private ArrayList cRecips = new ArrayList();
		private ArrayList cRecipEmail = new ArrayList();

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
				Response.Expires = 0;
				Response.Cache.SetNoStore();
				Response.AppendHeader("Pragma", "no-cache");
				if(!Page.IsPostBack)
				{
					pop_reps();
					setchecks(true);
				}
				pop_atts();	
			}
		}

		private void pop_atts()
		{
			this.lbAtts.Items.Clear();
			insp_files = (Camelot.classes.cFiles)Session["insp_files"];
			if(insp_files != null)
			{
				foreach(cc.cFile f in insp_files)
				{
					this.lbAtts.Items.Add(Path.GetFileName(f.File));
				}
			}
		}



		private void setchecks(bool check)
		{
			
			foreach(DataGridItem dgi in this.dgInsps.Items)
			{
				CheckBox chkBox = (CheckBox)dgi.FindControl("schk");
				if(dgi.Cells[4].Text == "0")
				{
					TextBox txtbox = (TextBox)dgi.FindControl("txtEBody");
					txtbox.Enabled = false;
				}
				else
				{
					dgi.Cells[6].Enabled = true;
				}

				if(dgi.Cells[4].Text == "0" && dgi.Cells[5].Text == "0")
				{
					chkBox.Enabled = false;
					chkBox.Checked = false;
				}
				else
				{
					chkBox.Enabled = true;
					chkBox.Checked = check;
				}
			}
		}

		private void pop_reps()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_unsent_inspections";

			this.dgInsps.DataSource = cmd.ExecuteReader();
			this.dgInsps.DataBind();
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
			this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
			this.btnUncheck.Click += new System.EventHandler(this.btnUncheck_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnUncheck_Click(object sender, System.EventArgs e)
		{
			setchecks(true);
		}

		private void btnCheck_Click(object sender, System.EventArgs e)
		{
			setchecks(false);
		}

		private void btnSend_Click(object sender, System.EventArgs e)
		{
			foreach(DataGridItem dgi in this.dgInsps.Items)
			{
				CheckBox chkBox = (CheckBox)dgi.FindControl("schk");
				TextBox txt = (TextBox)dgi.FindControl("txtEBody");

				if(chkBox.Checked)
				{
					string insp = dgi.Cells[0].Text;
					string email = "";

					email = get_email(insp);
					if(email == "1")
					{
						string insp_rep = gen_report(insp, "print");
						//Response.Write("<script>window.showModalDialog('insp_brep.aspx?insp='" + insp + "&action=print','note','dialogHeight: 485px; dialogWidth: 800px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
					}
					else
					{
						string recip_email="";
						foreach(string em in cRecipEmail)
						{
							recip_email = recip_email + em + "; ";
						}
						send_inspection(insp,recip_email,txt.Text);
					}
					set_rep_sent(insp);
				}
			}
			Response.Write("<script>alert('All sent !!')</script>");
			insp_files = null;
			Session["insp_files"] = insp_files;
			this.pop_reps();
			this.setchecks(true);
			this.pop_atts();
		}

		private string get_email(string insp)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			string email = "";

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_binspection_email";

			cmd.Parameters.Add(
				new SqlParameter("@insp_id", insp));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				email = rdr.GetValue(0).ToString();
			}

			if(email == "2")
			{
				rdr.NextResult();
				while(rdr.Read())
				{
					cRecips.Add(rdr.GetValue(0).ToString());
					cRecipEmail.Add(rdr.GetValue(1).ToString());
				}
			}

			return email;

		}

		private void btnAll_Click(object sender, System.EventArgs e)
		{
			insp_files = null;
			Session["insp_files"] = insp_files;
			this.pop_atts();
		}

		private string gen_report(string l, string action)
		{
			Response.Expires = 0;
			Response.Cache.SetNoStore();
			Response.AppendHeader("Pragma", "no-cache");

			linsp = l;
			//prop = get_property(insp);

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
			string prop_name = "";
			string prop = "";

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "insp_rep";

			cmd.Parameters.Add(
				new SqlParameter("@insp_id", linsp));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				insp=rdr["INSPECTOR"].ToString();
				prop = rdr["property"].ToString();
				prop_id = rdr["object_id"].ToString();
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
								new SqlParameter("@prop_id", prop_id));

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
								new SqlParameter("@prop_id", prop_id));

							cmd.Parameters.Add(
								new SqlParameter("@insp_id", linsp));

							sqlb.SelectCommand = cmd;

							sqlb.Fill(ds,"res_incs");

							crSubrepDoc.SetDataSource(ds);
						}
					}
				}
			}

			//this.CRv.RefreshReport();

			if(action == "print")
			{
				this.crp.PrintOptions.PrinterName=Session["printer"].ToString();
				this.crp.PrintToPrinter(1,false,0,0);
			}
			else
			{

				
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
			}

			return pdfFile;
		}

		private void set_rep_sent(string linsp)
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

		private void send_inspection(string insp,string to, string eText)
		{
			cc.Utils uts = new Camelot.classes.Utils();
			MailMessage message = new MailMessage();
			try
			{
				if(insp_files != null)
				{
					foreach(cc.cFile file in insp_files)
					{
						MailAttachment attach = new MailAttachment(file.File);
						message.Attachments.Add(attach);
					}
				}

				string insp_rep = gen_report(insp, "email");
				MailAttachment att = new MailAttachment(insp_rep);
				message.Attachments.Add(att);
				att = null;

				
				message.From = pUser.Email;
		
				if(message.From == null)
				{
					message.From = "info@camelotproperty.com";
				}
				message.To = uts.validate_emails(to);
				message.Cc = uts.validate_emails(this.txtCC.Text);
				message.Bcc = uts.validate_emails(this.txtBcc.Text) + pUser.Email;
				message.Subject = this.txtSubject.Text;
				message.Body = this.txtBody.Text + "\n\n" + eText;
				message.BodyFormat = MailFormat.Text;
				message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", "2225"); 
				SmtpMail.SmtpServer = "192.168.75.1";
				//SmtpMail.SmtpServer="localhost";
				SmtpMail.Send(message);				
				Response.Flush();
				message = null;
				save_email(pdfFile, to, eText);
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

		private void save_email(string pdfile, string to, string eText)
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
						to_recip.Add(tto.Substring(0,tto.IndexOf(";",0,tto.Length)));
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

			if(this.txtCC.Text != null)
			{
				string tcc = this.txtCC.Text;
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

			if(this.txtBcc.Text != null)
			{
				string tbcc = this.txtBcc.Text;
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
				email_id = save_corr_email(eText);
				save_email_recip(email_id, to_recip, cc_recip, bcc_recip);
				if(insp_files != null)
				{
					foreach(cc.cFile file in insp_files)
					{
						att_id = save_att(file.File);
						save_corr_att(att_id, email_id);
					}
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
				new SqlParameter("@PROP_id", prop_id));
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


		private int save_corr_email(string eText)
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
				new SqlParameter("@subject",this.txtSubject.Text));

			cmd.Parameters.Add(
				new SqlParameter("@body",this.txtBody.Text + "\n\n" + eText));

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

		public void ShowReport(Object sender, DataGridCommandEventArgs e) 
		{
			string t = e.Item.Cells[0].Text;
            Response.Write("<script>window.showModalDialog('insp_brep.aspx?insp=" + t + "&action=view','note','dialogHeight: 485px; dialogWidth: 800px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
			//Response.Write("<script>window.ShowModalDialog('insp_brep.aspx?insp='" + t + "&action=view','note','dialogHeight: 485px; dialogWidth: 800px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
			
		}
	}
}
