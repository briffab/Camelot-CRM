<%@ Page language="c#" Codebehind="guardian.aspx.cs" AutoEventWireup="false" Inherits="Camelot.guardian" %>
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
					<td class="logon" width="30%" height="14"><asp:label id="Label1" runat="server" Font-Size="20pt">Guardian Details</asp:label></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center">
				<tr>
					<td class="logon" width="30%" height="14"><asp:label id="lblTitle" runat="server" Font-Size="10pt"></asp:label></td>
					<td class="logon" width="70%" height="14"><asp:label id="lblMessage" runat="server" Font-Size="Larger" ForeColor="Red" Font-Names="Arial"
							Font-Bold="false"></asp:label></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center" border="0">
				<tr>
					<td vAlign="top" width="50%">
						<table width="100%" valign="top">
							<tr>
								<td class="logon" width="249" height="21"><asp:label id="lblfactype" runat="server">Title</asp:label></td>
								<td class="data" width="60%" height="21"><asp:dropdownlist id="cmbtitle" runat="server" Width="184" CssClass="logon"></asp:dropdownlist></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label4" runat="server">Salutation</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtSal" runat="server" Width="184px"></asp:textbox>&nbsp;</td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="lblfacdesc" runat="server">First Name</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtfname" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="4">Middle Name</td>
								<td class="data" width="60%" height="4"><asp:textbox id="txtpref" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="4">Initials</td>
								<td class="data" width="60%" height="4"><asp:textbox id="txtinit" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label2" runat="server">Last Name</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtlname" runat="server" Width="184px"></asp:textbox><asp:label id="Label29" runat="server" Font-Size="Larger" ForeColor="Red" Font-Names="Arial"
										Font-Bold="True">*</asp:label></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label11" runat="server">Date of Birth</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtDOB" runat="server" Width="184px"></asp:textbox><asp:label id="Label36" runat="server" Font-Size="Larger" ForeColor="Red" Font-Names="Arial"
										Font-Bold="True">*</asp:label></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label12" runat="server">Nationality</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtNat" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<TR>
								<td class="logon" width="249" height="21"><asp:label id="Label24" runat="server">Sex</asp:label></td>
								<td class="data" width="60%" height="21"><asp:dropdownlist id="cmbSex" runat="server" Width="184" CssClass="logon">
										<asp:ListItem Value="1">Male</asp:ListItem>
										<asp:ListItem Value="2">Female</asp:ListItem>
									</asp:dropdownlist></td>
							</TR>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label3" runat="server">Work Telephone</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtwktel" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label13" runat="server">Home Telephone</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtHmTel" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label14" runat="server">Parents Telephone</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtPtel" runat="server" Width="184px"></asp:textbox></td>
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
								<td class="logon" width="249" height="21"><asp:label id="Label16" runat="server">Parents Mobile</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtPmobile" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label6" runat="server">Fax</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtfax" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label17" runat="server">Work Email</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtwkEmail" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label8" runat="server">Private Email</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtHmemail" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label18" runat="server">Parents Email</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtPemail" runat="server" Width="184px"></asp:textbox></td>
							</tr>
						</table>
					</td>
					<td vAlign="top" width="50%">
						<table cellPadding="0" width="100%">
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label28" runat="server">Room</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtRoom" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label26" runat="server">Date Started</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtDtStart" runat="server" Width="184px"></asp:textbox><asp:label id="Label30" runat="server" Font-Size="Larger" ForeColor="Red" Font-Names="Arial"
										Font-Bold="True">*</asp:label></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label27" runat="server">Date Finished</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtDtFinished" runat="server" Width="184px"></asp:textbox><asp:label id="Label31" runat="server" Font-Size="Larger" ForeColor="Red" Font-Names="Arial"
										Font-Bold="True">*</asp:label></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label25" runat="server">Head Guardian</asp:label></td>
								<td class="data" width="60%" height="21"><asp:checkbox id="chkhead" runat="server" TextAlign="Left"></asp:checkbox></td>
							<TR>
								<td class="logon" width="249" height="21"><asp:label id="Label19" runat="server">Status</asp:label></td>
								<td class="data" width="60%" height="21"><asp:dropdownlist id="cmbStat" runat="server" Width="184" CssClass="logon"></asp:dropdownlist>&nbsp;</td>
							</TR>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label7" runat="server">Monthly Rent</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtRent" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label9" runat="server">Payment Break Until</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtpbu" runat="server" Width="184px"></asp:textbox><asp:label id="Label33" runat="server" Font-Size="Larger" ForeColor="Red" Font-Names="Arial"
										Font-Bold="True">*</asp:label></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label21" runat="server">Payment Break Reason</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtpbr" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="25"><asp:label id="lblUpBy" runat="server">Last Updated by</asp:label></td>
								<td class="data" width="60%" height="25"><asp:label id="lblUby" runat="server"></asp:label></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="23"><asp:label id="Label22" runat="server">Fire Pack Purchased</asp:label></td>
								<td class="data" width="60%" height="23"><asp:textbox id="txtfire" runat="server" Width="184px"></asp:textbox><asp:label id="Label34" runat="server" Font-Size="Larger" ForeColor="Red" Font-Names="Arial"
										Font-Bold="True">*</asp:label></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label23" runat="server">Insurance</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtins" runat="server" Width="184px"></asp:textbox><asp:label id="Label35" runat="server" Font-Size="Larger" ForeColor="Red" Font-Names="Arial"
										Font-Bold="True">*</asp:label></td>
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
					<td vAlign="middle" align="center" width="22%"><asp:button id="btnCorr" runat="server" Width="125" CssClass="button" Text="Correspondence"></asp:button></td>
					<td vAlign="middle" align="center" width="18%"><asp:button id="btnVet" runat="server" CssClass="button" Text="Vetting Criteria"></asp:button></td>
					<td vAlign="middle" align="center" width="22%"><asp:button id="btnOther" runat="server" Width="125" CssClass="button" Text="Other Address"></asp:button></td>
					<td vAlign="middle" align="center" width="17%"><asp:button id="btnBank" runat="server" CssClass="button" Text="Bank Details"></asp:button></td>
					<td vAlign="middle" align="center" width="20%"><asp:button id="btnChange" runat="server" Width="150" CssClass="button" Text="Change Property"></asp:button></td>
					<td vAlign="middle" align="right" width="15%">&nbsp;<asp:button id="btnEdit" runat="server" CssClass="button" Text="Edit"></asp:button><asp:button id="btnUpdate" runat="server" CssClass="button" Text="Update"></asp:button>&nbsp;
						<asp:button id="btnCancel" runat="server" CssClass="button" Text="Cancel"></asp:button></td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
