<%@ Page language="c#" Codebehind="employeedetails.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.employeedetails" %>
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
					<td class="logon" width="30%" height="14"><asp:label id="Label1" runat="server" Font-Size="20pt">Employee Details</asp:label></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center" border="0">
				<tr>
					<td vAlign="top" width="50%">
						<table width="100%" valign="top">
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="lblfacdesc" runat="server">First Name</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtfname" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label2" runat="server">Last Name</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtlname" runat="server" Width="184px"></asp:textbox><asp:label id="Label29" runat="server" Font-Size="Larger" ForeColor="Red" Font-Names="Arial"
										Font-Bold="True">*</asp:label></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label3" runat="server">Telephone</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtwktel" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label5" runat="server">Work Mobile</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtwkmobile" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label15" runat="server">Private Mobile</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtHmmobile" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label8" runat="server">Email</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtHmemail" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label4" runat="server">Job Title</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtJob" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="25"><asp:label id="Label9" runat="server">Account Manager</asp:label></td>
								<td class="data" width="60%" height="25"><asp:checkbox id="chkAcc" runat="server"></asp:checkbox></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="25"><asp:label id="Label6" runat="server">Active</asp:label></td>
								<td class="data" width="60%" height="25"><asp:checkbox id="chkAct" runat="server"></asp:checkbox></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="25"><asp:label id="Label7" runat="server">Edit Permisions</asp:label></td>
								<td class="data" width="60%" height="25"><asp:checkbox id="chkEdp" runat="server"></asp:checkbox></td>
							</tr>
						</table>
					</td>
					<td vAlign="top" width="50%">
						<table cellPadding="0" width="100%">
							<tr>
								<td class="logon" width="249" height="25"><asp:label id="lblUpBy" runat="server">Last Updated by</asp:label></td>
								<td class="data" width="60%" height="25"><asp:label id="lblUby" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="25"><asp:label id="lblUpOn" runat="server">Last Updated on </asp:label></td>
								<td class="data" width="60%" height="25"><asp:label id="lblUDate" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td class="data" align="center" width="100%" colSpan="2"><asp:image id="imgMainPhoto" runat="server" Width="240px" CssClass="photo" Height="160px"></asp:image></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<hr width="96%">
			<table height="30" width="96%" align="center">
				<tr>
					<td vAlign="middle" align="left" width="8%"><asp:button id="btnClose" runat="server" CssClass="button" Text="Close"></asp:button></td>
					<td vAlign="middle" align="right" width="15%">&nbsp;<asp:button id="btnEdit" runat="server" CssClass="button" Text="Edit"></asp:button><asp:button id="btnUpdate" runat="server" CssClass="button" Text="Update"></asp:button>&nbsp;
						<asp:button id="btnCancel" runat="server" CssClass="button" Text="Cancel"></asp:button></td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
