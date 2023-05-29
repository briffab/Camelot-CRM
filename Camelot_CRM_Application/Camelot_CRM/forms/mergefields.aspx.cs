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
	/// Summary description for mergefields.
	/// </summary>
	public class mergefields : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblField;
		protected System.Web.UI.WebControls.TextBox txtField;
		protected System.Web.UI.WebControls.Button btnRup;
		protected System.Web.UI.WebControls.Button btnRdown;
		protected System.Web.UI.WebControls.ListBox lbMergeFields;
		protected System.Web.UI.WebControls.Button btnClose;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.Button btnRemove;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Button btnCsv;
		private cc.cUser pUser;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			bool oktogo;
			Camelot.classes.Utils pUtil = new Camelot.classes.Utils();
			pUser = (Camelot.classes.cUser)Session["curUser"];
			oktogo = pUtil.valid_user(pUser);

			this.btnClose.Attributes.Add("OnClick","Done();");

			if(!oktogo)
			{
				Response.Write("<script>window.close();</script>");
			}
			else
			{
				if(!Page.IsPostBack)
				{	
				
					getFields();
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
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.btnRup.Click += new System.EventHandler(this.btnRup_Click);
			this.btnRdown.Click += new System.EventHandler(this.btnRdown_Click);
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			this.btnCsv.Click += new System.EventHandler(this.btnCsv_Click);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void getFields()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.saveUtils us = new Camelot.classes.saveUtils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_merge_fields";

			rdr = cmd.ExecuteReader();
	
			this.lbMergeFields.Items.Clear();
			this.lbMergeFields.DataSource =rdr;
			this.lbMergeFields.DataValueField = "ORD" ;
			this.lbMergeFields.DataTextField = "FIELD";
			this.lbMergeFields.DataBind();

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
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
				data = data + "setup,";
			}

			csv.Add(fields);
			csv.Add(data);

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

			return csv;
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			ListItem li = new ListItem(this.txtField.Text);
			this.lbMergeFields.Items.Add(li);
		}

		private void btnRemove_Click(object sender, System.EventArgs e)
		{
			ArrayList fs = new ArrayList();
			foreach(ListItem li in this.lbMergeFields.Items)
			{
				if(li.Selected)
				{
					fs.Add(li);
				}
			}

			foreach(ListItem li in fs)
			{
				this.lbMergeFields.Items.Remove(li);
			}
		}

		private void btnRup_Click(object sender, System.EventArgs e)
		{
			int c = 0;
			ArrayList lists = new ArrayList();

			foreach(ListItem li in this.lbMergeFields.Items)
			{
				if(li.Selected)
				{
					lists.Add(li);
					c++;
				}
			}

			for(int i = 0; i<c;i++)
			{
				int index = this.lbMergeFields.Items.IndexOf((ListItem)lists[i]);				
				if(index > 0)
				{
					this.lbMergeFields.Items.Remove((ListItem)lists[i]);
					this.lbMergeFields.Items.Insert(index-1, (ListItem)lists[i]);
				}
			}
		}

		private void btnRdown_Click(object sender, System.EventArgs e)
		{
			int c = 0;
			ArrayList lists = new ArrayList();

			foreach(ListItem li in this.lbMergeFields.Items)
			{
				if(li.Selected)
				{
					lists.Add(li);
					c++;
				}
			}

			for(int i = c; i>0;i--)
			{
				int index = this.lbMergeFields.Items.IndexOf((ListItem)lists[i-1]);				
				if(index < this.lbMergeFields.Items.Count - 1)
				{
					this.lbMergeFields.Items.Remove((ListItem)lists[i-1]);
					this.lbMergeFields.Items.Insert(index+1, (ListItem)lists[i-1]);
				}
			}
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.close();</script>");
		}

		private void savefields()
		{
			int o = 1;

			deletefields();
			foreach(ListItem li in this.lbMergeFields.Items)
			{
				savefield(li.Text, o);
				o++;
			}
			Response.Write("<script>window.close();</script>");
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			savefields();
		}

		private void savefield(string field, int order)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			Camelot.classes.saveUtils us = new Camelot.classes.saveUtils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "add_merge_field";

			cmd.Parameters.Add(
				new SqlParameter("@field", field));
			cmd.Parameters.Add(
				new SqlParameter("@ORD", order));
			
			cmd.ExecuteNonQuery();

			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		private void deletefields()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			Camelot.classes.saveUtils us = new Camelot.classes.saveUtils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "DELETE_MERGE_FIELDS";
			
			cmd.ExecuteNonQuery();

			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		private void btnCsv_Click(object sender, System.EventArgs e)
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
