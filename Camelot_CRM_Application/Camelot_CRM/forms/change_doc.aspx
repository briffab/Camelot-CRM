<%@ Page language="c#" Codebehind="change_doc.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.change_doc" %>
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
					<td class="logon" width="100%" height="14"><asp:label id="Label20" runat="server" Font-Size="20pt">Change Merge Document</asp:label></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center">
				<tr>
					<td class="logon" width="30%" height="14"><asp:label id="Label1" runat="server" CssClass="logon">Upload New Document</asp:label></td>
					<td><INPUT id="doc" type="file" runat="server" width="250px" NAME="scan">
					</td>
				</tr>
			</table>
			<HR width="96%">
			<TABLE height="30" width="96%" align="center">
				<TR>
					<TD vAlign="middle" align="left" width="33%"><asp:button id="btnClose" runat="server" CssClass="button" Text="Close"></asp:button></TD>
					<td align="right" colSpan="2"><input class="Button" id="btnUpload" type="submit" value="Upload" runat="server" NAME="upload">
					</td>
				</TR>
			</TABLE>
		</form>
	</BODY>
</HTML>
