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
using System.IO;
using System.Data.SqlClient;
using CC = Camelot.classes;
using System.Web.Mail;


namespace Camelot.forms
{
	/// <summary>
	/// Summary description for upload1.
	/// </summary>
	/// 
	public class send_email_att : System.Web.UI.Page
	{
		private CC.cFiles files = new Camelot.classes.cFiles();
		Camelot.classes.cUser pUser;
		string from = "";
		string to = "";
		string cc = "";
		string bcc = "";
		string subj = "";
		string body = "";

		private void Page_Load(object sender, System.EventArgs e)
		{
			
			if( Request.ContentType.IndexOf( "multipart/form-data" ) < 0 )
				return;

			string strFilename = "";
			pUser = (Camelot.classes.cUser)Session["curUser"];
		
			//Response.Write( Request.Files.Count.ToString() + " file(s) have been uploaded:\r\n\r\n" );
			
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
					strFilename = "c:\\inetpub\\wwwroot\\camelot_crm\\\\email\\\\" + Path.GetFileName(myFile.FileName);
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
			to = Request["to"];
			cc= Request["cc"];
			bcc = Request["bcc"];
			subj = Request["subject"];
			body = Request["body"];
			sendmail();
		}

		private void sendmail()
		{
			
			MailMessage message = new MailMessage();
			try
			{
				CC.Utils uts = new Camelot.classes.Utils();
				if(files != null)
				{
					foreach(CC.cFile file in files)
					{
						MailAttachment attach = new MailAttachment(file.File);
						message.Attachments.Add(attach);
					}
				}
			
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
				SmtpMail.Send(message);
				foreach(CC.cFile file in files)	
				{
					File.Delete(file.File);
				}
				Response.Flush();

				Response.Write("<script>alert('email sent');</script>");
			}
			catch(Exception ex)
			{
				while( ex.InnerException != null )
				{
					Response.Write("--------------------------------");
					Response.Write("The following InnerException reported: " + ex.InnerException.ToString() );
					ex = ex.InnerException;
					Response.Write("<script>alert('email failed');</script>");
				}
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
