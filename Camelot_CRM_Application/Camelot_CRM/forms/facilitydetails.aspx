<%@ Page language="c#" Codebehind="facilitydetails.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.facilitydetails" %>
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
					<td class="logon" width="100%" height="14"><asp:label id="Label20" runat="server" Font-Size="20pt">Facility Details</asp:label></td>
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
							<tr>
								<td class="logon" width="249" height="23"><asp:label id="lblfactype" runat="server">Facility</asp:label></td>
								<td class="data" width="60%" height="23">&nbsp;
									<asp:dropdownlist id="cmbfactype" runat="server" Width="184" CssClass="logon"></asp:dropdownlist>
									<asp:label id="Label12" runat="server" ForeColor="Red" Font-Size="Larger" Font-Names="Arial"
										Font-Bold="True">*</asp:label></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="lblfacdesc" runat="server">Description</asp:label></td>
								<td class="data" width="60%" height="21">&nbsp;
									<asp:textbox id="txtfacdesc" runat="server" Width="184px"></asp:textbox>&nbsp;<asp:label id="Label11" runat="server" ForeColor="Red" Font-Size="Larger" Font-Names="Arial"
										Font-Bold="True">*</asp:label></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label10" runat="server">Location</asp:label></td>
								<td class="data" width="60%" height="21">&nbsp;
									<asp:textbox id="txtLoc" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label1" runat="server">Serial Number</asp:label></td>
								<td class="data" width="60%" height="21">&nbsp;
									<asp:textbox id="txtfacsn" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label2" runat="server">Installed</asp:label></td>
								<td class="data" width="60%" height="21">&nbsp;
									<asp:textbox id="txtinsdate" runat="server" Width="184px"></asp:textbox>&nbsp;<asp:label id="Label13" runat="server" ForeColor="Red" Font-Size="Larger" Font-Names="Arial"
										Font-Bold="True">*</asp:label></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label3" runat="server">Last Service</asp:label></td>
								<td class="data" width="60%" height="21">&nbsp;
									<asp:textbox id="txtlasts" runat="server" Width="184px"></asp:textbox>&nbsp;<asp:label id="Label14" runat="server" ForeColor="Red" Font-Size="Larger" Font-Names="Arial"
										Font-Bold="True">*</asp:label></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label4" runat="server">Next Service</asp:label></td>
								<td class="data" width="60%" height="21">&nbsp;
									<asp:textbox id="txtnexts" runat="server" Width="184px"></asp:textbox>&nbsp;<asp:label id="Label15" runat="server" ForeColor="Red" Font-Size="Larger" Font-Names="Arial"
										Font-Bold="True">*</asp:label></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="21"><asp:label id="Label5" runat="server">Serviced by</asp:label></td>
								<td class="data" width="60%" height="21">&nbsp;
									<asp:dropdownlist id="cmbserv" runat="server" Width="184" CssClass="logon"></asp:dropdownlist>&nbsp;<asp:label id="Label16" runat="server" ForeColor="Red" Font-Size="Larger" Font-Names="Arial"
										Font-Bold="True">*</asp:label></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label6" runat="server">Notes</asp:label></td>
								<td class="data" width="60%" height="21">&nbsp;&nbsp;<asp:textbox id="txtnotes" runat="server" Width="272px" Height="72px"></asp:textbox></td>
							</tr>
						</table>
					</td>
					<td vAlign="top" width="50%">
						<table cellPadding="0" width="100%">
							<tr>
								<td class="logon" width="249" height="21"><asp:label id="Label7" runat="server">Guardian</asp:label></td>
								<td class="data" width="60%" height="21">&nbsp;
									<asp:dropdownlist id="cmbguard" runat="server" Width="184" CssClass="logon"></asp:dropdownlist>&nbsp;<asp:label id="Label17" runat="server" ForeColor="Red" Font-Size="Larger" Font-Names="Arial"
										Font-Bold="True">*</asp:label></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="25"><asp:label id="lblUpBy" runat="server">Last Updated by</asp:label></td>
								<td class="data" width="60%" height="25"><asp:label id="lblUby" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="25"><asp:label id="lblUpOn" runat="server">Last Updated on </asp:label></td>
								<td class="data" width="60%" height="25"><asp:label id="lblUDate" runat="server"></asp:label></td>
							</tr>
							<tr>
							<tr>
								<td class="logon" width="249" height="25"><asp:label id="Label9" runat="server">In Use</asp:label></td>
								<td class="data" width="60%" height="25"><asp:checkbox id="chkUse" runat="server"></asp:checkbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label18" runat="server">Date Removed</asp:label></td>
								<td class="data" width="60%" height="21">&nbsp;
									<asp:textbox id="txtDateRem" runat="server" Width="184px"></asp:textbox>&nbsp;<asp:label id="Label19" runat="server" ForeColor="Red" Font-Size="Larger" Font-Names="Arial"
										Font-Bold="True">*</asp:label></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="25"><asp:label id="Label21" runat="server">In Inspection</asp:label></td>
								<td class="data" width="60%" height="25"><asp:checkbox id="chkInsp" runat="server"></asp:checkbox></td>
							</tr>
							<tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label8" runat="server">Photo</asp:label></td>
								<td class="data" align="left" width="60%">&nbsp;<asp:image id="imgMainPhoto" CssClass="photo" runat="server" Width="240px" Height="160px"></asp:image></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<hr width="96%">
			<table height="30" width="96%" align="center">
				<tr>
					<td vAlign="middle" align="left" width="50%"><asp:button id="btnClose" runat="server" CssClass="button" Text="Close"></asp:button></td>
					<td vAlign="middle" align="right" width="100%"><asp:button id="btnEdit" runat="server" CssClass="button" Text="Edit"></asp:button><asp:button id="btnUpdate" runat="server" CssClass="button" Text="Update"></asp:button>&nbsp;
						<asp:button id="btnCancel" runat="server" CssClass="button" Text="Cancel"></asp:button></td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
