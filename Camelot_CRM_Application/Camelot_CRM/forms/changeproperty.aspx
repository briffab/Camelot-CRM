<%@ Page language="c#" Codebehind="changeproperty.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.changeproperty" %>
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
					<td class="logon" width="40%" height="14"><asp:label id="lblTitle" runat="server" Font-Size="20pt">Change Property</asp:label></td>
					<td class="logon" width="60%" height="14"><asp:label id="lblMessage" runat="server" Font-Bold="false" Font-Names="Arial" Font-Size="Larger"
							ForeColor="Red"></asp:label></td>
				</tr>
			</table>
			<table id="tblDetails" width="96%" align="center" border="0">
				<tr>
					<td class="logon" width="147"><asp:label id="lblFCompany" runat="server" Width="136px">Find Property</asp:label></td>
					<td class="data" width="60%"><asp:textbox id="txtProperty" runat="server" Width="184px"></asp:textbox>&nbsp;<asp:button id="btnCserch" runat="server" CssClass="button" Text="Find"></asp:button>&nbsp;
						<asp:label id="Label15" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Larger"
							ForeColor="Red">*</asp:label></td>
				</tr>
				<tr>
					<td></td>
					<td class="logon" width="147"><asp:listbox id="lbProperties" ondblclick="setproperty(this.form.lbProperties, this.form.txtSProp, this.form.txtPropID)"
							runat="server" Width="424px" Height="112px"></asp:listbox></td>
				</tr>
				<tr>
					<td class="logon" width="147"><asp:label id="lblProperty" runat="server" Width="136px">Property</asp:label></td>
					<td class="data" width="60%"><asp:textbox id="txtSProp" runat="server" Width="184px"></asp:textbox></td>
				</tr>
				<tr>
					<td class="logon" width="147"><asp:label id="lblCompID" runat="server" Width="136px">Property ID</asp:label></td>
					<td class="data" width="60%"><asp:textbox id="txtPropID" runat="server" Width="184px"></asp:textbox></td>
				</tr>
				<tr>
					<td class="logon" width="147"><asp:label id="Label1" runat="server" Width="136px">Effective Date</asp:label></td>
					<td class="data" width="60%"><asp:textbox id="txtEffDate" runat="server" Width="184px"></asp:textbox><asp:label id="Label14" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Larger"
							ForeColor="Red">*</asp:label></td>
				</tr>
				<tr>
					<td class="logon" width="147"><asp:label id="Label2" runat="server" Width="136px">Room</asp:label></td>
					<td class="data" width="60%"><asp:textbox id="txtRoom" runat="server" Width="184px"></asp:textbox></td>
				</tr>
				<tr vAlign="top">
					<td class="logon" width="249" height="21"><asp:label id="Label25" runat="server">Head Guardian</asp:label></td>
					<td class="data" width="60%" height="21"><asp:checkbox id="chkhead" runat="server" TextAlign="Left"></asp:checkbox></td>
				<TR>
				</TR>
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
					function setproperty(lstbx, lblfld, propid)
					{					
						propid.value = lstbx.options[lstbx.options.selectedIndex].value;
						lblfld.value = lstbx.options[lstbx.options.selectedIndex].text;
					}
			</script>
		</form>
	</BODY>
</HTML>