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
using CC = Camelot.classes;
using System.Data.SqlClient;
using System.IO;

namespace Camelot.forms
{
	/// <summary>
	/// Summary description for compcorrreceived.
	/// </summary>
	public class compcorrreceived : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button btnClose;
		protected System.Web.UI.HtmlControls.HtmlInputFile scan;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.DropDownList cmbType;
		protected System.Web.UI.WebControls.Label lblDoc;
		protected System.Web.UI.WebControls.Label lblDate;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList cmbRecipient;
		protected System.Web.UI.HtmlControls.HtmlInputButton upload;
		
		CC.cUser pUser = null;
		protected System.Web.UI.WebControls.Label lblRec;
		protected System.Web.UI.HtmlControls.HtmlInputFile doc;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList cmbSender;
		protected System.Web.UI.WebControls.Label lblSender;
		CC.cCompany lcomp = null;
		int doc_id;

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

				lcomp=(CC.cCompany)Session["curCompany"];
				this.lblTitle.Text = lcomp.Company_Name;
				if(!Page.IsPostBack)
				{
					hideErr();
					poptypes();
					pop_recips();
					popconts();
				}
			}
		}

		private void pop_recips()
		{
			CC.Employees lemps = (CC.Employees)Session["Emps"];
			int ind =0;
			this.cmbRecipient.Items.Clear();
			this.cmbRecipient.Items.Add("");
			foreach(CC.Employee e in lemps)
			{
				this.cmbRecipient.Items.Add(e.Emp_Name);
				if(e.Emp_ID == pUser.ID.ToString())
				{
					ind = this.cmbRecipient.Items.Count-1;
				}
			}
			this.cmbRecipient.SelectedIndex = ind;
		}

		private void poptypes()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.Utils us = new Camelot.classes.Utils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_document_types";

			rdr = cmd.ExecuteReader();
		
			this.cmbType.Items.Clear();
			this.cmbType.DataSource = rdr;
			this.cmbType.DataTextField = "description";
			this.cmbType.DataValueField = "document_type";
			this.cmbType.DataBind();
				
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

		}

		private void popconts()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.Utils us = new Camelot.classes.Utils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_company_contacts_corr";

			cmd.Parameters.Add(
				new SqlParameter("@COMP_id", lcomp.Company_ID));

			rdr = cmd.ExecuteReader();
		
			this.cmbSender.Items.Clear();
			this.cmbSender.DataSource = rdr;
			this.cmbSender.DataTextField = "CNAME";
			this.cmbSender.DataValueField = "contact_id";
			this.cmbSender.DataBind();
				
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

		}

		private void hideErr()
		{
			this.lblMessage.Visible=false;
			this.lblDate.Visible=false;
			this.lblDoc.Visible=false;
			this.lblRec.Visible=false;
			this.lblSender.Visible=false;
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
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			this.upload.ServerClick += new System.EventHandler(this.upload_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void upload_ServerClick(object sender, System.EventArgs e)
		{
			bool oktosave = true;
			int cnt = 0;
			string Msg = "";
			CC.saveUtils su = new Camelot.classes.saveUtils();
			
			if(this.cmbType.SelectedItem.Text=="")
			{
				oktosave=false;
				cnt = 1;
				Msg = "Document Type";
				this.lblDoc.Visible=true;
			}

			if(!su.IsDate(su.setdate(txtDate.Text)))
			{
				oktosave=false;
				cnt++;
				if(Msg!="")
				{
					Msg = Msg + ", Date Recieved";
				}
				else
				{
					Msg = "Date Recieved";
				}
				this.lblDate.Visible=true;
			}

			if(this.cmbSender.SelectedItem.Text=="")
			{
				oktosave=false;
				cnt = 1;
				
				if(Msg!="")
				{
					Msg = Msg + ", Sender";
				}
				else
				{
					Msg = "Sender";
				}

				this.lblSender.Visible=true;
			}
			
			if(this.cmbRecipient.SelectedItem.Text=="")
			{
				oktosave=false;
				cnt = 1;
				
				if(Msg!="")
				{
					Msg = Msg + ", Recipient";
				}
				else
				{
					Msg = "Recipient";
				}

				this.lblRec.Visible=true;
			}

			if(oktosave)
			{
				int nFileLen = this.doc.PostedFile.ContentLength; 
				if( nFileLen > 0 )
				{
					// Allocate a buffer for reading of the file
					byte[] myData = new byte[nFileLen];

					// Read uploaded file from the Stream
					this.doc.PostedFile.InputStream.Read(myData, 0, nFileLen);

					// Create a name for the file to store
					string strFilename = Path.GetFileName(this.doc.PostedFile.FileName);
					WriteToDB(strFilename, ref myData);
				}
			}
			else
			{
				if(cnt==1)
				{
					Msg ="The field " + Msg + " is";
				}
				else
				{
					Msg ="The fields " + Msg + " are";
				}
				Msg = Msg+ " incomplete or in the wrong format";
				lblMessage.Text = Msg;
				lblMessage.Visible=true;
			}
		}

		private void WriteToDB(string strPath, ref byte[] full)
		{
			save_corr_and_recips(strPath, ref full);
			Response.Write("<script>window.close();</script>");

		}


		private void save_corr_and_recips(string strPath, ref byte[] full)
		{
			int corr_id;
			int doc_id;
			corr_id = save_corr();
			doc_id = save_doc(strPath,ref full);
			save_doc_recip(doc_id);
			save_corr_doc(doc_id, corr_id);
		}

		private int save_corr()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			int corr_id =0;
			CC.saveUtils su = new Camelot.classes.saveUtils();

			
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "insert_received_correspondence";

			cmd.Parameters.Add(
				new SqlParameter("@C_TYPE", this.cmbType.SelectedValue));
			cmd.Parameters.Add(
				new SqlParameter("@target", "3"));
			cmd.Parameters.Add(
				new SqlParameter("@rdate", DateTime.Parse(this.txtDate.Text)));
			cmd.Parameters.Add(
				new SqlParameter("@PROP_id", "0"));
			cmd.Parameters.Add(
				new SqlParameter("@COMP_id", lcomp.Company_ID));
			cmd.Parameters.Add(
				new SqlParameter("@bulk", "0"));
			cmd.Parameters.Add(
				new SqlParameter("@dir", "0"));
			cmd.Parameters.Add(
				new SqlParameter("@sender", this.cmbSender.SelectedItem.Text));

			rdr = cmd.ExecuteReader();
			while(rdr.Read())
			{
				corr_id = Convert.ToInt32(rdr.GetValue(0));
			}

			return corr_id;

		}

		private void save_doc_recip(int doc)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
	
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "insert_document_recipient";

			cmd.Parameters.Clear();
			cmd.Parameters.Add(
				new SqlParameter("@doc_id", doc));
			cmd.Parameters.Add(
				new SqlParameter("@recip",get_employeeid(this.cmbRecipient.SelectedItem.Text)));

			cmd.ExecuteNonQuery();
		}

		public int get_employeeid(string emp)
		{
			int id = 0;
			CC.Employees lemps = (CC.Employees)Session["Emps"];
			
			foreach(CC.Employee em in lemps)
			{
				if(em.Emp_Name == emp)
				{
					id = Convert.ToInt32(em.Emp_ID);
					break;
				}
			}
			return id;
		}

		private void save_corr_doc(int doc, int corr)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
	
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "insert_correspondence_document";

			cmd.Parameters.Add(
				new SqlParameter("@doc_id", doc));
			cmd.Parameters.Add(
				new SqlParameter("@corr", corr));

			cmd.ExecuteNonQuery();

		}

		private int save_doc(string strPath, ref byte[] full)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "insert_received_corr_doc";

			cmd.Parameters.Add(
				new SqlParameter("@MERGE_FILE", full));

			cmd.Parameters.Add(
				new SqlParameter("@FILESIZE",full.Length));

			cmd.Parameters.Add(
				new SqlParameter("@FILENAME",strPath));
			cmd.Parameters.Add(
				new SqlParameter("@DOC_TYPE",this.cmbType.SelectedValue));

			rdr = cmd.ExecuteReader();
			while(rdr.Read())
			{
				doc_id = Convert.ToInt32(rdr.GetValue(0));
			}

			return doc_id;

		}
		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.close();</script>");
		}
	}
}
