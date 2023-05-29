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
	/// Summary description for correspondence.
	/// </summary>
	public class correspondence : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList cmbTarget;
		protected System.Web.UI.WebControls.Label lblTarget;
		protected System.Web.UI.WebControls.ListBox lstOwner;
		protected System.Web.UI.WebControls.Label lblArea;
		protected System.Web.UI.WebControls.ListBox lstArea;
		protected System.Web.UI.WebControls.Label lblPost;
		protected System.Web.UI.WebControls.TextBox txtPost;
		protected System.Web.UI.WebControls.ListBox lstStatus;
		protected System.Web.UI.WebControls.Label lblTown;
		protected System.Web.UI.WebControls.TextBox txtTown;
		protected System.Web.UI.WebControls.Label lblRoute;
		protected System.Web.UI.WebControls.ListBox lstRoute;
		protected System.Web.UI.WebControls.ListBox lstComp;
		protected System.Web.UI.WebControls.Label lblStat;
		protected System.Web.UI.WebControls.Label lblPType;
		protected System.Web.UI.WebControls.ListBox lstPType;
		protected System.Web.UI.WebControls.ListBox lstProps;
		protected System.Web.UI.WebControls.ListBox lstGStat;
		protected System.Web.UI.WebControls.Label LblCtype;
		protected System.Web.UI.WebControls.Label lblprop;
		protected System.Web.UI.WebControls.Label lblGstat;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.DataGrid dgRecipients;
		protected System.Web.UI.WebControls.Label lblCount;
		protected System.Web.UI.WebControls.Button btnCheck;
		protected System.Web.UI.WebControls.Button btnUncheck;
		protected System.Web.UI.WebControls.ListBox lstConts;
		protected System.Web.UI.WebControls.DataGrid dgGuardians;
		protected System.Web.UI.WebControls.Label lblList;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList cmbCtype;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList cmbDoc;
		protected System.Web.UI.WebControls.Button btnAddDoc;
		protected System.Web.UI.WebControls.Button btnGen;
		protected System.Web.UI.WebControls.ListBox lstGuard;
		private Camelot.classes.cUser pUser = new Camelot.classes.cUser();
	
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
				if(!Page.IsPostBack)
				{
					show_lists();
					pop_lists();
				}
			}
		}

		private void show_lists()
		{
			switch(this.cmbTarget.SelectedValue)
			{
				case "0":
					this.lblList.Visible=true;
					this.lstGuard.Visible=false;
					this.lstOwner.Visible=true;
					this.lstConts.Visible=false;
					this.btnSearch.Visible=true;
					break;
				case "1":
					this.lblList.Visible=true;
					this.lstGuard.Visible=true;
					this.lstOwner.Visible=false;
					this.lstConts.Visible=false;
					this.btnSearch.Visible=true;
					break;
				case "2":
					this.lblList.Visible=false;
					this.lstGuard.Visible=false;
					this.lstOwner.Visible=false;
					this.lstConts.Visible=false;
					this.btnSearch.Visible=false;
					break;
				case "3":
					this.lblList.Visible=true;
					this.lstGuard.Visible=false;
					this.lstOwner.Visible=false;
					this.lstConts.Visible=true;
					this.btnSearch.Visible=true;
					break;
			}
			
			this.txtPost.Visible=false;
			this.txtTown.Visible=false;
			this.lstArea.Visible=false;
			this.lstComp.Visible=false;
			this.lstGStat.Visible=false;
			this.lstProps.Visible=false;
			this.lstPType.Visible=false;
			this.lstRoute.Visible=false;
			this.lstStatus.Visible=false;
			this.lblArea.Visible=false;
			this.LblCtype.Visible=false;
			this.lblPost.Visible=false;
			this.lblprop.Visible=false;
			this.lblPType.Visible=false;
			this.lblStat.Visible=false;
			this.lblTown.Visible=false;
			this.lblGstat.Visible=false;
			this.lblRoute.Visible=false;
			this.dgRecipients.Visible=false;
			this.dgGuardians.Visible=false;
			this.lblCount.Visible=false;
			this.btnCheck.Visible=false;
			this.btnUncheck.Visible=false;
			this.btnGen.Visible = false;
			this.cmbDoc.Visible=false;
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
			this.cmbTarget.SelectedIndexChanged += new System.EventHandler(this.cmbTarget_SelectedIndexChanged);
			this.lstOwner.SelectedIndexChanged += new System.EventHandler(this.lstOwner_SelectedIndexChanged);
			this.lstGuard.SelectedIndexChanged += new System.EventHandler(this.lstGuard_SelectedIndexChanged);
			this.lstConts.SelectedIndexChanged += new System.EventHandler(this.lstConts_SelectedIndexChanged);
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.cmbCtype.SelectedIndexChanged += new System.EventHandler(this.cmbCtype_SelectedIndexChanged);
			this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
			this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
			this.btnUncheck.Click += new System.EventHandler(this.btnUncheck_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmbTarget_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(Page.IsPostBack)
			{
				show_lists();
			}
		}

		private void pop_lists()
		{
			CC.Areas ars = (CC.Areas)Session["Areas"];
			this.lstArea.DataSource = ars;
			this.lstArea.DataValueField = "Area_id";
			this.lstArea.DataTextField = "Description";
			this.DataBind();

			CC.Object_stats obs = (CC.Object_stats)Session["stats"];
			this.lstStatus.DataSource = obs;
			this.lstStatus.DataValueField = "Status_ID";
			this.lstStatus.DataTextField = "Description";
			this.lstStatus.DataBind();

			CC.O_Types types = (CC.O_Types)Session["otypes"];
			this.lstPType.DataSource = types;
			this.lstPType.DataValueField = "O_TypeID";
			this.lstPType.DataTextField = "Description";
			this.lstPType.DataBind();

			CC.C_Types ctypes = (CC.C_Types)Session["ctypes"];
			this.lstComp.DataSource = ctypes;
			this.lstComp.DataValueField = "C_TypeID";
			this.lstComp.DataTextField = "Description";
			this.lstComp.DataBind();

			CC.Guard_stats gstats = new Camelot.classes.Guard_stats();
			CC.Guard_stat estat = new Camelot.classes.Guard_stat();
			estat.Status_ID = "0";
			estat.Description = "Existing Guardian";
			gstats.Add(estat);
			
			CC.Guard_stat tstat = new Camelot.classes.Guard_stat();
			tstat.Status_ID = "1";
			tstat.Description = "Terminated Guardian";
			gstats.Add(tstat);

			this.lstGStat.DataSource = gstats;
			this.lstGStat.DataValueField = "Status_ID";
			this.lstGStat.DataTextField = "Description";
			this.lstGStat.DataBind();

			pop_props();
			pop_routes();
			popdocs();
		}

		private void pop_props()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			Camelot.classes.Utils us = new Camelot.classes.Utils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_placement_props";

			this.lstProps.DataSource = cmd.ExecuteReader();
			lstProps.DataTextField = "OBJECT_NAME";
			lstProps.DataValueField = "OBJECT_ID";
			this.lstProps.DataBind();
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

		}

		private void pop_routes()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			Camelot.classes.Utils us = new Camelot.classes.Utils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_active_routes";

			this.lstRoute.DataSource = cmd.ExecuteReader();
			lstRoute.DataTextField = "NAME";
			lstRoute.DataValueField = "ROUTEID";
			this.lstRoute.DataBind();
			
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

		}

		private void lstOwner_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			show_lists();
			foreach(ListItem li in this.lstOwner.Items)
			{
				if(li.Selected)
				{
					switch(li.Value)
					{
						case "1":
							this.lblArea.Visible=true;
							this.lstArea.Visible=true;
							break;
						case "2":
							this.lblPost.Visible=true;
							this.txtPost.Visible=true;
							break;
						case "3":
							this.lblStat.Visible=true;
							this.lstStatus.Visible=true;
							break;
						case "4":
							this.lblPType.Visible=true;
							this.lstPType.Visible=true;
							break;
						case "5":
							this.lblTown.Visible=true;
							this.txtTown.Visible=true;
							break;
						case "6":
							this.LblCtype.Visible=true;
							this.lstComp.Visible=true;
							break; 
					}
				}
			}
			clear_lists();
		}

		private void lstGuard_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			show_lists();
			foreach(ListItem li in this.lstGuard.Items)
			{
				if(li.Selected)
				{
					switch(li.Value)
					{
						case "1":
							this.lblArea.Visible=true;
							this.lstArea.Visible=true;
							break;
						case "2":
							this.lblGstat.Visible=true;
							this.lstGStat.Visible=true;
							break;
						case "3":
							this.lblPost.Visible=true;
							this.txtPost.Visible=true;
							break;
						case "4":
							this.lblprop.Visible=true;
							this.lstProps.Visible=true;
							break;
						case "5":
							this.lblRoute.Visible=true;
							this.lstRoute.Visible=true;
							break;
						case "6":
							this.lblTown.Visible=true;
							this.txtTown.Visible=true;
							break;
					}
				}
			}
			clear_lists();
		}

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			search();
		}

		private void search()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			string area = "0";
			string pstatus = "0";
			string ptype = "0";
			string ctype = "0";
			string gstat = "3";
			string prop = "0";
			string route = "0";
			string post = "";
			string ppost = "";
			string town = "";
			string ptown = "";
			string corr = "";
			int cnt = 0;

			corr = this.cmbCtype.SelectedValue;

			foreach(ListItem li in this.lstArea.Items)
			{
				if(li.Selected)
				{
					if(cnt == 0)
					{
						switch(this.cmbTarget.SelectedValue)
						{
							case "0" :
								area= "AND A.AREA_ID IN (" + li.Value;
								break;
							case "1" :
								area= "AND O.AREA_ID IN (" + li.Value;
								break;
							case "3" :
								area= "AND A.AREA_ID IN (" + li.Value;
								break;
						}
						cnt++;
					}
					else
					{
						area=area + ',' + li.Value;
					}
				}
			}
			if(cnt > 0)
			{
				area = area + ")";
			}

			cnt = 0;
			foreach(ListItem li in this.lstStatus.Items)
			{
				if(li.Selected)
				{
					if(cnt == 0)
					{
						pstatus= "AND O.STATUS_ID IN (" + li.Value;
						cnt++;
					}
					else
					{
						pstatus=pstatus + ',' + li.Value;
					}
				}
			}
			if(cnt > 0)
			{
				pstatus = pstatus + ")";
			}

			cnt = 0;
			foreach(ListItem li in this.lstPType.Items)
			{
				if(li.Selected)
				{
					if(cnt == 0)
					{
						ptype= "AND O.OBJECT_TYPE IN (" + li.Value;
						cnt++;
					}
					else
					{
						ptype=ptype + ',' + li.Value;
					}
				}
			}
			if(cnt > 0)
			{
				ptype = ptype + ")";
			}
			
			cnt = 0;
			foreach(ListItem li in this.lstComp.Items)
			{
				if(li.Selected)
				{
					if(cnt == 0)
					{
						ctype= "AND C.COMPANY_TYPE IN (" + li.Value;
						cnt++;
					}
					else
					{
						ctype=ctype + ',' + li.Value;
					}
				}
			}
			if(cnt > 0)
			{
				ctype = ctype + ")";
			}

			cnt = 0;
			foreach(ListItem li in this.lstGStat.Items)
			{
				if(li.Selected)
				{
					if(cnt == 0)
					{
						gstat= li.Value;
						cnt++;
					}
					else
					{
						gstat = "3";
					}
				}
			}

			cnt = 0;
			foreach(ListItem li in this.lstProps.Items)
			{
				if(li.Selected)
				{
					if(cnt == 0)
					{
						prop= "AND O.OBJECT_ID IN (" + li.Value;
						cnt++;
					}
					else
					{
						prop=prop + ',' + li.Value;
					}
				}
			}
			if(cnt > 0)
			{
				prop = prop + ")";
			}

			cnt = 0;
			foreach(ListItem li in this.lstRoute.Items)
			{
				if(li.Selected)
				{
					if(cnt == 0)
					{
						route= "AND RT.ROUTE_ID IN (" + li.Value;
						cnt++;
					}
					else
					{
						route=route + ',' + li.Value;
					}
				}
			}
			if(cnt > 0)
			{
				route = route + ")";
			}

			cnt = 0;
			ppost = this.txtPost.Text;
			if(ppost.Length > 0)
			{
				string table = "";
				switch(this.cmbTarget.SelectedValue)
				{
					case "0" :
						table = "A";
						break;
					case "1" :
						table = "O";
						break;
					case "3":
						table = "A";
						break;
				}

				post = "AND (" + table + ".POSTALCODE LIKE '";
				
				while(ppost.Length > 0)
				{
					if(cnt==0)
					{
						if(ppost.IndexOf(",",0)>0)
						{
							post = post + ppost.Substring(0, ppost.IndexOf(",",0)) + "%'";
							ppost = ppost.Substring(ppost.IndexOf(",",0)+1);
						}
						else
						{
							post = post + ppost + "%'";
							ppost = "";
						}
						cnt++;
					}
					else
					{
						post = post + " OR " + table + ".POSTALCODE LIKE '";
						if(ppost.IndexOf(",",0)>0)
						{
							post = post + ppost.Substring(0, ppost.IndexOf(",",0)) + "%'";
							ppost = ppost.Substring(ppost.IndexOf(",",0)+1);
						}
						else
						{
							post = post + ppost + "%'";
							ppost = "";
						}
					}
				}
			}
			if(cnt>0)
			{
				post = post + ")";
			}

			cnt = 0;
			ptown = this.txtTown.Text;
			if(ptown.Length > 0)
			{
				string table = "";
				switch(this.cmbTarget.SelectedValue)
				{
					case "0" :
						table = "A";
						break;
					case "1" :
						table = "O";
						break;
					case "3":
						table = "A";
						break;
				}

				town = "AND (" + table + ".CITY LIKE '%";
				cnt = 0;
				while(ptown.Length > 0)
				{
					if(cnt==0)
					{
						if(ptown.IndexOf(",",0)>0)
						{
							town = town + ptown.Substring(0, ptown.IndexOf(",",0)).Trim() + "%'";
							ptown = ptown.Substring(ppost.IndexOf(",",0)+1);
						}
						else
						{
							town = town + ptown.Trim() + "%'";
							ptown = "";
						}
						cnt++;
					}
					else
					{
						town = town + " OR " + table + ".CITY LIKE '%";
						if(ptown.IndexOf(",",0)>0)
						{
							town = town + ptown.Substring(0, ptown.IndexOf(",",0)).Trim() + "%'";
							ptown = ptown.Substring(ptown.IndexOf(",",0)+1);
						}
						else
						{
							town = town + ptown.Trim() + "%'";
							ptown = "";
						}
					}
				}
			}
			if(cnt>0)
			{
				town = town + ")";
			}

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_corr_recipients";

			cmd.Parameters.Add(
				new SqlParameter("@target", this.cmbTarget.SelectedValue));
			cmd.Parameters.Add(
				new SqlParameter("@AREA", area));
			cmd.Parameters.Add(
				new SqlParameter("@PSTATUS", pstatus));
			cmd.Parameters.Add(
				new SqlParameter("@PTYPE", ptype));
			cmd.Parameters.Add(
				new SqlParameter("@cTYPE", ctype));
			cmd.Parameters.Add(
				new SqlParameter("@GSTAT", gstat));
			cmd.Parameters.Add(
				new SqlParameter("@PROP", prop));
			cmd.Parameters.Add(
				new SqlParameter("@ROUTE", route));
			cmd.Parameters.Add(
				new SqlParameter("@POST", post));
			cmd.Parameters.Add(
				new SqlParameter("@TOWN", town));
			cmd.Parameters.Add(
				new SqlParameter("@CORR", corr));
			
			switch(this.cmbTarget.SelectedValue)
			{
				case "0":
					this.dgRecipients.DataSource = null;
					this.dgRecipients.DataSource = cmd.ExecuteReader();
					this.dgRecipients.DataBind();
					this.dgRecipients.Visible = true;
					this.lblCount.Text = "Number of Recipients found : " + this.dgRecipients.Items.Count;
					if(this.dgRecipients.Items.Count > 0)
					{
						this.btnGen.Visible = true;
					}
					else
					{
						this.btnGen.Visible=false;
					} 
					break;
				case "1":
					this.dgGuardians.DataSource = null;
					this.dgGuardians.DataSource = cmd.ExecuteReader();
					this.dgGuardians.DataBind();
					this.dgGuardians.Visible = true;
					this.lblCount.Text = "Number of Recipients found : " + this.dgGuardians.Items.Count;
					if(this.dgGuardians.Items.Count > 0)
					{
						this.btnGen.Visible = true;
					}
					else
					{
						this.btnGen.Visible=false;
					}
					break;
				case "3":
					this.dgRecipients.DataSource = null;
					this.dgRecipients.DataSource = cmd.ExecuteReader();
					this.dgRecipients.DataBind();
					this.dgRecipients.Visible = true;
					this.lblCount.Text = "Number of Recipients found : " + this.dgRecipients.Items.Count;
					if(this.dgRecipients.Items.Count > 0)
					{
						this.btnGen.Visible = true;
					}
					else
					{
						this.btnGen.Visible=false;
					}
					break;
			}
			this.lblCount.Visible=true;
			this.btnCheck.Visible=true;
			this.btnUncheck.Visible=true;

			setchecks(true);
		}

		private void setchecks(bool check)
		{
			switch(this.cmbTarget.SelectedValue)
			{
				case "0" :
					foreach(DataGridItem dgi in this.dgRecipients.Items)
					{
						CheckBox chkBox = (CheckBox)dgi.FindControl("chk");
						chkBox.Checked = check;
					}
					break;
				case "1" :
					foreach(DataGridItem dgi in this.dgGuardians.Items)
					{
						CheckBox chkBox = (CheckBox)dgi.FindControl("gchk");
						chkBox.Checked = check;
					}
					break;
				case "3" :
					foreach(DataGridItem dgi in this.dgRecipients.Items)
					{
						CheckBox chkBox = (CheckBox)dgi.FindControl("chk");
						chkBox.Checked = check;
					}
					break;
			}

		}

		private void btnCheck_Click(object sender, System.EventArgs e)
		{
			setchecks(false);
		}

		private void btnUncheck_Click(object sender, System.EventArgs e)
		{
			setchecks(true);
		}

		private void clear_lists()
		{
			if(!this.lstArea.Visible)
			{
				foreach(ListItem li in this.lstArea.Items)
				{
					li.Selected=false;
				}
			}
			if(!this.lstStatus.Visible)
			{
				foreach(ListItem li in this.lstStatus.Items)
				{
					li.Selected=false;
				}
			}
			if(!this.lstProps.Visible)
			{
				foreach(ListItem li in this.lstProps.Items)
				{
					li.Selected=false;
				}
			}
			if(!this.lstComp.Visible)
			{
				foreach(ListItem li in this.lstComp.Items)
				{
					li.Selected=false;
				}
			}
			if(!this.lstGStat.Visible)
			{
				foreach(ListItem li in this.lstGStat.Items)
				{
					li.Selected=false;
				}
			}
			if(!this.lstPType.Visible)
			{
				foreach(ListItem li in this.lstPType.Items)
				{
					li.Selected=false;
				}
			}
			if(!this.lstRoute.Visible)
			{
				foreach(ListItem li in this.lstRoute.Items)
				{
					li.Selected=false;
				}
			}

			this.txtPost.Text = "";
			this.txtTown.Text = "";
		}

		private void lstConts_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			show_lists();
			foreach(ListItem li in this.lstConts.Items)
			{
				if(li.Selected)
				{
					switch(li.Value)
					{
						case "1":
							this.lblArea.Visible=true;
							this.lstArea.Visible=true;
							break;
						case "2":
							this.lblPost.Visible=true;
							this.txtPost.Visible=true;
							break;
						case "3":
							this.lblTown.Visible=true;
							this.txtTown.Visible=true;
							break;
						case "4":
							this.LblCtype.Visible=true;
							this.lstComp.Visible=true;
							break; 
					}
				}
			}
			clear_lists();
		}

		private void btnGen_Click(object sender, System.EventArgs e)
		{
			string recip_type = "";
			string corr_type = "";
			string doc_id = "";

			ArrayList recip_email = new ArrayList();
			ArrayList recip = new ArrayList();

			recip_type = this.cmbTarget.SelectedValue;
			corr_type = this.cmbCtype.SelectedValue;
			doc_id = this.cmbDoc.SelectedValue;

			if(recip_type=="1")
			{
				foreach(DataGridItem dgi in this.dgGuardians.Items)
				{
					CheckBox chkBox = (CheckBox)dgi.FindControl("gchk");
					if(chkBox.Checked)
					{
						recip.Add(dgi.Cells[0].Text);
						recip_email.Add(dgi.Cells[1].Text);
						Session["cRecip"] = recip;
						Session["cEmail"] = recip_email;
					}
				}

				if(this.cmbCtype.SelectedValue == "0")
				{
					Response.Write("<script>window.showModalDialog('emailInd.aspx?corr_type=" + corr_type + "&doc_id=" + doc_id + "&recip_type=" + recip_type + "&prop=0','corresp','dialogHeight: 700px; dialogWidth: 900px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
				}
				else if(this.cmbCtype.SelectedValue == "1")
				{
					Response.Write("<script>window.showModalDialog('emailmerge.aspx?doc_id=" + doc_id + "&recip_type=" + recip_type + "&prop=0','emailmerge','dialogHeight: 850px; dialogWidth: 800px; dialogTop: 0px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
				}
				else if(this.cmbCtype.SelectedValue == "2")
				{
					Response.Write("<script>window.showModalDialog('mailmerge.aspx?doc_id=" + doc_id + "&recip_type=" + recip_type + "&prop=0','mailmerge','dialogHeight: 400px; dialogWidth: 700px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
				}
			}
			else
			{
				foreach(DataGridItem dgi in this.dgRecipients.Items)
				{
					CheckBox chkBox = (CheckBox)dgi.FindControl("chk");
					if(chkBox.Checked)
					{
						recip.Add(dgi.Cells[0].Text);
						recip_email.Add(dgi.Cells[1].Text);
						Session["cRecip"] = recip;
						Session["cEmail"] = recip_email;
					}
				}

				if(this.cmbCtype.SelectedValue == "0" || this.cmbCtype.SelectedValue == "1")
				{
					Response.Write("<script>window.showModalDialog('emailInd.aspx?corr_type=" + corr_type + "&doc_id=" + doc_id + "&recip_type=" + recip_type + "&prop=0','corresp','dialogHeight: 700px; dialogWidth: 900px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
				}
				else if(this.cmbCtype.SelectedValue == "2")
				{
					Response.Write("<script>window.showModalDialog('mailmerge.aspx?doc_id=" + doc_id + "&recip_type=" + recip_type + "&prop=0','mailmerge','dialogHeight: 400px; dialogWidth: 700px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
				}
			}
		}

		
		private void popdocs()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.Utils us = new Camelot.classes.Utils();

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_documents";

			rdr = cmd.ExecuteReader();
			
		
			this.cmbDoc.Items.Clear();
			this.cmbDoc.DataSource = rdr;
			this.cmbDoc.DataTextField = "doc_list_name";
			this.cmbDoc.DataValueField = "doc_id";
			this.cmbDoc.DataBind();

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		private void cmbCtype_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			search();
			if(this.cmbCtype.SelectedValue=="1" || this.cmbCtype.SelectedValue=="2")
			{
				this.cmbDoc.Visible=true;
			}
			else
			{
				this.cmbDoc.Visible=false;
			}
		}
	}
}
