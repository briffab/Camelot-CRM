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
using System.Data.SqlClient;
using Camelot.classes;

namespace Camelot
{
	/// <summary>
	/// Summary description for invoicedetails.
	/// </summary>
	public class invoicedetails : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblfacdesc;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Button btnClose;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.TextBox txtDesc;
		protected System.Web.UI.WebControls.DropDownList cmbContact;
		protected System.Web.UI.WebControls.DropDownList cmbPayBy;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtItemDesc;
		protected System.Web.UI.WebControls.TextBox txtValue;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Button btnRemove;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.ListBox lbItems;
		protected System.Web.UI.WebControls.TextBox txtVat;
		Camelot.classes.cContacts lconts;
		Camelot.classes.Inv_Periods linvps;
		Camelot.classes.cCompany lcomp;
		Camelot.classes.cUser pUser;
		Camelot.classes.cInvoice lInvoice = new cInvoice();
		Camelot.classes.Utils Utils = new Camelot.classes.Utils();
		Camelot.classes.Invoice_Items lItems = new Invoice_Items();
		int maxitem;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label lblUpBy;
		protected System.Web.UI.WebControls.Label lblUby;
		protected System.Web.UI.WebControls.TextBox txtTValue;
		protected System.Web.UI.WebControls.TextBox txtTVat;
		protected System.Web.UI.WebControls.TextBox txtTotal;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.TextBox txtPaid;
		protected System.Web.UI.WebControls.Label lblDateStar;
		protected System.Web.UI.WebControls.Button btnView;
		protected System.Web.UI.WebControls.Label Label14;
		

