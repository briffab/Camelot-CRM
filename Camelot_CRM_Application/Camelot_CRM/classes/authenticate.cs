using System;
using System.Data;
using System.Data.SqlClient;


namespace Camelot.classes
{
	/// <summary>
	/// Summary description for athenticate.
	/// </summary>
	public class authenticate
	{
		public cLogins auth_logon(string user, string pass, string con)
		{
			cLogins alogins = new cLogins();
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;

			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Auth_User";

			cmd.Parameters.Add(
				new SqlParameter("@user", user));
			cmd.Parameters.Add(
				new SqlParameter("@pass", pass));


			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				cLogin alogin = new cLogin();
				alogin.ID = (int)rdr["id"];
				if(alogin.ID > 0)
				{
					alogin.Database = (string)rdr["database_name"];
					alogin.ConnString = (string)rdr["connection_string"];
				}
				else
				{
					alogin.Uname=(string)rdr["name"];
				}
				alogins.Add(alogin);
			}
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			return alogins;
		}
	}
}
