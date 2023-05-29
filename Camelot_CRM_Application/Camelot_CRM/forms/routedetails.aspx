<%@ Page language="c#" Codebehind="routedetails.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.routedetails" %>
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
					<td class="logon"><asp:label id="Label3" runat="server" Font-Size="20pt">Route Details</asp:label></td>
					<td class="logon" width="70%" height="14"><asp:label id="lblMessage" runat="server" ForeColor="Red" Font-Size="Larger" Font-Names="Arial"
							Font-Bold="false"></asp:label></td>
				</tr>
			</table>
			<hr align="center" width="96%">
			<table height="30" width="96%" align="center">
				<tr>
					<td class="logon" width="20%" height="24"><asp:label id="lblName" runat="server">Route Name</asp:label></td>
					<td class="data" width="40%" height="24"><asp:textbox id="txtName" runat="server" Width="250px"></asp:textbox><asp:label id="lblNameStar" runat="server" ForeColor="Red" Font-Size="Larger" Font-Names="Arial"
							Font-Bold="True">*</asp:label></td>
				</tr>
				<tr>
					<td class="logon" width="20%" height="24"><asp:label id="Label4" runat="server">In Use</asp:label></td>
					<td class="data" width="40%" height="24"><asp:checkbox id="chkRoute" runat="server"></asp:checkbox></td>
				</tr>
				<tr>
					<td class="logon" width="20%" height="24"><asp:label id="Label6" runat="server">Last Printed</asp:label></td>
					<td class="data" width="40%" height="24"><asp:label id="lblLast" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td class="logon" width="20%" height="24"><asp:label id="Label5" runat="server">Number of Properties</asp:label></td>
					<td class="data" width="40%" height="24"><asp:label id="txtNum" runat="server"></asp:label></td>
				</tr>
			</table>
			<hr align="center" width="96%">
			<table width="96%" align="center">
				<tr>
					<td class="logon" width="40%" colspan="2"><asp:label id="Label1" runat="server">Properties on Route</asp:label></td>
					<td width="10%"></td>
					<td class="logon" width="40%" colspan="2"><asp:label id="Label2" runat="server">Other Properties</asp:label></td>
				</tr>
				<tr>
					<td width="5%">
						<table height="30" width="96%" align="center">
							<tr>
								<td vAlign="middle" align="center"><asp:button id="btnRup" runat="server" Text="▲" CssClass="button" Width="50"></asp:button></td>
							</tr>
							<tr>
								<td vAlign="middle" align="center"><asp:button id="btnRdown" runat="server" Text="▼" CssClass="button" Width="50"></asp:button></td>
							</tr>
						</table>
					</td>
					<td width="40%"><asp:listbox id="lbOnRoute" runat="server" Width="100%" SelectionMode="Multiple" Rows="15"></asp:listbox></td>
					<td width="5%">
						<table height="30" width="96%" align="center">
							<tr>
								<td vAlign="middle" align="center"><asp:button id="btnMto" runat="server" Text="►" CssClass="button" Width="50"></asp:button></td>
							</tr>
							<tr>
								<td vAlign="middle" align="center"><asp:button id="btnMfrom" runat="server" Text="◄" CssClass="button" Width="50"></asp:button></td>
							</tr>
						</table>
					</td>
					<td width="40%"><asp:listbox id="lbNotRoute" runat="server" Width="100%" SelectionMode="Multiple" Rows="15"></asp:listbox></td>
				</tr>
			</table>
			<table height="30" width="96%" align="center">
				<tr>
					<td vAlign="middle" align="left" width="25%"><asp:button id="btnClose" runat="server" Text="Close" CssClass="button"></asp:button></td>
					<td vAlign="middle" align="right" width="25%"><asp:button id="btnUpdate" runat="server" Text="Update" CssClass="button"></asp:button></td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
