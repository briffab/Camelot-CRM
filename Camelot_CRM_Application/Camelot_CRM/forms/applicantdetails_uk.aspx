<%@ Page language="c#" Codebehind="applicantdetails_uk.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.applicantdetails_uk" %>
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
					<td class="Logon" width="50%"><asp:label id="Label29" runat="server" Font-Bold="false" Font-Names="Arial" Font-Size="20pt">Guardian Application</asp:label></td>
					<td class="logon" vAlign="bottom" width="50%" height="14"><asp:label id="lblMessage" runat="server" Font-Bold="false" Font-Names="Arial" Font-Size="Larger"
							ForeColor="Red"></asp:label></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center" border="0">
				<tr>
					<td vAlign="top" width="50%">
						<table width="100%">
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label26" runat="server">Interested In</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtWTlive" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label2" runat="server">First name</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtFname" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label12" runat="server">Last name</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtLname" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="21"><asp:label id="lblfactype" runat="server">Gender</asp:label></td>
								<td class="data" width="60%" height="21"><asp:dropdownlist id="cmbGender" runat="server" Width="184" CssClass="logon">
										<asp:ListItem Value="1">Male</asp:ListItem>
										<asp:ListItem Value="0">Female</asp:ListItem>
									</asp:dropdownlist>&nbsp;
								</td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="lblfacdesc" runat="server">Address</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtAddr1" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label11" runat="server"></asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtAddr2" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label13" runat="server"></asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtAddr3" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label14" runat="server"></asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtAddr4" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label1" runat="server">Post Code</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtPcode" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label4" runat="server">Town</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtTown" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label18" runat="server">County</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtCounty" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label19" runat="server">Phone</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtPhone" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label20" runat="server">Work Phone</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtWkPhone" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label21" runat="server">Mobile Phone</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtMbPhone" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label22" runat="server">Email</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtEmail" runat="server" Width="184px"></asp:textbox></td>
							</tr>
						</table>
					</td>
					<td vAlign="top" width="50%">
						<table cellPadding="0" width="100%">
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label5" runat="server">Date of Birth</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtDOB" runat="server" Width="184px"></asp:textbox>&nbsp;<asp:label id="Label16" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Larger"
										ForeColor="Red">*</asp:label>
								</td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label15" runat="server">Nationality</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtNat" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="21"><asp:label id="Label7" runat="server">Own Transport</asp:label></td>
								<td class="data" width="60%" height="21"><asp:dropdownlist id="cmbTrans" runat="server" Width="184" CssClass="logon">
										<asp:ListItem Value="0">No</asp:ListItem>
										<asp:ListItem Value="1">Yes</asp:ListItem>
									</asp:dropdownlist>&nbsp;
								</td>
							</tr>
							<tr>
								<td class="logon" width="249" height="21"><asp:label id="Label8" runat="server">Pets</asp:label></td>
								<td class="data" width="60%" height="21"><asp:dropdownlist id="cmbPets" runat="server" Width="184" CssClass="logon">
										<asp:ListItem Value="0">No</asp:ListItem>
										<asp:ListItem Value="1">Yes</asp:ListItem>
									</asp:dropdownlist>&nbsp;
								</td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label3" runat="server">Employment Status</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtEmpl" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label23" runat="server">Occupation</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtOccup" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label17" runat="server">Criminal Record</asp:label></td>
								<td class="data" width="60%" height="21"><asp:dropdownlist id="cmbCrim" runat="server" Width="184" CssClass="logon">
										<asp:ListItem Value="0">No</asp:ListItem>
										<asp:ListItem Value="1">Yes</asp:ListItem>
									</asp:dropdownlist>&nbsp;
								</td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label24" runat="server">Religion</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtRel" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label25" runat="server">Ethnic Background</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtEth" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label6" runat="server">Remarks</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtRem" runat="server" Width="272px" Height="128px" TextMode="MultiLine"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label9" runat="server">Application Date</asp:label></td>
								<td class="data" width="60%" height="21"><asp:label id="lblApp" runat="server"></asp:label></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<hr width="96%">
			<table height="30" width="96%" align="center">
				<tr>
					<td class="data" align="left" width="33%" height="25"><asp:checkbox id="chkApp" runat="server" Font-Bold="True" Text="Application" AutoPostBack="True"></asp:checkbox></td>
					<td class="data" align="left" width="33%" height="25"><asp:checkbox id="chkPhoto" runat="server" Font-Bold="True" Text="Photo ID" AutoPostBack="True"></asp:checkbox></td>
					<td class="data" align="left" width="33%" height="25"><asp:checkbox id="chkRef" runat="server" Font-Bold="True" Text="References" AutoPostBack="True"></asp:checkbox></td>
				</tr>
				<tr>
					<td class="data" align="left" width="33%" height="25"><asp:checkbox id="chkBank" runat="server" Font-Bold="True" Text="Bank Statement / Utility" AutoPostBack="True"></asp:checkbox></td>
					<td class="data" align="left" width="33%" height="25"><asp:checkbox id="chkLic" runat="server" Font-Bold="True" Text="License" AutoPostBack="True"></asp:checkbox></td>
					<td class="data" align="left" width="33%" height="25"><asp:checkbox id="chkBook" runat="server" Font-Bold="True" Text="Booklet Given" AutoPostBack="True"></asp:checkbox></td>
				</tr>
				<tr>
					<td class="data" align="left" width="33%" height="25"><asp:checkbox id="chkSO" runat="server" Font-Bold="True" Text="Standing Order" AutoPostBack="True"></asp:checkbox></td>
					<td class="data" align="left" width="33%" height="25"><asp:checkbox id="chkED" runat="server" Font-Bold="True" AutoPostBack="True" Text="Executive Decision"></asp:checkbox></td>
					<td class="data" align="left" width="33%" height="25"></td>
				</tr>
			</table>
			<table height="30" width="96%" align="center">
				<tr>
					<td class="logon" align="left" width="33%" height="21"><asp:label id="Label27" runat="server">Notes</asp:label></td>
					<td class="logon" align="left" width="33%" height="25"><asp:label id="Label31" runat="server">In Outlook</asp:label></td>
					<td class="logon" align="left" width="33%" height="21"><asp:label id="Label28" runat="server">For date</asp:label></td>
				</tr>
				<tr>
					<td class="data" width="33%" height="21"><asp:textbox id="txtNotes" runat="server" Width="100%" Height="88px" TextMode="MultiLine"></asp:textbox></td>
					<td class="data" vAlign="top" align="left" width="33%" height="25"><asp:checkbox id="chkOut" runat="server" AutoPostBack="True"></asp:checkbox></td>
					<td class="data" vAlign="top" align="left" width="33%" height="21"><asp:textbox id="txtDate" runat="server" Width="184px"></asp:textbox>&nbsp;<asp:label id="Label30" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Larger"
							ForeColor="Red">*</asp:label>
					</td>
				</tr>
			</table>
			<hr width="96%">
			<table height="30" width="96%" align="center">
				<tr>
					<td vAlign="middle" align="left" width="25%"><asp:button id="btnClose" runat="server" CssClass="button" Text="Close"></asp:button></td>
					<td vAlign="middle" align="center" width="25%"><asp:button id="btnPlace" runat="server" CssClass="button" Text="Place Guardian"></asp:button></td>
					<td vAlign="middle" align="right" width="25%"><asp:button id="btnEdit" runat="server" CssClass="button" Text="Edit"></asp:button><asp:button id="btnUpdate" runat="server" CssClass="button" Text="Update"></asp:button>&nbsp;
						<asp:button id="btnCancel" runat="server" CssClass="button" Text="Cancel"></asp:button></td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
