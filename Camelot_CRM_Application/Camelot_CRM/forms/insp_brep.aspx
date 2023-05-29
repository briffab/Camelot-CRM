<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=9.1.5000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<%@ Page language="c#" Codebehind="insp_brep.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.insp_brep" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>insp_rep</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table width="96%" align="center">
				<tr>
					<td width="100%" align="left">
						<CR:CrystalReportViewer id="CRv" runat="server" Width="350px" Height="50px"></CR:CrystalReportViewer>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
