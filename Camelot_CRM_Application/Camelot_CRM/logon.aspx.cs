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
using cc=Camelot.classes;

namespace Camelot
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class logon : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtUser;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.WebControls.Button btnLogon;
		protected System.Web.UI.WebControls.Label lblMessage;
		Camelot.classes.cUser lUser;

		private void Page_Load(object sender, System.EventArgs e)
		{
			lUser= (Camelot.classes.cUser)Session["curUser"];
			
			/*if(lUser.ID == 0 )
			{
				string user = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString();
				this.txtUser.Text = user;
			}*/
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
			
			this.btnLogon.Click += new System.EventHandler(this.btnLogon_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void startup(string pcon, int eid)
		{
			Camelot.classes.cUser curUser = new Camelot.classes.cUser();
			Camelot.classes.cCompany curCompany = new Camelot.classes.cCompany();
			Camelot.classes.cProperty curProperty = new Camelot.classes.cProperty();
			Camelot.classes.cFacility curFac = new Camelot.classes.cFacility();
			Camelot.classes.cSecurity curSec = new cc.cSecurity();
			Camelot.classes.cContact curCont = new Camelot.classes.cContact();
			Camelot.classes.cMeter curMet = new Camelot.classes.cMeter();
			Camelot.classes.cGuardian curGuardian = new Camelot.classes.cGuardian();
			Camelot.classes.Employees Emps = new Camelot.classes.Employees();
			Camelot.classes.Areas Ars = new Camelot.classes.Areas();
			Camelot.classes.Object_stats Stats = new Camelot.classes.Object_stats();
			Camelot.classes.O_Types Types = new Camelot.classes.O_Types();
			Camelot.classes.Facility_Types fTypes = new Camelot.classes.Facility_Types();
			Camelot.classes.Security_Types sTypes = new Camelot.classes.Security_Types();
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
			Camelot.classes.cont_types ContTypes = new cc.cont_types();
			Camelot.classes.Reports Reports = new cc.Reports();
			Camelot.classes.cAcc_Mans Acc_mans = new Camelot.classes.cAcc_Mans();
			Camelot.classes.cInspection cinsp = new cc.cInspection();
			Camelot.classes.cJTitles jts = new cc.cJTitles();
			Camelot.classes.Incident_Types iTypes = new cc.Incident_Types();
			Camelot.classes.cIncident curInc = new cc.cIncident();
			Camelot.classes.inc_stats Istats = new cc.inc_stats();
			Camelot.classes.cInc_Srcs Isrcs = new cc.cInc_Srcs();
			Camelot.classes.cInc_urgs Iurgs = new cc.cInc_urgs();
			Camelot.classes.cAction curAct = new cc.cAction();
			Camelot.classes.cRoute curRoute = new cc.cRoute();

			string con = "server=" + Session["server"].ToString() + ";integrated security=false;uid=sa;pwd=" + Session["pwd"].ToString() + ";database=" + pcon + ";";
			//string con = "server=FUJI;integrated security=false;uid=sa;pwd=fvzappa3;database=" + pcon + ";";
			Session["fac"] = "";
			curUser = Utils.get_User(con,eid);
			Session["curUser"] = curUser;
			Session["curCompany"] = curCompany;
			Session["curProperty"] = curProperty;
			Session["curFac"] = curFac;
			Session["curSec"] = curSec;
			Session["curMeter"] = curMet;
			Session["curGuardian"] = curGuardian;
			Session["Connection"] = con;
			Session["con"] = con;
			Session["curRead"] = mRead;
			Session["curCont"] = curCont;
			Session["curCorr"] = mCorr;
			Session["curNote"] = cnote;
			Session["curInvoice"] = cinvoice;
			Session["curInspection"] = cinsp;
			Session["curIncident"] = curInc;
			Session["curAction"] = curAct;
			Session["curRoute"] = curRoute;
			string printer = "";

			printer = Utils.get_printer(con);
			Session["printer"] = printer;
			Emps = Utils.get_Employees(con);
			Session["Emps"] = Emps;
			Ars = Utils.get_Areas(con);
			Session["Areas"] = Ars;
			ContTypes= Utils.get_conttypes(con);
			Session["ContTypes"] = ContTypes;
			fTypes = Utils.get_Facility_Types(con);
			Session["Ftypes"] = fTypes;
			sTypes = Utils.get_Security_Types(con);
			Session["Stypes"] = sTypes;
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
			Acc_mans = Utils.get_Accmans(con);
			//jts = Utils.get_Job_Titles(con);
			iTypes = Utils.get_Incident_Types(con);
			Session["Itypes"] = iTypes;
			Istats = Utils.get_Inc_Stats(con);
			Isrcs = Utils.get_Inc_Srcs(con);
			Iurgs = Utils.get_Incident_Urgencies(con);
			Utils.delete_files();

			Session["CTypes"] = CTypes;
			Session["Cstats"] = Cstats;
			Session["Costats"] = Costats;
			Session["OTypes"] = Types;
			Session["Gstats"] = Gstats;
			Session["Reports"]  = Reports;
			Session["Accmans"] = Acc_mans;
			Session["JTitles"] = jts;
			Session["prop_edit"] = false;
			Session["prop_save"] = false;
			Session["prop_new"] = false;
			Session["fac_edit"] = false;
			Session["fac_save"] = false;
			Session["fac_new"] = false;			
			Session["sec_edit"] = false;
			Session["sec_save"] = false;
			Session["sec_new"] = false;
			Session["met_edit"] = false;
			Session["met_save"] = false;
			Session["insp_edit"] = false;
			Session["insp_save"] = false;
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
			Session["inc_edit"] = false;
			Session["inc_save"] = false;
			Session["inc_new"] = false;
			Session["IStats"] = Istats;
			Session["ISrcs"] = Isrcs;
			Session["IUrgs"] = Iurgs;
			Session["act_edit"] = false;
			Session["act_save"] = false;
			Session["act_new"] = false;
			Session["app_id"]="";
			Session["app_edit"] = false;
			Session["app_save"] = false;
			Session["place_app"] = false;
			Session["app_con"]="";
			Session["vet_edit"] = false;
			Session["vet_save"] = false;
			Session["ptype"] = "";
		}

		private void btnLogon_Click(object sender, System.EventArgs e)
		{
			cc.authenticate a = new cc.authenticate();
			Camelot.classes.cLogins logins = new cc.cLogins();
			Camelot.classes.cLogin login = new cc.cLogin();
			cc.cUser user = new Camelot.classes.cUser();

			logins = a.auth_logon(txtUser.Text, txtPassword.Text, (string)Session["Logon"]);
			Session["logins"] = logins;
			if(logins.Count > 1)
			{
				Response.Redirect("database.aspx");
			}
			else
			{
				login = logins.Item(0);
				if(login.Uname == "uname" )
				{
					lblMessage.Text="**** Invalid Username ****";
				}
				else if(login.Uname=="pword")
				{
					lblMessage.Text="**** Invalid Password ****";
				}
				else
				{
					startup(login.ConnString,login.ID);
					user = (cc.cUser)Session["curUser"];
					Session["menu"] = user.Menu;
					switch(user.Menu.Substring(0,3))
					{
						case "adm":
							Response.Redirect("forms/property.aspx");
							break;
						case "pro":
							Response.Redirect("forms/property.aspx");
							break;
						case "acc":
							Response.Redirect("forms/property.aspx");
							break;
						case "sal":
							Response.Redirect("forms/comopany.aspx");
							break;
					}
				}
			}
		}
	}
}
