<%@ Page language="c#" Codebehind="mergefields.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.mergefields" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<%
Response.CacheControl="private";
Response.Expires=0;
Response.AddHeader("pragma", "no-cache");
%>
	<!--#include file="head.aspx" -->
	<script language="javascript">
		function Done()
		{
			window.close();		
		}
	</script>
	<BODY onunload="parent.location.reload(true);">
		<form id="Form1" method="post" runat="server">
			<table height="54" width="96%" align="center">
				<tr>
					<td class="logon"><asp:label id="Label3" runat="server" Font-Size="20pt">Merge Fields</asp:label></td>
					<td class="logon" width="70%" height="14"><asp:label id="lblMessage" runat="server" Font-Size="Larger" Font-Bold="false" Font-Names="Arial"
							ForeColor="Red"></asp:label></td>
				</tr>
			</table>
			<hr align="center" width="96%">
			<table height="30" width="96%" align="center">
				<tr>
					<td class="logon" width="20%" height="24"><asp:label id="lblField" runat="server">Field Name</asp:label></td>
					<td class="data" width="40%" height="24"><asp:textbox id="txtField" runat="server" Width="250px"></asp:textbox></td>
					<td vAlign="middle" align="left" width="25%"><asp:button id="btnAdd" runat="server" CssClass="button" Text="Add"></asp:button></td>
				</tr>
			</table>
			<hr align="center" width="96%">
			<table width="96%" align="center">
				<tr>
					<td width="5%">
						<table height="30" width="96%" align="center">
							<tr>
								<td vAlign="middle" align="center"><asp:button id="btnRup" runat="server" Width="50" CssClass="button" Text="▲"></asp:button></td>
							</tr>
							<tr>
								<td vAlign="middle" align="center"><asp:button id="btnRdown" runat="server" Width="50" CssClass="button" Text="▼"></asp:button></td>
							</tr>
						</table>
					</td>
					<td width="40%"><asp:listbox id="lbMergeFields" runat="server" Width="100%" Rows="15" SelectionMode="Multiple"></asp:listbox></td>
					<td vAlign="bottom" align="left" width="25%"><asp:button id="btnRemove" runat="server" CssClass="button" Text="Remove"></asp:button></td>
				</tr>
			</table>
			<table height="30" width="96%" align="center">
				<tr>
					<td vAlign="middle" align="left" width="25%"><asp:button id="btnClose" runat="server" CssClass="button" Text="Close"></asp:button></td>
					<td vAlign="middle" align="center" width="50%"><asp:button id="btnCsv" runat="server" Width="250" CssClass="button" Text="Open CSV Template"></asp:button></td>
					<td vAlign="middle" align="right" width="25%"><asp:button id="btnUpdate" runat="server" CssClass="button" Text="Update"></asp:button></td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
