<%@ Page language="c#" Codebehind="correspondence.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.correspondence" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
	<body>
		<!--#include file="head.aspx" -->
		<script language="JavaScript" src="../functions/menu.js"></script>
		<script language="JavaScript" src="../functions/menu<%=Session["menu"]%>.js"></script>
		<script language="JavaScript">
					showToolbar();
		</script>
		<form id="Form1" runat="server">
			<P>&nbsp;</P>
			<table width="96%" align="center">
				<tr>
					<td class="logon"><asp:label id="Label1" runat="server" Font-Size="20pt">Correspondence</asp:label></td>
				</tr>
			</table>
			<hr width="96%">
			<table id="tblDetails" width="96%" align="center" border="0">
				<tr>
					<td class="logon" vAlign="top" width="25%" height="21"><asp:label id="lblTarget" runat="server" CssClass="logon">Target</asp:label><asp:dropdownlist id="cmbTarget" runat="server" CssClass="logon" Width="100%" AutoPostBack="True">
							<asp:ListItem Value="1">Guardians</asp:ListItem>
							<asp:ListItem Value="3">Contacts</asp:ListItem>
							<asp:ListItem Value="2">Newsletter Subscriptions</asp:ListItem>
							<asp:ListItem Value="0">Owners</asp:ListItem>
						</asp:dropdownlist></td>
					<td class="logon" vAlign="top" width="25%" height="21"><asp:label id="lblList" runat="server" CssClass="logon">List by</asp:label><asp:listbox id="lstOwner" runat="server" CssClass="logon" Width="100%" AutoPostBack="True" SelectionMode="Multiple"
							Rows="7">
							<asp:ListItem Value="0">All</asp:ListItem>
							<asp:ListItem Value="1">Area</asp:ListItem>
							<asp:ListItem Value="2">Post Code</asp:ListItem>
							<asp:ListItem Value="3">Property Status</asp:ListItem>
							<asp:ListItem Value="4">Property Type</asp:ListItem>
							<asp:ListItem Value="5">Town</asp:ListItem>
							<asp:ListItem Value="6">Company Type</asp:ListItem>
						</asp:listbox><asp:listbox id="lstGuard" runat="server" CssClass="logon" AutoPostBack="True" SelectionMode="Multiple"
							Rows="7" width="100%">
							<asp:ListItem Value="0">All</asp:ListItem>
							<asp:ListItem Value="1">Area</asp:ListItem>
							<asp:ListItem Value="2">Guardian Status</asp:ListItem>
							<asp:ListItem Value="3">Post Code</asp:ListItem>
							<asp:ListItem Value="4">Property</asp:ListItem>
							<asp:ListItem Value="5">Route</asp:ListItem>
							<asp:ListItem Value="6">Town</asp:ListItem>
						</asp:listbox><asp:listbox id="lstConts" runat="server" CssClass="logon" Width="100%" AutoPostBack="True" SelectionMode="Multiple"
							Rows="5">
							<asp:ListItem Value="0">All</asp:ListItem>
							<asp:ListItem Value="1">Area</asp:ListItem>
							<asp:ListItem Value="2">Post Code</asp:ListItem>
							<asp:ListItem Value="3">Town</asp:ListItem>
							<asp:ListItem Value="4">Company Type</asp:ListItem>
						</asp:listbox></td>
					<td vAlign="top" width="50%"><asp:label class="logon" id="lblArea" runat="server" valign="top">Area</asp:label><asp:listbox id="lstArea" runat="server" CssClass="logon" SelectionMode="Multiple" Rows="6" width="100%"></asp:listbox><asp:label class="logon" id="lblPost" runat="server">Post Code</asp:label><asp:textbox id="txtPost" runat="server" CssClass="data" width="100%"></asp:textbox><asp:label class="logon" id="lblStat" runat="server">Property Status</asp:label><asp:listbox id="lstStatus" runat="server" CssClass="logon" SelectionMode="Multiple" Rows="6"
							width="100%"></asp:listbox><asp:label class="logon" id="lblPType" runat="server">Property Type</asp:label><asp:listbox id="lstPType" runat="server" CssClass="logon" SelectionMode="Multiple" Rows="6"
							width="100%"></asp:listbox><asp:label class="logon" id="lblTown" runat="server">Town</asp:label><asp:textbox id="txtTown" runat="server" CssClass="data" width="100%"></asp:textbox><asp:label class="logon" id="LblCtype" runat="server">Company Type</asp:label><asp:listbox id="lstComp" runat="server" CssClass="logon" SelectionMode="Multiple" Rows="6" width="100%"></asp:listbox><asp:label class="logon" id="lblprop" runat="server">Property</asp:label><asp:listbox id="lstProps" runat="server" CssClass="logon" SelectionMode="Multiple" Rows="6"
							width="100%"></asp:listbox><asp:label class="logon" id="lblRoute" runat="server">Route</asp:label><asp:listbox id="lstRoute" runat="server" CssClass="logon" SelectionMode="Multiple" Rows="6"
							width="100%"></asp:listbox><asp:label class="logon" id="lblGstat" runat="server">Guardian Status</asp:label><asp:listbox id="lstGStat" runat="server" CssClass="logon" SelectionMode="Multiple" Rows="6"
							width="100%"></asp:listbox></td>
				</tr>
				<tr>
					<td colSpan="3"><asp:button id="btnSearch" runat="server" CssClass="button" Text="Search"></asp:button></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center" border="0">
				<tr>
					<td class="logon" vAlign="top" width="25%" height="21"><asp:label id="Label2" runat="server" CssClass="logon">Correspondence Type</asp:label><asp:dropdownlist id="cmbCtype" runat="server" CssClass="logon" Width="100%" AutoPostBack="True">
							<asp:ListItem Value="0">Email</asp:ListItem>
							<asp:ListItem Value="1">Email and Merged Document</asp:ListItem>
							<asp:ListItem Value="2">Merged Document</asp:ListItem>
							<asp:ListItem Value="3">Newsletter</asp:ListItem>
						</asp:dropdownlist></td>
					<td class="logon" vAlign="top" width="25%" height="21"><asp:label id="Label3" runat="server" CssClass="logon">Document</asp:label><asp:dropdownlist id="cmbDoc" runat="server" CssClass="logon" Width="100%" AutoPostBack="True"></asp:dropdownlist></td>
					<td vAlign="bottom" width="25%"></td>
					<td vAlign="bottom" align="right" width="25%"><asp:button id="btnGen" runat="server" CssClass="button" Width="200" Text="Generate Correspondence"></asp:button></td>
				</tr>
			</table>
			<hr width="96%">
			<table id="tblRecipients" width="96%" align="center" border="0">
				<tr>
					<td align="left" width="50%"><asp:label id="lblCount" CssClass="logon" Runat="server"></asp:label></td>
					<td align="right" width="50%"><asp:button id="btnCheck" runat="server" CssClass="button" Text="Uncheck All"></asp:button>&nbsp; 
						&nbsp;
						<asp:button id="btnUncheck" runat="server" CssClass="button" Text="Check All"></asp:button></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" colSpan="2">
						<div style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 300px"><asp:datagrid id="dgRecipients" runat="server" Font-Size="8" Width="100%" HorizontalAlign="Center"
								Font-Bold="false" ForeColor="#56a80f" Font-Name="arial" CellPadding="5" GridLines="None" AutoGenerateColumns="False">
								<HeaderStyle BackColor="#56a80f" ForeColor="#dae7ca" Font-Bold="True" HorizontalAlign="Left" />
								<Columns>
									<asp:BoundColumn DataField="contact_id" Visible="False"></asp:BoundColumn>
									<asp:BoundColumn DataField="email" Visible="false"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Include">
										<ItemTemplate>
											<asp:CheckBox width="5%" id="chk" runat="server"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="name" HeaderText="Contact">
										<ItemStyle Width="20%" Font-Bold="True"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="company_name" HeaderText="Company">
										<ItemStyle Width="20%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="job_title" HeaderText="Job Title">
										<ItemStyle Width="15%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Address" HeaderText="Address">
										<ItemStyle Width="40%"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:datagrid><asp:datagrid id="dgGuardians" runat="server" Font-Size="8" Width="100%" HorizontalAlign="Center"
								Font-Bold="false" ForeColor="#56a80f" Font-Name="arial" CellPadding="5" GridLines="None" AutoGenerateColumns="False">
								<HeaderStyle BackColor="#56a80f" ForeColor="#dae7ca" Font-Bold="True" HorizontalAlign="Left" />
								<Columns>
									<asp:BoundColumn DataField="resident_id" Visible="False"></asp:BoundColumn>
									<asp:BoundColumn DataField="email" Visible="false"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Include">
										<ItemTemplate>
											<asp:CheckBox width="5%" id="gchk" runat="server"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="name" HeaderText="Guardian">
										<ItemStyle Width="20%" Font-Bold="True"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="email" HeaderText="Email">
										<ItemStyle Width="20%" Font-Bold="True"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="property" HeaderText="Property">
										<ItemStyle Width="20%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="room" HeaderText="Room">
										<ItemStyle Width="15%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Head" HeaderText="Head Guardian">
										<ItemStyle Width="15%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="date_from" HeaderText="Date Started" DataFormatString="{0:dd MMMM yyyy}">
										<ItemStyle Width="15%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="date_to" HeaderText="Date Finished" DataFormatString="{0:dd MMMM yyyy}">
										<ItemStyle Width="15%"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:datagrid></div>
					</td>
				</tr>
			</table>
			<hr width="96%">
		</form>
	</body>
</HTML>