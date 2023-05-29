using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using cc = Camelot.classes;
using System.Data.SqlClient;

namespace Camelot.forms
{
	/// <summary>
	/// Summary description for blankroute.
	/// </summary>
	/// 

	 
	public class blankroute : System.Web.UI.Page
	{
		private ArrayList props = new ArrayList();
		private cc.cRoute lroute = new Camelot.classes.cRoute();
		private void Page_Load(object sender, System.EventArgs e)
		{
			string route = Request.QueryString["route_id"];
			lroute.Route_ID = route;
			get_props();

			if(props.Count>0)
			{
				Response.Write("<html>");
				Response.Write("<HEAD>");
				Response.Write("<title>Route</title>");
				Response.Write("<LINK href=../stylesheets/inspection.css type=text/css rel=stylesheet>");
				Response.Write("</HEAD>");

				Response.Write("<body><form>");
				for(int i=0; i < props.Count; i++)
				{
					get_details(props[i].ToString());
					getNotes(Convert.ToInt32(props[i].ToString()));
					Response.Write("<hr align=center width=96%>");
					getMeters(Convert.ToInt32(props[i].ToString()));
					Response.Write("<BR>");
					getSecurity(Convert.ToInt32(props[i].ToString()));
					Response.Write("<BR>");
					getFacility(Convert.ToInt32(props[i].ToString()));
					Response.Write("<BR>");
					getOpenIncidents(Convert.ToInt32(props[i].ToString()));
					Response.Write("<BR>");
					getInspIncidents(Convert.ToInt32(props[i].ToString()));
					Response.Write("<BR>");
					getGuardians(Convert.ToInt32(props[i].ToString()));
					if(i!= props.Count -1)
					{
						Response.Write("<p class=page_break></p>");
					}
				}

				Response.Write("<script language=javascript>");
				Response.Write("window.print();");
				Response.Write("</script>");

				Response.Write("</form></body></html>");
			}
		}


		private void get_details(string prop)
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
				new SqlParameter("@P_ID", prop));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				
				Response.Write("<table class=add_table width=96% align=center>");
				Response.Write("<tr>");
				Response.Write("<td vAlign=top width=30%><img id=\"propImg\" src=\"" + pop_pic(prop) + "\" alt=\"\" border=\"0\" style=\"height:160px;width:240px;\" /></td>");
				Response.Write("<td vAlign=top align=right width=70%>");
				Response.Write("<table width=100%>");
				Response.Write("<tr>");
				Response.Write("<td class=blank_insp align=left width=30%>Property No. :</td>");
				Response.Write("<td class=blank_insp width=70%><asp:label id=lblPropNo Runat=server>" + rdr["property_id"].ToString() + "</asp:label></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td class=blank_insp align=left width=30%>Address :</td>");
				Response.Write("<td class=blank_insp width=70%><asp:label id=lblName Runat=server>" + rdr["object_name"].ToString() + "</asp:label></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td class=blank_insp width=30%></td>");
				Response.Write("<td class=blank_insp width=70%><asp:label id=lblAddress Runat=server>" + rdr["address"].ToString() + "</asp:label></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td class=blank_insp align=left width=30%>Town :</td>");
				Response.Write("<td class=blank_insp width=70%><asp:label id=lblTown Runat=server>" + rdr["city"].ToString() + "</asp:label></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td class=blank_insp align=left width=30%>Post Code :</td>");
				Response.Write("<td class=blank_insp width=70%><asp:label id=lblPost Runat=server>" + rdr["postalcode"].ToString() + "</asp:label></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td class=blank_insp align=left width=30%>Owner :</td>");
				Response.Write("<td class=blank_insp width=70%><asp:label id=lblOwner Runat=server>" + rdr["company"].ToString() + "</asp:label></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td class=blank_insp align=left width=30%>Owner Contact :</td>");
				Response.Write("<td class=blank_insp width=70%><asp:label id=lblCont Runat=server>" + rdr["contact"].ToString() + "</asp:label></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td class=blank_insp align=left width=30%>Key No. :</td>");
				Response.Write("<td class=blank_insp width=70%><asp:label id=lblKeyNo Runat=server>" + rdr["key_number"].ToString() + "</asp:label></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td class=blank_insp align=left width=30%>Calamity Limit :</td>");
				Response.Write("<td class=blank_insp width=70%><asp:label id=lblCalam Runat=server>" + rdr["calam_limit"].ToString() + "</asp:label></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
			}

