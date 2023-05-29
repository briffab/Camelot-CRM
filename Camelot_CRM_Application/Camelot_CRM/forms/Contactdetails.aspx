<%@ Page language="c#" Codebehind="Contactdetails.aspx.cs" AutoEventWireup="false" Inherits="Camelot.Contactdetails" %>
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
					<td class="logon"><asp:label id="Label1" runat="server" Font-Size="20pt">Contact Details</asp:label></td>
				</tr>
			</table>
			<hr width="96%" align="center">
			<table width="96%" align="center">
				<tr>
					<td class="logon" width="30%" height="14"><asp:label id="lblTitle" runat="server"></asp:label></td>
					<td class="logon" width="70%" height="14"><asp:label id="lblMessage" runat="server" Font-Size="Larger" ForeColor="Red" Font-Names="Arial"
							Font-Bold="false"></asp:label></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center" border="0">
				<TBODY>
					<tr>
						<td vAlign="top" width="50%">
							<table width="100%" valign="top">
								<TBODY>
									<tr>
										<td class="logon" width="249" height="21"><asp:label id="lblfactype" runat="server">Title</asp:label></td>
										<td class="data" width="60%" height="21"><asp:dropdownlist id="cmbtitle" runat="server" Width="184" CssClass="logon"></asp:dropdownlist>&nbsp;</td>
									</tr>
									<tr vAlign="top">
										<td class="logon" width="249" height="21"><asp:label id="Label4" runat="server">Salutation</asp:label></td>
										<td class="data" width="60%" height="21"><asp:textbox id="txtSal" runat="server" Width="184px"></asp:textbox>&nbsp;</td>
									</tr>
									<tr vAlign="top">
										<td class="logon" width="249" height="21"><asp:label id="lblfacdesc" runat="server">First Name</asp:label></td>
										<td class="data" width="60%" height="21"><asp:textbox id="txtfname" runat="server" Width="184px"></asp:textbox>&nbsp;</td>
									</tr>
									<tr vAlign="top">
										<td class="logon" width="249" height="21">Middle Name</td>
										<td class="data" width="60%" height="21"><asp:textbox id="txtpref" runat="server" Width="184px"></asp:textbox>&nbsp;</td>
									</tr>
									<tr vAlign="top">
										<td class="logon" width="249" height="21">Initials</td>
										<td class="data" width="60%" height="21"><asp:textbox id="txtInit" runat="server" Width="184px"></asp:textbox>&nbsp;</td>
									</tr>
									<tr vAlign="top">
										<td class="logon" width="249" height="21"><asp:label id="Label2" runat="server">Last Name</asp:label></td>
										<td class="data" width="60%" height="21"><asp:textbox id="txtlname" runat="server" Width="184px"></asp:textbox>&nbsp;
											<asp:label id="lblLName" runat="server" Font-Size="Larger" ForeColor="Red" Font-Names="Arial"
												Font-Bold="True">*</asp:label></td>
									</tr>
									<tr vAlign="top">
										<td class="logon" width="249" height="21"><asp:label id="Label3" runat="server">Wk Telephone</asp:label></td>
										<td class="data" width="60%" height="21"><asp:textbox id="txtwktel" runat="server" Width="184px"></asp:textbox>&nbsp;</td>
									</tr>
									<tr vAlign="top">
										<td class="logon" width="249" height="21"><asp:label id="Label5" runat="server">Mobile</asp:label></td>
										<td class="data" width="60%" height="21"><asp:textbox id="txtmobile" runat="server" Width="184px"></asp:textbox>&nbsp;</td>
									</tr>
									<tr vAlign="top">
										<td class="logon" width="249" height="21"><asp:label id="Label6" runat="server">Fax</asp:label></td>
										<td class="data" width="60%" height="21"><asp:textbox id="txtfax" runat="server" Width="184px"></asp:textbox></td>
									</tr>
									<tr vAlign="top">
										<td class="logon" width="249" height="21"><asp:label id="Label8" runat="server">Email</asp:label></td>
										<td class="data" width="60%" height="21"><asp:textbox id="txtemail" runat="server" Width="184px"></asp:textbox></td>
									</tr>
									<tr vAlign="top">
										<td class="logon" width="249" height="21"><asp:label id="Label9" runat="server">Job Title</asp:label></td>
										<td class="data" width="60%" height="21"><asp:textbox id="txtJob" runat="server" Width="184px"></asp:textbox></td>
									</tr>
								</TBODY></table>
						</td>
						<td vAlign="top" width="50%">
							<table cellPadding="0" width="100%">
								<tr>
									<td class="logon" align="left" width="249" height="21"><asp:label id="lblStatus" runat="server">Status</asp:label></td>
									<td class="data" width="60%" height="31"><asp:dropdownlist id="cmbstatus" runat="server" Width="184" CssClass="logon"></asp:dropdownlist><asp:label id="lblStatusStar" runat="server" Font-Size="Larger" ForeColor="Red" Font-Names="Arial"
											Font-Bold="True">*</asp:label><asp:button id="btnHist" runat="server" Width="50" CssClass="button" Text="History"></asp:button>&nbsp;</td>
								</tr>
								<tr>
									<td class="logon" width="249"><asp:label id="lblStatEff" runat="server">Status Effective </asp:label></td>
									<td class="data" width="60%"><asp:textbox id="txtStatEff" runat="server" Width="184px"></asp:textbox><asp:label id="lblStatstar" runat="server" Font-Size="Larger" ForeColor="Red" Font-Names="Arial"
											Font-Bold="True">*</asp:label></td>
								</tr>
								<tr>
									<td class="logon" width="249" height="21"><asp:label id="Label10" runat="server">Do not recieve bulk email</asp:label></td>
									<td class="data" width="60%" height="21"><asp:checkbox id="chkbulk" runat="server" TextAlign="Left"></asp:checkbox></td>
								</tr>
								<tr vAlign="top">
									<td class="logon" width="249" height="46"><asp:label id="Label7" runat="server">Notes</asp:label></td>
									<td class="data" width="60%" height="46"><asp:textbox id="txtnotes" runat="server" Width="224px" Height="96px"></asp:textbox></td>
								</tr>
								<tr>
									<td class="logon" width="249" height="25"><asp:label id="lblUpBy" runat="server">Last Updated by</asp:label></td>
									<td class="data" width="60%" height="25"><asp:label id="lblUby" runat="server"></asp:label></td>
								</tr>
								<tr>
									<td class="logon" width="249" height="25"><asp:label id="lblUpOn" runat="server">Last Updated on </asp:label></td>
									<td class="data" width="60%" height="25"><asp:label id="lblUDate" runat="server"></asp:label></td>
								</tr>
							</table>
						</td>
					</tr>
				</TBODY></table>
			<hr width="96%">
			<table height="30" width="96%" align="center">
				<tr>
					<td vAlign="middle" align="left" width="33%"><asp:button id="btnClose" runat="server" CssClass="button" Text="Close"></asp:button></td>
					<td vAlign="middle" align="center" width="33%"><asp:button id="btnCorr" runat="server" CssClass="button" Text="Correspondence" Width="150"></asp:button></td>
					<td vAlign="middle" align="right" width="33%">&nbsp;<asp:button id="btnEdit" runat="server" CssClass="button" Text="Edit"></asp:button><asp:button id="btnUpdate" runat="server" CssClass="button" Text="Update"></asp:button>&nbsp;
						<asp:button id="btnCancel" runat="server" CssClass="button" Text="Cancel"></asp:button><asp:button id="btnNcancel" runat="server" CssClass="button" Text="Cancel"></asp:button></td>
				</tr>
			</table>
			<script language="javascript">
					function setcompany(lstbx, lblfld, compid)
					{					
						compid.value = lstbx.options[lstbx.options.selectedIndex].value;
						lblfld.value = lstbx.options[lstbx.options.selectedIndex].text;
					}
			</script>
		</form>
		</TR></TBODY></TABLE></TR></TBODY></TABLE></FORM>
	</BODY>
</HTML>
