<%@ Page language="c#" Codebehind="doc_admin.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.doc_admin" %>
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
			<table height="54" width="96%" align="center">
				<tr>
					<td class="logon"><asp:label id="Label3" runat="server" Font-Size="20pt">Mail Merge Documents</asp:label></td>
				</tr>
			</table>
			<table width="96%" align="center">
				<tr>
					<td class="logon" width="100%" height="14"><asp:label id="lblMessage" runat="server" Font-Size="Larger" Font-Bold="false" Font-Names="Arial"
							ForeColor="Red"></asp:label></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center" border="0">
				<tr vAlign="top">
					<td class="logon" width="249" height="21"><asp:label id="lblDocName" runat="server">Document List Name</asp:label></td>
					<td class="data" width="60%" height="21"><asp:textbox id="txtDocName" runat="server" Width="184px"></asp:textbox><asp:label id="lblNameStar" runat="server" Font-Size="Larger" Font-Bold="True" Font-Names="Arial"
							ForeColor="Red">*</asp:label></td>
				</tr>
				<tr vAlign="top">
					<td class="logon" width="249" height="21"><asp:label id="Label1" runat="server">Document</asp:label></td>
					<td class="data" width="60%" height="21"><asp:label id="lblDoc" runat="server"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="btnChange" runat="server" CssClass="button" Text="Change"></asp:button></td>
				</tr>
				<tr>
					<td class="logon" width="249" height="21"><asp:label id="Label5" runat="server">Document Type</asp:label></td>
					<td class="data" width="60%" height="21"><asp:dropdownlist id="cmbType" runat="server" CssClass="logon" Width="184"></asp:dropdownlist></td>
				</tr>
				<tr vAlign="top">
					<td class="logon" width="249" height="21"><asp:label id="Label6" runat="server">Description</asp:label></td>
					<td class="data" width="60%" height="21"><asp:textbox id="txtnotes" runat="server" Width="272px" TextMode="MultiLine" Height="72px"></asp:textbox></td>
				</tr>
				<tr>
					<td class="logon" width="249" height="25"><asp:label id="lblUpBy" runat="server">Last Updated by</asp:label></td>
					<td class="data" width="60%" height="25"><asp:label id="lblUby" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td class="logon" width="249" height="25"><asp:label id="lblUpOn" runat="server">Last Updated on </asp:label></td>
					<td class="data" width="60%" height="25"><asp:label id="lblUDate" runat="server"></asp:label></td>
				</tr>
			</table>
			<hr width="96%">
			<table height="30" width="96%" align="center">
				<tr>
					<td vAlign="middle" align="left" width="33%"><asp:button id="btnClose" runat="server" CssClass="button" Text="Close"></asp:button></td>
					<td vAlign="middle" align="center" width="33%"><asp:button id="btnView" runat="server" CssClass="button" Text="View"></asp:button></td>
					<td vAlign="middle" align="right" width="33%"><asp:button id="btnEdit" runat="server" CssClass="button" Text="Edit"></asp:button><asp:button id="btnUpdate" runat="server" CssClass="button" Text="Update"></asp:button>&nbsp;
						<asp:button id="btnCancel" runat="server" CssClass="button" Text="Cancel"></asp:button></td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
