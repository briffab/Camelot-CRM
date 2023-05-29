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
	/// Summary description for blankinspection.
	/// </summary>
	public class blankinspection : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtDamage;
		
		Camelot.classes.Utils Utils = new Camelot.classes.Utils();
		Camelot.classes.cInspection linsp = new cInspection();
		public Camelot.classes.cProperty lprop;
		protected System.Web.UI.WebControls.DataGrid dgMets;
		protected System.Web.UI.WebControls.Image propImg;
		Camelot.classes.cUser pUser;
		protected System.Web.UI.WebControls.Label lblName;
		protected System.Web.UI.WebControls.Label lblAddress;
		protected System.Web.UI.WebControls.Label lblTown;
		protected System.Web.UI.WebControls.Label lblPost;
		protected System.Web.UI.WebControls.Label lblOwner;
		protected System.Web.UI.WebControls.Label lblCont;
		public string defUrl;
		private int lcnt = 0;
		protected System.Web.UI.WebControls.Label lblPropNo;
		protected System.Web.UI.WebControls.Label lblKeyNo;
		protected System.Web.UI.WebControls.Label lblCalam;
		protected System.Web.UI.WebControls.Label lblLast;
		protected System.Web.UI.WebControls.Label lblMaxOccup;
		private int rocnt = 0;

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
				lprop = (Camelot.classes.cProperty)Session["curProperty"];

				Response.Expires = 0;
				Response.Cache.SetNoStore();
				Response.AppendHeader("Pragma", "no-cache");


				pop_details(lprop.Property_ID);
				pop_pic(lprop.Property_ID);
			}
		}

		private void pop_pic(string prop)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_def_photos";

			cmd.Parameters.Add(
				new SqlParameter("@P_ID", lprop.Property_ID));
			cmd.Parameters.Add(
				new SqlParameter("@type", 1));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				byte[] img= new byte[0];
				img =  (byte[])rdr["photo"];
				string file = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + rdr["fileName"].ToString();

				FileStream fs = new FileStream(Server.MapPath("\\camelot_crm\\photos\\" + file), System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write, System.IO.FileShare.ReadWrite);
				fs.Write(img,0,(int)rdr["filesize"]);
				fs.Close();
				
				defUrl= "\\camelot_crm\\photos\\" + file;
			}
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			if(defUrl==null)
			{
				defUrl= "\\camelot_crm\\images\\cam_logo.gif";
			}
			this.propImg.ImageUrl = defUrl;
		}

		private void pop_details(string prop)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_insp_details";

			cmd.Parameters.Add(
				new SqlParameter("@P_ID", lprop.Property_ID));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				this.lblName.Text = rdr["object_name"].ToString();
				this.lblAddress.Text = rdr["address"].ToString();
				this.lblPost.Text = rdr["postalcode"].ToString();
				this.lblTown.Text = rdr["city"].ToString();
				this.lblOwner.Text = rdr["company"].ToString();
				this.lblCont.Text = rdr["contact"].ToString();
				this.lblKeyNo.Text = rdr["key_number"].ToString();
				this.lblPropNo.Text = rdr["property_id"].ToString();
				this.lblCalam.Text = rdr["calam_limit"].ToString();
			}

			rdr.NextResult();
			while(rdr.Read())
			{
				this.lblLast.Text = rdr.GetValue(0).ToString();
			}

			rdr.NextResult();
			while(rdr.Read())
			{
				this.lblMaxOccup.Text = rdr.GetValue(0).ToString();
			}

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		public void getMeters(int propid)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.saveUtils su = new Camelot.classes.saveUtils();
			string met_id = "";
			bool head=false;

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_insp_meters";

			cmd.Parameters.Add(
				new SqlParameter("@propid", propid));
		
			rdr = cmd.ExecuteReader();
			lcnt = 19;
			while(rdr.Read())
			{
				met_id = rdr["met"].ToString();
				string rmet = getMeterRates(met_id);
				string meter = "<table cellSpacing=2 cellPadding=0 width=96% align=center>";

				meter = meter + "<tr><td class=meter_head width=20%>" + su.ToTitle(rdr["description"].ToString()) + "</td><td class=meter_head width=15%>" + rdr["serial"].ToString()+ "</td><td class=meter_head width=65%>" + rdr["location"].ToString() + "</td></tr>";
				rocnt = rocnt + 1;
				meter = meter+rmet;
				meter=meter+"<tr><td colspan=3><br/></td></tr></table>";
				rocnt = rocnt + 1;
				if(!head)
				{
					if(lcnt > 39)
					{
					//	Response.Write("<p class=page_break></p>");
						Response.Write("<table cellSpacing=2 cellPadding=0 width=96% align=center><tr><td class=blank_insp colspan=3>Meters</td></tr><tr><td class=blank_insp colspan=3><hr></td></tr></table>");
						lcnt = 4;
					}else
					{
						Response.Write("<table cellSpacing=2 cellPadding=0 width=96% align=center><tr><td class=blank_insp colspan=3>Meters</td></tr><tr><td class=blank_insp colspan=3><hr></td></tr></table>");
					}
					head=true;
				}

				if((lcnt + rocnt) > 46)
				{
				//	Response.Write("<p class=page_break></p>");
					Response.Write("<table cellSpacing=2 cellPadding=0 width=96% align=center><tr><td class=blank_insp colspan=3>Meters</td></tr><tr><td class=blank_insp colspan=3><hr></td></tr></table>");
					Response.Write(meter);
					lcnt = rocnt;
				}
				else
				{
					Response.Write(meter);
					lcnt = lcnt + rocnt;
					rocnt = 0;
				}
			}
	
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		public string getMeterRates(string metid)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.saveUtils su = new Camelot.classes.saveUtils();
			string rmeter = "";

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_insp_meter_readings";

			cmd.Parameters.Add(
				new SqlParameter("@metid", metid));
			
			rdr = cmd.ExecuteReader();
			while(rdr.Read())
			{
				rmeter = rmeter + "<tr><td class=rate width=15%>" + su.ToTitle(rdr["rate_desc"].ToString()) + "</td><td class=rate width=25%>" + rdr["reading"].ToString()+ "</td><td class=rate width=65%>&nbsp</td></tr>";				
				rocnt = rocnt + 1;
			}

			cmd.Dispose();
			conn.Close();
			conn.Dispose();

			return rmeter;
		}

		public void getSecurity(int propid)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.saveUtils su = new Camelot.classes.saveUtils();
			bool head = false;
	
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_insp_securitIES";

			cmd.Parameters.Add(
				new SqlParameter("@propid", propid));
		
			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				if(!head)
				{
					Response.Write("<table cellSpacing=2 cellPadding=0 width=96% align=center><tr><td class=blank_insp colspan=2>Security Items</td></tr><tr><td class=blank_insp colspan=2><hr></td></tr>");
					Response.Write("<tr><td class=blank_insp width=30%>Type</td><td class=blank_insp width=70%>Location</td></tr>");
					if(lcnt > 39 )
					{
						lcnt = 4;
					}else
					{
						lcnt =lcnt + 4;
					}
					head=true;
				}

				Response.Write("<tr><td class=rate width=30%>" + su.ToTitle(rdr["type"].ToString()) + "</td><td class=rate width=70%>" + rdr["location"].ToString() + "</td></tr>");
				if((lcnt + 3) > 46)
				{
					lcnt = 4;
				}
				else
				{
					lcnt++;
				}
			}
			if(head)
			{
				Response.Write("</table>");
			}
	
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		public void getFacility(int propid)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.saveUtils su = new Camelot.classes.saveUtils();
			bool head = false;
	
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_insp_facilities";

			cmd.Parameters.Add(
				new SqlParameter("@propid", propid));
		
			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				if(!head)
				{
					Response.Write("<table cellSpacing=2 cellPadding=0 width=96% align=center><tr><td class=blank_insp colspan=3>Facilities</td></tr><tr><td class=blank_insp colspan=3><hr></td></tr>");
					Response.Write("<tr><td class=blank_insp width=20%>Type</td><td class=blank_insp width=60%>Location</td><td class=blank_insp width=20%>Serial Number</td></tr>");
					if(lcnt > 39 )
					{
						lcnt = 4;
					}
					else
					{
						lcnt =lcnt + 4;
					}
					head=true;
				}
				Response.Write("<tr><td class=rate width=20%>" + su.ToTitle(rdr["type"].ToString()) + "</td><td class=rate width=40%>" + rdr["location"].ToString()+ "</td><td class=rate width=40%>" + rdr["serial"].ToString() + "</td></tr>");
				if((lcnt + 3) > 46)
				{
					lcnt = 4;
				}
				else
				{
					lcnt++;
				}
			}
			if(head)
			{
				Response.Write("</table>");
			}
	
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}


		public void getGuardians(int prop_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.saveUtils su = new Camelot.classes.saveUtils();
			bool head = false;
			string maxocc="";
	
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_insp_guardians";

			cmd.Parameters.Add(
				new SqlParameter("@propid", prop_id));
		
			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				
			
				if(!head)
				{
					maxocc = rdr["maxocc"].ToString();
					Response.Write("<table cellSpacing=2 cellPadding=0 width=96% align=center><tr><td class=blank_insp colspan=5>Guardians</td></tr><tr><td class=blank_insp colspan=5><hr></td></tr></table>");
					Response.Write("<table cellSpacing=2 cellPadding=0 width=96% align=center><tr><td class=blank_insp width=20%>Room</td><td class=blank_insp width=40%>Maximum Occupancy " + maxocc + "</td><td class=blank_insp width=20%>Work Tel</td><td class=blank_insp width=20%>Mobile</td></tr></table>");
					if(lcnt > 39 )
					{
						lcnt = 4;
					}
					else
					{
						lcnt =lcnt + 4;
					}
					head=true;
				}
				lcnt++;
			}
	
			rdr.NextResult();
			while(rdr.Read())
			{
				Response.Write("<table cellSpacing=2 cellPadding=0 width=96% align=center><tr><td class=rate width=20%>" + rdr["Room"].ToString() + "</td><td class=rate width=40%>" + rdr["name"].ToString()+ "</td><td class=rate width=20%>" + rdr["phone"].ToString() + "</td><td class=rate width=20%>" + rdr["mobile"].ToString() + "</td></tr></table>");
				if((lcnt + 3) > 46)
				{
					lcnt = 4;
				}
				else
				{
					lcnt++;
				}
			}
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		public void getOpenIncidents(int prop_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.saveUtils su = new Camelot.classes.saveUtils();
			bool head = false;
	
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_insp_open_incidents";

			cmd.Parameters.Add(
				new SqlParameter("@propid", prop_id));
		
			rdr = cmd.ExecuteReader();
	
			while(rdr.Read())
			{
				if(!head)
				{
					Response.Write("<br/><table cellSpacing=2 cellPadding=0 width=96% align=center><tr><td class=blank_insp colspan=5>Open Incidents</td></tr><tr><td class=blank_insp colspan=5><hr></td></tr></table>");
					Response.Write("<table cellSpacing=2 cellPadding=0 width=96% align=center><tr><td class=blank_insp width=10%>Inc No.</td><td class=blank_insp width=20%>Date</td><td class=blank_insp width=55%>Description</td><td class=blank_insp width=15%>Status</td></tr></table>");
					head=true;
				}
					
				Response.Write("<table cellSpacing=2 cellPadding=0 width=96% align=center><tr><td class=rate width=10%>" + rdr["comp_id"].ToString() + "</td><td class=rate width=20%>" + rdr["c_date"].ToString() + "</td><td class=rate width=55%>" + rdr["description"].ToString()+ "</td><td class=rate width=15%>" + rdr["status"].ToString() + "</td></tr></table>");
					
			}
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		public void getInspIncidents(int prop_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.saveUtils su = new Camelot.classes.saveUtils();
			bool head = false;
	
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_insp_incidents";

			cmd.Parameters.Add(
				new SqlParameter("@propid", prop_id));
		
			rdr = cmd.ExecuteReader();
	
			while(rdr.Read())
			{
				if(!head)
				{
					Response.Write("<br/><table cellSpacing=2 cellPadding=0 width=96% align=center><tr><td class=blank_insp colspan=5>Incidents for Inspection</td></tr><tr><td class=blank_insp colspan=5><hr></td></tr></table>");
					Response.Write("<table cellSpacing=2 cellPadding=0 width=96% align=center><tr><td class=blank_insp width=10%>Inc No.</td><td class=blank_insp width=20%>Date</td><td class=blank_insp width=55%>Description</td><td class=blank_insp width=15%>Status</td></tr></table>");
					head=true;
				}
					
				Response.Write("<table cellSpacing=2 cellPadding=0 width=96% align=center><tr><td class=rate width=10%>" + rdr["comp_id"].ToString() + "</td><td class=rate width=20%>" + rdr["c_date"].ToString() + "</td><td class=rate width=55%>" + rdr["description"].ToString()+ "</td><td class=rate width=15%>" + rdr["status"].ToString() + "</td></tr></table>");
					
			}
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		public void getNotes(int prop_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.saveUtils su = new Camelot.classes.saveUtils();
	
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_insp_notes";

			cmd.Parameters.Add(
				new SqlParameter("@prop_id", prop_id));
		
			rdr = cmd.ExecuteReader();

			Response.Write("<table width=96% align=center>");
			while(rdr.Read())
			{
				Response.Write("<tr><td width=100% valign=top>" + rdr["description"].ToString() + "</td></tr>");
				lcnt = 3;				
			}
			Response.Write("</table>");
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
