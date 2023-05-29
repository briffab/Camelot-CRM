
using System.Reflection; // For Missing.Value and BindingFlags
using System.Runtime.InteropServices; // For COMException
//using Excel;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using Camelot.classes;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


namespace Camelot.classes
{
	/// <summary>
	/// Summary description for AutoExcel.
	/// </summary>
	/// 
	

	public class AutoExcel : System.Web.UI.Page
	{
		/*enum cells : int
		{
			cWeight = 3
		}
		
		private const int MAX_ARRAY_SIZE = 5460;
		private const string FONT_DEFAULT_NAME = "Arial";
		private const int FONT_DEFAULT_SIZE = 10;
		private const int MAX_REPORT_WIDTH = 133;
		private object m_objOpt = System.Reflection.Missing.Value;


	
		public AutoExcel()
		{
		}

		public string genRep(string proc, string repid, string from, string to, string con)
		{
		string camrep = "";
			string camreppath = "";
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = proc;

			cmd.Parameters.Add(
				new SqlParameter("@rep", repid));
			cmd.Parameters.Add(
				new SqlParameter("@from", from));
			cmd.Parameters.Add(
				new SqlParameter("@to", to));

			rdr = cmd.ExecuteReader();

			if(rdr.HasRows)
			{	
				camrep = "cam_" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + ".xls";
				DirectoryInfo dir = new DirectoryInfo(Server.MapPath("\\camelot_crm\\reports\\"));
				
				FileInfo[] reps = dir.GetFiles("*.xls");
				foreach(FileInfo f in reps)
				{
					if(f.CreationTime < DateTime.Now.Subtract(System.TimeSpan.FromDays(4)))
					{
						File.Delete(f.FullName);
					}
				}
				GC.Collect();
				System.Globalization.CultureInfo oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
				System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

				Excel.Application exc = new Excel.ApplicationClass();

				exc.Visible= false; 
				Workbooks workbooks = exc.Workbooks;
				Workbook workbook = workbooks.Add(m_objOpt);
				Sheets sheets = workbook.Worksheets;

				Worksheet wsht = (Worksheet) sheets.get_Item(1);

				putData(wsht, rdr);
				doColumns(wsht,repid,con);
				doHeaders(wsht,repid,con);

				camreppath = Server.MapPath("\\camelot_crm\\reports\\") + camrep;
				workbook.SaveAs(camreppath, m_objOpt, m_objOpt, m_objOpt,m_objOpt,m_objOpt,Excel.XlSaveAsAccessMode.xlNoChange,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt);
				workbook.Close(false,m_objOpt,m_objOpt);
				workbooks.Close();
				exc.Quit();
				System.Runtime.InteropServices.Marshal.ReleaseComObject (wsht);
				System.Runtime.InteropServices.Marshal.ReleaseComObject (workbook);
				System.Runtime.InteropServices.Marshal.ReleaseComObject (workbooks);
				System.Runtime.InteropServices.Marshal.ReleaseComObject (exc);
				wsht=null;
				workbooks=null;
				workbook = null;
				exc = null;
				GC.Collect();
				rdr.Close();
				cmd.Dispose();
				conn.Dispose();
				conn.Close();
				System.Threading.Thread.CurrentThread.CurrentCulture = oldCI;
				return camreppath;
			}
			else
			{
				rdr.Close();
				cmd.Dispose();
				conn.Dispose();
				conn.Close();
				return "0";
			}

			
		}

		private void putData(Worksheet sht, SqlDataReader rdr)
		{
			int nFields = rdr.FieldCount;
			int iRow = 1;
			
			while(rdr.Read())
			{
				for(int i=4;i<nFields;i++)
				{
					sht.Cells[iRow,i-3] = rdr.GetValue(i).ToString();
					Excel.Range currentCell = (Excel.Range)sht.Cells[iRow,i-3];
					if(rdr.GetValue(2).ToString() == "1")
					{
						currentCell.Font.Bold=true;
					}
					else
					{
						
						currentCell.Font.Bold=false;

					}
					System.Runtime.InteropServices.Marshal.ReleaseComObject(currentCell);
				}
				iRow++;
			}
			sht.Cells.Replace("#","",m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt,m_objOpt);
			//sht.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
			GC.Collect();
		}

		private void doColumns(Worksheet sht, string repID, string con)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "rpt_cols";

			cmd.Parameters.Add(
				new SqlParameter("@rep", repID));
			
			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				((Excel.Range)sht.Cells[1,Convert.ToInt32(rdr.GetValue(1))]).EntireColumn.ColumnWidth = Convert.ToInt32(rdr.GetValue(2));
			}
		}

		private void doHeaders(Worksheet sht, string repID, string con)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			conn.ConnectionString = con;
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "rpt_hdrs";
			string s_col="";
			string f_col="";
			int bord = 0;


			cmd.Parameters.Add(
				new SqlParameter("@rep", repID));
			
			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				s_col=Convert.ToString(rdr.GetValue(0));
				f_col=Convert.ToString(rdr.GetValue(8));
				bord = Convert.ToInt32(rdr.GetValue(2));
				if(string.Compare(f_col,s_col)>0)
				{
					Excel.Range rng = sht.get_Range(s_col, f_col);
					rng.Merge(m_objOpt);
					rng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
					System.Runtime.InteropServices.Marshal.ReleaseComObject(rng);
				}
				if(bord > 0)
				{
					Excel.Range rng = sht.get_Range(s_col, f_col);
					rng.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous;
					rng.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).Weight = Excel.XlBorderWeight.xlThin;
					rng.WrapText=true;
					System.Runtime.InteropServices.Marshal.ReleaseComObject(rng);
				}
				GC.Collect();
			}
		}*/
	}
}
