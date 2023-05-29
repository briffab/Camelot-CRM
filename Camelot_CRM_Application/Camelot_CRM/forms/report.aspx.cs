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
	/// Summary description for report.
	/// </summary>
	public class report : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblMes;
		protected System.Web.UI.WebControls.Button btnClose;

		Camelot.classes.cUser pUser;

		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			bool oktogo;
			string repname = "";
			Camelot.classes.Utils pUtil = new Camelot.classes.Utils();
			//Camelot.classes.AutoExcel ae = new AutoExcel();
			pUser = (Camelot.classes.cUser)Session["curUser"];
			oktogo = pUtil.valid_user(pUser);

			if(!oktogo)
			{
				Response.Redirect("../logon.aspx");
			}
			else
			{
				string repProc = Request.QueryString["repProc"];
				string repProcID = Request.QueryString["repProcID"];
				string from = Request.QueryString["from"];
				string to = Request.QueryString["to"];


	//			repname = ae.genRep(repProc, repProcID, from, to, (string)Session["Connection"]);
				if(repname != "0")
				{
					Response.Redirect(repname);
				}
				else
				{
					lblMes.Text = "No Data Found";
				}
			}
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
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.close();</script>");
		}
	}
}