		private void Page_Load(object sender, System.EventArgs e)
		{
			bool oktogo;
			lcomp=(Camelot.classes.cCompany)Session["curCompany"];
			lconts = Utils.get_Comp_Contacts(Session["con"].ToString(),lcomp.Company_ID);
			linvps = Utils.get_Invoice_Periods(Session["con"].ToString());
			Camelot.classes.Utils pUtil = new Camelot.classes.Utils();
			pUser = (Camelot.classes.cUser)Session["curUser"];
			oktogo = pUtil.valid_user(pUser);

			if(!oktogo)
			{
				Response.Redirect("../logon.aspx");
			}
			else
			{
				lInvoice=(Camelot.classes.cInvoice)Session["curInvoice"];
			
				if(lInvoice.Invoice_ID==null || lInvoice.Invoice_ID=="" || lInvoice.Invoice_ID=="0")
				{
					string inv = Request.QueryString["inv"];
					lInvoice.Invoice_ID = inv;
				}
			
				Response.Expires = 0;
				Response.Cache.SetNoStore();
				Response.AppendHeader("Pragma", "no-cache");
			
			
				bool edit = (bool)Session["invoice_edit"];
				bool nnew = (bool)Session["invoice_new"];
									
				setenabled(edit);
				lblDateStar.Visible=false;
				

				if(nnew)
				{
					if(!(bool)Session["invoice_save"])
					{
						pop_combos();
						btnUpdate.Visible = true;
						btnCancel.Visible = true;
						btnEdit.Visible = false;
						btnClose.Visible=false;
						lInvoice.Invoice_ID = "0";
						Session["invoice_save"] = true;
					}
					else
					{
						lItems=(Camelot.classes.Invoice_Items)Session["lItems"];
					}
				}
				else
				{
					if(!Page.IsPostBack)
					{
						lItems = Utils.get_Invoice_Items((string)Session["Connection"], lInvoice.Invoice_ID);
						Session["lItems"] = lItems;
					}
					else
					{
						lItems=(Camelot.classes.Invoice_Items)Session["lItems"];
					}
                
					foreach(cInvoice_Item it in lItems)
					{
						if(Convert.ToInt32(it.Item_ID) > maxitem)
						{
							maxitem = Convert.ToInt32(it.Item_ID);
						}
					}
					if(edit)
					{
						if(!(bool)Session["invoice_save"] && (lInvoice.Invoice_ID!=null && lInvoice.Invoice_ID!=""))
						{
							if(!Page.IsPostBack)
							{
								pop_invoice(lInvoice.Invoice_ID);
							}
						}
				
						btnUpdate.Visible = true;
						btnCancel.Visible = true;
						btnEdit.Visible = false;
						btnClose.Visible=false;
					}
					else
					{
						if(!(bool)Session["invoice_save"] && (lInvoice.Invoice_ID!=null && lInvoice.Invoice_ID!=""))
						{
							if(!Page.IsPostBack)
							{
								pop_invoice(lInvoice.Invoice_ID);
							}
						}
						btnUpdate.Visible = false;
						btnCancel.Visible = false;
						if(pUser.Permission=="1")
						{
							btnEdit.Visible = true;
						}
						else
						{
							btnEdit.Visible=false;
						}
						btnClose.Visible=true;
					}
				}
				
				Session["curInvoice"] = lInvoice;
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
			this.btnView.Click += new System.EventHandler(this.btnView_Click);
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.close();</script>");
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			bool nnew = (bool)Session["invoice_new"];
			Session["invoice_edit"] = false;
			Session["invoice_save"] = false;
			Session["invoice_new"] = false;
			if(nnew)
			{
				Response.Write("<script>window.close();</script>");
			}
			else
			{
				Response.Redirect("invoicedetails.aspx");
			}
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			saveinvoice();
		}

		public int get_contact(string cont)
		{
			int id = 0;
			
			foreach(cContact ct in lconts)
			{
				if(ct.Contact_Name == cont)
				{
					id = Convert.ToInt32(ct.Contact_ID);
					break;
				}
			}
			return id;
		}

		private void saveinvoice()
		{
			bool oktosave = true;
			string Msg = "";
			int cnt = 0;
			Camelot.classes.saveUtils su = new saveUtils();

						
			if(!su.IsDate(su.setdate(txtDate.Text)))
			{
				oktosave=false;
				if(Msg!="")
				{
					Msg = Msg + ", Date";
				}
				else
				{
					Msg = "Date";
				}
				lblDateStar.Visible=true;
			}
			if(!su.IsDate(su.setdate(txtPaid.Text)))
			{
				oktosave=false;
				if(Msg!="")
				{
					Msg = Msg + ", Date";
				}
				else
				{
					Msg = "Date";
				}
				lblDateStar.Visible=true;
			}
			if(txtTValue.Text=="")
			{
				txtTValue.Text="0";
			}
			if(txtTVat.Text=="")
			{
				txtTVat.Text="0";
			}
			if(oktosave)
			{
				SqlConnection conn = new SqlConnection();
				SqlCommand cmd =  new SqlCommand();
				SqlDataReader rdr = null;				
				pUser = (Camelot.classes.cUser)Session["curUser"];

				conn.ConnectionString = (string)Session["Connection"];
				conn.Open();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "update_invoice";

				cmd.Parameters.Add(
					new SqlParameter("@comp_id", lcomp.Company_ID));
				cmd.Parameters.Add(
					new SqlParameter("@invoice_id", lInvoice.Invoice_ID));
				cmd.Parameters.Add(
					new SqlParameter("@dateofissue", DateTime.Parse(su.setdate(txtDate.Text))));
				cmd.Parameters.Add(
					new SqlParameter("@contact_id", get_contact(cmbContact.SelectedItem.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@overdueafter_id", get_period(cmbPayBy.SelectedItem.Text)));
				cmd.Parameters.Add(
					new SqlParameter("@description", txtDesc.Text));
				cmd.Parameters.Add(
					new SqlParameter("@amount", txtTValue.Text));
				cmd.Parameters.Add(
					new SqlParameter("@vat", txtTVat.Text));
				cmd.Parameters.Add(
					new SqlParameter("@record_manager", pUser.ID));
				cmd.Parameters.Add(
					new SqlParameter("@paid", DateTime.Parse(su.setdate(txtPaid.Text))));
				
				rdr = cmd.ExecuteReader();
				while(rdr.Read())
				{
					lInvoice.Invoice_ID = rdr.GetValue(0).ToString();
				}
				Session["curInvoice"]=lInvoice;		
				updateitems(lInvoice.Invoice_ID);
				
				cmd.Dispose();
				conn.Close();
				conn.Dispose();
			
				bool nnew = (bool)Session["invoice_new"];
				Session["invoice_edit"] = false;
				Session["invoice_save"] = false;
				Session["invoice_new"] = false;
//				if(nnew)
//				{
//					Response.Write("<script>window.close();</script>");
//				}
//				else
//				{
					Response.Redirect("invoicedetails.aspx");
//				}
			}
			else
			{
				if(cnt==1)
				{
					Msg ="The field " + Msg + " is";
				}
				else
				{
					Msg ="The fields " + Msg + " are";
				}
				Msg = Msg+ " incomplete or in the wrong format";
				lblMessage.Text = Msg;
				lblMessage.Visible=true;
			}
		}

		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			setenabled(true);
			btnUpdate.Visible = true;
			btnCancel.Visible = true;
			btnEdit.Visible = false;
			btnClose.Visible=false;
			Session["invoice_edit"] = true;
			Session["invoice_save"] = true;
			Session["invoice_new"] = false;
		}

		private void setenabled(bool en)
		{
			txtDate.Enabled=en;
			cmbContact.Enabled=en;
			txtDesc.Enabled=en;
			cmbPayBy.Enabled=en;
			txtItemDesc.Enabled=en;
			txtValue.Enabled=en;
			txtVat.Enabled=en;
			btnAdd.Enabled=en;
			btnRemove.Enabled=en;
			txtTValue.Enabled=false;
			txtTVat.Enabled=false;
			txtTotal.Enabled=false;
			txtPaid.Enabled=en;
		}

		private void pop_contacts(string cont)
		{
			int ind =0;
			cmbContact.Items.Clear();
			cmbContact.Items.Add("");
			foreach(cContact ct in lconts)
			{
				cmbContact.Items.Add(ct.Contact_Name);
				if(ct.Contact_ID == cont)
				{
					ind = cmbContact.Items.Count-1;
				}
			}
			cmbContact.SelectedIndex = ind;
			
		}

		private void pop_invoice_periods(string ip)
		{
			int ind =0;
			cmbPayBy.Items.Clear();
			cmbPayBy.Items.Add("");
			foreach(Inv_Period ivp in linvps)
			{
				cmbPayBy.Items.Add(ivp.Description);
				if(ivp.ID == ip)
				{
					ind = cmbPayBy.Items.Count-1;
				}
			}
			cmbPayBy.SelectedIndex = ind;
			
		}
		public int get_period(string per)
		{
			int id = 0;
			
			foreach(Inv_Period ip in linvps)
			{
				if(ip.Description == per)
				{
					id = Convert.ToInt32(ip.ID);
					break;
				}
			}
			return id;
		}

		private void pop_items(string inv)
		{
			lbItems.Items.Clear();
			foreach(cInvoice_Item it in lItems)
			{
				ListItem li = new ListItem();
				li.Value = it.Item_ID;
				li.Text = it.Description;
				lbItems.Items.Add(li);
			}
		}

		private void pop_invoice(string inv_id)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			SqlDataReader rdr = null;
			Camelot.classes.Utils us = new Camelot.classes.Utils();
			Camelot.classes.saveUtils su = new saveUtils();

			string pay = "";
			string recp = "";
			decimal total = 0;
			decimal amount = 0;
			decimal vat = 0;

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "get_invoice";

			cmd.Parameters.Add(
				new SqlParameter("@inv_id", inv_id));
			
			rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				lblTitle.Text = "Invoice Number : " + rdr["invoiceid"].ToString();
				txtDate.Text = rdr["dateofissue"].ToString();
				txtDesc.Text = rdr["description"].ToString();
				pay = rdr["overdueafter_id"].ToString();
				recp = rdr["contact_id"].ToString();
				lblUby.Text = get_employeename(Convert.ToInt32(rdr["record_manager"]));
				txtPaid.Text = su.getdate(rdr["paid"].ToString());
			}

			
			rdr.Close();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();

			pop_contacts(recp);
			pop_invoice_periods(pay);
			pop_items(inv_id);

			foreach(cInvoice_Item it in lItems)
			{
				amount = amount + Convert.ToDecimal(it.Amount);
				vat = vat + Convert.ToDecimal(it.VAT);
			}
			total = (amount + vat);
			txtTValue.Text = amount.ToString();
			txtTVat.Text = vat.ToString();
			txtTotal.Text = total.ToString();
		}

		public string get_employeename(int emp)
		{
			string name = "";
			Employees lemps = (Employees)Session["Emps"];
			
			foreach(Employee em in lemps)
			{
				if(Convert.ToInt32(em.Emp_ID) == emp)
				{
					name = em.Emp_Name;
					break;
				}
			}
			return name;
		}
		private void pop_combos()
		{
			pop_contacts("");
			pop_invoice_periods("");
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			Camelot.classes.cInvoice_Item lit = new cInvoice_Item();
			Camelot.classes.saveUtils su = new saveUtils();
			decimal amount = 0;
			decimal vat = 0;
			decimal total = 0;
			bool oktoadd = true;
			
			if(txtItemDesc.Text=="")
			{
				oktoadd = false;
			}
			else if(txtValue.Text=="" || !su.IsNumber(txtValue.Text))
			{
				oktoadd=false;
			}
			else if(txtVat.Text=="")
			{
				txtVat.Text="0";
			}
			else if(!su.IsNumber(txtVat.Text))
			{
				oktoadd=false;
			}
				
			if(oktoadd)
			{
				ListItem li = new ListItem();
				lit.Item_ID = Convert.ToString(maxitem+1);
				lit.Description = txtItemDesc.Text;
				lit.Amount = txtValue.Text;
				lit.VAT = txtVat.Text;
				lItems.Add(lit);

				li.Value=lit.Item_ID;
				li.Text=lit.Description;
				lbItems.Items.Add(li);
				Session["lItems"] = lItems;
			
				foreach(cInvoice_Item it in lItems)
				{
					amount = amount + Convert.ToDecimal(it.Amount);
					vat = vat + Convert.ToDecimal(it.VAT);
				}
				total = (amount + vat);
				txtTValue.Text = amount.ToString();
				txtTVat.Text = vat.ToString();
				txtTotal.Text = total.ToString();

				txtItemDesc.Text = "";
				txtValue.Text = "";
				txtVat.Text = "";

			}
			else
			{
				lblMessage.Text="Incorrect Item";
			}

		}

		private void btnRemove_Click(object sender, System.EventArgs e)
		{
			int itemid;
			Camelot.classes.cInvoice_Item rit = new cInvoice_Item();
			bool remove = false;
			decimal amount = 0;
			decimal vat = 0;
			decimal total= 0;

			itemid = Convert.ToInt32(lbItems.SelectedValue);
			lbItems.Items.Remove(lbItems.SelectedItem);

			foreach(cInvoice_Item it in lItems)
			{
				if(it.Item_ID == itemid.ToString())
				{
				
						rit = it;
						remove = true;
				}
			}

			if(remove)
			{
				lItems.Remove(rit);
			}

			Session["lItems"] = lItems;

			foreach(cInvoice_Item it in lItems)
			{
				amount = amount + Convert.ToDecimal(it.Amount);
				vat = vat + Convert.ToDecimal(it.VAT);
			}
			total = (amount + vat);
			txtTValue.Text = amount.ToString();
			txtTVat.Text = vat.ToString();
			txtTotal.Text = total.ToString();

		}

		private void updateitems(string inv)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			pUser = (Camelot.classes.cUser)Session["curUser"];

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "delete_invoice_items";

			cmd.Parameters.Add(
				new SqlParameter("@inv_id", inv));
			cmd.ExecuteNonQuery();

			cmd.Dispose();
			conn.Close();
			conn.Dispose();

			foreach(cInvoice_Item it in lItems)
			{
				updateitem(it);
			}


		}

		private void updateitem(cInvoice_Item it)
		{
			SqlConnection conn = new SqlConnection();
			SqlCommand cmd =  new SqlCommand();
			pUser = (Camelot.classes.cUser)Session["curUser"];

			conn.ConnectionString = (string)Session["Connection"];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "insert_invoice_item";

			cmd.Parameters.Add(
				new SqlParameter("@invoice_id",lInvoice.Invoice_ID));
			cmd.Parameters.Add(
				new SqlParameter("@description", it.Description));
			cmd.Parameters.Add(
				new SqlParameter("@amount", it.Amount));
			cmd.Parameters.Add(
				new SqlParameter("@vat", it.VAT));

			cmd.ExecuteNonQuery();

			cmd.Dispose();
			conn.Close();
			conn.Dispose();

		}

		private void btnView_Click(object sender, System.EventArgs e)
		{
			string iv = lbItems.SelectedValue;

			foreach(cInvoice_Item it in lItems)
			{
				if(it.Item_ID == iv)
				{
					txtItemDesc.Text = it.Description;
					txtValue.Text = it.Amount;
					txtVat.Text = it.VAT;
				}
			}
		}

	}
}
