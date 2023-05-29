<%@ Page language="c#" Codebehind="routedate.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.routedate" %>
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
					<td class="logon" width="40%" height="14"><asp:label id="lblTitle" runat="server" Font-Size="20pt">Route Inspection Date</asp:label></td>
					<td class="logon" width="60%" height="14"><asp:label id="lblMessage" runat="server" Font-Bold="false" Font-Names="Arial" Font-Size="Larger"
							ForeColor="Red"></asp:label></td>
				</tr>
			</table>
			<table id="tblDetails" width="96%" align="center" border="0">
				<tr>
					<td class="logon" width="147"><asp:label id="Label1" runat="server" Width="136px">Date</asp:label></td>
					<td class="data" width="60%"><asp:textbox id="txtDate" runat="server" Width="184px"></asp:textbox><asp:label id="Label14" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Larger"
							ForeColor="Red">*</asp:label></td>
				</tr>
			</table>
			<hr width="96%">
			<table height="30" width="96%" align="center">
				<tr>
					<td vAlign="middle" align="left" width="50%"></td>
					<td vAlign="middle" align="right" width="100%"><asp:button id="btnPrint" runat="server" CssClass="button" Text="Print"></asp:button>&nbsp;
						<asp:button id="btnCancel" runat="server" CssClass="button" Text="Cancel"></asp:button>&nbsp;
					</td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>