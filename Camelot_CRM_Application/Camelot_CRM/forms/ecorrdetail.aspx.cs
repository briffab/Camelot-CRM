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
using System.IO;

namespace Camelot.forms
{
	/// <summary>
	/// Summary description for corrdetail.
	/// </summary>
	public class ecorrdetail : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label lblfacdesc;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label lblUpBy;
		protected System.Web.UI.WebControls.Label lblUby;
		protected System.Web.UI.WebControls.Button btnClose;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblType;
		protected System.Web.UI.WebControls.Label lblDate;
		protected System.Web.UI.WebControls.ListBox lbRecipients;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblDir;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label lblBulk;
		Camelot.classes.cUser pUser;
		Camelot.classes.cProperty lcomp;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.ListBox lbnCRM;
		protected System.Web.UI.WebControls.DataGrid dgImgs;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label lblSubject;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.WebControls.TextBox txtBody;
		protected System.Web.UI.WebControls.Button btnCall;
		string sfile = "";
		string corr = "";

		private void Page_Load(object sender, System.EventArgs e)
		{
			bool oktogo;
			Camelot.classes.Utils pUtil = new Camelot.classes.Utils();
			pUser = (Camelot.classes.cUser)Session["curUser"];
			lcomp = (Camelot.classes.cProperty)Session["curProperty"];
			oktogo = pUtil.valid_user(pUser);

			corr = Request.QueryString["corr"];
			if(corr != "" && corr != null)
			{
				Session["corr_id"] = corr;
			}
			else
			{
				corr = (string)Session["corr_id"];
			}

			if(!oktogo)
			{
				Response.Redirect("../logon.aspx");
			}
			else
			{			
				Response.Expires = 0;
				Response.Cache.SetNoStore();
				Response.AppendHeader("Pragma", "no-cache");
								
				pop_corr(corr);
			}
			this.lblTitle.Text = lcomp.Property_Name;
						
		}


		private void pop_corr(string corr)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.Utils us = new Camelot.classes.Utils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_ecorr";

			cmd.Parameters.Add(
				new SqlParameter("@corr_id", corr));
			

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				lblType.Text=rdr["type"].ToString();
				lblDate.Text=rdr["C_date"].ToString();
				this.lblBulk.Text = rdr["bulk"].ToString();
				this.lblDir.Text = rdr["dir"].ToString();
				this.lblUby.Text = rdr["sent_by"].ToString();
				this.lblSubject.Text = rdr["subject"].ToString();
				this.txtBody.Text = rdr["body"].ToString();
			}
			rdr.NextResult();
			pop_recipients(rdr);

			rdr.NextResult();
			pop_recipients_no_crm(rdr);

			rdr.NextResult();
			pop_attachments(rdr);

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		public string get_employeename(int emp)
		{
			string name = "";
			Employees lemps = (Employees)Session["Emps"];
			
			foreach(Employee em in lemps)
			{
				if(Convert.ToInt32(em.Emp_ID) == emp)
				{
					name = em.Emp_Name;
					break;
				}
			}
			return name;
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
			this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void pop_recipients(SqlDataReader rs)
		{
			lbRecipients.DataSource = rs;
			lbRecipients.DataTextField = "name";
			lbRecipients.DataBind();
			
		}

		private void pop_recipients_no_crm(SqlDataReader rs)
		{
			this.lbnCRM.DataSource = rs;
			this.lbnCRM.DataTextField = "name";
			this.lbnCRM.DataBind();
			
		}

		private void pop_attachments(SqlDataReader rs)
		{
			this.dgImgs.DataSource = rs;
			this.dgImgs.DataBind();
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.close();</script>");
		}

		
		public void ShowAttachment(Object sender, DataGridCommandEventArgs e) 
		{
			
			getdoc(e.Item.Cells[0].Text);
			
		}

		private void getdoc(string doc_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_attach";

			cmd.Parameters.Add(
				new SqlParameter("@doc_ID", doc_id));

			rdr = cmd.ExecuteReader();
			while(rdr.Read())
			{
				byte[] img= new byte[0];
				img =  (byte[])rdr["merge_file"];
				string file = "c:\\inetpub\\wwwroot\\camelot_crm\\\\email\\\\" + rdr["filename"].ToString();
				string sfile = "http://ntsbs01/camelot_crm/email/" + rdr["filename"].ToString();
				FileStream fs = new FileStream(file, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write, System.IO.FileShare.ReadWrite);
				fs.Write(img,0,(int)rdr["filesize"]);
				fs.Close();
				Response.Write("<script>window.open('" + sfile + "');</script>");
			}
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
   
			
		}

		private void btnCall_Click(object sender, System.EventArgs e)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			string sfile = "";
			string hfile = "";
			string ex = System.DateTime.Now.Day.ToString() + "_" + System.DateTime.Now.Month.ToString() + "_" + System.DateTime.Now.Year.ToString() + "_callback.csv";
			sfile = "c:/inetpub/wwwroot/camelot_crm/mergedocs/" + ex;
			hfile = "http://ntsbs01/camelot_crm/mergedocs/" + ex;
			
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_ecallback_recipients";

			cmd.Parameters.Add(
				new SqlParameter("@corr_id", corr));


			StreamWriter mfile = new  StreamWriter(sfile);
			rdr = cmd.ExecuteReader();
			while(rdr.Read())
			{
				mfile.Write(rdr.GetValue(0).ToString()+"\r");
			}
			mfile.Close();

			Response.Write("<script>window.open('" + hfile + "');</script>");
		}
		
	}
}
