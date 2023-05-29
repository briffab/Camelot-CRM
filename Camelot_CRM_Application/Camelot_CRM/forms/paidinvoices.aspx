<%@ Page language="c#" Codebehind="paidinvoices.aspx.cs" AutoEventWireup="false" Inherits="Camelot.paidinvoices" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
<META http-equiv=Content-Type content="text/html; charset=windows-1252">
<%
Response.CacheControl="private";
Response.Expires=0;
Response.AddHeader("pragma", "no-cache");
%>
	<BODY>
		<!--#include file="head.aspx" -->
		<script language="JavaScript" src="../functions/menu.js"></script>
		<script language="JavaScript" src="../functions/menu<%=Session["menu"]%>.js"></script>
		<script language="JavaScript">
					showToolbar();
		</script>
		<form id="Form1" name="Form1" runat="server">
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
									<ItemStyle Width="30%" Font-Bold="True" VerticalAlign="Top"></ItemStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn DataField="company_id" Visible="False"></asp:BoundColumn>
								<asp:BoundColumn DataField="description" HeaderText="Type">
									<ItemStyle Width="20%" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="address" HeaderText="Address">
									<ItemStyle Width="50%" VerticalAlign="Top"></ItemStyle>
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
					<div style=" OVERFLOW:auto; WIDTH:100%; HEIGHT:450px">
					<asp:datagrid id="dgInvoices" runat="server" Width="100%" HorizontalAlign="Center" Font-Bold="false"
							ForeColor="#56a80f" Font-Name="arial" CellPadding="5" GridLines="None" AutoGenerateColumns="False"
							OnItemDataBound="dgInvoices_ItemDataBound" DataKeyField="invoiceid">
							<HeaderStyle BackColor="#56a80f" ForeColor="#dae7ca" Font-Bold="True" HorizontalAlign="Left" />
							<Columns>
								<asp:ButtonColumn DataTextField="invoiceid" HeaderText="Invoice Number" >
									<ItemStyle Width="20%" Font-Bold="True" VerticalAlign="Top"></ItemStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn DataField="dateofissue" HeaderText="Date" DataFormatString="{0:dd MMMM yyyy}"></asp:BoundColumn>
								<asp:BoundColumn DataField="DESCRIPTION" HeaderText="Description">
									<ItemStyle Width="30%" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="amount" HeaderText="Amount" >
									<ItemStyle Width="20%" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:datagrid></div></td>
    <DIV></DIV>
				</tr>
			</table>
			<hr width="96%">
		</form>
	</BODY>
</HTML>
