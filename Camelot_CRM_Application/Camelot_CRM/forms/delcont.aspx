<%@ Page language="c#" Codebehind="delcont.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.delcont" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<%
Response.CacheControl="private";
Response.Expires=0;
Response.AddHeader("pragma", "no-cache");
%>
	<!--#include file="head.aspx" -->
	<BODY onunload="parent.location.reload(true);">
		<form id="Form1" runat="server">
			<table width="96%" align="center" border="0">
				<tr>
					<td class="logon" width="50%" height="14" align="center"><asp:label id="lblTitle" runat="server" Font-Size="12pt">This contact has correspondence, do you wish to continue ?</asp:label></td>
				</tr>
			</table>
			<table height="30" width="96%" align="center">
				<tr>
					<td vAlign="middle" align="left" width="50%">
						<asp:button id="btnCancel" runat="server" Text="Cancel" CssClass="button"></asp:button></td>
					<td vAlign="middle" align="right" width="50%"><asp:button id="btnDel" runat="server" Text="Delete" CssClass="button"></asp:button></td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
