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

namespace Camelot.forms
{
	/// <summary>
	/// Summary description for emailmerge.
	/// </summary>
	public class emailmerge : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblDocName;
		protected System.Web.UI.WebControls.Label lblDoc;
		protected System.Web.UI.WebControls.Label lblRecs;
		protected System.Web.UI.WebControls.Label lblnrecs;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtMerge1;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.TextBox txtMerge2;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.TextBox txtMerge3;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.TextBox txtMerge4;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.TextBox txtMerge5;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.TextBox txtMerge6;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtCC;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtBcc;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtSubject;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.TextBox txtBody;
		protected System.Web.UI.WebControls.Button btnClose;

		string rec_type = "";
		string prop;
		ArrayList recemail;
		string csvfile = "";
		string wordfile="";
		string whfile = "";
		string whdfile = "";
		string ex = "";
		string drt = "";
		string doc_id = "";
		Camelot.classes.cUser pUser;
	
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
				if(!Page.IsPostBack)
				{
					recemail = (ArrayList)Session["cEmail"];
						
					rec_type = Request.QueryString["recip_type"];
					Session["rec_type"] = rec_type;
					
					doc_id = Request.QueryString["doc_id"];
					Session["doc_id"] = doc_id;

					prop = Request.QueryString["prop"];
					Session["mergeprop"] = prop;

					prop = Request.QueryString["prop"];
					Session["mergeprop"] = prop;
					get_files();
				}
				prop = Session["mergeprop"].ToString();
				rec_type = Session["rec_type"].ToString();
			}			
		}

		private void get_files()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.saveUtils us = new Camelot.classes.saveUtils();
			string docname = "";

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_merge_doc";

			cmd.Parameters.Add(
				new SqlParameter("@doc_id", doc_id));

			rdr = cmd.ExecuteReader();
	
			while(rdr.Read())
			{
				docname = rdr["doc_name"].ToString();
				ex = System.DateTime.Now.Hour.ToString() + "_" + System.DateTime.Now.Minute.ToString() + "_" + System.DateTime.Now.Second.ToString() + "_" + System.DateTime.Now.Day.ToString() + "_" + System.DateTime.Now.Month.ToString() + "_" + System.DateTime.Now.Year.ToString() + "_" + rdr["doc_name"].ToString();
				drt = ex.Substring(0,(ex.Length-4));
				Directory.CreateDirectory("c:\\inetpub\\wwwroot\\camelot_crm\\\\email\\\\" + drt);
				byte[] mdoc= new byte[0];
				mdoc =  (byte[])rdr["document"];
				wordfile = "c:\\inetpub\\wwwroot\\camelot_crm\\\\email\\\\" + drt + "\\\\" + ex;		
				FileStream fs = new FileStream(wordfile, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write, System.IO.FileShare.ReadWrite);
				fs.Write(mdoc,0,(int)rdr["filesize"]);
				fs.Close();
			}

			whfile = "http://ntsbs01/camelot_crm/email/" + drt + "/" + docname;
			whdfile= docname;
			csvfile = "c:\\inetpub\\wwwroot\\camelot_crm\\\\email\\\\" + drt + "\\\\" + ex.Substring(0,ex.Length-4) + "data.csv";
			
			Session["wordfile"]=wordfile;
			Session["csvfile"] = csvfile;
			Session["whfile"] = whfile;
			Session["whdfile"] = whdfile;
			Session["direct"] = drt;
			
			this.lblDoc.Text = docname;
			this.lblnrecs.Text = recemail.Count.ToString();

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.close();</script>");
		}
	}
}
