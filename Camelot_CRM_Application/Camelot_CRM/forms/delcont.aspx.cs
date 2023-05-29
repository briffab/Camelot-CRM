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
	/// Summary description for delcont.
	/// </summary>
	public class delcont : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Button btnDel;
		protected System.Web.UI.WebControls.Button btnCancel;
		private string cont_id = "";
		private void Page_Load(object sender, System.EventArgs e)
		{
			cont_id = Request.QueryString["cont"];
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
			this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.close();</script>");
		}

		private void btnDel_Click(object sender, System.EventArgs e)
		{
			Camelot.classes.del_cont dc = new del_cont();

			dc.Cont_ID = cont_id;
			dc.Con = (string)Session["Connection"];
			dc.del_contact();

			Response.Write("<script>window.close();</script>");
		}
	}
}
