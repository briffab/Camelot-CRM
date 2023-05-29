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

namespace Camelot.forms
{
	/// <summary>
	/// Summary description for progress.
	/// </summary>
	public class progress : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblMessages;
		protected System.Web.UI.WebControls.Panel panelProgress;
		protected System.Web.UI.WebControls.Panel panelBarSide;
		protected System.Web.UI.WebControls.Label lblPercent;
	
		private int state = 0;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["State"] != null)
			{
				state = Convert.ToInt32(Session["State"].ToString());
			}
			else
			{
				Session["State"] = 1;
			}
			while(Session["State"].ToString() != "100")
			{
				this.lblMessages.Text = "Processing";
				this.panelProgress.Width = state * 30;
				this.lblPercent.Text = state * 10 + "%";
			}
			
			if (state == 100)
			{
				this.panelProgress.Visible = false;
				this.panelBarSide.Visible = false;
				this.lblMessages.Text = "Task Completed!";
				Response.Write("<script>window.close();</script>");
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
