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
	/// Summary description for facilitydetails.
	/// </summary>
	public class facilitydetails : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label lblfactype;
		protected System.Web.UI.WebControls.DropDownList cmbfactype;
		protected System.Web.UI.WebControls.Label lblfacdesc;
		protected System.Web.UI.WebControls.TextBox txtfacdesc;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtfacsn;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtinsdate;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtlasts;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtnexts;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.DropDownList cmbserv;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtnotes;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.DropDownList cmbguard;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Image imgMainPhoto;
		Camelot.classes.Utils Utils = new Camelot.classes.Utils();
		protected System.Web.UI.WebControls.Button btnClose;
		Camelot.classes.cFacility lfac;
		Camelot.classes.cProperty lprop;
		protected System.Web.UI.WebControls.Label lblUpBy;
		protected System.Web.UI.WebControls.Label lblUby;
		protected System.Web.UI.WebControls.Label lblUpOn;
		protected System.Web.UI.WebControls.Label lblUDate;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.CheckBox chkUse;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.TextBox txtLoc;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.TextBox txtDateRem;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.Label Label20;
		Camelot.classes.cUser pUser;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.CheckBox chkInsp;
		public string defUrl;

		private void pop_pic()
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
				new SqlParameter("@P_ID", lfac.Facility_ID));
			cmd.Parameters.Add(
				new SqlParameter("@type", 2));

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
			imgMainPhoto.ImageUrl = defUrl;
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			bool oktogo;
			Camelot.classes.Utils pUtil = new Camelot.classes.Utils();
			pUser = (Camelot.classes.cUser)Session["curUser"];
			oktogo = pUtil.valid_user(pUser);

			if (!Page.IsClientScriptBlockRegistered("Photo"))
			{		
				// use next line for direct with <base target="_self"> between <Head> and </HEAD> 
				string scrp="<script>var rc = new Array(0,0);function doPIt(){rc= window.showModalDialog('photo_frame.aspx','photo','dialogHeight:650px; dialogWidth: 900px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');"+"\n";
				scrp+="document.Form1.submit();}</script>";

				Page.RegisterStartupScript("Photo",scrp);			
				this.imgMainPhoto.Attributes.Add("onClick","doPIt();");
			}

			Session["ptype"] = "2";
			if(!oktogo)
			{
				Response.Redirect("../logon.aspx");
			}
			else
			{
				lfac=(Camelot.classes.cFacility)Session["curfac"];
				hideErr();
				string err=Request.QueryString["err"];
			
				if(lfac.Facility_ID==null || lfac.Facility_ID=="")
				{
					string fac = Request.QueryString["fac"];
					lfac.Facility_ID = fac;
					Session["curfac"] = lfac;
				}
			
				Response.Expires = 0;
				Response.Cache.SetNoStore();
				Response.AppendHeader("Pragma", "no-cache");
			
			
				bool edit = (bool)Session["fac_edit"];
				bool fnew = (bool)Session["fac_new"];
						
				//lfac = (Camelot.classes.cFacility)Session["curFac"];
			
				setenabled(edit);
			
				if(fnew)
				{
					if(!(bool)Session["fac_save"])
					{
						pop_combos();
						btnUpdate.Visible = true;
						btnCancel.Visible = true;
						btnEdit.Visible = false;
						btnClose.Visible=false;
						lfac.Facility_ID = "";
						Session["fac_save"] = true;
						chkUse.Checked=true;
						this.imgMainPhoto.Visible=false;
					}
				}
				else
				{
					if(edit)
					{
						if(!(bool)Session["fac_save"] && (lfac.Facility_ID!=null && lfac.Facility_ID!=""))
						{
							pop_fac(lfac.Facility_ID);
						}
				
						btnUpdate.Visible = true;
						btnCancel.Visible = true;
						btnEdit.Visible = false;
						btnClose.Visible=false;
					}
					else
					{
						if(!(bool)Session["fac_save"] && (lfac.Facility_ID!=null && lfac.Facility_ID!=""))
						{
							pop_fac(lfac.Facility_ID);
						}
						btnUpdate.Visible = false;
						btnCancel.Visible = false;
						if(pUser.Permission=="1")
						{
							btnEdit.Visible = true;
						}
						else
						{
							btnEdit.Visible = false;
						}
						btnClose.Visible=true;
					}
				}
			}

		}
		private void pop_fac(string fac_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			bool edit = (bool)Session["prop_edit"];
			Camelot.classes.saveUtils su = new saveUtils();
			Camelot.classes.Utils us = new Camelot.classes.Utils();
			string Factype = "";
			string facServ = "";
			string facGuard = "";

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_facility";

			cmd.Parameters.Add(
				new SqlParameter("@fac_id", fac_id));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				lblTitle.Text = rdr["description"].ToString();
				Factype = rdr["facility_type"].ToString();
				txtfacdesc.Text = rdr["description"].ToString();
				txtLoc.Text = rdr["location"].ToString();
				txtfacsn.Text = rdr["serial_number"].ToString();
				txtinsdate.Text = su.getdate(rdr["date_installed"].ToString());
				txtDateRem.Text = su.getdate(rdr["date_removed"].ToString());
				txtlasts.Text = su.getdate(rdr["date_last_check"].ToString());
				txtnexts.Text = su.getdate(rdr["date_next_check"].ToString());
				facServ = rdr["maint_id"].ToString();
				txtnotes.Text = rdr["remarks"].ToString();
				facGuard = rdr["resident_id"].ToString();
				lblUby.Text = get_employeename(Convert.ToInt32(rdr["record_manager"]));
				lblUDate.Text = rdr["Date_modified"].ToString();
				chkUse.Checked = (bool)rdr["in_use"];
				this.chkInsp.Checked = (bool)rdr["insp"];
			}
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

			pop_fac_types(Factype);
			pop_guards(facGuard);
			pop_maintainers(facServ);
			pop_pic();
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
		private void pop_maintainers(string man)
		{
			
			Camelot.classes.Maintainers main = new Maintainers();
			main = Utils.get_Maintainers(Session["con"].ToString());

			int ind =0;

			cmbserv.Items.Clear();
			cmbserv.Items.Add("");
			foreach(cMaintenance mn in main)
			{
				cmbserv.Items.Add(mn.Name);
				if(mn.ID == man)
				{
					ind = cmbserv.Items.Count-1;
				}
			}
			cmbserv.SelectedIndex = ind;
			
		}

		private void pop_fac_types(string ftid)
		{
			Facility_Types fts = (Facility_Types)Session["Ftypes"];
			int ind =0;
			cmbfactype.Items.Clear();
			cmbfactype.Items.Add("");
			foreach(cFac_type ft in fts)
			{
				cmbfactype.Items.Add(ft.Facility_Type);
				if(ft.Fac_ID == ftid)
				{
					ind = cmbfactype.Items.Count-1;
				}
			}
			cmbfactype.SelectedIndex = ind;
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
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void setenabled(bool edit)
		{
			cmbfactype.Enabled = edit;
			txtfacdesc.Enabled=edit;
			txtLoc.Enabled=edit;
			txtfacsn.Enabled=edit;
			txtinsdate.Enabled=edit;
			txtlasts.Enabled=edit;
			txtnexts.Enabled=edit;
			cmbserv.Enabled=edit;
			cmbguard.Enabled=edit;
			txtnotes.Enabled=edit;
			chkUse.Enabled=edit;
			txtDateRem.Enabled=edit;
			this.chkInsp.Enabled=edit;
		}
		
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			setenabled(true);
			btnUpdate.Visible = true;
			btnCancel.Visible = true;
			btnEdit.Visible = false;
			btnClose.Visible=false;
			Session["fac_edit"] = true;
			Session["fac_save"] = true;
			Session["fac_new"] = false;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			bool fnew = (bool)Session["fac_new"];
			Session["fac_edit"] = false;
			Session["fac_save"] = false;
			Session["fac_new"] = false;
			if(fnew)
			{
				Response.Write("<script>window.close();</script>");
			}
			else
			{
				Response.Redirect("facilitydetails.aspx");
			}
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Session["fac_edit"] = false;
			Session["fac_save"] = false;
			Session["fac_new"] = false;
			Response.Write("<script>window.close();</script>");
		}

		private void pop_guards(string gdid)
		{
			
			Camelot.classes.pGuardians gds = new pGuardians();
			Camelot.classes.cProperty lprop = (Camelot.classes.cProperty)Session["curProperty"];

			gds = Utils.get_Prop_Guardians(Session["con"].ToString(), lprop.Property_ID);

			int ind =0;

			cmbguard.Items.Clear();
			cmbguard.Items.Add("");
			foreach(cGuardian gd in gds)
			{
				cmbguard.Items.Add(gd.Guardian_Name);
				if(gd.Guardian_ID == gdid)
				{
					ind = cmbguard.Items.Count-1;
				}
			}
			cmbguard.SelectedIndex = ind;
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			savefacility();
		}

		private void savefacility()
		{
			bool oktosave = true;
			string Msg = "";
			int cnt = 0;
			Camelot.classes.saveUtils su = new saveUtils();

			if(cmbfactype.SelectedItem.Text=="")
			{
				oktosave=false;
				cnt = 1;
				Msg = "Facility Type";
				Label12.Visible=true;
			}

			if(!su.IsDate(su.setdate(txtinsdate.Text)))
			{
				oktosave=false;
				cnt++;
				if(Msg!="")
				{
					Msg = Msg + ", Install Date";
				}
				else
				{
					Msg = "Install Date";
				}
				Label13.Visible=true;
			}
			
			if(!su.IsDate(su.setdate(txtlasts.Text)))
			{
				oktosave=false;
				cnt++;
				if(Msg!="")
				{
					Msg = Msg + ", Last Serviced Date";
				}
				else
				{
					Msg = "Last Serviced Date";
				}
				Label14.Visible=true;
			}
			
			if(!su.IsDate(su.setdate(txtnexts.Text)))
			{
				oktosave=false;
				cnt++;
				if(Msg!="")
				{
					Msg = Msg + ", Next Service Date";
				}
				else
				{
					Msg = "Next Service Date";
				}
				Label15.Visible=true;
			}
			if(!chkUse.Checked)
			{
				
				if(txtDateRem.Text=="")
				{
					oktosave=false;
					if(Msg!="")
					{
						Msg = Msg + ", Removal Date";
					}
					else
					{
						Msg = "Removal Date";
					}
					Label19.Visible=true;
				}
				else
				{
					if(!su.IsDate(su.setdate(txtDateRem.Text)))
					{
						oktosave=false;
						cnt++;
						if(Msg!="")
						{
							Msg = Msg + ", Removal Date";
						}
						else
						{
							Msg = "Removal Date";
						}
						Label15.Visible=true;
					}
				}
			}
			
			if(oktosave)
			{
				lprop=(Camelot.classes.cProperty)Session["curProperty"];
				SqlConnection conn = new SqlConnection();
				SqlCommand cmd =  new SqlCommand();
				lfac= (Camelot.classes.cFacility)Session["curfac"];
				pUser = (Camelot.classes.cUser)Session["curUser"];

				conn.ConnectionString = (string)Session["Connection"];
				conn.Open();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "update_facility";

				cmd.Parameters.Add(
					new SqlParameter("@prop_id", lprop.Property_ID));
				cmd.Parameters.Add(
					new SqlParameter("@fac_id", lfac.Facility_ID));
				cmd.Parameters.Add(
					new SqlParameter("@fac_type", get_factypeid(cmbfactype.SelectedItem.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@fac_desc", txtfacdesc.Text));
				cmd.Parameters.Add(
					new SqlParameter("@fac_loc", txtLoc.Text));
				cmd.Parameters.Add(
					new SqlParameter("@fac_sn", txtfacsn.Text));
				cmd.Parameters.Add(
					new SqlParameter("@insdate", su.setdate(txtinsdate.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@remdate", su.setdate(txtDateRem.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@lastcheck", su.setdate(txtlasts.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@nextcheck", su.setdate(txtnexts.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@maint_id", get_facmaint(cmbserv.SelectedItem.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@notes", txtnotes.Text));
				cmd.Parameters.Add(
					new SqlParameter("@res_id", get_facres(cmbguard.SelectedItem.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@record_manager", pUser.ID));
				cmd.Parameters.Add(
					new SqlParameter("@inuse", chkUse.Checked));
				cmd.Parameters.Add(
					new SqlParameter("@insp", this.chkInsp.Checked));
				cmd.ExecuteNonQuery();
				
				cmd.Dispose();
				conn.Close();
				conn.Dispose();
			
				bool fnew = (bool)Session["fac_new"];
				Session["fac_edit"] = false;
				Session["fac_save"] = false;
				Session["fac_new"] = false;
				if(fnew)
				{
					Response.Write("<script>parent.location.reload(true);</script>");
					Response.Write("<script>window.close();</script>");
				}
				else
				{
					Response.Redirect("facilitydetails.aspx");
				}
			}
			else
			{
				if(cnt==1)
				{
					Msg ="The field " + Msg + " is";
				}else
				{
					Msg ="The fields " + Msg + " are";
				}
				Msg = Msg+ " incomplete or in the wrong format";
				lblMessage.Text = Msg;
				lblMessage.Visible=true;
			}
		}

		public int get_factypeid(string fac)
		{
			int id = 0;
			Facility_Types fts = (Facility_Types)Session["Ftypes"];
			
			foreach(cFac_type fc in fts)
			{
				if(fc.Facility_Type == fac)
				{
					id = Convert.ToInt32(fc.Fac_ID);
					break;
				}
			}
			return id;
		}

		public int get_facmaint(string man)
		{
			int id = 0;
			Camelot.classes.Maintainers main = new Maintainers();
			main = Utils.get_Maintainers(Session["con"].ToString());
			
			foreach(cMaintenance mc in main)
			{
				if(mc.Name == man)
				{
					id = Convert.ToInt32(mc.ID);
					break;
				}
			}
			return id;
		}

		public int get_facres(string res)
		{
			int id = 0;
			Camelot.classes.cProperty lprop = (Camelot.classes.cProperty)Session["curProperty"];
			Camelot.classes.pGuardians pgs = new pGuardians();
			pgs = Utils.get_Prop_Guardians(Session["con"].ToString(),lprop.Property_ID );
			
			foreach(cGuardian gd in pgs)
			{
				if(gd.Guardian_Name == res)
				{
					id = Convert.ToInt32(gd.Guardian_ID);
					break;
				}
			}
			return id;
		}

		private void pop_combos()
		{
			pop_fac_types("");
			pop_guards("");
			pop_maintainers("");
		}

		private void hideErr()
		{
			lblMessage.Visible = false;
			Label11.Visible=false;
			Label12.Visible=false;
			Label13.Visible=false;
			Label14.Visible=false;
			Label15.Visible=false;
			Label16.Visible=false;
			Label17.Visible=false;
			Label19.Visible=false;
		}
	}
}
