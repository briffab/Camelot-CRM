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
using System.IO;
using CC = Camelot.classes;
using System.Web.Mail;
using mw = Microsoft.Office.Interop.Word;


namespace Camelot.forms
{
	/// <summary>
	/// Summary description for send_emailmerge.
	/// </summary>
	public class send_emailmerge : System.Web.UI.Page
	{
		
		private CC.cFiles files = new Camelot.classes.cFiles();
		Camelot.classes.cUser pUser;
		string from = "";
		string to = "";
		string cc = "";
		string bcc = "";
		string subj = "";
		string body = "";
		string merge1 = "";
		string merge2 = "";
		string merge3 = "";
		string merge4 = "";
		string merge5 = "";
		string merge6 = "";
		string rec_type = "";
		string csvfile = "";
		string wordfile = "";
		string whdfile = "";
		string prop="";
		string dct = "";
		ArrayList recs = new ArrayList();
		string rec_name = "";

		private void Page_Load(object sender, System.EventArgs e)
		{
			rec_type = Session["rec_type"].ToString();
			prop = Session["mergeprop"].ToString();
			recs = (ArrayList)Session["cRecip"];
			dct = Session["direct"].ToString();
			wordfile = Session["wordfile"].ToString();
			csvfile = Session["csvfile"].ToString();
			whdfile = Session["whdfile"].ToString();
			
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
					strFilename = "c:\\inetpub\\wwwroot\\camelot_crm\\\\email\\" + dct + "\\" + Path.GetFileName(myFile.FileName);
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
			merge1 = Request["merge1"];
			merge2 = Request["merge2"];
			merge3 = Request["merge3"];
			merge4 = Request["merge4"];
			merge5 = Request["merge5"];
			merge6 = Request["merge6"];

			if(merge1 == null)
			{
				merge1 = "";
			}
			if(merge2 == null)
			{
				merge2 = "";
			}
			if(merge3 == null)
			{
				merge3 = "";
			}
			if(merge4 == null)
			{
				merge4 = "";
			}
			if(merge5 == null)
			{
				merge5 = "";
			}
			if(merge6 == null)
			{
				merge6 = "";
			}
			merge_sendmail();
		}

		private string getCSVFields()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.saveUtils us = new Camelot.classes.saveUtils();

			string fields = "";

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_merge_fields";

			rdr = cmd.ExecuteReader();
	
			while(rdr.Read())
			{
				fields = fields + rdr.GetValue(0).ToString() + ",";
			}

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

			return fields.Substring(0,fields.Length-1);
		}

		private void merge_sendmail()
		{
			foreach(string rec in recs)
			{
				createcsv(rec);
				mergedoc();
				sendemail(rec);
				save_email();
				//File.Delete(csvfile);
				//File.Delete(whdfile);
			}
			Response.Write("<script>alert('email sent')</script>");
			/*if(Directory.Exists("c:\\inetpub\\wwwroot\\camelot_crm\\\\email\\" + dct))
			{
				Directory.Delete("c:\\inetpub\\wwwroot\\camelot_crm\\\\email\\" + dct,true);
			}*/
		}

