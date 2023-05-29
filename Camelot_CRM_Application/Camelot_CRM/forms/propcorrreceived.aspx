<%@ Page language="c#" Codebehind="propcorrreceived.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.propcorrreceived" %>
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
			<table width="96%" align="center">
				<tr>
					<td class="logon" width="100%" height="14"><asp:label id="Label20" runat="server" Font-Size="20pt">Recieved Property Correspondence</asp:label></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center">
				<tr>
					<td class="logon" width="30%" height="14"><asp:label id="lblTitle" runat="server"></asp:label></td>
					<td class="logon" width="70%" height="14"><asp:label id="lblMessage" runat="server" Font-Size="Larger" ForeColor="Red" Font-Names="Arial"
							Font-Bold="false"></asp:label></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center">
				<tr>
					<td class="logon" width="249" height="24"><asp:label id="Label4" runat="server">Sent by</asp:label></td>
					<td class="data" width="60%" height="24"><asp:dropdownlist id="cmbSender" runat="server" Width="184" CssClass="logon"></asp:dropdownlist><asp:label id="lblSender" runat="server" Font-Size="Larger" ForeColor="Red" Font-Names="Arial"
							Font-Bold="True">*</asp:label></td>
				</tr>
				<tr>
					<td class="logon" width="249" height="21"><asp:label id="Label5" runat="server">Document Type</asp:label></td>
					<td class="data" width="60%" height="21"><asp:dropdownlist id="cmbType" runat="server" Width="184" CssClass="logon"></asp:dropdownlist><asp:label id="lblDoc" runat="server" Font-Size="Larger" ForeColor="Red" Font-Names="Arial"
							Font-Bold="True">*</asp:label></td>
				</tr>
				<tr>
					<td class="logon" width="30%" height="14"><asp:label id="Label2" runat="server" CssClass="logon">Date Recieved (DD/MM/yyy)</asp:label></td>
					<td><asp:textbox id="txtDate" runat="server" Width="250px"></asp:textbox><asp:label id="lblDate" runat="server" Font-Size="Larger" ForeColor="Red" Font-Names="Arial"
							Font-Bold="True">*</asp:label></td>
				</tr>
				<tr>
					<td class="logon" width="249" height="21"><asp:label id="Label3" runat="server">Recipient</asp:label></td>
					<td class="data" width="60%" height="21"><asp:dropdownlist id="cmbRecipient" runat="server" Width="184" CssClass="logon"></asp:dropdownlist><asp:label id="lblRec" runat="server" Font-Size="Larger" ForeColor="Red" Font-Names="Arial"
							Font-Bold="True">*</asp:label></td>
				</tr>
				<TR>
					<td class="logon" width="30%" height="14"><asp:label id="Label1" runat="server" CssClass="logon">Upload Scan</asp:label></td>
					<td><INPUT id="doc" type="file" name="doc" runat="server" width="400px"></td>
				<tr>
				</tr>
			</table>
			<HR width="96%">
			<TABLE height="30" width="96%" align="center">
				<TR>
					<TD vAlign="middle" align="left" width="50%"><asp:button id="btnClose" runat="server" CssClass="button" Text="Close"></asp:button></TD>
					<td align="right" width="50%"><input class="Button" id="upload" type="submit" value="Save" runat="server" NAME="upload">
					</td>
				</TR>
			</TABLE>
		</form>
	</BODY>
</HTML>
