using System;
using System.Data;
using System.Data.SqlClient;
using Camelot.classes;
using System.IO;
using System.Text.RegularExpressions;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for Utils.
	/// </summary>
	public class Utils
	{
		public  enum DateInterval
		{
			Second, Minute, Hour, Day, Week, Month, Quarter, Year
		}

		public string validate_emails(string emails)
		{
			string nemails = "";
			string iemail = "";
			
			if(emails == null)
			{
				emails = "";
			}

			while(emails.Length > 0)
			{
				if(emails.IndexOf(";",0,emails.Length) != 0 && emails.IndexOf(";",0,emails.Length) != -1)
				{				
					iemail=emails.Substring(0,emails.IndexOf(";",0,emails.Length));
					emails = emails.Substring(emails.IndexOf(";",0,emails.Length)+1,emails.Length - (emails.IndexOf(";",0,emails.Length)+1));
				}
				else
				{
					emails = emails.Trim();
					if(emails.Length > 0)
					{
						iemail = emails;
						emails = "";
					}
				}
				if(isEmail(iemail.Trim()))
				{
					nemails = nemails + iemail.Trim() + "; ";
				}
			}

			return nemails;
		}

		public static bool isEmail(string inputEmail)
		{
			if(inputEmail == null)
			{
				inputEmail = "";
			}
			string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
				@"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + 
				@".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
			Regex re = new Regex(strRegex);
			if (re.IsMatch(inputEmail))
				return (true);
			else
				return (false);
		}

		public string get_printer(string con)
		{
			string printer = "";
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_default_printer";

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				printer = rdr.GetValue(0).ToString();
			}
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

			return printer;
		}

		public Employees get_Employees(string con)
		{
			Employees emps = new Employees();
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_employees";

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				Employee emp = new Employee();
				emp.Active= rdr["active"].ToString();
				emp.Email = rdr["email"].ToString();
				emp.Emp_ID = rdr["employee_id"].ToString();
				emp.Job = rdr["job_title"].ToString();
				emp.UserID = rdr["userid"].ToString();
				emp.AccMan = rdr["accman"].ToString();
				emp.Emp_Name = rdr["name"].ToString();
				emp.PMobile = rdr["private_mobile"].ToString();
				emp.WMobile = rdr["work_mobile"].ToString();
				emp.Phone = rdr["direct_phone"].ToString();
				emps.Add(emp);
			}
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

			return emps;
		}

		public Areas get_Areas(string con)
		{
			Areas ars = new Areas();
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_areas";

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				Area ar = new Area();
				ar.Area_ID = rdr["area_id"].ToString();
				ar.Description = rdr["description"].ToString();
				ars.Add(ar);
			}
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

			return ars;
		}


		public cAcc_Mans get_Accmans(string con)
		{
			cAcc_Mans acs = new cAcc_Mans();
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_account_managers";

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				cAccMan ac = new cAccMan();
				ac.Acc_Man = rdr["employee_id"].ToString();
				acs.Add(ac);
			}
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

			return acs;
		}

		public Reports get_Reports(string con)
		{
			Reports rs = new Reports();
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_Reports";

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				Report rt = new Report();
				rt.Report_ID = rdr["report_id"].ToString();
				rt.Report_Name = rdr["report_name"].ToString();
				rt.Dates = rdr["dates"].ToString();
				rt.Property = rdr["property"].ToString();
				rt.Company = rdr["company_type"].ToString();
				rt.AccMan = rdr["account"].ToString();
				rs.Add(rt);
			}
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

			return rs;
		}

		public cDocs get_documents(string con)
		{
			cDocs cds = new cDocs();
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_documents";

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				cDoc d = new cDoc();
				d.Doc_id = rdr["doc_id"].ToString();
				d.Doc_List = rdr["doc_list_name"].ToString();
				cds.Add(d);
			}
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

			return cds;
		}

		public cDoc_Types get_document_types(string con)
		{
			cDoc_Types cds = new cDoc_Types();
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_document_types";

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				cDoc_Type d = new cDoc_Type();
				d.Type_ID = rdr["document_type"].ToString();
				d.Description = rdr["description"].ToString();
				cds.Add(d);
			}
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

			return cds;
		}

		public cUser get_User(string con,int uid)
		{
			cUser cuse = new cUser();
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_User";

			cmd.Parameters.Add(
				new SqlParameter("@uid", uid));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				cuse.ID = Convert.ToInt32(rdr["id"].ToString());
				cuse.Name = rdr["name"].ToString();
				cuse.Uname = rdr["uname"].ToString();
				cuse.Permission = rdr["permission"].ToString();
				cuse.Menu = rdr["menu"].ToString();
				cuse.Phone = rdr["direct_phone"].ToString();
				cuse.AccMan = rdr["accman"].ToString();
				cuse.WMobile = rdr["work_mobile"].ToString();
				cuse.PMobile = rdr["private_mobile"].ToString();
				cuse.Email = rdr["email"].ToString();
				cuse.Job = rdr["job_title"].ToString();
			}
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

			return cuse;

		}
	
		public cont_types get_conttypes(string con)
		{
			cont_types cts = new cont_types();
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_conttypes";

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				cont_type ct = new cont_type();
				ct.C_TypeID = rdr["contact_type"].ToString();
				ct.Description = rdr["description"].ToString();
				cts.Add(ct);
			}
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

			return cts;
		}

		public Object_stats get_Object_Stats(string con)
		{
			Object_stats stats = new Object_stats();
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_object_stats";

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				Object_stat os = new Object_stat();
				os.Status_ID = rdr["status_id"].ToString();
				os.Description = rdr["status_description"].ToString();
				stats.Add(os);
			}

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			return stats;
		}

		public Comp_stats get_Comp_Stats(string con)
		{
			Comp_stats cstats = new Comp_stats();
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_comp_stats";

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				Comp_stat cs = new Comp_stat();
				cs.Status_ID = rdr["company_status_id"].ToString();
				cs.Description = rdr["description"].ToString();
				cstats.Add(cs);
			}

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			return cstats;
		}

		public inc_stats get_Inc_Stats(string con)
		{
			inc_stats incs = new inc_stats();
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_inc_stats";

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				inc_stat inc = new inc_stat();
				inc.Status_ID = rdr["status_id"].ToString();
				inc.Description = rdr["description"].ToString();
				incs.Add(inc);
			}

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			return incs;
		}

		public cInc_Srcs get_Inc_Srcs(string con)
		{
			cInc_Srcs incs = new cInc_Srcs();
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_inc_srcs";

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				cInc_src inc = new cInc_src();
				inc.Src_ID = rdr["COMPLAINT_SOURCE_id"].ToString();
				inc.Incident_Source = rdr["description"].ToString();
				inc.Source_Type = rdr["src_type_id"].ToString();
				incs.Add(inc);
			}

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			return incs;
		}

		public Guard_stats get_Guard_Stats(string con)
		{
			Guard_stats cstats = new Guard_stats();
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_Guard_stats";

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				Guard_stat cs = new Guard_stat();
				cs.Status_ID = rdr["resident_status_id"].ToString();
				cs.Description = rdr["description"].ToString();
				cstats.Add(cs);
			}

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			return cstats;
		}

		public Cont_Stats get_Cont_Stats(string con)
		{
			Cont_Stats cstats = new Cont_Stats();
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_cont_stats";

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				Cont_stat cs = new Cont_stat();
				cs.Status_ID = rdr["contact_status_id"].ToString();
				cs.Description = rdr["description"].ToString();
				cstats.Add(cs);
			}

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			return cstats;
		}

		public cJTitles get_Job_Titles(string con)
		{
			cJTitles jts = new cJTitles();
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_JobTitles";

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				cJTitle jt = new cJTitle();
				jt.Title_ID = rdr["job_title"].ToString();
				jt.Description = rdr["description"].ToString();
				jts.Add(jt);
			}

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			return jts;
		}

		public O_Types get_Object_Types(string con)
		{
			O_Types types = new O_Types();
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_object_Types";

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				O_Type ot = new O_Type();
				ot.O_TypeID = rdr["OBJECT_type_id"].ToString();
				ot.O_TypeCode = rdr["object_type_code"].ToString();
				ot.Description = rdr["description"].ToString();
				types.Add(ot);
			}

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			return types;
		}

		public C_Types get_Comp_Types(string con)
		{
			C_Types ctypes = new C_Types();
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_comp_Types";

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				C_Type ct = new C_Type();
				ct.C_TypeID = rdr["company_type_id"].ToString();
				ct.Description = rdr["description"].ToString();
				ctypes.Add(ct);
			}

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			return ctypes;
		}

		public Maintainers get_Maintainers(string con)
		{
			Maintainers man = new Maintainers();
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_maintainers";

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				cMaintenance cMan = new cMaintenance();
				cMan.ID = rdr["maint_id"].ToString();
				cMan.Name = rdr["name"].ToString();
				cMan.Contact = rdr["contact"].ToString();
				cMan.Address1 = rdr["Address1"].ToString();
				cMan.Address2 = rdr["Address2"].ToString();
				cMan.Address3 = rdr["Address3"].ToString();
				cMan.Address4 = rdr["Address4"].ToString();
				cMan.City = rdr["city"].ToString();
				cMan.County= rdr["county"].ToString();
				cMan.Postcode = rdr["postcode"].ToString();
				cMan.Country = rdr["country"].ToString();
				cMan.Email= rdr["email"].ToString();
				cMan.Telephone = rdr["telephone"].ToString();
				cMan.Mobile = rdr["mobile"].ToString();

				man.Add(cMan);
			}

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			return man;
		}
		
		public Facility_Types get_Facility_Types(string con)
		{
			Facility_Types fts = new Facility_Types();
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_facility_types";

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				cFac_type ft = new cFac_type();
				ft.Fac_ID = rdr["facility_type"].ToString();
				ft.Facility_Type = rdr["description"].ToString();
				ft.Facility_Modifier = rdr["record_manager"].ToString();
				ft.Mod_Date = rdr["date_entered"].ToString();
				
				fts.Add(ft);
			}

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			return fts;
		}

		public Incident_Types get_Incident_Types(string con)
		{
			Incident_Types incs = new Incident_Types();
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_Incident_types";

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				cInc_type inc = new cInc_type();
				inc.Inc_ID = rdr["incident_type"].ToString();
				inc.Incident_Type = rdr["description"].ToString();
				
				incs.Add(inc);
			}

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			return incs;
		}

		public cInc_urgs get_Incident_Urgencies(string con)
		{
			cInc_urgs urgs = new cInc_urgs();
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_Incident_Urgencies";

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				cInc_urg urg = new cInc_urg();
				urg.Urg_ID = rdr["urgency_id"].ToString();
				urg.Incident_Urgency = rdr["description"].ToString();
				urg.Urg_Time = rdr["time_to_solution"].ToString();				
				urgs.Add(urg);
			}

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			return urgs;
		}

		public Security_Types get_Security_Types(string con)
		{
			Security_Types sts = new Security_Types();
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_Security_types";

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				cSec_type st = new cSec_type();
				st.Sec_ID = rdr["Security_type"].ToString();
				st.Security_Type = rdr["description"].ToString();
				st.Security_Modifier = rdr["record_manager"].ToString();
				st.Mod_Date = rdr["date_entered"].ToString();
				
				sts.Add(st);
			}

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			return sts;
		}

		public pGuardians get_Prop_Guardians(string con, string propid)
		{
			pGuardians gds = new pGuardians();
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_prop_residents";

			cmd.Parameters.Add(
				new SqlParameter("@prop_id", propid));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				cGuardian gd = new cGuardian();
				gd.Guardian_ID = rdr["resident_id"].ToString();
				gd.Guardian_Name = rdr["name"].ToString();
				gds.Add(gd);
			}
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

			return gds;
		}

		public Meter_Types get_Meter_Types(string con)
		{
			Meter_Types Mts = new Meter_Types();
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_METER_types";

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				cMeter_type mt = new cMeter_type();
				mt.Met_ID = rdr["type_id"].ToString();
				mt.Meter_Type = rdr["description"].ToString();
				
				Mts.Add(mt);
			}

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			return Mts;
		}
		public Supplier get_Suppliers(string con)
		{
			Supplier sup = new Supplier();
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_suppliers";

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				cSupplier cSupp = new cSupplier();
				cSupp.ID = rdr["supp_id"].ToString();
				cSupp.Name = rdr["name"].ToString();
				cSupp.Contact = rdr["contact"].ToString();
				cSupp.Address1 = rdr["Address1"].ToString();
				cSupp.Address2 = rdr["Address2"].ToString();
				cSupp.Address3 = rdr["Address3"].ToString();
				cSupp.Address4 = rdr["Address4"].ToString();
				cSupp.City = rdr["city"].ToString();
				cSupp.County= rdr["county"].ToString();
				cSupp.Postcode = rdr["postcode"].ToString();
				cSupp.Country = rdr["country"].ToString();
				cSupp.Email= rdr["email"].ToString();
				cSupp.Telephone = rdr["telephone"].ToString();
				cSupp.Mobile = rdr["mobile"].ToString();

				sup.Add(cSupp);
			}

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			return sup;
		}

		public cContacts get_Comp_Contacts(string con, string comp)
		{
			cContacts Conts = new cContacts();
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_Company_Contacts";

			cmd.Parameters.Add(
				new SqlParameter("@comp_id", comp));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				cContact ct = new cContact();
				ct.Contact_ID = rdr["contact_id"].ToString();
				ct.Contact_Name = rdr["cname"].ToString();
				Conts.Add(ct);
			}

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			return Conts;
		}

		public cContacts get_Prop_Contacts(string con, string prop)
		{
			cContacts Conts = new cContacts();
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_property_Contacts";

			cmd.Parameters.Add(
				new SqlParameter("@prop_id", prop));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				cContact ct = new cContact();
				ct.Contact_ID = rdr["contact_id"].ToString();
				ct.Contact_Name = rdr["cname"].ToString();
				Conts.Add(ct);
			}
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			return Conts;
		}

		public bool valid_user(Camelot.classes.cUser luser)
		{
			if(luser.ID!=0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public Invoice_Items get_Invoice_Items(string con, string inv)
		{
			Invoice_Items invs = new Invoice_Items();
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_Invoice_Items";

			cmd.Parameters.Add(
				new SqlParameter("@inv_id", inv));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				cInvoice_Item iv = new cInvoice_Item();
				iv.Item_ID = rdr["item_id"].ToString();
				iv.Description = rdr["description"].ToString();
				iv.Amount = rdr["amount"].ToString();
				iv.VAT = rdr["vat"].ToString();
				invs.Add(iv);
			}

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			return invs;
		}

		public Inv_Periods get_Invoice_Periods(string con)
		{
			Inv_Periods invps = new Inv_Periods();
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Get_Invoice_Periods";

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				Inv_Period iv = new Inv_Period();
				iv.ID = rdr["overdue_id"].ToString();
				iv.Description = rdr["description"].ToString();
				iv.Period = rdr["period"].ToString();
				invps.Add(iv);
			}

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			return invps;
		}

		public void delete_files()
		{
			DirectoryInfo mrg = new DirectoryInfo("c:\\inetpub\\wwwroot\\camelot_crm\\mergedocs");
			if(mrg.Exists)
			{
				foreach(FileInfo f in mrg.GetFiles())
				{
					if(DateDiff(DateInterval.Hour,f.LastWriteTime,DateTime.Now)> 2)
					{
						f.Delete();
					}
				}
			}

			DirectoryInfo man = new DirectoryInfo("c:\\inetpub\\wwwroot\\camelot_crm\\man_reports");
			if(man.Exists)
			{
				foreach(FileInfo f in man.GetFiles())
				{
					if(DateDiff(DateInterval.Hour,f.LastWriteTime,DateTime.Now)> 2)
					{
						f.Delete();
					}
				}
			}

			DirectoryInfo photo = new DirectoryInfo("c:\\inetpub\\wwwroot\\camelot_crm\\photos");
			if(photo.Exists)
			{
				foreach(FileInfo f in photo.GetFiles())
				{
					if(DateDiff(DateInterval.Hour,f.LastWriteTime,DateTime.Now)> 2)
					{
						f.Delete();
					}
				}
			}

			DirectoryInfo email = new DirectoryInfo("c:\\inetpub\\wwwroot\\camelot_crm\\email");
			if(email.Exists)
			{
				foreach(FileInfo f in email.GetFiles())
				{
					if(DateDiff(DateInterval.Hour,f.LastWriteTime,DateTime.Now)> 2)
					{
						f.Delete();
					}
				}
				foreach(DirectoryInfo d in email.GetDirectories())
				{
					if(DateDiff(DateInterval.Hour,d.LastWriteTime,DateTime.Now)> 2)
					{
						d.Delete(true);
					}
				}
			}

			DirectoryInfo scans = new DirectoryInfo("c:\\inetpub\\wwwroot\\camelot_crm\\scans");
			if(scans.Exists)
			{
				foreach(FileInfo f in scans.GetFiles())
				{
					if(DateDiff(DateInterval.Hour,f.LastWriteTime,DateTime.Now)> 2)
					{
						f.Delete();
					}
				}
			}

			DirectoryInfo upload = new DirectoryInfo("c:\\inetpub\\wwwroot\\camelot_crm\\upload");
			if(upload.Exists)
			{
				foreach(FileInfo f in upload.GetFiles())
				{
					if(DateDiff(DateInterval.Hour,f.LastWriteTime,DateTime.Now)> 2)
					{
						f.Delete();
					}
				}
			}


		}

		public static long DateDiff(DateInterval Interval, System.DateTime StartDate, System.DateTime EndDate )
		{
			long lngDateDiffValue = 0;
			System.TimeSpan TS = new System.TimeSpan(EndDate.Ticks - StartDate.Ticks);
			switch (Interval)
			{
				case DateInterval.Day:
					lngDateDiffValue = (long) TS.Days;
					break;
				case DateInterval.Hour:
					lngDateDiffValue = (long)TS.TotalHours;
					break;
				case DateInterval.Minute:
					lngDateDiffValue = (long) TS.TotalMinutes;
					break;
				case DateInterval.Month:
					lngDateDiffValue = (long)( TS.Days / 30);
					break;
				case DateInterval.Quarter:
					lngDateDiffValue = (long)( (TS.Days / 30) / 3 );
					break;
				case DateInterval.Second:
					lngDateDiffValue = (long) TS.TotalSeconds;
					break;
				case DateInterval.Week:
					lngDateDiffValue = (long)( TS.Days / 7);
					break;
				case DateInterval.Year:
					lngDateDiffValue = (long)( TS.Days / 365);
					break;
			}
			return (lngDateDiffValue);
		}
	}
}