		private void sendemail(string rec)
		{
			CC.Utils uts = new Camelot.classes.Utils();
			if(rec_type=="1")
			{	
				to = getguardemail(rec);	
			}
			else
			{	
				to = getcontemail(rec);
			}
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
				MailAttachment att = new MailAttachment("c:\\inetpub\\wwwroot\\camelot_crm\\email\\" + dct + "\\" + rec_name + "_" + whdfile);
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

		private bool mergedoc()
		{
			Object oMissing = System.Reflection.Missing.Value;
			object oFalse = false;
			object wdFile = wordfile;
			object wdCSV = csvfile;
			object format = Microsoft.Office.Interop.Word.WdOpenFormat.wdOpenFormatText;
			object oOutFileName = "c:\\inetpub\\wwwroot\\camelot_crm\\email\\" + dct + "\\" + rec_name + "_" + whdfile;

			mw.Application wrdApp = new mw.Application();
			mw.Documents wrdDocs = wrdApp.Documents;
			object saveChanges = mw.WdSaveOptions.wdDoNotSaveChanges;

			try
			{		
				wrdApp.DisplayAlerts=mw.WdAlertLevel.wdAlertsNone;
				mw.Document wrdDoc = wrdDocs.Open(ref wdFile,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing);
				mw.MailMerge wrdMail = wrdDoc.MailMerge;
				wrdMail.OpenDataSource(csvfile,ref format,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing);
				wrdMail.Destination = Microsoft.Office.Interop.Word.WdMailMergeDestination.wdSendToNewDocument;
				wrdMail.Execute(ref oMissing);
				wrdApp.ActiveDocument.SaveAs(ref oOutFileName, ref oMissing, ref oMissing, 
					ref oMissing, ref oMissing, ref oMissing, ref oMissing,
					ref oMissing,  ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

				NAR(wrdMail);
				wrdMail = null;
				wrdDoc.Close(ref saveChanges,ref oMissing,ref oMissing);
				NAR(wrdDoc);
				wrdDoc = null;
				
				
				//wrdDocs.Close(ref saveChanges,ref oMissing,ref oMissing);
				foreach(mw.Document wd in wrdDocs)
				{
					wd.Close(ref saveChanges, ref oMissing, ref oMissing);
				}
				NAR(wrdDocs);
				wrdDocs=null;

				foreach(mw.Document wd in wrdApp.Documents)
				{
					wd.Close(ref saveChanges, ref oMissing, ref oMissing);
				}
				
				wrdApp.Quit(ref saveChanges,ref oMissing,ref oMissing);
				NAR(wrdApp);
				wrdApp = null;
				GC.Collect();
				GC.WaitForPendingFinalizers();

				GC.Collect();
				GC.WaitForPendingFinalizers();
				//save_corr_and_recips();
				
				return true;

			}
			catch(Exception ex)
			{
				//wrdApp.Documents.Close(ref oFalse, ref oMissing, ref oMissing);
				/*if(wrdDoc != null)
				{
					wrdDoc.Close(ref oMissing,ref oMissing,ref oMissing);
					NAR(wrdDoc);
					wrdDoc = null;
				}*/
				foreach(mw.Document wd in wrdApp.Documents)
				{
					wd.Close(ref saveChanges, ref oMissing, ref oMissing);
				}
				if(wrdDocs!=null)
				{
					NAR(wrdDocs);
					wrdDocs=null;
				}
				if(wrdApp != null)
				{
					wrdApp.Quit(ref oMissing,ref oMissing,ref oMissing);
					NAR(wrdApp);
					wrdApp = null;
				}
				GC.Collect();
				GC.WaitForPendingFinalizers();

				GC.Collect();
				GC.WaitForPendingFinalizers();
				//mergedoc();
				return false;

			}
		}

		private void createcsv(string rec)
		{
			string csv = "";
			ArrayList gds =  new ArrayList();
			//StreamWriter mfile = null;
			csv = getCSVFields();
			if(File.Exists(csvfile))
			{
				File.Delete(csvfile);
			}

			StreamWriter mfile = new StreamWriter(csvfile);
			
			//			try
			//			{
				
			mfile.WriteLine(csv);
			if(rec_type=="1")
			{	
				mfile.WriteLine(fillguardcsv(rec));	
			}
			else
			{	
				mfile.WriteLine(fillcontcsv(rec));
			}

			mfile.Close();
			//			}
			//			catch(Exception ex)
			//			{
			//				Response.Write(ex.Message);
			//				mfile.Close();
			//			}
			
		}

		private string fillguardcsv(string guard)
		{
			string grec="";

			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			cmd.CommandTimeout = 600;
			
			try
			{
				conn.ConnectionString = (string)Session["Connection"];
				conn.Open();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "get_merge_guard";

				cmd.Parameters.Add("@guard", System.Data.SqlDbType.VarChar);
				cmd.Parameters["@guard"].Value = guard;
				cmd.Parameters.Add("@emp", System.Data.SqlDbType.Int);
				cmd.Parameters["@emp"].Value = pUser.ID ;
		
				rdr = cmd.ExecuteReader();
				while(rdr.Read())
				{
					rec_name = rdr["firstname"].ToString().Replace(","," ") + "_" +rdr["lastname"].ToString().Replace(","," ");
					grec = rdr["lastname"].ToString().Replace(","," ") + "," + rdr["firstname"].ToString().Replace(","," ") + ",,,,";
					grec=grec + rdr["object_name"].ToString().Replace(","," ") + ",," + rdr["housename"].ToString().Replace(","," ") + "," + rdr["housenumber"].ToString().Replace(","," ") + "," + rdr["streetname"].ToString().Replace(","," ") + ",," + rdr["city"].ToString().Replace(","," ") + "," + rdr["county"].ToString().Replace(","," ") + "," + rdr["postalcode"].ToString().Replace(","," ") + ",";
					grec = grec + rdr["signature"].ToString().Replace(","," ") + "," + merge1.Replace(","," ") + "," + merge2.Replace(","," ") + "," + merge3.Replace(","," ") + "," + merge4.Replace(","," ") + "," + merge5.Replace(","," ") + "," + merge6.Replace(","," ") + "," + rdr["sigtitle"].ToString().Replace(","," ")+ "," + rdr["sigemail"].ToString().Replace(","," ") + ",";
					
					grec = grec.Replace("\r"," ");
					grec = grec.Replace("\n"," ");
					grec = grec + "\r";
				}

				return grec;
			}
			catch(Exception e)
			{
				Response.Write(e.Message);
				return null;
			}
		}

		private string fillcontcsv(string cont_id)
		{
			string grec="";

			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			cmd.CommandTimeout = 600;
			
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_merge_contact";

			cmd.Parameters.Add("@cont_id", System.Data.SqlDbType.VarChar);
			cmd.Parameters["@cont_id"].Value = cont_id;
			cmd.Parameters.Add("@emp", System.Data.SqlDbType.Int);
			cmd.Parameters["@emp"].Value = pUser.ID ;
			cmd.Parameters.Add("@prop_id", System.Data.SqlDbType.Int);
			cmd.Parameters["@prop_id"].Value = prop;
		
			rdr = cmd.ExecuteReader();
			while(rdr.Read())
			{
				rec_name = rdr["firstname"].ToString().Replace(","," ") + "_" +rdr["lastname"].ToString().Replace(","," ");
				grec = rdr["lastname"].ToString().Replace(","," ") + "," + rdr["firstname"].ToString().Replace(","," ") + "," + rdr["title"].ToString().Replace(","," ") + ",," + rdr["job_title"].ToString().Replace(","," ") + "," + rdr["object_name"].ToString().Replace(",",",") + ",";
				grec=grec + rdr["company"].ToString().Replace(","," ") + "," + rdr["housename"].ToString().Replace(","," ") + "," + rdr["housenumber"].ToString().Replace(","," ") + "," + rdr["streetname"].ToString().Replace(","," ") + ",," + rdr["city"].ToString().Replace(","," ") + "," + rdr["county"].ToString().Replace(","," ") + "," + rdr["postalcode"].ToString().Replace(","," ") + ",";
				grec = grec + rdr["signature"].ToString().Replace(","," ") + "," + merge1.Replace(","," ") + "," + merge2.Replace(","," ") + "," + merge3.Replace(","," ") + "," + merge4.Replace(","," ") + "," + merge5.Replace(","," ") + "," + merge6.Replace(","," ") + "," + rdr["sigtitle"].ToString().Replace(","," ")+ "," + rdr["sigemail"].ToString().Replace(","," ") + "," + rdr["salutation"].ToString().Replace(","," ");

				grec = grec.Replace("\r"," ");
				grec = grec.Replace("\n"," ");
				grec = grec + "\r";
			}
			return grec;			
		}

		private string getguardemail(string guard)
		{
			string email="";

			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			cmd.CommandTimeout = 600;
			
			try
			{
				conn.ConnectionString = (string)Session["Connection"];
				conn.Open();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "get_guard_email";

				cmd.Parameters.Add("@guard", System.Data.SqlDbType.VarChar);
				cmd.Parameters["@guard"].Value = guard;
		
				rdr = cmd.ExecuteReader();
				while(rdr.Read())
				{
					email=rdr.GetValue(0).ToString();
				}

				return email;
			}
			catch(Exception e)
			{
				Response.Write(e.Message);
				return null;
			}
		}
		
		private string getcontemail(string cont_id)
		{
			string email="";

			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			cmd.CommandTimeout = 600;
			
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_contact_email";

			cmd.Parameters.Add("@cont_id", System.Data.SqlDbType.VarChar);
			cmd.Parameters["@cont_id"].Value = cont_id;
		
			rdr = cmd.ExecuteReader();
			while(rdr.Read())
			{
				email = rdr.GetValue(0).ToString();
			}
			return email;			
		}

		private void NAR(object o)
		{
			try 
			{
				System.Runtime.InteropServices.Marshal.ReleaseComObject(o);
			}
			catch {}
			finally 
			{
				o = null;
			}
		}

		private void save_email()
		{
			int corr_id;
			int email_id;
			int att_id;
			
			ArrayList to_recip = new ArrayList();
			ArrayList cc_recip = new ArrayList();
			ArrayList bcc_recip = new ArrayList();
					
			if(to != null)
			{
				while(to.Length > 0)
				{
					if(to.IndexOf(";",0,to.Length) != 0 && to.IndexOf(";",0,to.Length) != -1)
					{
						to_recip.Add(to.Substring(1,to.IndexOf(";",0,to.Length)));
						to = to.Substring(to.IndexOf(";",0,to.Length)+1,to.Length - (to.IndexOf(";",0,to.Length)+1));
					}
					else
					{
						to_recip.Add(to);
						to = "";
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
						cc_recip.Add(tcc);
						tcc ="";
					}
				}
			}

			if(bcc != null)
			{
				string tbcc = bcc;
				while(tbcc.Length > 0)
				{
					if(tbcc.IndexOf(";",0,bcc.Length) != 0 && tbcc.IndexOf(";",0,tbcc.Length) != -1)
					{
						bcc_recip.Add(tbcc.Substring(0,tbcc.IndexOf(";",0,tbcc.Length)));
						tbcc = tbcc.Substring(tbcc.IndexOf(";",0,tbcc.Length)+1,tbcc.Length - (tbcc.IndexOf(";",0,tbcc.Length)+1));
					}
					else
					{
						bcc_recip.Add(tbcc);
						tbcc="";
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

				att_id = save_att("c:\\inetpub\\wwwroot\\camelot_crm\\email\\" + dct + "\\" + rec_name + "_" + whdfile);
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
				new SqlParameter("@C_TYPE", "3"));
			cmd.Parameters.Add(
				new SqlParameter("@target", this.rec_type));
			cmd.Parameters.Add(
				new SqlParameter("@PROP_id", prop));
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
