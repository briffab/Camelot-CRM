<%@ Page language="c#" Codebehind="meterrates.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.meterrates" %>
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
	<BODY>
		<form id="Form1" method="post" runat="server">
			<table width="96%" height="54" align="center">
				<tr>
					<td class="logon">
						<asp:Label id="Label3" runat="server" Font-Size="20pt">Meter Rates</asp:Label>
					</td>
				</tr>
			</table>
			<table width="96%" align="center">
				<tr>
					<td class="logon"><asp:label id="Lblmeter" runat="server"></asp:label></td>
				</tr>
			</table>
			<hr align="center" width="96%">
			<table height="30" width="96%" align="center">
				<tr>
					<td class="logon" width="20%" height="24"><asp:label id="lblPost" runat="server">New Rate</asp:label></td>
					<td class="data" width="40%" height="24"><asp:textbox id="txtRate" runat="server" Width="184px"></asp:textbox></td>
					<td class="data" width="40%" height="24"><asp:button id="btnAddRate" runat="server" CssClass="button" Text="Add"></asp:button></td>
				</tr>
			</table>
			<hr align="center" width="96%">
			<table width="96%" align="center">
				<tr>
					<td class="logon" width="40%"><asp:label id="Label1" runat="server">Available Rates</asp:label></td>
					<td width="10%"></td>
					<td class="logon" width="40%"><asp:label id="Label2" runat="server">Selected Rates</asp:label></td>
				</tr>
				<tr>
					<td width="40%"><asp:listbox id="lbARates" runat="server" Rows="8" Width="100%" SelectionMode="Multiple"></asp:listbox></td>
					<td width="10%">
						<table height="30" width="96%" align="center">
							<tr>
								<td vAlign="middle" align="center"><asp:button id="btnMto" runat="server" CssClass="button" Text=">>"></asp:button></td>
							</tr>
							<tr>
								<td vAlign="middle" align="center"><asp:button id="btnMfrom" runat="server" CssClass="button" Text="<<"></asp:button></td>
							</tr>
						</table>
					</td>
					<td width="40%">
						<asp:ListBox id="lbCRates" Rows="8" runat="server" Width="100%" SelectionMode="Multiple"></asp:ListBox></td>
				</tr>
			</table>
			<table height="30" width="96%" align="center">
				<tr>
					<td vAlign="middle" align="left" width="25%"><asp:button id="btnClose" runat="server" CssClass="button" Text="Close"></asp:button></td>
					<td vAlign="middle" align="right" width="25%"><asp:button id="btnUpdate" runat="server" CssClass="button" Text="Update"></asp:button></td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
