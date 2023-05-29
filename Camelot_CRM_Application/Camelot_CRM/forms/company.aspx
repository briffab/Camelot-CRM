<%@ Page language="c#" Codebehind="company.aspx.cs" AutoEventWireup="false" Inherits="Camelot.company" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<%
Response.CacheControl="private";
Response.Expires=0;
Response.AddHeader("pragma", "no-cache");
%>
	<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
	<script language='JavaScript'>
		<!--
		function SetFocus()
		{
			document.Form1['txtFind'].focus();
		}

		function keystroke()
		{
			if (window.event.keyCode == 13) 
			{
				event.returnValue=false;
				event.cancel = true;
				document.Form1.btnSearch.click();
			}
		}

		window.onload = SetFocus;
		// -->;
	</script>
	<body onkeydown="keystroke()">
		<!--#include file="head.aspx" -->
		<script language="JavaScript" src="../functions/menu.js"></script>
		<script language="JavaScript" src="../functions/menu<%=Session["menu"]%>.js"></script>
		<script language="JavaScript">
					showToolbar();
		</script>
		<form id="Form1" runat="server">
			<table width="96%" height="54" align="center">
				<tr>
					<td class="logon">
						<asp:Label id="Label1" runat="server" Font-Size="20pt">Company Details</asp:Label>
					</td>
				</tr>
			</table>
			<table height="54" width="96%" align="center">
				<tr>
					<td vAlign="bottom" align="right" width="10%" height="100%">Search</td>
					<td vAlign="bottom" align="left" width="30%" height="100%">&nbsp;
						<asp:dropdownlist id="cmbFind" runat="server" Width="167px">
							<asp:ListItem Value="Company_Name" Selected="True">Owner Name</asp:ListItem>
							<asp:ListItem Value="Contact_name">Contact Name</asp:ListItem>
							<asp:ListItem Value="POSTALCODE">Post Code</asp:ListItem>
							<asp:ListItem Value="CITY">Town/ City</asp:ListItem>
							<asp:ListItem Value="COUNTY">County</asp:ListItem>
							<asp:ListItem Value="DESCRIPTION">Area</asp:ListItem>
							<asp:ListItem Value="TYPE">Company Type</asp:ListItem>
						</asp:dropdownlist></td>
					<td vAlign="bottom" align="left" width="40%" height="100%">&nbsp; 
						for&nbsp;&nbsp;&nbsp; &nbsp;
						<asp:textbox id="txtFind" runat="server" Width="192px"></asp:textbox></td>
					<td vAlign="bottom" align="left" width="20%" height="100%">&nbsp;&nbsp;
						<asp:button id="btnSearch" runat="server" Text="Search" CssClass="button"></asp:button></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center">
				<tr>
					<td><asp:datagrid id="dgComps" runat="server" Width="100%" OnItemCommand="set_comp" HorizontalAlign="Center"
							Font-Bold="false" ForeColor="#56a80f" Font-Name="arial" CellPadding="5" GridLines="None" AutoGenerateColumns="False">
							<HeaderStyle BackColor="#56a80f" ForeColor="#dae7ca" Font-Bold="True" HorizontalAlign="Left" />
							<Columns>
								<asp:ButtonColumn DataTextField="company_name" HeaderText="Company">
									<ItemStyle Width="30%" Font-Bold="True"></ItemStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn DataField="company_id" Visible="False"></asp:BoundColumn>
								<asp:BoundColumn DataField="company_name" Visible="False"></asp:BoundColumn>
								<asp:BoundColumn DataField="description" HeaderText="Type">
									<ItemStyle Width="20%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="address" HeaderText="Address">
									<ItemStyle Width="50%"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Delete" HeaderText="Delete Company" CommandName="Delete">
									<ItemStyle Wrap="False"></ItemStyle>
									<HeaderStyle Wrap="False"></HeaderStyle>
								</asp:ButtonColumn>
							</Columns>
						</asp:datagrid></td>
				</tr>
			</table>
			<table id="tblDetails" width="96%" align="center" border="0">
				<tr>
					<td vAlign="top" width="50%" height="100%">
						<table width="100%">
							<tr>
								<td class="logon" width="249" height="24"><asp:label id="lblCompName" runat="server">Company Name</asp:label></td>
								<td class="data" width="60%" height="24">&nbsp;
									<asp:textbox id="txtCompName" runat="server" Width="184px"></asp:textbox>
									<asp:label id="lblNamestar" runat="server" Font-Size="Larger" Font-Names="Arial" ForeColor="Red"
										Font-Bold="True">*</asp:label></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="24"><asp:label id="lblAddress" runat="server">Address</asp:label></td>
								<td class="data" width="60%" height="24">&nbsp;
									<asp:textbox id="txtAddress1" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td width="249" height="24"></td>
								<td class="data" width="60%" height="24">&nbsp;
									<asp:textbox id="txtAddress2" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td width="249" height="24"></td>
								<td class="data" width="60%" height="24">&nbsp;
									<asp:textbox id="txtAddress3" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td width="249" height="24"></td>
								<td class="data" width="60%" height="24">&nbsp;
									<asp:textbox id="txtAddress4" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="24"><asp:label id="lblTown" runat="server">Town/City</asp:label></td>
								<td class="data" width="60%" height="24">&nbsp;
									<asp:textbox id="txtTown" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="24"><asp:label id="lblPost" runat="server">Post Code</asp:label></td>
								<td class="data" width="60%" height="24">&nbsp;
									<asp:textbox id="txtPost" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="24"><asp:label id="lblCounty" runat="server">County</asp:label></td>
								<td class="data" width="60%" height="24">&nbsp;
									<asp:textbox id="txtCounty" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="24"><asp:label id="lblArea" runat="server">Area</asp:label></td>
								<td class="data" width="60%" height="24">&nbsp;
									<asp:dropdownlist id="cmbArea" runat="server" Width="184" CssClass="logon"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="24"><asp:label id="lblCountry" runat="server">Country</asp:label></td>
								<td class="data" width="60%" height="24">&nbsp;
									<asp:textbox id="txtCountry" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="24"><asp:label id="lblComptype" runat="server">Company Type</asp:label></td>
								<td class="data" width="60%" height="24">&nbsp;
									<asp:dropdownlist id="cmbCompType" runat="server" Width="184" CssClass="logon"></asp:dropdownlist></td>
							</tr>
						</table>
					</td>
					<td vAlign="top" width="50%" height="100%">
						<table width="100%">
							<TR>
								<td class="logon" colspan="2"><asp:label id="lblMessage" runat="server" Font-Bold="false" ForeColor="Red" Font-Names="Arial"
										Font-Size="Larger"></asp:label></td>
							<tr>
								<td class="logon" width="249" height="24"><asp:label id="lblTel" runat="server">Telephone</asp:label></td>
								<td class="data" width="60%" height="24">&nbsp;
									<asp:textbox id="txtTel" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="24"><asp:label id="lblFax" runat="server">Fax</asp:label></td>
								<td class="data" width="60%" height="24">&nbsp;
									<asp:textbox id="txtFax" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="24"><asp:label id="lblEmail" runat="server">Email</asp:label></td>
								<td class="data" width="60%" height="24">&nbsp;
									<asp:textbox id="txtEmail" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="24"><asp:label id="lblWeb" runat="server">Website</asp:label></td>
								<td class="data" width="60%" height="24">&nbsp;
									<asp:textbox id="txtWeb" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td class="logon" width="147" height="24"><asp:label id="lblAccMan" runat="server">Account Manager </asp:label></td>
								<td class="data" width="60%" height="24">&nbsp;&nbsp;<asp:dropdownlist id="cmbAccMan" runat="server" Width="184" CssClass="logon"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="logon" width="147" height="24"><asp:label id="lblSalesMan" runat="server">Sales Manager</asp:label></td>
								<td class="data" width="60%" height="24">&nbsp;&nbsp;<asp:dropdownlist id="cmbSalesMan" runat="server" Width="184" CssClass="logon"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="logon" align="left" width="249" height="24"><asp:label id="lblStatus" runat="server">Status</asp:label></td>
								<td class="data" width="60%" height="24">&nbsp;
									<asp:dropdownlist id="cmbStatus" runat="server" Width="184" CssClass="logon"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="24"><asp:label id="lblStatEff" runat="server">Status Effective </asp:label></td>
								<td class="data" width="60%" height="24">&nbsp;
									<asp:textbox id="txtStatEff" runat="server" Width="184px"></asp:textbox><asp:label id="lblDateStar" runat="server" Font-Size="Larger" Font-Names="Arial" ForeColor="Red"
										Font-Bold="True">*</asp:label></td>
							</tr>
							<tr>
								<td class="logon" width="147" height="24"><asp:label id="lblUpBy" runat="server">Last Updated by</asp:label></td>
								<td class="data" width="60%" height="24">&nbsp;&nbsp;<asp:label id="lblUby" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td class="logon" width="147" height="24"><asp:label id="lblUpOn" runat="server">Last Updated on </asp:label></td>
								<td class="data" width="60%" height="24">&nbsp;<asp:label id="lblUDate" runat="server"></asp:label></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<table height="30" width="96%" align="center">
				<tr>
					<td vAlign="middle" align="left" width="20%"><asp:button id="btnAddComp" runat="server" CssClass="button" Text="Add Company"></asp:button></td>
					<td vAlign="middle" align="center" width="20%"><asp:button id="btnDel" runat="server" CssClass="button" Text="Delete"></asp:button></td>
					<td vAlign="middle" align="center" width="20%"><asp:button id="btnVisit" runat="server" CssClass="button" Text="Visiting Address" Width="150px"></asp:button></td>
					<td vAlign="middle" align="center" width="20%"><asp:button id="btnBank" runat="server" CssClass="button" Text="Bank Details"></asp:button></td>
					<td vAlign="middle" align="right" width="20%"><asp:button id="btnEdit" runat="server" CssClass="button" Text="Edit"></asp:button><asp:button id="btnUpdate" runat="server" CssClass="button" Text="Update"></asp:button>&nbsp;
						<asp:button id="btnCancel" runat="server" CssClass="button" Text="Cancel"></asp:button>&nbsp;
					</td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td width="100%">
						<div style=" OVERFLOW:auto; WIDTH:100%; HEIGHT:152px">
							<asp:datagrid id="dgProps" runat="server" Width="100%" Font-Size="8pt" AutoGenerateColumns="False" GridLines="None"
								CellPadding="5" Font-Name="arial" ForeColor="#56a80f" Font-Bold="false" HorizontalAlign="Center"
								OnItemCommand="set_prop">
								<HeaderStyle BackColor="#56a80f" ForeColor="#dae7ca" Font-Bold="True" HorizontalAlign="Left" />
								<Columns>
									<asp:ButtonColumn DataTextField="name" HeaderText="Property">
										<ItemStyle Width="30%" Font-Bold="True"></ItemStyle>
									</asp:ButtonColumn>
									<asp:BoundColumn DataField="name" Visible="False"></asp:BoundColumn>
									<asp:BoundColumn DataField="prop" Visible="False"></asp:BoundColumn>
									<asp:BoundColumn DataField="Address" HeaderText="Address">
										<ItemStyle Width="40%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="property_manager" HeaderText="Property Manager">
										<ItemStyle Width="15%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="status_description" HeaderText="Status">
										<ItemStyle Width="15%"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:datagrid>
						</div>
					</td>
				</tr>
			</table>
			<table height="30" width="96%" align="center">
				<tr>
					<td vAlign="middle" align="left" width="50%"><asp:button id="btnAddProp" runat="server" CssClass="button" Text="Add Property"></asp:button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>