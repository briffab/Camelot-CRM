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

namespace Camelot
{
	/// <summary>
	/// Summary description for meterdetails.
	/// </summary>
	public class meterdetails : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label lblfacdesc;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtnotes;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Image imgMainPhoto;
		protected System.Web.UI.WebControls.Button btnClose;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Button btnCancel;
		Camelot.classes.Utils Utils = new Camelot.classes.Utils();
		Camelot.classes.cMeter lmet;
		Camelot.classes.cProperty lprop;
		protected System.Web.UI.WebControls.DropDownList cmbmettype;
		protected System.Web.UI.WebControls.TextBox txtloc;
		protected System.Web.UI.WebControls.TextBox txtmetsn;
		protected System.Web.UI.WebControls.DropDownList cmbsupp;
		protected System.Web.UI.WebControls.CheckBox chkUse;
		protected System.Web.UI.WebControls.Label lblfactype;
		protected System.Web.UI.WebControls.Button btnReadings;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.Label lblUpBy;
		protected System.Web.UI.WebControls.Label lblUby;
		protected System.Web.UI.WebControls.Label lblUpOn;
		protected System.Web.UI.WebControls.Label lblUDate;
		protected System.Web.UI.WebControls.TextBox txtStart;
		protected System.Web.UI.WebControls.TextBox txtFinish;
		protected System.Web.UI.WebControls.DataGrid dgRead;
		protected System.Web.UI.WebControls.Button btnRate;
		protected System.Web.UI.WebControls.Label Label3;
		Camelot.classes.cUser pUser;
		public string defUrl;
		

		private void Page_Load(object sender, System.EventArgs e)
		{
			bool oktogo;
			Camelot.classes.Utils pUtil = new Camelot.classes.Utils();
			pUser = (Camelot.classes.cUser)Session["curUser"];
			oktogo = pUtil.valid_user(pUser);

			if (!Page.IsClientScriptBlockRegistered("Rate"))
			{		
				string title="Meter Rates";
				string height="400";
				string width="630";	
			 
				// use next line for direct with <base target="_self"> between <Head> and </HEAD> 
				string scrp="<script>var rc = new Array(0,0);function doIt(){rc= window.showModalDialog('meterrates.aspx?Title="+title + "','','dialogHeight:"+height+" px;dialogWidth:"+width+" px;');"+"\n";
				scrp+="__doPostBack('','');}</script>";

				Page.RegisterStartupScript("Rate",scrp);			
				this.btnRate.Attributes.Add("onClick","doIt();");
			}

			if (!Page.IsClientScriptBlockRegistered("Read"))
			{		
				string title="Meter Reading";
				string height="450";
				string width="600";	
			 
				// use next line for direct with <base target="_self"> between <Head> and </HEAD> 
				string scrp="<script>var rc = new Array(0,0);function doRIt(){rc= window.showModalDialog('meterreading.aspx?Title="+title + "','','dialogHeight:"+height+" px;dialogWidth:"+width+" px;');"+"\n";
				scrp+="__doPostBack('','');}</script>";

				Page.RegisterStartupScript("Read",scrp);			
				this.btnReadings.Attributes.Add("onClick","doRIt();");
			}

			if (!Page.IsClientScriptBlockRegistered("Photo"))
			{			 
				// use next line for direct with <base target="_self"> between <Head> and </HEAD> 
				string scrp="<script>var rc = new Array(0,0);function doPIt(){rc= window.showModalDialog('photo_frame.aspx','newprop','dialogHeight:650px; dialogWidth: 900px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');"+"\n";
				scrp+="__doPostBack('','');}</script>";

				Page.RegisterStartupScript("Photo",scrp);			
				this.imgMainPhoto.Attributes.Add("onClick","doPIt();");
			}


			Session["ptype"] = "3";
			if(!oktogo)
			{
				Response.Redirect("../logon.aspx");
			}
			else
			{
				lmet=(Camelot.classes.cMeter)Session["curMeter"];
				hideErr();
				string err=Request.QueryString["err"];
			
				if(lmet.Meter_ID==null || lmet.Meter_ID=="")
				{
					string met = Request.QueryString["met"];
					lmet.Meter_ID = met;
				}
			
				Response.Expires = 0;
				Response.Cache.SetNoStore();
				Response.AppendHeader("Pragma", "no-cache");
			
			
				bool edit = (bool)Session["met_edit"];
				bool mnew = (bool)Session["met_new"];
									
				setenabled(edit);
			
				if(mnew)
				{
					if(!(bool)Session["met_save"])
					{
						pop_combos();
						btnUpdate.Visible = true;
						btnCancel.Visible = true;
						btnEdit.Visible = false;
						btnReadings.Visible = false;
						btnClose.Visible=false;
						lmet.Meter_ID = "";
						Session["met_save"] = true;
						this.btnRate.Visible=false;
						this.imgMainPhoto.Visible=false;
					}
				}
				else
				{
					if(edit)
					{
						if(!(bool)Session["met_save"] && (lmet.Meter_ID!=null && lmet.Meter_ID!=""))
						{
							pop_met(lmet.Meter_ID);
						}
				
						btnUpdate.Visible = true;
						btnCancel.Visible = true;
						btnEdit.Visible = false;
						btnReadings.Visible = false;
						btnClose.Visible=false;
					}
					else
					{
						if(!(bool)Session["met_save"] && (lmet.Meter_ID!=null && lmet.Meter_ID!=""))
						{
							pop_met(lmet.Meter_ID);
						}
						btnUpdate.Visible = false;
						btnCancel.Visible = false;
						if(pUser.Permission=="1")
						{
							btnEdit.Visible = true;
						}
						else
						{
							btnEdit.Visible=false;
						}
						btnReadings.Visible = true;
						btnClose.Visible=true;
					}
				}
				Session["curMeter"] = lmet;
			}
			if(!(bool)Session["metr_edit"])
			{
				pop_read();
			}
		}

		
		private void pop_read()
		{
			this.dgRead.DataSource = createsource();
			this.dgRead.DataBind();
		}

