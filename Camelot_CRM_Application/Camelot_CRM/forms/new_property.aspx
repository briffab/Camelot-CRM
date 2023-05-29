<%@ Page language="c#" Codebehind="new_property.aspx.cs" AutoEventWireup="false" Inherits="Camelot.new_property" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
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
					<td class="logon" width="30%" height="14"><asp:label id="lblTitle" runat="server" Font-Size="20pt">New Property</asp:label></td>
					<td class="logon" width="70%" height="14"><asp:label id="lblMessage" runat="server" Font-Bold="false" Font-Names="Arial" Font-Size="Larger"
							ForeColor="Red"></asp:label></td>
				</tr>
			</table>
			<hr width="96%">
			<table id="tblDetails" width="96%" align="center" border="0">
				<tr>
					<td vAlign="top" width="50%" height="100%">
						<table width="100%">
							<tr>
								<td class="logon" width="249" height="14">Key Number</td>
								<td class="data" width="60%" height="14">
									<asp:textbox id="txtKey" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="14">Address</td>
								<td class="data" width="60%" height="14">
									<asp:textbox id="txtName" runat="server" Width="184px"></asp:textbox>
									<asp:label id="lblPropName" runat="server" ForeColor="Red" Font-Size="Larger" Font-Names="Arial"
										Font-Bold="True">*</asp:label></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="14"></td>
								<td class="data" width="60%" height="14">
									<asp:textbox id="txtAddress1" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td width="249" height="24"></td>
								<td class="data" width="60%" height="24">
									<asp:textbox id="txtAddress2" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td width="249"></td>
								<td class="data" width="60%">
									<asp:textbox id="txtAddress3" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td class="logon" width="249"><asp:label id="lblTown" runat="server">Town/City</asp:label></td>
								<td class="data" width="60%">
									<asp:textbox id="txtTown" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td class="logon" width="249"><asp:label id="lblPost" runat="server">Post Code</asp:label></td>
								<td class="data" width="60%">
									<asp:textbox id="txtPost" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="21"><asp:label id="lblCounty" runat="server">County</asp:label></td>
								<td class="data" width="60%" height="21">
									<asp:textbox id="txtCounty" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="21"><asp:label id="lblArea" runat="server">Area</asp:label></td>
								<td class="data" width="60%" height="21">
									<asp:dropdownlist id="cmbArea" runat="server" Width="184" CssClass="logon"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="21"><asp:label id="lblCountry" runat="server">Country</asp:label></td>
								<td class="data" width="60%" height="21">
									<asp:textbox id="txtCountry" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="21"><asp:label id="lblProptype" runat="server">Property Type</asp:label></td>
								<td class="data" width="60%" height="21">
									<asp:dropdownlist id="cmbPropType" runat="server" Width="184" CssClass="logon"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="14"><asp:label id="lblRegMan" runat="server">Regional Manager</asp:label></td>
								<td class="data" width="60%" height="14">
									<asp:dropdownlist id="cmbRegMan" runat="server" Width="184" CssClass="logon"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="31"><asp:label id="lblMaxOcc" runat="server" Width="152px">Maximum Occupancy</asp:label></td>
								<td class="data" width="60%" height="31">
									<asp:textbox id="txtMaxOcc" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td class="logon" align="left" width="249" height="21"><asp:label id="lblStatus" runat="server">Status</asp:label></td>
								<td class="data" width="60%" height="31">
									<asp:dropdownlist id="cmbStatus" runat="server" Width="184" CssClass="logon"></asp:dropdownlist><asp:label id="lblStatusStar" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Larger"
										ForeColor="Red">*</asp:label></td>
							</tr>
							<tr>
								<td class="logon" width="249"><asp:label id="lblStatEff" runat="server">Status Effective </asp:label></td>
								<td class="data" width="60%">
									<asp:textbox id="txtStatEff" runat="server" Width="184px"></asp:textbox><asp:label id="lblStatstar" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Larger"
										ForeColor="Red">*</asp:label></td>
							</tr>
						</table>
					</td>
					<td vAlign="top" width="50%" height="100%">
						<table width="100%">
							<tr>
								<td class="logon" width="249" height="14">Calamity Limit</td>
								<td class="data" width="60%" height="14">
									<asp:textbox id="txtCalam" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td class="logon" width="249"><asp:label id="Label1" runat="server">Monthly Fee</asp:label></td>
								<td class="data" width="60%"><asp:textbox id="txtMfee" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td class="logon" width="249"><asp:label id="Label3" runat="server">License Fee</asp:label></td>
								<td class="data" width="60%"><asp:textbox id="txtLfee" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td class="logon" width="249"><asp:label id="lblDtStart" runat="server">Date Started</asp:label></td>
								<td class="data" width="60%"><asp:textbox id="txtDtStart" runat="server" Width="184px"></asp:textbox><asp:label id="lblstartstar" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Larger"
										ForeColor="Red">*</asp:label></td>
							</tr>
							<tr>
								<td class="logon" width="249"><asp:label id="lblDtStop" runat="server">Date Finished</asp:label></td>
								<td class="data" width="60%"><asp:textbox id="txtDtStop" runat="server" Width="184px"></asp:textbox><asp:label id="lblstopstar" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Larger"
										ForeColor="Red">*</asp:label></td>
							</tr>
							<tr>
								<td class="logon" width="147" height="17"><asp:label id="lblAccMan" runat="server">Account Manager </asp:label></td>
								<td class="data" width="60%" height="17"><asp:dropdownlist id="cmbAccMan" runat="server" Width="184" CssClass="logon"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="logon" width="147" height="17"><asp:label id="lblPropMan" runat="server">Property Manager</asp:label></td>
								<td class="data" width="60%" height="17"><asp:dropdownlist id="cmbPropMan" runat="server" Width="184" CssClass="logon"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="logon" width="147" height="14"><asp:label id="lblPropInsp" runat="server">Property Inspector</asp:label></td>
								<td class="data" width="60%" height="14"><asp:dropdownlist id="cmbPropInsp" runat="server" Width="184" CssClass="logon"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="logon" width="147"><asp:label id="lblGuardMan" runat="server" Width="136px">Guardian Manager</asp:label></td>
								<td class="data" width="60%"><asp:dropdownlist id="cmbGuardMan" runat="server" Width="184" CssClass="logon"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="logon" width="147"><asp:label id="lblFCompany" runat="server" Width="136px">Find Company</asp:label></td>
								<td class="data" width="60%"><asp:textbox id="txtCompany" runat="server" Width="184px"></asp:textbox>&nbsp;<asp:button id="btnCserch" runat="server" CssClass="button" Text="Find"></asp:button></td>
							</tr>
							<tr>
								<td class="logon" width="147" colSpan="2"><asp:listbox id="lbCompanies" ondblclick="setcompany(this.form.lbCompanies, this.form.txtSCompany, this.form.txtCompID)"
										runat="server" Width="424px" Height="112px"></asp:listbox></td>
							</tr>
							<tr>
								<td class="logon" width="147"><asp:label id="lblCompany" runat="server" Width="136px">Company</asp:label></td>
								<td class="data" width="60%"><asp:textbox id="txtSCompany" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr>
								<td class="logon" width="147"><asp:label id="lblCompID" runat="server" Width="136px">Company ID</asp:label></td>
								<td class="data" width="60%"><asp:textbox id="txtCompID" runat="server" Width="184px"></asp:textbox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<hr width="96%">
			<table height="30" width="96%" align="center">
				<tr>
					<td vAlign="middle" align="left" width="50%"></td>
					<td vAlign="middle" align="right" width="100%"><asp:button id="btnUpdate" runat="server" CssClass="button" Text="Save"></asp:button>&nbsp;
						<asp:button id="btnCancel" runat="server" CssClass="button" Text="Cancel"></asp:button>&nbsp;
					</td>
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
	</BODY>
</HTML>
