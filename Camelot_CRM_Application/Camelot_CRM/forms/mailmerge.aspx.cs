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
using cc = Camelot.classes;
using System.Data.SqlClient;
using System.IO;
using mw = Microsoft.Office.Interop.Word;
using System.Threading;
using System.Text;

namespace Camelot.forms
{
	/// <summary>
	/// Summary description for mailmerge.
	/// </summary>
	public class mailmerge : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblDocName;
		protected System.Web.UI.WebControls.Label lblDoc;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label lblRecs;
		protected System.Web.UI.WebControls.Label lblnrecs;
		protected System.Web.UI.WebControls.TextBox txtMerge1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtMerge2;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtMerge3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtMerge4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtMerge5;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtMerge6;
		protected System.Web.UI.WebControls.Button btnMerge;
		protected System.Web.UI.WebControls.Button btnCancel;

		string csvfile = "";
		string wordfile="";
		string whfile = "";
		string whdfile = "";
		string ex = "";
		string doc_id = "";
		string rec_type = "";
		private cc.cUser pUser;
		ArrayList rec = new ArrayList();
		string prop="";
		
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			bool oktogo;
			Camelot.classes.Utils pUtil = new Camelot.classes.Utils();
			pUser = (Camelot.classes.cUser)Session["curUser"];
			oktogo = pUtil.valid_user(pUser);