		private ICollection createsource()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.saveUtils us = new Camelot.classes.saveUtils();
			int colc = 0;

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_readings";

			cmd.Parameters.Add(
				new SqlParameter("@met_id", lmet.Meter_ID));

			rdr = cmd.ExecuteReader();
			
			// Create sample data for the DataGrid control.
			DataTable dt = new DataTable();
			DataRow dr;
 
			// Define the columns of the table.
			
			DataColumn dc = new DataColumn();
			dc.ReadOnly=true;
			dc.ColumnName="Date";

			dt.Columns.Add(dc);
			while(rdr.Read())
			{
				dt.Columns.Add(new DataColumn(rdr.GetValue(0).ToString(), typeof(String)));
				colc++;
			}
			
			rdr.NextResult();
			while(rdr.Read())
			{
				dr = dt.NewRow();
				for(int i =0;i<=colc;i++)
				{
					dr[i]=rdr.GetValue(i).ToString();
				}
				dt.Rows.Add(dr);
			}

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

			DataView dv = new DataView(dt);
			return dv;
		}

		private void pop_met(string met_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.saveUtils us = new Camelot.classes.saveUtils();
			string mettype = "";
			string supp = "";

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_meter";

			cmd.Parameters.Add(
				new SqlParameter("@met_id", met_id));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				lblTitle.Text = rdr["location"].ToString();
				mettype = rdr["type_id"].ToString();
				txtloc.Text = rdr["location"].ToString();
				txtmetsn.Text = rdr["serialnumber"].ToString();
				supp = rdr["SUPP_ID"].ToString();
				txtStart.Text = us.getdate(rdr["start_date"].ToString());
				txtFinish.Text = us.getdate(rdr["finish_date"].ToString());		
				txtnotes.Text = rdr["notes"].ToString();
				lblUby.Text = get_employeename(Convert.ToInt32(rdr["modified_by"]));
				lblUDate.Text = us.getdate(rdr["Date_modified"].ToString());
				chkUse.Checked = (bool)rdr["in_use"];
			}
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

			lmet.Meter_Location = lblTitle.Text;
			lmet.Meter_Type = mettype;
			pop_met_types(mettype);
			pop_supplier(supp);
			pop_pic();

		}

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
				new SqlParameter("@P_ID", lmet.Meter_ID));
			cmd.Parameters.Add(
				new SqlParameter("@type", 3));

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

		private void pop_supplier(string sup)
		{
			
			Camelot.classes.Supplier supp  = new Supplier();
			supp = Utils.get_Suppliers(Session["con"].ToString());

			int ind =0;

			cmbsupp.Items.Clear();
			cmbsupp.Items.Add("");
			foreach(cSupplier sp in supp)
			{
				cmbsupp.Items.Add(sp.Name);
				if(sp.ID == sup)
				{
					ind = cmbsupp.Items.Count-1;
				}
			}
			cmbsupp.SelectedIndex = ind;
			
		}

		private void pop_met_types(string metid)
		{
			Meter_Types mts = (Meter_Types)Session["Mtypes"];
			int ind =0;
			cmbmettype.Items.Clear();
			cmbmettype.Items.Add("");
			foreach(cMeter_type mt in mts)
			{
				cmbmettype.Items.Add(mt.Meter_Type);
				if(mt.Met_ID == metid)
				{
					ind = cmbmettype.Items.Count-1;
				}
			}
			cmbmettype.SelectedIndex = ind;
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
			this.chkUse.CheckedChanged += new System.EventHandler(this.chkUse_CheckedChanged);
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			this.btnRate.Click += new System.EventHandler(this.btnRate_Click);
			this.btnReadings.Click += new System.EventHandler(this.btnReadings_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void setenabled(bool edit)
		{
			cmbmettype.Enabled = edit;
			txtloc.Enabled=edit;
			txtmetsn.Enabled=edit;
			cmbsupp.Enabled=edit;;
			txtnotes.Enabled=edit;
			txtStart.Enabled = edit;
			chkUse.Enabled=edit;
			txtFinish.Enabled=edit;
		}
		
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			setenabled(true);
			btnUpdate.Visible = true;
			btnCancel.Visible = true;
			btnEdit.Visible = false;
			btnReadings.Visible = false;
			this.btnRate.Visible = false;
			btnClose.Visible=false;
			this.dgRead.Enabled=false;
			Session["met_edit"] = true;
			Session["met_save"] = true;
			Session["met_new"] = false;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			bool mnew = (bool)Session["met_new"];
			Session["met_edit"] = false;
			Session["met_save"] = false;
			Session["met_new"] = false;
			if(mnew)
			{
				Response.Write("<script>window.close();</script>");
			}
			else
			{
				Response.Redirect("meterdetails.aspx");
			}
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Session["met_edit"] = false;
			Session["met_save"] = false;
			Session["met_new"] = false;
			Response.Write("<script>window.close();</script>");
		}

		
		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			savemeter();
		}

		private void savemeter()
		{
			bool oktosave = true;
			string Msg = "";
			int cnt = 0;
			Camelot.classes.saveUtils su = new saveUtils();

			if(cmbmettype.SelectedItem.Text=="")
			{
				oktosave=false;
				cnt = 1;
				Msg = "Meter Type";
				Label12.Visible=true;
			}
			
			if(!su.IsDate(su.setdate(txtStart.Text)))
			{
				oktosave=false;
				cnt++;
				if(Msg!="")
				{
					Msg = Msg + ", Start Date";
				}
				else
				{
					Msg = "Start Date";
				}
				Label10.Visible=true;
			}

			if(!su.IsDate(su.setdate(txtFinish.Text)))
			{
				oktosave=false;
				cnt++;
				if(Msg!="")
				{
					Msg = Msg + ", Finish Date";
				}
				else
				{
					Msg = "Finish Date";
				}
				Label17.Visible=true;
			}
			
			if(oktosave)
			{
				lprop=(Camelot.classes.cProperty)Session["curProperty"];
				SqlConnection conn = new SqlConnection();
				SqlCommand cmd =  new SqlCommand();
				lmet= (Camelot.classes.cMeter)Session["curMeter"];
				pUser = (Camelot.classes.cUser)Session["curUser"];

				conn.ConnectionString = (string)Session["Connection"];
				conn.Open();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "update_meter";

				cmd.Parameters.Add(
					new SqlParameter("@prop_id", lprop.Property_ID));
				cmd.Parameters.Add(
					new SqlParameter("@met_id", lmet.Meter_ID));
				cmd.Parameters.Add(
					new SqlParameter("@met_type", get_mettypeid(cmbmettype.SelectedItem.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@loc", txtloc.Text));
				cmd.Parameters.Add(
					new SqlParameter("@met_sn", txtmetsn.Text));
				cmd.Parameters.Add(
					new SqlParameter("@startdate", DateTime.Parse(su.setdate(txtStart.Text))));
				cmd.Parameters.Add(
					new SqlParameter("@finishdate", DateTime.Parse(su.setdate(txtFinish.Text))));
				cmd.Parameters.Add(
					new SqlParameter("@supp_id", get_metsupp(cmbsupp.SelectedItem.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@notes", txtnotes.Text));
				cmd.Parameters.Add(
					new SqlParameter("@record_modifier", pUser.ID));
				cmd.Parameters.Add(
					new SqlParameter("@inuse", chkUse.Checked));
				cmd.ExecuteNonQuery();
				
				cmd.Dispose();
				conn.Close();
				conn.Dispose();
			
				bool mnew = (bool)Session["met_new"];
				Session["met_edit"] = false;
				Session["met_save"] = false;
				Session["met_new"] = false;
				if(mnew)
				{
					Response.Write("<script>parent.location.reload(true);</script>");
					Response.Write("<script>window.close();</script>");
				}
				else
				{
					Response.Redirect("meterdetails.aspx");
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


		public int get_mettypeid(string met)
		{
			int id = 0;
			Meter_Types mts = (Meter_Types)Session["Mtypes"];
			
			foreach(cMeter_type mt in mts)
			{
				if(mt.Meter_Type == met)
				{
					id = Convert.ToInt32(mt.Met_ID);
					break;
				}
			}
			return id;
		}

		public int get_metsupp(string sup)
		{
			int id = 0;
			Camelot.classes.Supplier supp = new  Supplier();
			supp = Utils.get_Suppliers(Session["con"].ToString());
			
			foreach(cSupplier sp in supp)
			{
				if(sp.Name == sup)
				{
					id = Convert.ToInt32(sp.ID);
					break;
				}
			}
			return id;
		}

		
		private void pop_combos()
		{
			pop_met_types("");
			pop_supplier("");
	
		}

		private void hideErr()
		{
			lblMessage.Visible = false;
			Label11.Visible=false;
			Label12.Visible=false;
			Label16.Visible=false;
			Label4.Visible=false;
			Label10.Visible=false;
			Label17.Visible=false;
		}

		private void btnReadings_Click(object sender, System.EventArgs e)
		{
			//Response.Write("<script>window.showModalDialog('meterreading.aspx?met=','metread','dialogHeight: 400px; dialogWidth: 600px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');</script>");
		}

		private void chkUse_CheckedChanged(object sender, System.EventArgs e)
		{
			
		}

		private void btnRate_Click(object sender, System.EventArgs e)
		{
			//Response.Write("<script>window.showModalDialog('meterrates.aspx?met=','metread','dialogHeight: 400px; dialogWidth: 630px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;'); __doPostBack('',''); </script>");
		}

		public void dgRead_Edit(Object sender, DataGridCommandEventArgs e) 
		{
			dgRead.EditItemIndex = e.Item.ItemIndex;
			this.btnRate.Enabled=false;
			this.btnReadings.Enabled=false;
			this.btnEdit.Enabled=false;
			this.btnClose.Enabled=false;
			Session["metr_edit"] = true;
			pop_read();

		}

		public void dgRead_Cancel(Object sender, DataGridCommandEventArgs e) 
		{

			// Set the EditItemIndex property to -1 to exit editing mode. 
			// Be sure to rebind the DateGrid to the data source to refresh
			// the control.
			dgRead.EditItemIndex = -1;
			this.btnRate.Enabled=true;
			this.btnReadings.Enabled=true;
			this.btnEdit.Enabled=true;
			this.btnClose.Enabled=true;
			Session["metr_edit"] = false;
			pop_read();

		}

		public void dgRead_Delete(Object sender, DataGridCommandEventArgs e) 
		{
			deletereading(e.Item.Cells[2].Text);
			pop_read();
		}

		public void dgRead_Update(Object sender, DataGridCommandEventArgs e) 
		{

			// Set the EditItemIndex property to -1 to exit editing mode. 
			// Be sure to rebind the DateGrid to the data source to refresh
			// the control.

			
			int cnt = 0;

			cnt= e.Item.Cells.Count;
			for(int i=3;i<cnt;i++)
			{
				string tb = ((TextBox)e.Item.Cells[i].Controls[0]).Text;
				savereading(e.Item.Cells[2].Text, tb,i-2);
			}
			dgRead.EditItemIndex = -1;
			this.btnRate.Enabled=true;
			this.btnReadings.Enabled=true;
			this.btnEdit.Enabled=true;
			this.btnClose.Enabled=true;			
			Session["metr_edit"] = false;
			pop_read();
		}

		private void deletereading(string date)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			lmet= (Camelot.classes.cMeter)Session["curMeter"];
			
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "delete_meter_reading";

			cmd.Parameters.Add(
				new SqlParameter("@met_id", lmet.Meter_ID));
			cmd.Parameters.Add(
				new SqlParameter("@date", Convert.ToDateTime(date)));
			cmd.ExecuteNonQuery();
				
			cmd.Dispose();
			conn.Close();
			conn.Dispose();	
		}
		private void savereading(string date, string read, int index)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			lmet= (Camelot.classes.cMeter)Session["curMeter"];
			pUser = (Camelot.classes.cUser)Session["curUser"];
			
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "update_meter_readings";

			cmd.Parameters.Add(
				new SqlParameter("@met_id", lmet.Meter_ID));
			cmd.Parameters.Add(
				new SqlParameter("@date", Convert.ToDateTime(date)));
			cmd.Parameters.Add(
				new SqlParameter("@read", read));
			cmd.Parameters.Add(
				new SqlParameter("@index", index));
			cmd.Parameters.Add(
				new SqlParameter("@insp_id", pUser.ID));
			cmd.ExecuteNonQuery();
				
			cmd.Dispose();
			conn.Close();
			conn.Dispose();	

		}
	}
}