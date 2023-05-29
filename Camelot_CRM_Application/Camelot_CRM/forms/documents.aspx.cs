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
using cc = Camelot.classes;
using System.IO;

namespace Camelot.forms
{
	/// <summary>
	/// Summary description for documents.
	/// </summary>
	public class documents : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label LblProp;
		protected System.Web.UI.WebControls.DataGrid dgDocs;
		protected System.Web.UI.HtmlControls.HtmlInputButton Button1;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnMerge;
		cc.cUser pUser;

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			bool oktogo;
			Camelot.classes.Utils pUtil = new Camelot.classes.Utils();
			pUser = (Camelot.classes.cUser)Session["curUser"];
			oktogo = pUtil.valid_user(pUser);
			Session["insp_files"] = null;

			if(!oktogo)
			{
				Response.Redirect("../logon.aspx");
			}
			else
			{
				getDocuments();
			}

			if(pUser.AccMan!="True")
			{
				this.dgDocs.Columns[7].Visible=false;
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
			this.Button1.ServerClick += new System.EventHandler(this.Button1_ServerClick);
			this.btnMerge.ServerClick += new System.EventHandler(this.btnMerge_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public void dgDocs_ItemDataBound(Object sender, DataGridItemEventArgs e)
		{
			if(e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
			{
				LinkButton fButton = (LinkButton)e.Item.Cells[1].Controls[0];
				fButton.Attributes.Add("onclick", "javascript:window.showModalDialog('doc_admin.aspx?doc=" + DataBinder.Eval(e.Item.DataItem, "doc_id") + "','docs','dialogHeight: 400px; dialogWidth: 700px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');self.document.location.href = 'documents.aspx';");
			}
		}

		public void dgDocs_delete(Object sender, DataGridCommandEventArgs e)
		{
			delete_doc(e.Item.Cells[0].Text);
		}

		private void delete_doc(string doc_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "delete_Document";

			cmd.Parameters.Add(
				new SqlParameter("@doc_id", doc_id));

			cmd.ExecuteNonQuery();

			cmd.Dispose();
			conn.Dispose();
			conn.Close();

			this.getDocuments();

		}

		private void getDocuments()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_merge_Documents";
			
			dgDocs.DataSource = cmd.ExecuteReader();
			dgDocs.DataBind();
			dgDocs.Visible= true;
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}
		

		private void Button1_ServerClick(object sender, System.EventArgs e)
		{
			
			Response.Write("<script>window.showModalDialog('add_doc.aspx','docs','dialogHeight: 400px; dialogWidth: 700px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
			Response.Write("<script>self.document.location.href = 'documents.aspx';</script>");
		}

		private ArrayList getCSVFields()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.saveUtils us = new Camelot.classes.saveUtils();

			ArrayList csv = new ArrayList();
			string fields = "";
			string data = "";

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_merge_fields";

			rdr = cmd.ExecuteReader();
	
			while(rdr.Read())
			{
				fields = fields + rdr.GetValue(0).ToString() + ",";
				data = data + rdr.GetValue(0).ToString()+ " data,";
			}

			csv.Add(fields);
			csv.Add(data);

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

			return csv;
		}

		private void btnMerge_ServerClick(object sender, System.EventArgs e)
		{
			string sfile = "";
			string hfile = "";
			ArrayList csv = new ArrayList();

			csv = getCSVFields();
			string ex = System.DateTime.Now.Day.ToString() + "_" + System.DateTime.Now.Month.ToString() + "_" + System.DateTime.Now.Year.ToString() + "_mergefields.csv";
			sfile = "c:/inetpub/wwwroot/camelot_crm/mergedocs/" + ex;
			hfile = "http://ntsbs01/camelot_crm/mergedocs/" + ex;

			StreamWriter mfile = new  StreamWriter(sfile);
			foreach(string str in csv)
			{
				mfile.Write(str+"\r");
			}
			mfile.Close();

			Response.Write("<script>window.open('" + hfile + "');</script>");
		}
	}
}
