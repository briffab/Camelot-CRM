<%@ Page language="c#" validateRequest="false" Codebehind="emailInd.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.emailInd" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Camelot Properties CRM</title>
		<%
Response.CacheControl="private";
Response.Expires=0;
Response.AddHeader("pragma", "no-cache");
%>
		<base target="_self">
		<LINK href="../stylesheets/camelot.css" type="text/css" rel="stylesheet">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
  </HEAD>
	<body>
		<form id="Form1" name="Form1" method="post" runat="server">
			<table width="96%" align="center">
				<tr>
					<td vAlign="top" width="50%"><asp:label id="Label1" runat="server" Font-Size="20pt" CssClass="logon">Compose Mail Message</asp:label></td>
					<td width="50%"><asp:label id="lblMessage" runat="server" CssClass="logon"></asp:label></td>
				</tr>
			</table>
			<hr align="center" width="96%">
			<table width="96%" align="center">
				<tr>
					<td style="WIDTH: 30%" vAlign="top" width="30%"><asp:label id="Label4" runat="server" CssClass="logon">To :</asp:label></td>
					<td width="60%"><asp:textbox id="txtTo" runat="server" Width="100%" TextMode="MultiLine"></asp:textbox></td>
				<tr>
					<td style="WIDTH: 30%" vAlign="top" width="30%"><asp:label id="Label2" runat="server" CssClass="logon">Cc :</asp:label></td>
					<td width="70%"><asp:textbox id="txtCc" runat="server" Width="100%" TextMode="MultiLine"></asp:textbox></td>
				</tr>
				<tr>
					<td style="WIDTH: 30%" vAlign="top" width="30%"><asp:label id="Label6" runat="server" CssClass="logon">Bcc :</asp:label></td>
					<td width="70%"><asp:textbox id="txtBcc" runat="server" Width="100%" TextMode="MultiLine"></asp:textbox></td>
				</tr>
				<tr>
					<td style="WIDTH: 30%" vAlign="top" width="30%"><asp:label id="Label5" runat="server" CssClass="logon">Subject :</asp:label></td>
					<td width="70%"><asp:textbox id="txtSubject" runat="server" Width="100%" TextMode="MultiLine"></asp:textbox></td></TD></tr>
				<tr>
					<td style="WIDTH: 30%" vAlign="top" width="30%"><asp:label id="Label7" runat="server" CssClass="logon">Attachment :</asp:label></td>
					<td width="70%">
      <OBJECT id=Uploader codeBase=XUpload.ocx height=100 width="100%" 
      classid=CLSID:E87F6C8E-16C0-11D3-BEF7-009027438003 name=Uploader 
      VIEWASTEXT>
	<PARAM NAME="_cx" VALUE="15637">
	<PARAM NAME="_cy" VALUE="2646">
	<PARAM NAME="Server" VALUE="ntsbs01">
	<PARAM NAME="Script" VALUE="/camelot_crm/forms/send_email.aspx">
	<PARAM NAME="Directory" VALUE="">
	<PARAM NAME="Filter" VALUE="All Files(.*)|*.*">
	<PARAM NAME="Extensions" VALUE="">
	<PARAM NAME="Username" VALUE="">
	<PARAM NAME="Password" VALUE="">
	<PARAM NAME="RedirectURL" VALUE="">
	<PARAM NAME="HtmlForm" VALUE="Form1">
	<PARAM NAME="SSL" VALUE="0">
	<PARAM NAME="ViewServerReply" VALUE="0">
	<PARAM NAME="EnablePopupMenu" VALUE="-1">
	<PARAM NAME="ShowLoginDialog" VALUE="-1">
	<PARAM NAME="ShowErrors" VALUE="-1">
	<PARAM NAME="Redirect" VALUE="0">
	<PARAM NAME="ShowProgress" VALUE="-1">
	<PARAM NAME="MaxFileSize" VALUE="0">
	<PARAM NAME="MaxTotalSize" VALUE="0">
	<PARAM NAME="MaxFileCount" VALUE="0">
	<PARAM NAME="Port" VALUE="0">
	<PARAM NAME="IncludeDateInfo" VALUE="-1">
	<PARAM NAME="International" VALUE="">
	<PARAM NAME="IncludeSubfoldersChecked" VALUE="0">
	<PARAM NAME="RegKey" VALUE="">
	<PARAM NAME="AskAfter" VALUE="1000">
	<PARAM NAME="CanLaunch" VALUE="0">
	<PARAM NAME="RedirectTarget" VALUE="">
	</OBJECT>
						<script src="../functions/ie_workaround.js" type="text/javascript"></script>
					</td>
				</tr>
				<tr>
					<td style="WIDTH: 30%" vAlign="top" width="30%"><asp:label id="Label9" runat="server" CssClass="logon"></asp:label></td>
					<td align="right" width="70%"><INPUT class="button" type="button" value="Remove" name="REMOVE">&nbsp;&nbsp;<INPUT class="button" type="button" value="Remove All" name="REMOVEALL">&nbsp;&nbsp;<INPUT class="button" type="button" value="Select" name="SELECT"></td>
				</tr>
				<tr>
					<td style="WIDTH: 30%" vAlign="top" width="30%"><asp:label id="Label8" runat="server" CssClass="logon">Body :</asp:label></td>
					<td width="70%"><asp:textbox id="txtBody" runat="server" CssClass="logon" TextMode="MultiLine" AutoPostBack="false"
							width="100%" Rows="10"></asp:textbox></td>
				</tr>
				<tr>
					<td style="WIDTH: 30%" align="left" width="50%"><asp:button id="btnClose" runat="server" CssClass="button" Width="145" Text="Close"></asp:button></td>
					<td align="right" colspan="2" width="50%"><INPUT class="button" type="button" value="Send Email" name="UPLOAD">
					</td>
				</tr>
			</table>
			<SCRIPT language="VBScript"> 
				Sub Select_OnClick 
					form1.Uploader.Select
				End Sub 
				Sub Remove_OnClick 
					form1.Uploader.RemoveHighlighted 
				End Sub 

				Sub RemoveAll_OnClick 
					form1.Uploader.RemoveAll 
				End Sub 

				Sub Upload_OnClick 
					form1.Uploader.RemoveAllFormItems
					if form1.txtTo.value <> "" then form1.Uploader.addFormItem "to", form1.txtTo.value
					if form1.txtCC.value <> "" then form1.Uploader.addFormItem "cc", form1.txtCC.value
					if form1.txtBcc.value <> "" then form1.Uploader.addFormItem "bcc", form1.txtBcc.value
					if form1.txtSubject.value <> "" then form1.Uploader.addFormItem "subject", form1.txtSubject.value
					if form1.txtBody.value <> "" then form1.Uploader.addFormItem "body", form1.txtBody.value
					form1.Uploader.Upload
				End Sub
				
				Sub Uploader_UploadFinish()
					alert("Email Sent !!!")
				End Sub
			</SCRIPT>
		</form>
	</body>
</HTML>
