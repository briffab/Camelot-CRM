<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=9.1.5000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<%@ Page language="c#" Codebehind="insp_rep_NL.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.insp_rep_NL" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>insp_rep</title>
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<TABLE height="771" cellSpacing="0" cellPadding="0" width="126" border="0" ms_2d_layout="TRUE">
			<TR>
				<TD width="0" height="0"></TD>
				<TD width="10" height="0"></TD>
				<TD width="116" height="0"></TD>
			</TR>
			<TR vAlign="top">
				<TD width="0" height="15"></TD>
				<TD colSpan="2" rowSpan="2">
					<form id="Form1" method="post" runat="server">
						<TABLE height="109" cellSpacing="0" cellPadding="0" width="759" border="0" ms_2d_layout="TRUE">
							<TR vAlign="top">
								<TD width="25" height="45"></TD>
								<TD width="734"></TD>
							</TR>
							<TR vAlign="top">
								<TD height="64"></TD>
								<TD>
									<table width="733" align="center" height="63">
										<tr>
											<td width="100%" align="left">
												<CR:CrystalReportViewer id="CRv" runat="server" Width="350px" Height="50px" DisplayToolbar="False" DisplayGroupTree="False"></CR:CrystalReportViewer>
											</td>
										</tr>
									</table>
								</TD>
							</TR>
						</TABLE>
					</form>
				</TD>
			</TR>
			<TR vAlign="top">
				<TD width="0" height="756"></TD>
				<TD>
					<!--#include file="head.aspx" --></TD>
			</TR>
		</TABLE>
	</body>
</HTML>
