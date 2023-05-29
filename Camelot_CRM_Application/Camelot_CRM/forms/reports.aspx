<%@ Page language="c#" Codebehind="reports.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.reports" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
	<BODY>
		<!--#include file="head.aspx" -->
		<script language="JavaScript" src="../functions/menu.js"></script>
		<script language="JavaScript" src="../functions/menu<%=Session["menu"]%>.js"></script>
		<script language="JavaScript">
					showToolbar();
		</script>
		<form id="Form1" runat="server">
			<table height="35%" width="100%" border="0">
				<tr height="100%" width="100%">
					<td vAlign="top" align="left"><IMG src="..\images\cam_logo.gif"></td>
				</tr>
			</table>
			<table height="54" width="80%" align="center" valign="middle">
				<tr valign="middle">
					<td width="30%" colspan="3" align="center"><asp:Label id="lblMes" runat="server" ForeColor="Red" Font-Size="Larger" Font-Names="Arial"
							Font-Bold="false"></asp:Label></td>
				</tr>
				<tr valign="middle">
					<td width="20%"><asp:Label id="lblreport" runat="server">Report</asp:Label></td>
					<td width="20%"><asp:Label id="lblFrom" runat="server">Date From</asp:Label></td>
					<td width="20%"><asp:Label id="lblTo" runat="server">Date To</asp:Label></td>
					<td width="20%"><asp:Label id="lblAcc" runat="server">Account Manager</asp:Label></td>
					<td width="20%"><asp:Label id="Label1" runat="server">Property</asp:Label></td>
				</tr>
				<tr valign="middle">
					<td width="20%"><asp:DropDownList id="cmbReport" runat="server" Width="176px" AutoPostBack="True"></asp:DropDownList></td>
					<td width="20%"><asp:TextBox id="txtDateFrom" runat="server"></asp:TextBox><asp:label id="lblFromStar" runat="server" ForeColor="Red" Font-Size="Larger" Font-Names="Arial"
							Font-Bold="True">*</asp:label></td>
					<td width="20%"><asp:TextBox id="txtDateTo" runat="server"></asp:TextBox><asp:label id="lblToStar" runat="server" ForeColor="Red" Font-Size="Larger" Font-Names="Arial"
							Font-Bold="True">*</asp:label></td>
					<td width="20%"><asp:DropDownList id="cmbAccman" runat="server" Width="176px"></asp:DropDownList></td>
					<td width="20%"><asp:DropDownList id="cmbProps" runat="server" Width="176px"></asp:DropDownList></td>
				</tr>
			</table>
			<hr width="80%" align="center">
			<table height="30" width="80%" align="center">
				<tr>
					<td vAlign="middle" align="right" width="50%"><asp:button id="btnReport" runat="server" CssClass="button" Text="Report"></asp:button></td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
