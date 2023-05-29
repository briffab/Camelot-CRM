<%@ Page language="c#" Codebehind="report.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.report" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>report</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<!--#include file="head.aspx" -->
		<form id="Form1" runat="server">
			<table height="100%" width="96%" align="center">
				<tr>
					<td vAlign="bottom" align="center" width="100%"><asp:label id="lblMes" runat="server" Font-Bold="false" Font-Names="Arial" Font-Size="Larger"
							ForeColor="Red">Please Wait, Report Being Generated ...</asp:label></td>
				</tr>
				<tr>
					<td vAlign="top" align="center" width="50%"><asp:button id="btnClose" runat="server" CssClass="button" Text="Close"></asp:button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
