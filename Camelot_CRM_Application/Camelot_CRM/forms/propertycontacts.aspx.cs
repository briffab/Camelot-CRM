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

namespace Camelot
{
	/// <summary>
	/// Summary description for propertycontacts.
	/// </summary>
	public class propertycontacts : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList cmbFind;
		protected System.Web.UI.WebControls.TextBox txtFind;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.DataGrid dgProps;
		protected System.Web.UI.WebControls.DataGrid dgConts;
		protected System.Web.UI.HtmlControls.HtmlInputButton Button1;
		Camelot.classes.cProperty lprop;
		Camelot.classes.cCompany lcomp = new cCompany();
		Camelot.classes.cContact lcont = new Camelot.classes.cContact();
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label LblProp;
		Camelot.classes.cUser pUser;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			bool oktogo;
			Camelot.classes.Utils pUtil = new Camelot.classes.Utils();
			pUser = (Camelot.classes.cUser)Session["curUser"];
			oktogo = pUtil.valid_user(pUser);
			Session["insp_files"] = null;

			if (!Page.IsClientScriptBlockRegistered("Contact"))
			{		
				string title="Property Contacts";
				string height="500";
				string width="900";	
			 
				// use next line for direct with <base target="_self"> between <Head> and </HEAD> 
				string scrp="<script>var rc = new Array(0,0);function doIt(){rc= window.showModalDialog('addpropertycontact.aspx?Title="+title + "','','dialogHeight:"+height+" px;dialogWidth:"+width+" px;');"+"\n";
				scrp+="__doPostBack('','');}</script>";

				Page.RegisterStartupScript("Contact",scrp);			
				this.Button1.Attributes.Add("onClick","doIt();");
			}

			if(!oktogo)
			{
				Response.Redirect("../logon.aspx");
			}
			else
			{
				lcont.Contact_ID = "";
				Session["curCont"] = lcont;
				lprop= (Camelot.classes.cProperty)Session["curProperty"];
				bool vis = false;
				if(lprop.Property_ID==null)
				{
					vis = false;
				}
				else
				{
					vis = true;
					getContacts(Convert.ToInt32(lprop.Property_ID));
				}
				setvisible(vis);
				LblProp.Text = lprop.Property_Name;
			}
			
		}

		private void getContacts(int propid)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_property_contacts";

			cmd.Parameters.Add(
				new SqlParameter("@prop_id", propid));
			
			dgConts.DataSource = cmd.ExecuteReader();
			dgConts.DataBind();
			dgConts.Visible= true;
			conn.Close();
			conn.Dispose();
		}

		private void getProperties()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			string txt=this.txtFind.Text.Replace("'","''");

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;

			cmd.CommandText = "get_properties";

			cmd.Parameters.Add(
				new SqlParameter("@search", cmbFind.SelectedItem.Value));
			cmd.Parameters.Add(
				new SqlParameter("@crit", txt));

			rdr = cmd.ExecuteReader();
			dgProps.DataSource = rdr;
			dgProps.DataBind();
			dgProps.Visible= true;
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}


		private void setvisible(bool vis)
		{
			dgProps.Visible=!vis;
			dgConts.Visible = vis;
			if(pUser.Permission=="1")
			{
				Button1.Visible = vis;
			}
			else
			{
				Button1.Visible=false;
			}
		}
		public void set_prop(Object sender, DataGridCommandEventArgs e)
		{
			lprop= (Camelot.classes.cProperty)Session["curProperty"];
			lprop.Property_ID = e.Item.Cells[2].Text;
			lprop.Property_Name = e.Item.Cells[1].Text;
			lcomp=(Camelot.classes.cCompany)Session["curCompany"];
			lcomp.Company_ID = e.Item.Cells[3].Text;
			lcomp.Company_Name = e.Item.Cells[5].Text;
			Session["curCompany"] = lcomp;
			Session["curProperty"] = lprop;
			Response.Redirect("propertycontacts.aspx");
		}

		public void dgConts_ItemDataBound(Object sender, DataGridItemEventArgs e)
		{
			if(e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
			{
				LinkButton fButton = (LinkButton)e.Item.Cells[0].Controls[0];
				fButton.Attributes.Add("onclick", "javascript:window.showModalDialog('propertycontactdetails.aspx?cid=" + DataBinder.Eval(e.Item.DataItem, "contact_id") + "','contdets','dialogHeight: 500px; dialogWidth: 900px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');");
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
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.dgConts.SelectedIndexChanged += new System.EventHandler(this.dgConts_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			lprop= (Camelot.classes.cProperty)Session["curProperty"];
			lprop.Property_ID = null;
			Session["curProperty"] = lprop;

			bool vis = false;
			setvisible(vis);
			dgProps.Visible=vis;
			LblProp.Visible=false;
			
			if(txtFind.Text!="")
			{
				getProperties();		
			}
		}

		private void dgConts_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