			rdr.NextResult();
			while(rdr.Read())
			{
				Response.Write("<td class=blank_insp vAlign=bottom align=left width=30%>Last Inspection :</td>");
				Response.Write("<td class=blank_insp width=70%><asp:label id=lblLast Runat=server>" + rdr.GetValue(0).ToString() + "</asp:label></td>");
				Response.Write("</tr>");				
			}

			rdr.NextResult();
			while(rdr.Read())
			{
				Response.Write("<tr>");
				Response.Write("<td class=blank_insp vAlign=bottom align=left width=30%>Max Occupancy :</td>");
				Response.Write("<td class=blank_insp width=70%><asp:label id=lblMaxOccup Runat=server>" + rdr.GetValue(0).ToString() + "</asp:label></td>");
				Response.Write("</tr>");
			}

			
			Response.Write("</table>");
			Response.Write("</td>");
			Response.Write("</tr>");
			Response.Write("</table>");
			Response.Write("<table class=addr_table height=40% width=96% align=center>");
			Response.Write("<tr>");
			Response.Write("<td vAlign=top align=left width=100% height=100%>Overall Impression of the property, its rooms and grounds.</td>");
			Response.Write("</tr>");
			Response.Write("</table>");
			Response.Write("<hr align=center width=96%>");
			Response.Write("<table width=96% align=center>");
			Response.Write("<tr>");
			Response.Write("<td vAlign=top align=left width=100% height=100%><strong>Internal Remarks</strong></td>");
			Response.Write("</tr>");
			Response.Write("</table>");


			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}


		private void get_props()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_route_properties";

			cmd.Parameters.Add(
				new SqlParameter("@route_id", lroute.Route_ID));
			
			rdr = cmd.ExecuteReader();
			while(rdr.Read())
			{
				props.Add(rdr["prop_id"].ToString());
			}

			cmd.Dispose();
			conn.Close();
			conn.Dispose();


		}

		private string pop_pic(string prop)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			string defUrl = "";

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_def_photos";

			cmd.Parameters.Add(
				new SqlParameter("@P_ID", prop));
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
			if(defUrl=="")
			{
				defUrl= "\\camelot_crm\\images\\cam_logo.gif";
			}
			return defUrl;
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
			
			while(rdr.Read())
			{
				met_id = rdr["met"].ToString();
				string rmet = getMeterRates(met_id);
				string meter = "<table cellSpacing=2 cellPadding=0 width=96% align=center>";

				meter = meter + "<tr><td class=meter_head width=20%>" + su.ToTitle(rdr["description"].ToString()) + "</td><td class=meter_head width=15%>" + rdr["serial"].ToString()+ "</td><td class=meter_head width=65%>" + rdr["location"].ToString() + "</td></tr>";
				
				meter = meter+rmet;
				meter=meter+"<tr><td colspan=3><br/></td></tr></table>";
				
				if(!head)
				{
					
					//	Response.Write("<p class=page_break></p>");
					Response.Write("<table cellSpacing=2 cellPadding=0 width=96% align=center><tr><td class=blank_insp colspan=3>Meters</td></tr><tr><td class=blank_insp colspan=3><hr></td></tr></table>");	
					head=true;
				}
				Response.Write(meter);
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
					head=true;
				}

				Response.Write("<tr><td class=rate width=30%>" + su.ToTitle(rdr["type"].ToString()) + "</td><td class=rate width=70%>" + rdr["location"].ToString() + "</td></tr>");
				
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
					
					head=true;
				}
				Response.Write("<tr><td class=rate width=20%>" + su.ToTitle(rdr["type"].ToString()) + "</td><td class=rate width=40%>" + rdr["location"].ToString()+ "</td><td class=rate width=40%>" + rdr["serial"].ToString() + "</td></tr>");
				
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
					
					head=true;
				}
				
			}
	
			rdr.NextResult();
			while(rdr.Read())
			{
				Response.Write("<table cellSpacing=2 cellPadding=0 width=96% align=center><tr><td class=rate width=20%>" + rdr["Room"].ToString() + "</td><td class=rate width=40%>" + rdr["name"].ToString()+ "</td><td class=rate width=20%>" + rdr["phone"].ToString() + "</td><td class=rate width=20%>" + rdr["phone"].ToString() + "</td></tr></table>");
				
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
