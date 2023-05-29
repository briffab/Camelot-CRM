<%@ Page language="c#" Codebehind="propertycontactdetails.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.propertycontactdetails" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
	<%
Response.CacheControl="private";
Response.Expires=0;
Response.AddHeader("pragma", "no-cache");
%>
	<BODY onunload="parent.location.reload(true);">
		<!--#include file="head.aspx" -->
		<form id="Form1" runat="server">
			<table width="96%" align="center">
				<tr>
					<td class="logon" width="100%"><asp:label id="Label1" runat="server">Property Contact Details</asp:label></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center" border="0">
				<tr>
					<td vAlign="top" width="50%">
						<table width="100%" valign="top">
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="lblfacdesc" runat="server">Name</asp:label></td>
								<td class="data" width="60%" height="21"><asp:label id="LabelName" runat="server"></asp:label></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label4" runat="server">Company</asp:label></td>
								<td class="data" width="60%" height="21"><asp:label id="lblComp" runat="server"></asp:label></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label9" runat="server">Job Title</asp:label></td>
								<td class="data" width="60%" height="21"><asp:label id="lblJob" runat="server"></asp:label></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label3" runat="server">Wk Telephone</asp:label></td>
								<td class="data" width="60%" height="21"><asp:label id="lblWkTel" runat="server"></asp:label></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label2" runat="server">Fax</asp:label></td>
								<td class="data" width="60%" height="21"><asp:label id="lblFax" runat="server"></asp:label></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label6" runat="server">Mobile</asp:label></td>
								<td class="data" width="60%" height="21"><asp:label id="lblMob" runat="server"></asp:label></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label8" runat="server">Email</asp:label></td>
								<td class="data" width="60%" height="21"><asp:label id="lblEmail" runat="server"></asp:label></td>
							</tr>
						</table>
					<td vAlign="top" width="50%">
						<table cellPadding="0" width="100%">
							<tr vAlign="top">
								<td class="logon" width="249" height="25"><asp:label id="Label11" runat="server">Contact Types</asp:label></td>
								<td class="logon" width="60%"><asp:listbox id="lbTypes" runat="server" Width="224px" Height="96px" SelectionMode="Multiple"
										Rows="8"></asp:listbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="46"><asp:label id="Label7" runat="server">Notes</asp:label></td>
								<td class="data" width="60%" height="46"><asp:textbox id="txtnotes" runat="server" Width="224px" Height="96px" TextMode="MultiLine"></asp:textbox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<hr width="96%">
			<table height="30" width="96%" align="center">
				<tr>
					<td vAlign="middle" align="left" width="33%"><asp:button id="btnClose" runat="server" Text="Close" CssClass="button"></asp:button></td>
					<td vAlign="middle" align="center" width="33%"><asp:button id="btnRemove" runat="server" Text="Remove" CssClass="button"></asp:button></td>
					<td vAlign="middle" align="right" width="33%">&nbsp;<asp:button id="btnEdit" runat="server" CssClass="button" Text="Edit"></asp:button><asp:button id="btnUpdate" runat="server" CssClass="button" Text="Update"></asp:button>&nbsp;
						<asp:button id="btnCancel" runat="server" CssClass="button" Text="Cancel"></asp:button></td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>