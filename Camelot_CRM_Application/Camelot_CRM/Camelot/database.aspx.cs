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
using Camelot.classes;

namespace Camelot.forms
{
	/// <summary>
	/// Summary description for database.
	/// </summary>
	public class database : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.DropDownList cmbDatabase;
		protected System.Web.UI.WebControls.Button btnLogon;
		Camelot.classes.cUser user = new cUser();

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				pop_combos();
			}
			// Put user code to initialize the page here
		}

		private void pop_combos()
		{
			cUsers users = (cUsers)Session["users"];
			cmbDatabase.Items.Clear();
			foreach(cUser cu in users)
			{
				cmbDatabase.Items.Add(cu.Database);
			}
			cmbDatabase.SelectedIndex = 0;
			user.Database =cmbDatabase.SelectedItem.Text;
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
			this.cmbDatabase.SelectedIndexChanged += new System.EventHandler(this.cmbDatabase_SelectedIndexChanged);
			this.btnLogon.Click += new System.EventHandler(this.btnLogon_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnLogon_Click(object sender, System.EventArgs e)
		{
			cUsers users = (cUsers)Session["users"];
			
			foreach(cUser cu in users)
			{
				if(cu.Database == cmbDatabase.SelectedItem.Text)
				{
					Session["curUser"] = cu;
					startup(cu.ConnString);
					Session["menu"] = cu.Menu;
					switch(cu.Menu)
					{
						case "admin":
							Response.Redirect("forms/property.aspx");
							break;
						case "property":
							Response.Redirect("forms/property.aspx");
							break;
						case "account":
							Response.Redirect("forms/property.aspx");
							break;
						case "sales":
							Response.Redirect("forms/comopany.aspx");
							break;
					}
					break;
				}
			}
		
		}

		private void startup(string pcon)
		{
			Camelot.classes.cUser curUser = new Camelot.classes.cUser();
			Camelot.classes.cCompany curCompany = new Camelot.classes.cCompany();
			Camelot.classes.cProperty curProperty = new Camelot.classes.cProperty();
			Camelot.classes.cFacility curFac = new Camelot.classes.cFacility();
			Camelot.classes.cContact curCont = new Camelot.classes.cContact();
			Camelot.classes.cMeter curMet = new Camelot.classes.cMeter();
			Camelot.classes.cGuardian curGuardian = new Camelot.classes.cGuardian();
			Camelot.classes.Employees Emps = new Camelot.classes.Employees();
			Camelot.classes.Areas Ars = new Camelot.classes.Areas();
			Camelot.classes.Object_stats Stats = new Camelot.classes.Object_stats();
			Camelot.classes.O_Types Types = new Camelot.classes.O_Types();
			Camelot.classes.Facility_Types fTypes = new Camelot.classes.Facility_Types();
			Camelot.classes.Meter_Types mTypes = new Camelot.classes.Meter_Types();
			Camelot.classes.Utils Utils = new Camelot.classes.Utils();
			Camelot.classes.cMeterReading mRead = new Camelot.classes.cMeterReading();
			Camelot.classes.cCorr mCorr = new Camelot.classes.cCorr();
			Camelot.classes.C_Types CTypes = new Camelot.classes.C_Types();
			Camelot.classes.Comp_stats Cstats = new Camelot.classes.Comp_stats();
			Camelot.classes.Cont_Stats Costats = new Camelot.classes.Cont_Stats();
			Camelot.classes.Guard_stats Gstats  = new Camelot.classes.Guard_stats();
			Camelot.classes.cNote cnote = new Camelot.classes.cNote();
			Camelot.classes.cInvoice cinvoice = new Camelot.classes.cInvoice();
			Camelot.classes.cont_types ContTypes = new cont_types();
			Camelot.classes.Reports Reports = new Reports();

			string con = "server=192.168.75.1;integrated security=false;uid=sa;pwd=sa;database=" + pcon + ";";
			Session["fac"] = "";
			Session["curCompany"] = curCompany;
			Session["curProperty"] = curProperty;
			Session["curFac"] = curFac;
			Session["curMeter"] = curMet;
			Session["curGuardian"] = curGuardian;
			Session["Connection"] = con;
			Session["con"] = con;
			Session["curRead"] = mRead;
			Session["curCont"] = curCont;
			Session["curCorr"] = mCorr;
			Session["curNote"] = cnote;
			Session["curInvoice"] = cinvoice;

			Emps = Utils.get_Employees(con);
			Session["Emps"] = Emps;
			Ars = Utils.get_Areas(con);
			Session["Areas"] = Ars;
			ContTypes= Utils.get_conttypes(con);
			Session["ContTypes"] = ContTypes;
			fTypes = Utils.get_Facility_Types(con);
			Session["Ftypes"] = fTypes;
			mTypes = Utils.get_Meter_Types(con);
			Session["Mtypes"] = mTypes;
			Stats = Utils.get_Object_Stats(con);
			Session["Stats"] = Stats;
			Types = Utils.get_Object_Types(con);
			CTypes = Utils.get_Comp_Types(con);
			Cstats = Utils.get_Comp_Stats(con);
			Costats = Utils.get_Cont_Stats(con);
			Gstats = Utils.get_Guard_Stats(con);
			Reports = Utils.get_Reports(con);

			Session["CTypes"] = CTypes;
			Session["Cstats"] = Cstats;
			Session["Costats"] = Costats;
			Session["OTypes"] = Types;
			Session["Gstats"] = Gstats;
			Session["Reports"]  = Reports;
			Session["prop_edit"] = false;
			Session["prop_save"] = false;
			Session["fac_edit"] = false;
			Session["fac_save"] = false;
			Session["fac_new"] = false;
			Session["met_edit"] = false;
			Session["met_save"] = false;
			Session["metr_edit"] = false;
			Session["metr_save"] = false;
			Session["met_new"] = false;
			Session["metr_new"] = false;
			Session["read_edit"] = false;
			Session["read_save"] = false;
			Session["read_new"] = false;
			Session["cont_edit"] = false;
			Session["cont_save"] = false;
			Session["cont_new"] = false;
			Session["comp_edit"] = false;
			Session["comp_save"] = false;
			Session["comp_new"] = false;
			Session["note_edit"] = false;
			Session["note_save"] = false;
			Session["note_new"] = false;
			Session["guard_edit"] = false;
			Session["guard_save"] = false;
			Session["guard_new"] = false;
			Session["invoice_edit"] = false;
			Session["invoice_save"] = false;
			Session["invoice_new"] = false;
			Session["bank_edit"] = false;
			Session["bank_save"] = false;
			Session["src"] = "";
		}

		private void cmbDatabase_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string text;
			text = cmbDatabase.SelectedIndex.ToString();
		}
	}
}
