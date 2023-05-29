using System;
using System.Data.SqlClient;
using System.Data;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for del_cont.
	/// </summary>
	public class del_cont
	{
		private string pCont;
		private string pCon;


		public string Con
		{
			get
			{
				return pCon;
			}
			set
			{
				pCon = value;
			}
		}

		public string Cont_ID
		{
			get
			{
				return pCont;
			}
			set
			{
				pCont = value;
			}
		}

		public void del_contact()
		{
			delete_corr();
		}

		private void delete_corr()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			
			conn.ConnectionString = this.Con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "del_cont_corr";

			cmd.Parameters.Add(
				new SqlParameter("@cont", this.Cont_ID));

			cmd.ExecuteNonQuery();

		}
	}
}
