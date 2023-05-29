<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=9.1.5000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<%@ Page language="c#" Codebehind="ReportViewer.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.ReportViewer" %>
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
					<td class="logon">
						<asp:Label id="Label3" runat="server">Select Export Format</asp:Label>
					</td>
					<td class="logon">
						<asp:DropDownList id="cmbExport" runat="server" Height="39px" Width="221px">
							<asp:ListItem Value="0">PDF</asp:ListItem>
							<asp:ListItem Value="1">Rich Text Format</asp:ListItem>
							<asp:ListItem Value="2">Microsoft Word</asp:ListItem>
							<asp:ListItem Value="3">Microsoft Excel</asp:ListItem>
						</asp:DropDownList>
					</td>
					<td vAlign="middle" align="left"><asp:button id="btnExport" runat="server" CssClass="button" Text="Export"></asp:button></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center" border="0">
				<tr>
					<td vAlign="top" width="100%">
						<CR:CrystalReportViewer id="CRv" runat="server" Width="350px" Height="50px" DisplayGroupTree="False" DisplayToolbar="False"
							EnableDrillDown="False"></CR:CrystalReportViewer>
					</td>
				</tr>
			</table>
			<hr width="96%">
			<table height="30" width="96%" align="center">
				<tr>
					<td vAlign="middle" align="left" width="25%"><asp:button id="btnClose" runat="server" CssClass="button" Text="Close"></asp:button></td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
