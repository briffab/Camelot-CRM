<%@ Page language="c#" Codebehind="corrdetail.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.corrdetail" %>
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
					<td class="logon"><asp:label id="Label4" runat="server" Font-Size="20pt">Correspondence Details</asp:label></td>
				</tr>
			</table>
			<table width="96%" align="center">
				<tr>
					<td class="logon" width="30%" height="14"><asp:label id="lblTitle" runat="server"></asp:label></td>
					<td class="logon" width="70%" height="14"></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center" border="0">
				<tr>
					<td vAlign="top" width="50%">
						<table width="100%" valign="top">
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="lblfacdesc" runat="server">Type</asp:label></td>
								<td class="data" width="60%" height="21">
									<asp:label id="lblType" runat="server" Width="224px"></asp:label></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label1" runat="server">Date</asp:label></td>
								<td class="data" width="60%" height="21">
									<asp:label id="lblDate" runat="server" Width="224px"></asp:label></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label3" runat="server">Direction</asp:label></td>
								<td class="data" width="60%" height="21">
									<asp:label id="lblDir" runat="server" Width="224px"></asp:label></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label5" runat="server">Bulk</asp:label></td>
								<td class="data" width="60%" height="21">
									<asp:label id="lblBulk" runat="server" Width="224px"></asp:label></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="40"><asp:label id="Label2" runat="server">Document</asp:label></td>
								<td class="data" width="60%" height="40" valign="middle">
									<asp:label id="lblDoc" runat="server" Width="224px" Height="40px"></asp:label>&nbsp;<asp:button id="btnView" runat="server" CssClass="button" Text="View"></asp:button></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="25"><asp:label id="Label11" runat="server">Recipients</asp:label></td>
								<td class="logon" width="60%"><asp:listbox id="lbRecipients" SelectionMode="Multiple" Width="300px" Height="150px" runat="server"></asp:listbox></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="25"><asp:label id="lblUpBy" runat="server">Sent by</asp:label></td>
								<td class="data" width="60%" height="25"><asp:label id="lblUby" runat="server"></asp:label></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<hr width="96%">
			<table height="30" width="96%" align="center">
				<tr>
					<td vAlign="middle" align="left" width="50%"><asp:button id="btnClose" runat="server" CssClass="button" Text="Close"></asp:button></td>
					<td vAlign="middle" align="right" width="50%"><asp:button id="btnCall" runat="server" CssClass="button" Text="Callback"></asp:button></td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
