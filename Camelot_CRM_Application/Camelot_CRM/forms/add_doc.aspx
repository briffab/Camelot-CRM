<%@ Page language="c#" Codebehind="add_doc.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.add_doc" %>
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
			<table height="54" width="96%" align="center">
				<tr>
					<td class="logon"><asp:label id="Label3" runat="server" Font-Size="20pt">New Mail Merge Documents</asp:label></td>
				</tr>
			</table>
			<table width="96%" align="center">
				<tr>
					<td class="logon" width="100%" height="14"><asp:label id="lblMessage" runat="server" Font-Size="Larger" Font-Bold="false" Font-Names="Arial"
							ForeColor="Red"></asp:label></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center" border="0">
				<tr vAlign="top">
					<td class="logon" width="249" height="21"><asp:label id="lblfacdesc" runat="server">Document List Name</asp:label></td>
					<td class="data" width="60%" height="21"><asp:textbox id="txtDocName" runat="server" Width="184px"></asp:textbox><asp:label id="Label11" runat="server" Font-Size="Larger" Font-Bold="True" Font-Names="Arial"
							ForeColor="Red">*</asp:label></td>
				</tr>
				<tr vAlign="top">
					<td class="logon" width="249" height="21"><asp:label id="Label1" runat="server">Document</asp:label></td>
					<td class="data" width="60%" height="21"><INPUT id="doc" type="file" runat="server" width="250px" NAME="scan"></td>
				</tr>
				<tr>
					<td class="logon" width="249" height="21"><asp:label id="Label5" runat="server">Document Type</asp:label></td>
					<td class="data" width="60%" height="21"><asp:dropdownlist id="cmbType" runat="server" CssClass="logon" Width="184"></asp:dropdownlist><asp:label id="Label16" runat="server" Font-Size="Larger" Font-Bold="True" Font-Names="Arial"
							ForeColor="Red">*</asp:label></td>
				</tr>
				<tr vAlign="top">
					<td class="logon" width="249" height="21"><asp:label id="Label6" runat="server">Description</asp:label></td>
					<td class="data" width="60%" height="21"><asp:textbox id="txtnotes" runat="server" Width="272px" TextMode="MultiLine" Height="72px"></asp:textbox></td>
				</tr>
			</table>
			<hr width="96%">
			<table height="30" width="96%" align="center">
				<tr>
					<td vAlign="middle" align="right" width="25%"><asp:button id="btnUpdate" runat="server" CssClass="button" Text="Update"></asp:button>&nbsp;
						<asp:button id="btnCancel" runat="server" CssClass="button" Text="Cancel"></asp:button></td>
				</tr>
			</table>
			<script language="javascript">
					function openphotos()
					{	
						
						window.showModalDialog('photos.aspx?type=3','newprop','dialogHeight:650px; dialogWidth: 900px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');
						//self.document.location.href = 'meterdetails.aspx';
					}
			</script>
		</form>
	</BODY>
</HTML>
