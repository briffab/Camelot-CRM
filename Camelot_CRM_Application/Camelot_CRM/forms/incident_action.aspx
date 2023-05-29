<%@ Page language="c#" Codebehind="incident_action.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.incident_action" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<!--#include file="head.aspx" -->
	<body>
		<form id="Form1" method="post" runat="server">
			<table width="96%" height="54" align="center">
				<tr>
					<td class="logon">
						<asp:Label id="Label1" runat="server" Font-Size="20pt">Incident Action</asp:Label>
					</td>
				</tr>
			</table>
			<table width="96%" align="center" border="0" height="209">
				<tr>
					<td width="30%" class="logon">Date Entered</td>
					<td width="70%" class="data"><asp:label id="lblDate" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td width="30%" class="logon">Status</td>
					<td width="70%" class="data"><asp:dropdownlist id="cmbStatus" runat="server" Width="184" CssClass="logon"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td width="30%" class="logon" height="25">Action Undertaken</td>
					<td width="70%" class="data" height="25"><asp:dropdownlist id="cmbAct" runat="server" Width="184" CssClass="logon"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td valign="top" width="30%" class="logon" height="25">Description</td>
					<td width="70%" class="data" height="25"><asp:textbox id="txtDesc" height="75px" runat="server" Width="100%" TextMode="MultiLine"></asp:textbox></td>
				</tr>
				<tr>
					<td width="30%" class="logon">Responsible</td>
					<td width="70%" class="data"><asp:dropdownlist id="cmbResp" runat="server" Width="184" CssClass="logon"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td class="logon" width="249" height="25"><asp:label id="Label8" runat="server">On Website</asp:label></td>
					<td class="data" width="60%" height="25"><asp:checkbox id="chkWeb" runat="server"></asp:checkbox></td>
				</tr>
				<tr>
					<td class="logon" width="249" height="25"><asp:label id="lblUpBy" runat="server">Entered by</asp:label></td>
					<td class="data" width="60%" height="25"><asp:label id="lblUby" runat="server"></asp:label></td>
				</tr>
			</table>
			<table width="96%" height="30" align="center">
				<tr>
					<td vAlign="middle" align="left" width="50%"><asp:button id="btnClose" runat="server" CssClass="button" Text="Close"></asp:button></td>
					<td width="50%" valign="middle" align="right"><asp:button id="btnEdit" runat="server" CssClass="button" Text="Edit"></asp:button>&nbsp;<asp:button id="btnUpdate" runat="server" CssClass="button" Text="Update"></asp:button>&nbsp;
						<asp:button id="btnCancel" runat="server" CssClass="button" Text="Cancel"></asp:button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
