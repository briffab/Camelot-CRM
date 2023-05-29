<%@ Page language="c#" Codebehind="mailmerge.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.mailmerge" %>
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
					<td class="logon"><asp:label id="Label3" runat="server" Font-Size="20pt">Mail Merge</asp:label></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center" border="0">
				<tr vAlign="top">
					<td class="logon" width="249" height="21"><asp:label id="lblDocName" runat="server">Document List Name</asp:label></td>
					<td class="data" width="60%" height="21"><asp:label id="lblDoc" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td class="logon" width="249" height="25"><asp:label id="lblRecs" runat="server">Number of Recipients</asp:label></td>
					<td class="data" width="60%" height="25"><asp:label id="lblnrecs" runat="server"></asp:label></td>
				</tr>
				<tr vAlign="top">
					<td class="logon" width="249" height="21"><asp:label id="Label6" runat="server">Merge Field 1</asp:label></td>
					<td class="data" width="60%" height="21"><asp:textbox id="txtMerge1" runat="server" TextMode="SingleLine" Width="272px"></asp:textbox></td>
				</tr>
				<tr vAlign="top">
					<td class="logon" width="249" height="21"><asp:label id="Label1" runat="server">Merge Field 2</asp:label></td>
					<td class="data" width="60%" height="21"><asp:textbox id="txtMerge2" runat="server" TextMode="SingleLine" Width="272px"></asp:textbox></td>
				</tr>
				<tr vAlign="top">
					<td class="logon" width="249" height="21"><asp:label id="Label2" runat="server">Merge Field 3</asp:label></td>
					<td class="data" width="60%" height="21"><asp:textbox id="txtMerge3" runat="server" TextMode="SingleLine" Width="272px"></asp:textbox></td>
				</tr>
				<tr vAlign="top">
					<td class="logon" width="249" height="21"><asp:label id="Label4" runat="server">Merge Field 4</asp:label></td>
					<td class="data" width="60%" height="21"><asp:textbox id="txtMerge4" runat="server" TextMode="SingleLine" Width="272px"></asp:textbox></td>
				</tr>
				<tr vAlign="top">
					<td class="logon" width="249" height="21"><asp:label id="Label5" runat="server">Merge Field 5</asp:label></td>
					<td class="data" width="60%" height="21"><asp:textbox id="txtMerge5" runat="server" TextMode="SingleLine" Width="272px"></asp:textbox></td>
				</tr>
				<tr vAlign="top">
					<td class="logon" width="249" height="21"><asp:label id="Label7" runat="server">Merge Field 6</asp:label></td>
					<td class="data" width="60%" height="21"><asp:textbox id="txtMerge6" runat="server" TextMode="SingleLine" Width="272px"></asp:textbox></td>
				</tr>
			</table>
			<hr width="96%">
			<table height="30" width="96%" align="center">
				<tr>
					<td vAlign="middle" align="left" width="50%"><asp:button id="btnCancel" runat="server" Text="Cancel" CssClass="button"></asp:button></td>
					<td vAlign="middle" align="right" width="50%"><asp:button id="btnMerge" runat="server" Text="Merge" CssClass="button"></asp:button></td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
