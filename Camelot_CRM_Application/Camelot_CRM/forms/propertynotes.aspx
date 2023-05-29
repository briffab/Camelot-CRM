<%@ Page language="c#" Codebehind="propertynotes.aspx.cs" AutoEventWireup="false" Inherits="Camelot.propertynotes" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<%
Response.CacheControl="private";
Response.Expires=0;
Response.AddHeader("pragma", "no-cache");
%>
<HTML>
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
		<form id="Form1" name="Form1" runat="server">
			<table width="96%" height="54" align="center">
				<tr>
					<td class="logon">
						<asp:Label id="Label1" runat="server" Font-Size="20pt">Property Notes</asp:Label>
					</td>
				</tr>
			</table>
			<hr width="96%" align="center">
			<table width="96%" align="center">
				<tr>
					<td vAlign="bottom" class="logon" align="right" width="10%" height="100%">Search</td>
					<td vAlign="bottom" align="left" width="30%" height="100%">&nbsp;
						<asp:dropdownlist id="cmbFind" runat="server" Width="167px">
							<asp:ListItem Value="OBJECT_NAME" Selected="True">Address Line 1</asp:ListItem>
							<asp:ListItem Value="STREETNAME">Street Name</asp:ListItem>
							<asp:ListItem Value="POSTALCODE">Post Code</asp:ListItem>
							<asp:ListItem Value="CITY">Town/ City</asp:ListItem>
							<asp:ListItem Value="PROPERTY_ID">Property Number</asp:ListItem>
						</asp:dropdownlist></td>
					<td vAlign="bottom" align="left" width="40%" height="100%">&nbsp; 
						for&nbsp;&nbsp;&nbsp; &nbsp;
						<asp:textbox id="txtFind" runat="server" Width="192px"></asp:textbox></td>
					<td vAlign="bottom" align="left" width="20%" height="100%">&nbsp;&nbsp;
						<asp:button id="btnSearch" runat="server" CssClass="button" Text="Search"></asp:button></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center">
				<tr>
					<td><asp:datagrid id="dgProps" runat="server" Width="100%" AutoGenerateColumns="False" GridLines="None"
							CellPadding="5" Font-Name="arial" ForeColor="#56a80f" Font-Bold="false" HorizontalAlign="Center"
							OnItemCommand="set_prop">
							<HeaderStyle BackColor="#56a80f" ForeColor="#dae7ca" Font-Bold="True" HorizontalAlign="Left" />
							<Columns>
								<asp:ButtonColumn DataTextField="name" HeaderText="Property">
									<ItemStyle Width="30%" Font-Bold="True"></ItemStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn DataField="name" Visible="False"></asp:BoundColumn>
								<asp:BoundColumn DataField="prop" Visible="False"></asp:BoundColumn>
								<asp:BoundColumn DataField="company_id" Visible="False"></asp:BoundColumn>
								<asp:BoundColumn DataField="Address" HeaderText="Address">
									<ItemStyle Width="40%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Owner" HeaderText="Owner">
									<ItemStyle Width="30%"></ItemStyle>
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
					<div style="vertical-align top; height:400px; overflow:auto;width:100%;">
					<asp:datagrid id="dgNotes" runat="server" Width="100%" HorizontalAlign="Center" Font-Bold="false"
							ForeColor="#56a80f" Font-Name="arial" CellPadding="5" GridLines="None" AutoGenerateColumns="False"
							OnItemDataBound="dgNotes_ItemDataBound" DataKeyField="note_id">
							<HeaderStyle BackColor="#56a80f" ForeColor="#dae7ca" Font-Bold="True" HorizontalAlign="Left" />
							<Columns>
								<asp:ButtonColumn DataTextField="date" HeaderText="Date" DataTextFormatString="{0:dd MMMM yyyy}">
									<ItemStyle Width="20%" Font-Bold="True" VerticalAlign="Top"></ItemStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn DataField="note_id" Visible="False"></asp:BoundColumn>
								<asp:BoundColumn DataField="DESCRIPTION" HeaderText="Note">
									<ItemStyle Width="60%" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Account_manager" HeaderText="Last updated by">
									<ItemStyle Width="20%" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:datagrid></td>
						</DIV>
				</tr>
			</table>
			<hr width="96%">
			<table height="3%" width="96%" align="center">
				<tr>
					<td vAlign="middle" align="right" width="100%"><input class="button" id="Button1" type="button" value="Add" name="Button1" runat="server">
						<!--<input class="button" type="button" value="Cancel" />--></td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>