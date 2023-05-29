<%@ Page language="c#" Codebehind="residentaddress.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.residentaddress" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<%
Response.CacheControl="private";
Response.Expires=0;
Response.AddHeader("pragma", "no-cache");
%>
	<BODY onunload="parent.location.reload(true);">
		<!--#include file="head.aspx" -->
		<form id="Form1" runat="server">
			<table width="96%" height="54" align="center">
				<tr>
					<td class="logon">
						<asp:Label id="Label3" runat="server" Font-Size="20pt">Visiting Address</asp:Label>
					</td>
				</tr>
			</table>
			<table width="96%" align="center">
				<tr>
					<td class="logon" width="30%" height="14"><asp:label id="lblTitle" runat="server"></asp:label></td>
					<td class="logon" width="70%" height="14"><asp:label id="lblMessage" runat="server" ForeColor="Red" Font-Size="Larger" Font-Names="Arial"
							Font-Bold="false"></asp:label></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center" border="0">
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
					<td class="logon" width="249" height="24"><asp:label id="Label1" runat="server">Last Updated By</asp:label></td>
					<td class="data" width="60%" height="24">&nbsp;
						<asp:Label id="lblUpd" runat="server"></asp:Label>
					</td>
				</tr>
				<tr>
					<td class="logon" width="249" height="24"><asp:label id="Label2" runat="server">Last Updated on</asp:label></td>
					<td class="data" width="60%" height="24">&nbsp;
						<asp:Label id="lblUpdDate" runat="server"></asp:Label>
					</td>
				</tr>
			</table>
			<hr width="96%">
			<table height="30" width="96%" align="center">
				<tr>
					<td vAlign="middle" align="left" width="25%"><asp:button id="btnClose" runat="server" CssClass="button" Text="Close"></asp:button></td>
					<td vAlign="middle" align="right" width="25%"><asp:button id="btnEdit" runat="server" CssClass="button" Text="Edit"></asp:button><asp:button id="btnUpdate" runat="server" CssClass="button" Text="Update"></asp:button>&nbsp;
						<asp:button id="btnCancel" runat="server" CssClass="button" Text="Cancel"></asp:button></td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>

