<%@ Page language="c#" Codebehind="logon.aspx.cs" AutoEventWireup="false" Inherits="Camelot.logon" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Logon</title>
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="stylesheets/Camelot.css" type="text/css" rel="stylesheet">
		<script language='JavaScript'>
<!--
function SetFocus()
{
    document.logon['txtUser'].focus();
}
window.onload = SetFocus;
// -->;
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id=logon action="<%=response.encodeURL(request.getRequestURI())%>" 
method=post runat="server">
			<table height="35%" width="100%" border="0">
				<tr height="100%" width="100%">
					<td vAlign="top" align="left"><IMG src="images\cam_logo.gif"></td>
				</tr>
			</table>
			<table height="20%" width="100%" border="0">
				<tr height="100%" width="100%">
					<td vAlign="bottom" align="center" width="100%" colSpan="2"><asp:label id="lblMessage" runat="server" ForeColor="Red" Font-Size="Larger" Font-Names="Arial"
							Font-Bold="True"></asp:label></td>
				</tr>
				<tr height="100%" width="100%">
					<td class="Logon" vAlign="bottom" align="right" width="45%">User Name</td>
					<td vAlign="bottom" align="left" width="55%"><asp:textbox id="txtUser" runat="server"></asp:textbox></td>
				</tr>
				<tr height="100%" width="100%">
					<td class="Logon" vAlign="top" align="right" width="45%">Password</td>
					<td vAlign="top" align="left" width="55%"><asp:textbox id="txtPassword" runat="server" TextMode="Password"></asp:textbox></td>
				</tr>
				<tr height="100%" width="100%">
					<td class="Logon" vAlign="top" align="right" width="45%">&nbsp;</td>
					<td vAlign="top" align="left" width="55%"><asp:button id="btnLogon" class="button" runat="server" Text="Logon"></asp:button></td>
				</tr>
			</table>
			<table height="40%" width="100%" border="0">
				<tr height="100" width="100%">
					<td class="Logon" vAlign="bottom" align="center" width="50%">This application has 
						been provided by <a href="http://www.tryitsolutions.com">TryIT Solutions Ltd</a></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
