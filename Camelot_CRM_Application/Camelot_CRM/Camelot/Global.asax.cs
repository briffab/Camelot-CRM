using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;

namespace Camelot 
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{

		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{
			string con = "server=192.168.75.1;integrated security=false;uid=sa;pwd=sa;database=camelot_login;";

			Session["Logon"] = con;
			Camelot.classes.cUser curUser = new Camelot.classes.cUser();
			Session["curUser"] = curUser;
			/*
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

			
			Session["fac"] = "";
			Session["curUser"] = curUser;
			Session["curCompany"] = curCompany;
			Session["curProperty"] = curProperty;
			Session["curFac"] = curFac;
			Session["curMeter"] = curMet;
			Session["curGuardian"] = curGuardian;
			Session["Connection"] = con;
			Session["curRead"] = mRead;
			Session["curCont"] = curCont;
			Session["curCorr"] = mCorr;
			Session["curNote"] = cnote;

			Emps = Utils.get_Employees(con);
			Session["Emps"] = Emps;
			Ars = Utils.get_Areas(con);
			Session["Areas"] = Ars;
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

			Session["CTypes"] = CTypes;
			Session["Cstats"] = Cstats;
			Session["Costats"] = Costats;
			Session["OTypes"] = Types;
			Session["Gstats"] = Gstats;
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
			Session["src"] = "";
			*/
		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_Error(Object sender, EventArgs e)
		{

		}

		protected void Session_End(Object sender, EventArgs e)
		{

		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}
			
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

