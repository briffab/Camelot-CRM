<%@ Page language="c#" Codebehind="propertynotedetails.aspx.cs" AutoEventWireup="false" Inherits="Camelot.propertynotedetails" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<%
Response.CacheControl="private";
Response.Expires=0;
Response.AddHeader("pragma", "no-cache");
%>
	<BODY>
		<!--#include file="head.aspx" -->
		<form id="Form1" runat="server">
			<table width="96%" align="center">
				<tr>
					<td class="logon">
						<asp:Label id="Label10" runat="server" Font-Size="20pt">Property Note</asp:Label>
					</td>
				</tr>
			</table>
			<hr width="96%">
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
					<td vAlign="top" width="50%">
						<table width="100%" valign="top">
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label6" runat="server">Description</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtDesc" runat="server" Width="100%" Height="120px" TextMode="MultiLine"></asp:textbox></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="25"><asp:label id="Label9" runat="server">In Outlook</asp:label></td>
								<td class="data" width="60%" height="25"><asp:checkbox id="chkOutlook" runat="server"></asp:checkbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label1" runat="server">Calendar Date</asp:label></td>
								<td class="data" width="60%" height="21">
									<asp:textbox id="txtOdate" runat="server" Width="272px"></asp:textbox>&nbsp;<asp:label id="lblDateStar" runat="server" ForeColor="Red" Font-Size="Larger" Font-Names="Arial"
										Font-Bold="True">*</asp:label></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="25"><asp:label id="Label3" runat="server">Include in Inspection</asp:label></td>
								<td class="data" width="60%" height="25"><asp:checkbox id="chkInsp" runat="server"></asp:checkbox></td>
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
					</td>
				</tr>
			</table>
			<hr width="96%">
			<table height="20" width="96%" align="center">
				<tr>
					<td vAlign="middle" align="left" width="50%"><asp:button id="btnClose" runat="server" CssClass="button" Text="Close"></asp:button></td>
					<td vAlign="middle" align="right" width="100%"><asp:button id="btnEdit" runat="server" CssClass="button" Text="Edit"></asp:button><asp:button id="btnUpdate" runat="server" CssClass="button" Text="Update"></asp:button>&nbsp;
						<asp:button id="btnCancel" runat="server" CssClass="button" Text="Cancel"></asp:button></td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
