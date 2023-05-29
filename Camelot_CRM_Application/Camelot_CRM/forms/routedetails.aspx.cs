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

namespace Camelot.forms
{
	/// <summary>
	/// Summary description for routedetails.
	/// </summary>
	public class routedetails : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtName;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button btnMto;
		protected System.Web.UI.WebControls.Button btnMfrom;
		protected System.Web.UI.WebControls.Button btnClose;
		protected System.Web.UI.WebControls.Button btnUpdate;
	
		private cc.cUser pUser = new Camelot.classes.cUser();
		protected System.Web.UI.WebControls.ListBox lbOnRoute;
		protected System.Web.UI.WebControls.ListBox lbNotRoute;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.CheckBox chkRoute;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label txtNum;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label lblLast;
		protected System.Web.UI.WebControls.Button btnRup;
		protected System.Web.UI.WebControls.Button btnRdown;
		protected System.Web.UI.WebControls.Label lblNameStar;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblName;
		private cc.cRoute lRoute;

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
				hideErr();
				string route = Request.QueryString["route_id"];
				lRoute=(Camelot.classes.cRoute)Session["curRoute"];
				if(!Page.IsPostBack)
				{	
					if(lRoute.Route_ID==null || lRoute.Route_ID=="")
					{
						lRoute.Route_ID = route;
					}
					if(route=="0")
					{
						getRoute();
						this.chkRoute.Checked=true;
					}
					else
					{
						getRoute();
					}
				}
			}
		}

		private void hideErr()
		{
			this.lblMessage.Visible=false;
			this.lblNameStar.Visible=false;
		}

		private void getRoute()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.saveUtils us = new Camelot.classes.saveUtils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_route_details";

			cmd.Parameters.Add(
				new SqlParameter("@route_id", lRoute.Route_ID));

			rdr = cmd.ExecuteReader();
			while(rdr.Read())
			{
				this.txtName.Text = rdr["name"].ToString();
				this.chkRoute.Checked = (bool)rdr["active"];
				this.lblLast.Text = rdr["lastinsp"].ToString();
			}
			rdr.NextResult();
			this.lbOnRoute.Items.Clear();
			this.lbOnRoute.DataSource =rdr;
			this.lbOnRoute.DataValueField = "prop_id" ;
			this.lbOnRoute.DataTextField = "prop_name";
			this.lbOnRoute.DataBind();

			rdr.NextResult();
			this.lbNotRoute.Items.Clear();
			this.lbNotRoute.DataSource =rdr;
			this.lbNotRoute.DataValueField = "prop_id" ;
			this.lbNotRoute.DataTextField = "prop_name";
			this.lbNotRoute.DataBind();

			this.txtNum.Text = Convert.ToString(this.lbOnRoute.Items.Count);

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

		}

		private void btnMto_Click(object sender, System.EventArgs e)
		{
			foreach(ListItem li in this.lbOnRoute.Items)
			{
				if(li.Selected)
				{
					this.lbNotRoute.Items.Add(li);
				}
			}

			foreach(ListItem li in this.lbNotRoute.Items)
			{
				this.lbOnRoute.Items.Remove(li);
			}

			this.txtNum.Text = Convert.ToString(this.lbOnRoute.Items.Count);
		}

		private void btnMfrom_Click(object sender, System.EventArgs e)
		{
			foreach(ListItem li in this.lbNotRoute.Items)
			{
				if(li.Selected)
				{
					this.lbOnRoute.Items.Add(li);
				}
			}

			foreach(ListItem li in this.lbOnRoute.Items)
			{
				this.lbNotRoute.Items.Remove(li);
			}

			this.txtNum.Text = Convert.ToString(this.lbOnRoute.Items.Count);
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
			this.btnRup.Click += new System.EventHandler(this.btnRup_Click);
			this.btnRdown.Click += new System.EventHandler(this.btnRdown_Click);
			this.btnMto.Click += new System.EventHandler(this.btnMto_Click);
			this.btnMfrom.Click += new System.EventHandler(this.btnMfrom_Click);
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.close();</script>");
		}

		private void btnRup_Click(object sender, System.EventArgs e)
		{
			int c = 0;
			ArrayList lists = new ArrayList();

			foreach(ListItem li in this.lbOnRoute.Items)
			{
				if(li.Selected)
				{
					lists.Add(li);
					c++;
				}
			}

			for(int i = 0; i<c;i++)
			{
				int index = this.lbOnRoute.Items.IndexOf((ListItem)lists[i]);				
				if(index > 0)
				{
					this.lbOnRoute.Items.Remove((ListItem)lists[i]);
					this.lbOnRoute.Items.Insert(index-1, (ListItem)lists[i]);
				}
			}
		}

		private void btnRdown_Click(object sender, System.EventArgs e)
		{
			int c = 0;
			ArrayList lists = new ArrayList();

			foreach(ListItem li in this.lbOnRoute.Items)
			{
				if(li.Selected)
				{
					lists.Add(li);
					c++;
				}
			}

			for(int i = c; i>0;i--)
			{
				int index = this.lbOnRoute.Items.IndexOf((ListItem)lists[i-1]);				
				if(index < this.lbOnRoute.Items.Count - 1)
				{
					this.lbOnRoute.Items.Remove((ListItem)lists[i-1]);
					this.lbOnRoute.Items.Insert(index+1, (ListItem)lists[i-1]);
				}
			}
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			
			if(lRoute.Route_ID=="0")
			{
				insertroute();
			}
			else
			{
				updateroute();
			}
			
			
		}

		private void saverest()
		{
			int o = 1;

			deleteprops();
			foreach(ListItem li in this.lbOnRoute.Items)
			{
				saveroute(li.Value, o);
				o++;
			}
			Response.Write("<script>window.close();</script>");
		}

		private void updateroute()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			Camelot.classes.saveUtils us = new Camelot.classes.saveUtils();

			if(this.txtName.Text=="")
			{
				this.lblMessage.Text = "Please supply a name for the route";
				this.lblMessage.Visible = true;
				this.lblNameStar.Visible = true;
			}
			else
			{
				conn.ConnectionString = (string)Session["Connection"];
				conn.Open();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UPDATE_ROUTE";

				cmd.Parameters.Add(
					new SqlParameter("@route_id", lRoute.Route_ID));
				cmd.Parameters.Add(
					new SqlParameter("@name", this.txtName.Text));
				cmd.Parameters.Add(
					new SqlParameter("@active", this.chkRoute.Checked));
			
				cmd.ExecuteNonQuery();

				cmd.Dispose();
				conn.Close();
				conn.Dispose();
            
				saverest();
			}

		}

		private void insertroute()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.saveUtils us = new Camelot.classes.saveUtils();

			string route = "";

			if(this.txtName.Text=="")
			{
				this.lblMessage.Text = "Please supply a name for the new route";
				this.lblMessage.Visible = true;
				this.lblNameStar.Visible = true;
			}
			else
			{

				conn.ConnectionString = (string)Session["Connection"];
				conn.Open();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "INSERT_ROUTE";

				cmd.Parameters.Add(
					new SqlParameter("@name", this.txtName.Text));
				cmd.Parameters.Add(
					new SqlParameter("@active", this.chkRoute.Checked));
			
				rdr = cmd.ExecuteReader();

				while(rdr.Read())
				{
					route = rdr.GetValue(0).ToString();
				}
				lRoute.Route_ID = route;
				cmd.Dispose();
				conn.Close();
				conn.Dispose();

				saverest();
			}

		}

		private void deleteprops()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			Camelot.classes.saveUtils us = new Camelot.classes.saveUtils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "DELETE_ROUTE_PROPERTIES";

			cmd.Parameters.Add(
				new SqlParameter("@route_id", lRoute.Route_ID));
			
			cmd.ExecuteNonQuery();

			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		private void saveroute(string prop, int order)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			Camelot.classes.saveUtils us = new Camelot.classes.saveUtils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "INSERT_ROUTE_PROPERTY";

			cmd.Parameters.Add(
				new SqlParameter("@route_id", lRoute.Route_ID));
			cmd.Parameters.Add(
				new SqlParameter("@PROP_id", prop));
			cmd.Parameters.Add(
				new SqlParameter("@ORDER", order));
			
			cmd.ExecuteNonQuery();

			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}
	}
}