			if(!oktogo)
			{
				Response.Redirect("../logon.aspx");
			}
			else
			{
				if(!Page.IsPostBack)
				{
					rec = (ArrayList)Session["cRecip"];
					Session["mergeRec"] = rec;
					doc_id = Request.QueryString["doc_id"];
					rec_type = Request.QueryString["recip_type"];
					Session["rec_type"] = rec_type;
					Session["doc_id"] = doc_id;
					prop = Request.QueryString["prop"];
					Session["mergeprop"] = prop;
					get_files();
				}
				wordfile=Session["wordfile"].ToString();
				csvfile=Session["csvfile"].ToString();
				whfile=Session["whfile"].ToString();
				whdfile=Session["whdfile"].ToString();
				doc_id = Session["doc_id"].ToString();
				rec_type = Session["rec_type"].ToString();
				rec = (ArrayList)Session["mergeRec"];
				prop = Session["mergeprop"].ToString();
			}
		}

		private void get_files()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.saveUtils us = new Camelot.classes.saveUtils();
			string docname = "";

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_merge_doc";

			cmd.Parameters.Add(
				new SqlParameter("@doc_id", doc_id));

			rdr = cmd.ExecuteReader();
	
			while(rdr.Read())
			{
				docname = rdr["doc_name"].ToString();
				ex = System.DateTime.Now.Hour.ToString() + "_" + System.DateTime.Now.Minute.ToString() + "_" + System.DateTime.Now.Second.ToString() + "_" + System.DateTime.Now.Day.ToString() + "_" + System.DateTime.Now.Month.ToString() + "_" + System.DateTime.Now.Year.ToString() + "_" + rdr["doc_name"].ToString();
				byte[] mdoc= new byte[0];
				mdoc =  (byte[])rdr["document"];
				wordfile = "c:\\inetpub\\wwwroot\\camelot_crm\\\\mergedocs\\\\" + ex;		
				FileStream fs = new FileStream(wordfile, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write, System.IO.FileShare.ReadWrite);
				fs.Write(mdoc,0,(int)rdr["filesize"]);
				fs.Close();
			}

			whfile = "http://ntsbs01/camelot_crm/mergedocs/final" + ex;
			whdfile= "c:\\inetpub\\wwwroot\\camelot_crm\\\\mergedocs\\\\final" + ex;
			csvfile = "c:\\inetpub\\wwwroot\\camelot_crm\\\\mergedocs\\\\" + ex.Substring(0,ex.Length-4) + "data.csv";
			
			Session["wordfile"]=wordfile;
			Session["csvfile"] = csvfile;
			Session["whfile"] = whfile;
			Session["whdfile"] = whdfile;
			
			this.lblDoc.Text = docname;
			this.lblnrecs.Text = rec.Count.ToString();

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
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
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			if (System.IO.File.Exists(wordfile))
			{
				System.IO.File.Delete(wordfile);
			}
			if (System.IO.File.Exists(csvfile))
			{
				System.IO.File.Delete(csvfile);
			}
			if (System.IO.File.Exists(whfile))
			{
				System.IO.File.Delete(whfile);
			}
			Response.Write("<script>window.close();</script>");
		}

		private string getCSVFields()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.saveUtils us = new Camelot.classes.saveUtils();

			string fields = "";

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_merge_fields";

			rdr = cmd.ExecuteReader();
	
			while(rdr.Read())
			{
				fields = fields + rdr.GetValue(0).ToString() + ",";
			}

			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

			return fields.Substring(0,fields.Length-1);
		}


		private void btnMerge_Click(object sender, System.EventArgs e)
		{
			bool ok = true;
			
			createcsv();

			ok = mergedoc();
			if(ok)
			{
				Response.Write("<script>window.open('" + whfile + "');</script>");			
			}

			if (System.IO.File.Exists(csvfile))
			{
				System.IO.File.Delete(csvfile);
			}
			if (System.IO.File.Exists(whfile))
			{
				System.IO.File.Delete(whfile);
			}
		}

		private void NAR(object o)
		{
			try 
			{
				System.Runtime.InteropServices.Marshal.ReleaseComObject(o);
			}
			catch {}
			finally 
			{
				o = null;
			}
		}


		private bool mergedoc()
		{
			Object oMissing = System.Reflection.Missing.Value;
			object oFalse = false;
			object wdFile = wordfile;
			object wdCSV = csvfile;
			object format = Microsoft.Office.Interop.Word.WdOpenFormat.wdOpenFormatText;
			object oOutFileName = whdfile;
			
			mw.Application wrdApp = new mw.Application();
			mw.Documents wrdDocs = wrdApp.Documents;
			object saveChanges = mw.WdSaveOptions.wdDoNotSaveChanges;

			try
			{		
				wrdApp.DisplayAlerts=mw.WdAlertLevel.wdAlertsNone;
				mw.Document wrdDoc = wrdDocs.Open(ref wdFile,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing);
				mw.MailMerge wrdMail = wrdDoc.MailMerge;
				wrdMail.OpenDataSource(csvfile,ref format,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing);
				wrdMail.Destination = Microsoft.Office.Interop.Word.WdMailMergeDestination.wdSendToNewDocument;
				wrdMail.Execute(ref oMissing);
				wrdApp.ActiveDocument.SaveAs(ref oOutFileName, ref oMissing, ref oMissing, 
					ref oMissing, ref oMissing, ref oMissing, ref oMissing,
					ref oMissing,  ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

				NAR(wrdMail);
				wrdMail = null;
				wrdDoc.Close(ref saveChanges,ref oMissing,ref oMissing);
				NAR(wrdDoc);
				wrdDoc = null;
				foreach(mw.Document wd in wrdApp.Documents)
				{
					wd.Close(ref saveChanges, ref oMissing, ref oMissing);
				}
				
				//wrdDocs.Close(ref saveChanges,ref oMissing,ref oMissing);
				NAR(wrdDocs);
				wrdDocs=null;
				wrdApp.Quit(ref saveChanges,ref oMissing,ref oMissing);
				NAR(wrdApp);
				wrdApp = null;
				GC.Collect();
				GC.WaitForPendingFinalizers();

				GC.Collect();
				GC.WaitForPendingFinalizers();
				save_corr_and_recips();
				
				return true;

			}
			catch(Exception ex)
			{
				//wrdApp.Documents.Close(ref oFalse, ref oMissing, ref oMissing);
				/*if(wrdDoc != null)
				{
					wrdDoc.Close(ref oMissing,ref oMissing,ref oMissing);
					NAR(wrdDoc);
					wrdDoc = null;
				}*/
				foreach(mw.Document wd in wrdApp.Documents)
				{
					wd.Close(ref saveChanges, ref oMissing, ref oMissing);
				}
				if(wrdDocs!=null)
				{
					NAR(wrdDocs);
					wrdDocs=null;
				}
				if(wrdApp != null)
				{
					wrdApp.Quit(ref oMissing,ref oMissing,ref oMissing);
					NAR(wrdApp);
					wrdApp = null;
				}
				GC.Collect();
				GC.WaitForPendingFinalizers();

				GC.Collect();
				GC.WaitForPendingFinalizers();
				return false;

			}
		}

		private void save_corr_and_recips()
		{
			int corr_id;
			int doc_id;
			corr_id = save_corr();
			doc_id = save_doc();
			save_doc_recip(doc_id);
			save_corr_doc(doc_id, corr_id);

		}

		private int save_corr()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			int bulk = 0;
			int corr_id =0;

			if(this.rec.Count !=1)
			{
				bulk = 1;
			}
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "insert_correspondence";

			cmd.Parameters.Add(
				new SqlParameter("@C_TYPE", "2"));
			cmd.Parameters.Add(
				new SqlParameter("@target", this.rec_type));
			cmd.Parameters.Add(
				new SqlParameter("@PROP_id", prop));
			cmd.Parameters.Add(
				new SqlParameter("@COMP_id", "0"));
			cmd.Parameters.Add(
				new SqlParameter("@bulk", bulk));
			cmd.Parameters.Add(
				new SqlParameter("@dir", "1"));
			cmd.Parameters.Add(
				new SqlParameter("@sender", pUser.Name));

			rdr = cmd.ExecuteReader();
			while(rdr.Read())
			{
				corr_id = Convert.ToInt32(rdr.GetValue(0));
			}

			return corr_id;

		}

		private void save_doc_recip(int doc)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
	
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "insert_document_recipient";

			foreach(string recip in rec)
			{
				cmd.Parameters.Clear();
				cmd.Parameters.Add(
					new SqlParameter("@doc_id", doc));
				cmd.Parameters.Add(
					new SqlParameter("@recip", recip));

				cmd.ExecuteNonQuery();
			}
		}

		private void save_corr_doc(int doc, int corr)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
	
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "insert_correspondence_document";

			cmd.Parameters.Add(
				new SqlParameter("@doc_id", doc));
			cmd.Parameters.Add(
				new SqlParameter("@corr", corr));

			cmd.ExecuteNonQuery();

		}

		private int save_doc()
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			int doc_id =0;
			int fsize;
			FileInfo ifile = new FileInfo(whdfile);
			FileStream final = ifile.OpenRead();
			fsize = Convert.ToInt32(ifile.Length);
			byte[] bfinal = new byte[fsize];
			final.Read(bfinal,0,fsize);
			string strFilename = Path.GetFileName(ifile.Name);

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "insert_corr_doc";

			cmd.Parameters.Add(
				new SqlParameter("@MERGE_FILE", bfinal));

			cmd.Parameters.Add(
				new SqlParameter("@FILESIZE",fsize));

			cmd.Parameters.Add(
				new SqlParameter("@FILENAME",strFilename));

			rdr = cmd.ExecuteReader();
			while(rdr.Read())
			{
				doc_id = Convert.ToInt32(rdr.GetValue(0));
			}

			return doc_id;

		}

		private void createcsv()
		{
			string csv = "";
			ArrayList gds =  new ArrayList();
			//StreamWriter mfile = null;
			csv = getCSVFields();
			StreamWriter mfile = new StreamWriter(csvfile);
			
//			try
//			{
				
				mfile.WriteLine(csv);
				if(rec_type=="1")
				{
					gds = fillguardcsv();
					foreach(string gd in gds)
					{
						mfile.WriteLine(gd);
					}
				}
				else
				{
					gds = fillcontcsv();
					foreach(string gd in gds)
					{
						mfile.WriteLine(gd);
					}
				}

				mfile.Close();
//			}
//			catch(Exception ex)
//			{
//				Response.Write(ex.Message);
//				mfile.Close();
//			}
			
		}

		private ArrayList fillguardcsv()
		{
			string guards = "";
			string grec="";
			ArrayList gds = new ArrayList();
			int cnt = 1;
			string conts1 = "";
			string conts2 = "";
			string conts3 = "";
			string conts4 = "";
			string conts5 = "";
			string conts6 = "";
			string conts7 = "";
			string conts8 = "";
			string conts9 = "";
			string conts10 = "";
			string conts11 = "";
			string conts12 = "";

			foreach(string em in rec)
			{
				if(guards.Length + em.Length + 1 > 7990)
				{
					switch(cnt)
					{
						case 1:
							conts1 = guards;
							break;
						case 2:
							conts2 = guards;
							break;
						case 3:
							conts3 = guards;
							break;
						case 4:
							conts4 = guards;
							break;
						case 5:
							conts5 = guards;
							break;
						case 6:
							conts6 = guards;
							break;
						case 7:
							conts7 = guards;
							break;
						case 8:
							conts8 = guards;
							break;
						case 9:
							conts9 = guards;
							break;
						case 10:
							conts10 = guards;
							break;
						case 11:
							conts11 = guards;
							break;
						case 12:
							conts12 = guards;
							break;
					}
					guards = "";
					cnt++;
				}
				else
				{
					guards = guards + em + ",";
				}
			}
			guards = guards.Substring(0,guards.Length-1);
			switch(cnt)
			{
				case 1:
					conts1 = guards;
					break;
				case 2:
					conts2 = guards;
					break;
				case 3:
					conts3 = guards;
					break;
				case 4:
					conts4 = guards;
					break;
				case 5:
					conts5 = guards;
					break;
				case 6:
					conts6 = guards;
					break;
				case 7:
					conts7 = guards;
					break;
				case 8:
					conts8 = guards;
					break;
				case 9:
					conts9 = guards;
					break;
				case 10:
					conts10 = guards;
					break;
				case 11:
					conts11 = guards;
					break;
				case 12:
					conts12 = guards;
					break;
			}

			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			cmd.CommandTimeout = 600;
			
			try
			{
				conn.ConnectionString = (string)Session["Connection"];
				conn.Open();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "get_merge_guards";

				cmd.Parameters.Add("@conts1", System.Data.SqlDbType.VarChar);
				cmd.Parameters["@conts1"].Value = conts1;
				cmd.Parameters.Add("@conts2", System.Data.SqlDbType.VarChar);
				cmd.Parameters["@conts2"].Value = conts2;
				cmd.Parameters.Add("@conts3", System.Data.SqlDbType.VarChar);
				cmd.Parameters["@conts3"].Value = conts3;
				cmd.Parameters.Add("@conts4", System.Data.SqlDbType.VarChar);
				cmd.Parameters["@conts4"].Value = conts4;
				cmd.Parameters.Add("@conts5", System.Data.SqlDbType.VarChar);
				cmd.Parameters["@conts5"].Value = conts5;
				cmd.Parameters.Add("@conts6", System.Data.SqlDbType.VarChar);
				cmd.Parameters["@conts6"].Value = conts6;
				cmd.Parameters.Add("@conts7", System.Data.SqlDbType.VarChar);
				cmd.Parameters["@conts7"].Value = conts7;
				cmd.Parameters.Add("@conts8", System.Data.SqlDbType.VarChar);
				cmd.Parameters["@conts8"].Value = conts8;
				cmd.Parameters.Add("@conts9", System.Data.SqlDbType.VarChar);
				cmd.Parameters["@conts9"].Value = conts9;
				cmd.Parameters.Add("@conts10", System.Data.SqlDbType.VarChar);
				cmd.Parameters["@conts10"].Value = conts10;
				cmd.Parameters.Add("@conts11", System.Data.SqlDbType.VarChar);
				cmd.Parameters["@conts11"].Value = conts11;
				cmd.Parameters.Add("@conts12", System.Data.SqlDbType.VarChar);
				cmd.Parameters["@conts12"].Value = conts12;
				cmd.Parameters.Add("@emp", System.Data.SqlDbType.Int);
				cmd.Parameters["@emp"].Value = pUser.ID ;
		
				rdr = cmd.ExecuteReader();
				while(rdr.Read())
				{
					grec = rdr["lastname"].ToString().Replace(","," ") + "," + rdr["firstname"].ToString().Replace(","," ") + ",,,,";
					grec=grec + rdr["object_name"].ToString().Replace(","," ") + ",," + rdr["housename"].ToString().Replace(","," ") + "," + rdr["housenumber"].ToString().Replace(","," ") + "," + rdr["streetname"].ToString().Replace(","," ") + ",," + rdr["city"].ToString().Replace(","," ") + "," + rdr["county"].ToString().Replace(","," ") + "," + rdr["postalcode"].ToString().Replace(","," ") + ",";
					grec = grec + rdr["signature"].ToString().Replace(","," ") + "," + this.txtMerge1.Text.Replace(","," ") + "," + this.txtMerge2.Text.Replace(","," ") + "," + this.txtMerge3.Text.Replace(","," ") + "," + this.txtMerge4.Text.Replace(","," ") + "," + this.txtMerge5.Text.Replace(","," ") + "," + this.txtMerge6.Text.Replace(","," ") + "," + rdr["sigtitle"].ToString().Replace(","," ")+ "," + rdr["sigemail"].ToString().Replace(","," ") + ",";
					
					grec = grec.Replace("\r"," ");
					grec = grec.Replace("\n"," ");
					grec = grec + "\r";
					gds.Add(grec);
				}

				return gds;
			}
			catch(Exception e)
			{
				Response.Write(e.Message);
				return null;
			}
		}

		private ArrayList fillcontcsv()
		{
			string guards = "";
			string grec="";
			int cnt = 1;
			string conts1 = "";
			string conts2 = "";
			string conts3 = "";
			string conts4 = "";
			string conts5 = "";
			string conts6 = "";
			string conts7 = "";
			string conts8 = "";
			string conts9 = "";
			string conts10 = "";
			string conts11 = "";
			string conts12 = "";

			ArrayList gds = new ArrayList();
			foreach(string em in rec)
			{
				if(guards.Length + em.Length + 1 > 7990)
				{
					switch(cnt)
					{
						case 1:
							conts1 = guards;
							break;
						case 2:
							conts2 = guards;
							break;
						case 3:
							conts3 = guards;
							break;
						case 4:
							conts4 = guards;
							break;
						case 5:
							conts5 = guards;
							break;
						case 6:
							conts6 = guards;
							break;
						case 7:
							conts7 = guards;
							break;
						case 8:
							conts8 = guards;
							break;
						case 9:
							conts9 = guards;
							break;
						case 10:
							conts10 = guards;
							break;
						case 11:
							conts11 = guards;
							break;
						case 12:
							conts12 = guards;
							break;
					}
					guards = "";
					cnt++;
				}
				else
				{
					guards = guards + em + ",";
				}
			}
			guards = guards.Substring(0,guards.Length-1);
			switch(cnt)
			{
				case 1:
					conts1 = guards;
					break;
				case 2:
					conts2 = guards;
					break;
				case 3:
					conts3 = guards;
					break;
				case 4:
					conts4 = guards;
					break;
				case 5:
					conts5 = guards;
					break;
				case 6:
					conts6 = guards;
					break;
				case 7:
					conts7 = guards;
					break;
				case 8:
					conts8 = guards;
					break;
				case 9:
					conts9 = guards;
					break;
				case 10:
					conts10 = guards;
					break;
				case 11:
					conts11 = guards;
					break;
				case 12:
					conts12 = guards;
					break;
			}

			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			cmd.CommandTimeout = 600;
			
			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_merge_contacts";

			cmd.Parameters.Add("@conts1", System.Data.SqlDbType.VarChar);
			cmd.Parameters["@conts1"].Value = conts1;
			cmd.Parameters.Add("@conts2", System.Data.SqlDbType.VarChar);
			cmd.Parameters["@conts2"].Value = conts2;
			cmd.Parameters.Add("@conts3", System.Data.SqlDbType.VarChar);
			cmd.Parameters["@conts3"].Value = conts3;
			cmd.Parameters.Add("@conts4", System.Data.SqlDbType.VarChar);
			cmd.Parameters["@conts4"].Value = conts4;
			cmd.Parameters.Add("@conts5", System.Data.SqlDbType.VarChar);
			cmd.Parameters["@conts5"].Value = conts5;
			cmd.Parameters.Add("@conts6", System.Data.SqlDbType.VarChar);
			cmd.Parameters["@conts6"].Value = conts6;
			cmd.Parameters.Add("@conts7", System.Data.SqlDbType.VarChar);
			cmd.Parameters["@conts7"].Value = conts7;
			cmd.Parameters.Add("@conts8", System.Data.SqlDbType.VarChar);
			cmd.Parameters["@conts8"].Value = conts8;
			cmd.Parameters.Add("@conts9", System.Data.SqlDbType.VarChar);
			cmd.Parameters["@conts9"].Value = conts9;
			cmd.Parameters.Add("@conts10", System.Data.SqlDbType.VarChar);
			cmd.Parameters["@conts10"].Value = conts10;
			cmd.Parameters.Add("@conts11", System.Data.SqlDbType.VarChar);
			cmd.Parameters["@conts11"].Value = conts11;
			cmd.Parameters.Add("@conts12", System.Data.SqlDbType.VarChar);
			cmd.Parameters["@conts12"].Value = conts12;
			cmd.Parameters.Add("@emp", System.Data.SqlDbType.Int);
			cmd.Parameters["@emp"].Value = pUser.ID ;
			cmd.Parameters.Add("@prop_id", System.Data.SqlDbType.Int);
			cmd.Parameters["@prop_id"].Value = prop;
		
			rdr = cmd.ExecuteReader();
			while(rdr.Read())
			{
				grec = rdr["lastname"].ToString().Replace(","," ") + "," + rdr["firstname"].ToString().Replace(","," ") + "," + rdr["title"].ToString().Replace(","," ") + ",," + rdr["job_title"].ToString().Replace(","," ") + "," + rdr["object_name"].ToString().Replace(",",",") + ",";
				grec=grec + rdr["company"].ToString().Replace(","," ") + "," + rdr["housename"].ToString().Replace(","," ") + "," + rdr["housenumber"].ToString().Replace(","," ") + "," + rdr["streetname"].ToString().Replace(","," ") + ",," + rdr["city"].ToString().Replace(","," ") + "," + rdr["county"].ToString().Replace(","," ") + "," + rdr["postalcode"].ToString().Replace(","," ") + ",";
				grec = grec + rdr["signature"].ToString().Replace(","," ") + "," + this.txtMerge1.Text.Replace(","," ") + "," + this.txtMerge2.Text.Replace(","," ") + "," + this.txtMerge3.Text.Replace(","," ") + "," + this.txtMerge4.Text.Replace(","," ") + "," + this.txtMerge5.Text.Replace(","," ") + "," + this.txtMerge6.Text.Replace(","," ") + "," + rdr["sigtitle"].ToString().Replace(","," ")+ "," + rdr["sigemail"].ToString().Replace(","," ") + "," + rdr["salutation"].ToString().Replace(","," ");

				grec = grec.Replace("\r"," ");
				grec = grec.Replace("\n"," ");
				grec = grec + "\r";
				gds.Add(grec);
			}
			return gds;			
		}

		private void OpenProgressBar()
		{
			Response.Write("<script>window.showModalDialog('progress.aspx','','dialogHeight: 100px; dialogWidth: 350px; edge: Raised; center: Yes; help: No; resizable: No; status: No;scroll:No;');</script>");
		}
	}

}
