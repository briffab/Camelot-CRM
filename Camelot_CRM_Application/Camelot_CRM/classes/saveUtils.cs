using System;
using System.Globalization;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for saveUtils.
	/// </summary>
	public class saveUtils
	{
		public bool IsDate(object dt)
		{
			try
			{
				System.DateTime.Parse(dt.ToString());
				if(System.DateTime.Parse(dt.ToString()) < System.DateTime.Parse("01/01/1900"))
				{
					return false;
				}
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool IsNumber(object dt)
		{
			try
			{
				System.Decimal.Parse(dt.ToString());
				return true;
			}
			catch
			{
				return false;
			}
		}

		public string setdate(string dt)
		{
			string rdt;
			if(dt=="")
			{
				rdt="01/01/1900";
			}
			else
			{
				string oyr = "20";
				string yyr = "19";
				string ayr = dt.Substring(0,dt.LastIndexOf("/")+1);
				string byr = dt.Substring(dt.LastIndexOf("/")+1,dt.Length-(dt.LastIndexOf("/")+1));
				if (byr.Length ==2)
				{
					if(Convert.ToInt32(byr)<=35)
					{
						ayr = ayr +oyr+byr;
					}
					else
					{
						ayr = ayr +yyr+byr;
					}
				}
				else
				{
					ayr = dt;
				}
				rdt=ayr;
			}
			return rdt;	  
		}

		public string getdate(string dt)
		{
			string rdt;
			if(dt=="01/01/1900")
			{
				rdt="";
			}
			else
			{
				rdt=dt;
			}
			return rdt;
		}

		public int getCheck(bool chk)
		{
			if(chk)
			{
				return 1;
			}
			else
			{
				return 0;
			}
		}

		public string ToTitle(string str)
		{
			TextInfo txt = new CultureInfo("en-US",false).TextInfo;
			return txt.ToTitleCase(str);
		}

		public string ToUpper(string str)
		{
			TextInfo txt = new CultureInfo("en-US",false).TextInfo;
			return txt.ToUpper(str);
		}
	
		public bool checkcomp(String comp, String pcode, String con)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			int count = 0;
			bool comps = false;

			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "check_company";

			cmd.Parameters.Add(
				new SqlParameter("@comp", comp));
			cmd.Parameters.Add(
				new SqlParameter("@post", pcode));

			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				count = Convert.ToInt32(rdr["count"].ToString());
			}

			if(count > 0)
			{
				comps = true;
			}

			return comps;
		}

		public string setMoney(string mny)
		{
			StringBuilder cmny = new StringBuilder(mny);

			cmny.Replace(",",".");

			return cmny.ToString();
		}
	
	}



}
