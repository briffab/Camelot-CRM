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
	/// Summary description for secilitydetails.
	/// </summary>
	public class securitydetails : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label Label1;
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
		Camelot.classes.cSecurity lsec;
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
		protected System.Web.UI.WebControls.Label lblsectype;
		protected System.Web.UI.WebControls.DropDownList cmbsectype;
		protected System.Web.UI.WebControls.Label lblsecdesc;
		protected System.Web.UI.WebControls.TextBox txtsecdesc;
		protected System.Web.UI.WebControls.TextBox txtsecsn;
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.TextBox txtCode;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.TextBox txtEmCont;
		protected System.Web.UI.WebControls.Label Label22;
		protected System.Web.UI.WebControls.TextBox txtContNo;
		protected System.Web.UI.WebControls.Label Label23;
		Camelot.classes.cUser pUser;
		string defUrl;

		private void pop_pic()
		{

			if (!Page.IsClientScriptBlockRegistered("Photo"))
			{		
				// use next line for direct with <base target="_self"> between <Head> and </HEAD> 
				string scrp="<script>var rc = new Array(0,0);function doPIt(){rc= window.showModalDialog('photo_frame.aspx','photo','dialogHeight:650px; dialogWidth: 900px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');"+"\n";
				scrp+="document.Form1.submit();}</script>";

				Page.RegisterStartupScript("Photo",scrp);			
				this.imgMainPhoto.Attributes.Add("onClick","doPIt();");
			}

			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_def_photos";

			cmd.Parameters.Add(
				new SqlParameter("@P_ID", lsec.Security_ID));
			cmd.Parameters.Add(
				new SqlParameter("@type", 6));

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

			Session["ptype"] = "6";

			if(!oktogo)
			{
				Response.Redirect("../logon.aspx");
			}
			else
			{
				lsec=(Camelot.classes.cSecurity)Session["cursec"];
				hideErr();
				string err=Request.QueryString["err"];
			
				if(lsec.Security_ID==null || lsec.Security_ID=="")
				{
					string sec = Request.QueryString["sec"];
					lsec.Security_ID = sec;
					Session["cursec"] = lsec;
				}
			
				Response.Expires = 0;
				Response.Cache.SetNoStore();
				Response.AppendHeader("Pragma", "no-cache");
			
			
				bool edit = (bool)Session["sec_edit"];
				bool fnew = (bool)Session["sec_new"];
						
				//lsec = (Camelot.classes.cSecurity)Session["cursec"];
			
				setenabled(edit);
			
				if(fnew)
				{
					if(!(bool)Session["sec_save"])
					{
						pop_combos();
						btnUpdate.Visible = true;
						btnCancel.Visible = true;
						btnEdit.Visible = false;
						btnClose.Visible=false;
						lsec.Security_ID = "";
						Session["sec_save"] = true;
						chkUse.Checked=true;
						this.imgMainPhoto.Visible=false;
					}
				}
				else
				{
					if(edit)
					{
						if(!(bool)Session["sec_save"] && (lsec.Security_ID!=null && lsec.Security_ID!=""))
						{
							pop_sec(lsec.Security_ID);
						}
				
						btnUpdate.Visible = true;
						btnCancel.Visible = true;
						btnEdit.Visible = false;
						btnClose.Visible=false;
					}
					else
					{
						if(!(bool)Session["sec_save"] && (lsec.Security_ID!=null && lsec.Security_ID!=""))
						{
							pop_sec(lsec.Security_ID);
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
		private void pop_sec(string Sec_ID)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			bool edit = (bool)Session["prop_edit"];
			Camelot.classes.saveUtils su = new saveUtils();
			Camelot.classes.Utils us = new Camelot.classes.Utils();
			string sectype = "";
			string secServ = "";
			string secGuard = "";

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_security";

			cmd.Parameters.Add(
				new SqlParameter("@Sec_ID", Sec_ID));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				lblTitle.Text = rdr["description"].ToString();
				sectype = rdr["Security_Type"].ToString();
				txtsecdesc.Text = rdr["description"].ToString();
				txtLoc.Text = rdr["location"].ToString();
				txtsecsn.Text = rdr["serial_number"].ToString();
				txtinsdate.Text = su.getdate(rdr["date_installed"].ToString());
				txtDateRem.Text = su.getdate(rdr["date_removed"].ToString());
				txtlasts.Text = su.getdate(rdr["date_last_check"].ToString());
				txtnexts.Text = su.getdate(rdr["date_next_check"].ToString());
				secServ = rdr["maint_id"].ToString();
				txtnotes.Text = rdr["remarks"].ToString();
				secGuard = rdr["resident_id"].ToString();
				lblUby.Text = get_employeename(Convert.ToInt32(rdr["record_manager"]));
				lblUDate.Text = rdr["Date_modified"].ToString();
				chkUse.Checked = (bool)rdr["in_use"];
				this.txtCode.Text = rdr["code"].ToString();
				this.txtEmCont.Text = rdr["em_cont"].ToString();
				this.txtContNo.Text = rdr["cont_no"].ToString();
			}
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

			pop_sec_types(sectype);
			pop_guards(secGuard);
			pop_maintainers(secServ);
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

		private void pop_sec_types(string ftid)
		{
			Security_Types fts = (Security_Types)Session["Stypes"];
			int ind =0;
			cmbsectype.Items.Clear();
			cmbsectype.Items.Add("");
			foreach(cSec_type ft in fts)
			{
				cmbsectype.Items.Add(ft.Security_Type);
				if(ft.Sec_ID == ftid)
				{
					ind = cmbsectype.Items.Count-1;
				}
			}
			cmbsectype.SelectedIndex = ind;
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
			cmbsectype.Enabled = edit;
			txtsecdesc.Enabled=edit;
			txtLoc.Enabled=edit;
			txtsecsn.Enabled=edit;
			txtinsdate.Enabled=edit;
			txtlasts.Enabled=edit;
			txtnexts.Enabled=edit;
			cmbserv.Enabled=edit;
			cmbguard.Enabled=edit;
			txtnotes.Enabled=edit;
			chkUse.Enabled=edit;
			txtDateRem.Enabled=edit;
			this.txtContNo.Enabled=edit;
			this.txtEmCont.Enabled=edit;
			this.txtCode.Enabled=edit;
		}
		
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			setenabled(true);
			btnUpdate.Visible = true;
			btnCancel.Visible = true;
			btnEdit.Visible = false;
			btnClose.Visible=false;
			Session["sec_edit"] = true;
			Session["sec_save"] = true;
			Session["sec_new"] = false;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			bool fnew = (bool)Session["sec_new"];
			Session["sec_edit"] = false;
			Session["sec_save"] = false;
			Session["sec_new"] = false;
			if(fnew)
			{
				Response.Write("<script>window.close();</script>");
			}
			else
			{
				Response.Redirect("securitydetails.aspx");
			}
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Session["sec_edit"] = false;
			Session["sec_save"] = false;
			Session["sec_new"] = false;
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
			savesecurity();
		}

		private void savesecurity()
		{
			bool oktosave = true;
			string Msg = "";
			int cnt = 0;
			Camelot.classes.saveUtils su = new saveUtils();

			if(cmbsectype.SelectedItem.Text=="")
			{
				oktosave=false;
				cnt = 1;
				Msg = "secility Type";
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
				lsec= (Camelot.classes.cSecurity)Session["cursec"];
				pUser = (Camelot.classes.cUser)Session["curUser"];

				conn.ConnectionString = (string)Session["Connection"];
				conn.Open();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "update_security";

				cmd.Parameters.Add(
					new SqlParameter("@prop_id", lprop.Property_ID));
				cmd.Parameters.Add(
					new SqlParameter("@Sec_ID", lsec.Security_ID));
				cmd.Parameters.Add(
					new SqlParameter("@sec_type", get_sectypeid(cmbsectype.SelectedItem.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@sec_desc", txtsecdesc.Text));
				cmd.Parameters.Add(
					new SqlParameter("@sec_loc", txtLoc.Text));
				cmd.Parameters.Add(
					new SqlParameter("@sec_sn", txtsecsn.Text));
				cmd.Parameters.Add(
					new SqlParameter("@insdate", su.setdate(txtinsdate.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@remdate", su.setdate(txtDateRem.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@lastcheck", su.setdate(txtlasts.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@nextcheck", su.setdate(txtnexts.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@maint_id", get_secmaint(cmbserv.SelectedItem.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@notes", txtnotes.Text));
				cmd.Parameters.Add(
					new SqlParameter("@res_id", get_secres(cmbguard.SelectedItem.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@record_manager", pUser.ID));
				cmd.Parameters.Add(
					new SqlParameter("@inuse", chkUse.Checked));
				cmd.Parameters.Add(
					new SqlParameter("@code", txtCode.Text));
				cmd.Parameters.Add(
					new SqlParameter("@em_cont", txtEmCont.Text));
				cmd.Parameters.Add(
					new SqlParameter("@cont_no", txtContNo.Text));
				cmd.ExecuteNonQuery();
				
				cmd.Dispose();
				conn.Close();
				conn.Dispose();
			
				bool fnew = (bool)Session["sec_new"];
				Session["sec_edit"] = false;
				Session["sec_save"] = false;
				Session["sec_new"] = false;
				if(fnew)
				{
					Response.Write("<script>parent.location.reload(true);</script>");
					Response.Write("<script>window.close();</script>");
				}
				else
				{
					Response.Redirect("securitydetails.aspx");
				}
			}
			else
			{
				if(cnt==1)
				{
					Msg ="The field " + Msg + " is";
				}
				else
				{
					Msg ="The fields " + Msg + " are";
				}
				Msg = Msg+ " incomplete or in the wrong format";
				lblMessage.Text = Msg;
				lblMessage.Visible=true;
			}
		}

		public int get_sectypeid(string sec)
		{
			int id = 0;
			Security_Types fts = (Security_Types)Session["Stypes"];
			
			foreach(cSec_type fc in fts)
			{
				if(fc.Security_Type == sec)
				{
					id = Convert.ToInt32(fc.Sec_ID);
					break;
				}
			}
			return id;
		}

		public int get_secmaint(string man)
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

		public int get_secres(string res)
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
			pop_sec_types("");
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
