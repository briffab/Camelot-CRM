<%@ Page language="c#" Codebehind="placeGuard_UK.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.placeGuard_UK" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<%
Response.CacheControl="private";
Response.Expires=0;
Response.AddHeader("pragma", "no-cache");
%>
	<!--#include file="head.aspx" -->
	<BODY>
		<form id="Form1" runat="server">
			<table width="96%" align="center" border="0">
				<tr>
					<td class="logon" width="50%" height="14"><asp:label id="lblTitle" runat="server" Font-Size="20pt">Place Guardian</asp:label></td>
					<td class="logon" width="50%" height="14" valign="top"><asp:label id="lblMessage" runat="server" ForeColor="Red" Font-Bold="false" Font-Names="Arial"
							Font-Size="Larger"></asp:label></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center" valign="top">
				<tr vAlign="top">
					<td class="logon" width="50%" height="21"><asp:label id="lbldate" runat="server">Date of Placement</asp:label></td>
					<td class="data" width="50%" height="21">
						<asp:textbox id="txtDate" runat="server" Width="184px"></asp:textbox>&nbsp;<asp:label id="Label11" runat="server" ForeColor="Red" Font-Bold="True" Font-Names="Arial"
							Font-Size="Larger">*</asp:label></td>
				</tr>
				<tr vAlign="top">
					<td class="logon" width="50%" height="21"><asp:label id="Label1" runat="server">New Guardian Name</asp:label></td>
					<td class="logon" width="50%" height="21"><asp:label id="lblGName" runat="server"></asp:label></td>
				</tr>
				<tr vAlign="top">
					<td class="logon" width="50%" height="21"><asp:label id="Label2" runat="server">Property</asp:label></td>
					<td class="data" width="60%" height="21"><asp:dropdownlist id="cmbProp" runat="server" Width="184" CssClass="logon"></asp:dropdownlist>
					</td>
				</tr>
				<tr vAlign="top">
					<td class="logon" width="50%" height="21"><asp:label id="Label3" runat="server">Room</asp:label></td>
					<td class="data" width="50%" height="21">
						<asp:textbox id="txtRoom" runat="server" Width="184px"></asp:textbox></td>
				</tr>
			</table>
			<hr width="96%">
			<table height="30" width="96%" align="center">
				<tr>
					<td vAlign="middle" align="right" width="100%"><asp:button id="btnPlace" runat="server" Text="Place" CssClass="button"></asp:button>&nbsp;
						<asp:button id="btnCancel" runat="server" Text="Cancel" CssClass="button"></asp:button></td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
