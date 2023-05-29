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
using System.Web.Mail;
using System.IO;
using CC =Camelot.classes;

namespace Camelot.forms
{
	/// <summary>
	/// Summary description for emailInd.
	/// </summary>
	public class emailinsp : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.DropDownList cmbFrom;
		protected System.Web.UI.WebControls.TextBox txtTo;
		protected System.Web.UI.WebControls.TextBox txtCc; 
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtSubject;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.TextBox txtBody;
		protected System.Web.UI.WebControls.Button btnClose;
		protected System.Web.UI.WebControls.TextBox txtBcc;
		private CC.cInspection linsp = null;
		public string recip_email = "";
		ArrayList recemail;
		ArrayList recips;
		Camelot.classes.cUser pUser;

		private void Page_Load(object sender, System.EventArgs e)
		{
			/*if (!Page.IsClientScriptBlockRegistered("Rec"))
			{		
				string title="Recipients";
				string height="500";
				string width="650";	
			 
				// use next line for direct with <base target="_self"> between <Head> and </HEAD> 
				string scrp="<script>var rc = new Array(0,0);function doIt(){rc= window.showModalDialog('recipients.aspx?Title="+title + "','','dialogHeight:"+height+" px;dialogWidth:"+width+" px;');"+"\n";
				scrp+=";}</script>";

				Page.RegisterStartupScript("Recs",scrp);			
				this.btnTo.Attributes.Add("onClick","doIt();");
			}*/
			
			bool oktogo;
			Camelot.classes.Utils pUtil = new Camelot.classes.Utils();
			pUser = (Camelot.classes.cUser)Session["curUser"];
			oktogo = pUtil.valid_user(pUser);
			linsp = (CC.cInspection)Session["curInspection"];

			if(!oktogo)
			{
				Response.Redirect("../logon.aspx");
			}
			else
			{
				if(!Page.IsPostBack)
				{
					recemail = (ArrayList)Session["iRecipEmail"];
					recips =(ArrayList)Session["iRecip"];

					foreach(string em in recemail)
					{
						recip_email = recip_email + em + "; ";
					}
					this.txtBcc.Text = recip_email;
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

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.close();</script>");
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.close()</script>");
		}
	}
}
