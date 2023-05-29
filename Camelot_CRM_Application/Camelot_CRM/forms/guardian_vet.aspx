<%@ Page language="c#" Codebehind="guardian_vet.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.guardian_vet" %>
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
			<table width="96%" align="center">
				<tr>
					<td class="Logon" width="100%"><asp:label id="Label1" runat="server" Font-Size="20pt" Font-Names="Arial" Font-Bold="false">Guardian Placement Criteria</asp:label></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center">
				<tr>
					<td class="Logon" width="30%"><asp:label id="lblTitle" runat="server" Font-Names="Arial" Font-Bold="false"></asp:label></td>
					<td class="logon" vAlign="bottom" width="70%" height="14"><asp:label id="lblMessage" runat="server" Font-Size="Larger" Font-Names="Arial" Font-Bold="false"
							ForeColor="Red"></asp:label></td>
				</tr>
			</table>
			<hr width="96%">
			<table height="30" width="96%" align="center">
				<tr>
					<td class="data" align="left" width="33%" height="25"><asp:checkbox id="chkApp" runat="server" Font-Bold="True" AutoPostBack="True" Text="Application"></asp:checkbox></td>
					<td class="data" align="left" width="33%" height="25"><asp:checkbox id="chkPhoto" runat="server" Font-Bold="True" AutoPostBack="True" Text="Photo ID"></asp:checkbox></td>
					<td class="data" align="left" width="33%" height="25"><asp:checkbox id="chkRef" runat="server" Font-Bold="True" AutoPostBack="True" Text="References"></asp:checkbox></td>
				</tr>
				<tr>
					<td class="data" align="left" width="33%" height="25"><asp:checkbox id="chkBank" runat="server" Font-Bold="True" AutoPostBack="True" Text="Bank Statement / Utility"></asp:checkbox></td>
					<td class="data" align="left" width="33%" height="25"><asp:checkbox id="chkLic" runat="server" Font-Bold="True" AutoPostBack="True" Text="License"></asp:checkbox></td>
					<td class="data" align="left" width="33%" height="25"><asp:checkbox id="chkBook" runat="server" Font-Bold="True" AutoPostBack="True" Text="Booklet Given"></asp:checkbox></td>
				</tr>
				<tr>
					<td class="data" align="left" width="33%" height="25"><asp:checkbox id="chkSO" runat="server" Font-Bold="True" AutoPostBack="True" Text="Standing Order"></asp:checkbox></td>
					<td class="data" align="left" width="33%" height="25"><asp:checkbox id="chkED" runat="server" Font-Bold="True" AutoPostBack="True" Text="Executive Decision"></asp:checkbox></td>
					<td vAlign="middle" align="right" width="30%"></td>
				</tr>
			</table>
			<table height="30" width="96%" align="center">
				<tr>
					<td class="logon" align="left" width="33%" height="21"><asp:label id="Label27" runat="server">Notes</asp:label></td>
					<td class="logon" align="left" width="33%" height="25"><asp:label id="Label31" runat="server">In Outlook</asp:label></td>
					<td class="logon" align="left" width="33%" height="21"><asp:label id="Label28" runat="server">For date</asp:label></td>
				</tr>
				<tr>
					<td class="data" width="33%" height="21"><asp:textbox id="txtNotes" runat="server" TextMode="MultiLine" Height="88px" Width="100%"></asp:textbox></td>
					<td class="data" vAlign="top" align="left" width="33%" height="25"><asp:checkbox id="chkOut" runat="server" AutoPostBack="True"></asp:checkbox></td>
					<td class="data" vAlign="top" align="left" width="33%" height="21"><asp:textbox id="txtDate" runat="server" Width="184px"></asp:textbox>&nbsp;<asp:label id="Label30" runat="server" Font-Size="Larger" Font-Names="Arial" Font-Bold="True"
							ForeColor="Red">*</asp:label>
					</td>
				</tr>
			</table>
			<hr width="96%">
			<table height="30" width="96%" align="center">
				<tr>
					<td vAlign="middle" align="left" width="25%"><asp:button id="btnClose" runat="server" CssClass="button" Text="Close"></asp:button></td>
					<td vAlign="middle" align="center" width="25%"><asp:button id="btnScan" runat="server" CssClass="button" Text="Scans"></asp:button></td>
					<td vAlign="middle" align="right" width="25%"><asp:button id="btnEdit" runat="server" CssClass="button" Text="Edit"></asp:button><asp:button id="btnUpdate" runat="server" CssClass="button" Text="Update"></asp:button>&nbsp;
						<asp:button id="btnCancel" runat="server" CssClass="button" Text="Cancel"></asp:button></td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
