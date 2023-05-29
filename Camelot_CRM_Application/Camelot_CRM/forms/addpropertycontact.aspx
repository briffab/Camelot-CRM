<%@ Page language="c#" Codebehind="addpropertycontact.aspx.cs" AutoEventWireup="false" Inherits="Camelot.addpropertycontact" %>
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
			<table width="96%" height="54" align="center">
				<tr>
					<td class="logon">
						<asp:Label id="Label6" runat="server" Font-Size="20pt">New Property Contact</asp:Label>
					</td>
				</tr>
			</table>
			<table width="96%" align="center">
				<tr>
					<td class="logon" width="147"><asp:label id="Label1" runat="server" Width="136px">Find Company</asp:label></td>
					<td class="data" width="60%"><asp:textbox id="txtFCompany" runat="server" Width="184px"></asp:textbox>&nbsp;<asp:button id="Button1" runat="server" Text="Find" CssClass="button"></asp:button></td>
				</tr>
				<tr>
					<td></td>
					<td class="logon" width="147"><asp:listbox id="lbCompanies" runat="server" Height="112px" width="350px" AutoPostBack="True"></asp:listbox></td>
				</tr>
				<TR>
					<td class="logon" width="249" height="21"><asp:label id="Label4" runat="server">Contact</asp:label></td>
					<td class="data" width="60%" height="21"><asp:dropdownlist id="cmbcontact" runat="server" Width="184" CssClass="logon" AutoPostBack="True"></asp:dropdownlist>&nbsp;</td>
				</TR>
			</table>
			<hr width="96%">
			<table width="96%" align="center" border="0">
				<tr>
					<td vAlign="top" width="50%">
						<table width="100%" valign="top">
							<TBODY>
								<tr vAlign="top">
									<td class="logon" width="249" height="21"><asp:label id="lblfacdesc" runat="server">Name</asp:label></td>
									<td class="data" width="60%" height="21"><asp:label id="LabelName" runat="server"></asp:label></td>
								</tr>
								<tr vAlign="top">
									<td class="logon" width="249" height="21"><asp:label id="Label5" runat="server">Mobile</asp:label></td>
									<td class="data" width="60%" height="21"><asp:label id="lblMobile" runat="server"></asp:label></td>
					</td>
				</tr>
				<tr vAlign="top">
					<td class="logon" width="249" height="21"><asp:label id="Label9" runat="server">Job Title</asp:label></td>
					<td class="data" width="60%" height="21"><asp:label id="lblJob" runat="server"></asp:label></td></TD></tr>
				<tr vAlign="top">
					<td class="logon" width="249" height="25"><asp:label id="Label11" runat="server">Contact Types</asp:label></td>
					<td class="logon" width="60%"><asp:listbox id="lbTypes" runat="server" Width="224px" Height="96px" SelectionMode="Multiple"
							Rows="8"></asp:listbox></td>
				</tr>
			</table></TD>
			<td vAlign="top" width="50%">
				<table cellPadding="0" width="100%">
					<TBODY>
						<tr vAlign="top">
							<td class="logon" width="249" height="21"><asp:label id="Label3" runat="server">Wk Telephone</asp:label></td>
							<td class="data" width="60%" height="21"><asp:label id="lblWkTel" runat="server"></asp:label></td>
						</tr>
						<tr vAlign="top">
							<td class="logon" width="249" height="21"><asp:label id="Label8" runat="server">Email</asp:label></td>
							<td class="data" width="60%" height="21"><asp:label id="lblEmail" runat="server"></asp:label></td>
						</tr>
						<tr vAlign="top">
							<td class="logon" width="249" height="21"><asp:label id="Label2" runat="server">Status</asp:label></td>
							<td class="data" width="60%" height="21"><asp:label id="lblStatus" runat="server"></asp:label></td>
			</td></TR>
			<tr vAlign="top">
				<td class="logon" width="249" height="46"><asp:label id="Label7" runat="server">Notes</asp:label></td>
				<td class="data" width="60%" height="46"><asp:textbox id="txtnotes" runat="server" Width="224px" Height="96px" TextMode="MultiLine"></asp:textbox></td>
			</tr></TBODY></TABLE></TD></TR></TBODY></TABLE>
			<hr width="96%">
			<table height="30" width="96%" align="center">
				<tr>
					<td vAlign="middle" align="left" width="50%"><asp:button id="btnClose" runat="server" Text="Close" CssClass="button"></asp:button></td>
					<td vAlign="middle" align="right" width="100%">&nbsp;&nbsp;
						<asp:button id="btnAdd" runat="server" Text="Add" CssClass="button"></asp:button></td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>