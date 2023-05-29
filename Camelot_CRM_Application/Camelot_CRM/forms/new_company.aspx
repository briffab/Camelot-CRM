<%@ Page language="c#" Codebehind="new_company.aspx.cs" AutoEventWireup="false" Inherits="Camelot.new_company" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<%
Response.CacheControl="private";
Response.Expires=0;
Response.AddHeader("pragma", "no-cache");
%>
	<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
	<BODY onunload="parent.location.reload(true);">
		<!--#include file="head.aspx" -->
		<form id="Form1" runat="server">
			<table width="96%" align="center">
				<tr>
					<td class="logon" width="30%" height="14"><asp:label id="lblTitle" runat="server" Font-Size="20pt">New Company</asp:label></td>
					<td class="logon" width="70%" height="14"><asp:label id="lblMessage" runat="server" Font-Bold="false" ForeColor="Red" Font-Names="Arial"
							Font-Size="Larger"></asp:label></td>
				</tr>
			</table>
			<hr width="96%">
			<table id="tblDetails" width="96%" align="center" border="0">
				<tr>
					<td vAlign="top" width="50%" height="100%">
						<table width="100%">
							<tr>
								<td class="logon" width="249" height="24"><asp:label id="Label2" runat="server">Company Name</asp:label></td>
								<td class="data" width="60%" height="24">&nbsp;
									<asp:textbox id="txtCompName" runat="server" Width="184px"></asp:textbox>
									<asp:label id="lblCompStar" runat="server" Font-Size="Larger" Font-Names="Arial" ForeColor="Red"
										Font-Bold="True">*</asp:label></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="24"><asp:label id="lblAddress" runat="server">Address</asp:label></td>
								<td class="data" width="60%" height="24">&nbsp;
									<asp:textbox id="txtAddress1" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td width="249" height="24"></td>
								<td class="data" width="60%" height="24">&nbsp;
									<asp:textbox id="txtAddress2" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td width="249" height="24"></td>
								<td class="data" width="60%" height="24">&nbsp;
									<asp:textbox id="txtAddress3" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td width="249" height="24"></td>
								<td class="data" width="60%" height="24">&nbsp;
									<asp:textbox id="txtAddress4" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="24"><asp:label id="lblTown" runat="server">Town/City</asp:label></td>
								<td class="data" width="60%" height="24">&nbsp;
									<asp:textbox id="txtTown" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="24"><asp:label id="lblPost" runat="server">Post Code</asp:label></td>
								<td class="data" width="60%" height="24">&nbsp;
									<asp:textbox id="txtPost" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="24"><asp:label id="lblCounty" runat="server">County</asp:label></td>
								<td class="data" width="60%" height="24">&nbsp;
									<asp:textbox id="txtCounty" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="24"><asp:label id="lblArea" runat="server">Area</asp:label></td>
								<td class="data" width="60%" height="24">&nbsp;
									<asp:dropdownlist id="cmbArea" runat="server" Width="184" CssClass="logon"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="24"><asp:label id="lblCountry" runat="server">Country</asp:label></td>
								<td class="data" width="60%" height="24">&nbsp;
									<asp:textbox id="txtCountry" runat="server" Width="184px"></asp:textbox></td>
							</tr>
						</table>
					</td>
					<td vAlign="top" width="50%" height="100%">
						<table width="100%">
							<TBODY>
								<tr>
									<td class="logon" width="249" height="24"><asp:label id="lblComptype" runat="server">Company Type</asp:label></td>
									<td class="data" width="60%" height="24">&nbsp;
										<asp:dropdownlist id="cmbCompType" runat="server" Width="184" CssClass="logon"></asp:dropdownlist></td>
								</tr>
								<tr>
									<td class="logon" width="249" height="24"><asp:label id="lblTel" runat="server">Telephone</asp:label></td>
									<td class="data" width="60%" height="24">&nbsp;
										<asp:textbox id="txtTel" runat="server" Width="184px"></asp:textbox></td>
								</tr>
								<tr>
									<td class="logon" width="249" height="24"><asp:label id="lblFax" runat="server">Fax</asp:label></td>
									<td class="data" width="60%" height="24">&nbsp;
										<asp:textbox id="txtFax" runat="server" Width="184px"></asp:textbox></td>
								</tr>
								<tr>
									<td class="logon" width="249" height="24"><asp:label id="lblEmail" runat="server">Email</asp:label></td>
									<td class="data" width="60%" height="24">&nbsp;
										<asp:textbox id="txtEmail" runat="server" Width="184px"></asp:textbox></td>
								</tr>
								<tr>
									<td class="logon" width="249" height="24"><asp:label id="lblWeb" runat="server">Website</asp:label></td>
									<td class="data" width="60%" height="24">&nbsp;
										<asp:textbox id="txtWeb" runat="server" Width="184px"></asp:textbox></td>
								</tr>
								<tr>
									<td class="logon" width="147" height="24"><asp:label id="lblAccMan" runat="server">Account Manager </asp:label></td>
									<td class="data" width="60%" height="24">&nbsp;&nbsp;<asp:dropdownlist id="cmbAccMan" runat="server" Width="184" CssClass="logon"></asp:dropdownlist></td>
								</tr>
								<tr>
									<td class="logon" width="147" height="24"><asp:label id="lblSalesMan" runat="server">Sales Manager</asp:label></td>
									<td class="data" width="60%" height="24">&nbsp;&nbsp;<asp:dropdownlist id="cmbSalesMan" runat="server" Width="184" CssClass="logon"></asp:dropdownlist></td>
								</tr>
								<tr>
									<td class="logon" align="left" width="249" height="24"><asp:label id="lblStatus" runat="server">Status</asp:label></td>
									<td class="data" width="60%" height="24">&nbsp;
										<asp:dropdownlist id="cmbStatus" runat="server" Width="184" CssClass="logon"></asp:dropdownlist></td>
								</tr>
								<tr>
									<td class="logon" width="249" height="24"><asp:label id="lblStatEff" runat="server">Status Effective </asp:label></td>
									<td class="data" width="60%" height="24">&nbsp;
										<asp:textbox id="txtStatEff" runat="server" Width="184px"></asp:textbox>&nbsp;
										<asp:label id="lblStatstar" runat="server" Font-Bold="True" ForeColor="Red" Font-Names="Arial"
											Font-Size="Larger">*</asp:label></td>
					</td>
				</tr>
			</table>
			</TD></TR></TBODY></TABLE>
			<table height="30" width="96%" align="center">
				<tr>
					<td vAlign="middle" align="right" width="100%"><asp:button id="btnUpdate" runat="server" CssClass="button" Text="Update"></asp:button>&nbsp;
						<asp:button id="btnCancel" runat="server" CssClass="button" Text="Cancel"></asp:button>&nbsp;
					</td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
