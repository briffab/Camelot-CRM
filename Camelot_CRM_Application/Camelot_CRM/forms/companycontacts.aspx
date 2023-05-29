<%@ Page language="c#" Codebehind="companycontacts.aspx.cs" AutoEventWireup="false" Inherits="Camelot.companycontacts" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<%
Response.CacheControl="private";
Response.Expires=0;
Response.AddHeader("pragma", "no-cache");
%>
<HTML>
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
		<form ID="Form1" name="Form1" runat="server">
			<table width="96%" height="54" align="center">
				<tr>
					<td class="logon">
						<asp:Label id="Label1" runat="server" Font-Size="20pt">Company Contact</asp:Label>
					</td>
				</tr>
			</table>
			<hr width="96%" align="center">
			<table width="96%" align="center">
				<tr>
					<td vAlign="bottom" align="right" width="10%" height="100%">Search</td>
					<td vAlign="bottom" align="left" width="30%" height="100%">&nbsp;
						<asp:dropdownlist id="cmbFind" runat="server" Width="167px">
							<asp:ListItem Value="Company_Name" Selected="True">Owner Name</asp:ListItem>
							<asp:ListItem Value="lastname">Last Name</asp:ListItem>
							<asp:ListItem Value="firstname">First Name</asp:ListItem>
							<asp:ListItem Value="POSTALCODE">Post Code</asp:ListItem>
							<asp:ListItem Value="CITY">Town/ City</asp:ListItem>
							<asp:ListItem Value="COUNTY">County</asp:ListItem>
							<asp:ListItem Value="DESCRIPTION">Area</asp:ListItem>
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
					<td>
						<asp:datagrid id="dgComps" runat="server" Width="100%" OnItemCommand="set_comp" HorizontalAlign="Center"
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
							</Columns>
						</asp:datagrid></td>
				</tr>
			</table>
			<table width="96%" align="center">
				<tr>
					<td class="logon">
						<asp:Label id="lblComp" runat="server"></asp:Label>
					</td>
				</tr>
			</table>
			<table width="96%" align="center">
				<tr>
					<td>
						<asp:datagrid id="dgConts" name="dgConts" OnItemCommand="set_cont" runat="server" Width="100%" AutoGenerateColumns="False" OnDeleteCommand="dgConts_delete"
							GridLines="None" CellPadding="5" Font-Name="arial" ForeColor="#56a80f" Font-Bold="false" HorizontalAlign="Center"
							DataKeyField="contact_id" OnItemDataBound="dgConts_ItemDataBound">
							<HeaderStyle BackColor="#56a80f" ForeColor="#dae7ca" Font-Bold="True" HorizontalAlign="Left" />
							<Columns>
								<asp:ButtonColumn DataTextField="cName" HeaderText="Contact Name">
									<ItemStyle Width="25%" Font-Bold="True"></ItemStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn DataField="contact_id" Visible="False"></asp:BoundColumn>
								<asp:BoundColumn DataField="description" HeaderText="Contact Type">
									<ItemStyle Width="25%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="phone" HeaderText="Telephone">
									<ItemStyle Width="20%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="company_name" HeaderText="Company">
									<ItemStyle Width="30%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="company_id" Visible="False"></asp:BoundColumn>
								<asp:ButtonColumn Text="Delete" HeaderText="Delete Contact" CommandName="Delete">
									<ItemStyle Wrap="False"></ItemStyle>
									<HeaderStyle Wrap="False"></HeaderStyle>
								</asp:ButtonColumn>
							</Columns>
						</asp:datagrid>
					</td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" height="3%" align="center">
				<tr>
					<td width="100%" valign="middle" align="right">
						<input class="button" type="button" value="Add" id="Button1" name="Button1" runat="server">
						<!--<input class="button" type="button" value="Cancel" />-->
					</td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
