<%@ Page language="c#" Codebehind="emailmerge.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.emailmerge" %>
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
			<table height="54" width="96%" align="center">
				<tr>
					<td class="logon"><asp:label id="Label3" runat="server" Font-Size="20pt">Mail Merge</asp:label></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center" border="0">
				<tr vAlign="top">
					<td class="logon" width="30%" height="21"><asp:label id="lblDocName" runat="server">Document List Name</asp:label></td>
					<td class="data" width="70%" height="21"><asp:label id="lblDoc" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td class="logon" width="30%" height="25"><asp:label id="lblRecs" runat="server">Number of Recipients</asp:label></td>
					<td class="data" width="70%" height="25"><asp:label id="lblnrecs" runat="server"></asp:label></td>
				</tr>
				<tr vAlign="top">
					<td class="logon" width="30%" height="21"><asp:label id="Label6" runat="server">Merge Field 1</asp:label></td>
					<td class="data" width="70%" height="21"><asp:textbox id="txtMerge1" runat="server" Width="100%" TextMode="SingleLine"></asp:textbox></td>
				</tr>
				<tr vAlign="top">
					<td class="logon" width="30%" height="21"><asp:label id="Label10" runat="server">Merge Field 2</asp:label></td>
					<td class="data" width="70%" height="21"><asp:textbox id="txtMerge2" runat="server" Width="100%" TextMode="SingleLine"></asp:textbox></td>
				</tr>
				<tr vAlign="top">
					<td class="logon" width="30%" height="21"><asp:label id="Label11" runat="server">Merge Field 3</asp:label></td>
					<td class="data" width="70%" height="21"><asp:textbox id="txtMerge3" runat="server" Width="100%" TextMode="SingleLine"></asp:textbox></td>
				</tr>
				<tr vAlign="top">
					<td class="logon" width="30%" height="21"><asp:label id="Label12" runat="server">Merge Field 4</asp:label></td>
					<td class="data" width="70%" height="21"><asp:textbox id="txtMerge4" runat="server" Width="100%" TextMode="SingleLine"></asp:textbox></td>
				</tr>
				<tr vAlign="top">
					<td class="logon" width="30%" height="21"><asp:label id="Label13" runat="server">Merge Field 5</asp:label></td>
					<td class="data" width="70%" height="21"><asp:textbox id="txtMerge5" runat="server" Width="100%" TextMode="SingleLine"></asp:textbox></td>
				</tr>
				<tr vAlign="top">
					<td class="logon" width="30%" height="21"><asp:label id="Label14" runat="server">Merge Field 6</asp:label></td>
					<td class="data" width="70%" height="21"><asp:textbox id="txtMerge6" runat="server" Width="100%" TextMode="SingleLine"></asp:textbox></td>
				</tr>
			</table>
			<hr align="center" width="96%">
			<table width="96%" align="center">
				<tr>
					<td style="WIDTH: 30%" vAlign="top" width="30%"><asp:label id="Label4" runat="server" CssClass="logon">Cc :</asp:label></td>
					<td width="70%"><asp:textbox id="txtCC" runat="server" Width="100%" TextMode="MultiLine"></asp:textbox></td>
				<tr>
					<td style="WIDTH: 30%" vAlign="top" width="30%"><asp:label id="Label2" runat="server" CssClass="logon">Bcc :</asp:label></td>
					<td width="70%"><asp:textbox id="txtBcc" runat="server" Width="100%" TextMode="MultiLine"></asp:textbox></td>
				</tr>
				<tr>
					<td style="WIDTH: 30%" vAlign="top" width="30%"><asp:label id="Label5" runat="server" CssClass="logon">Subject :</asp:label></td>
					<td width="70%"><asp:textbox id="txtSubject" runat="server" Width="100%" TextMode="MultiLine"></asp:textbox></td>
					</TD></tr>
				<tr>
					<td style="WIDTH: 30%" vAlign="top" width="30%"><asp:label id="Label7" runat="server" CssClass="logon">Attachment :</asp:label></td>
					<td width="70%">
						<OBJECT id="Uploader" codeBase="XUpload.ocx" height="100" width="100%" classid="CLSID:E87F6C8E-16C0-11D3-BEF7-009027438003"
							name="Uploader" VIEWASTEXT>
							<PARAM NAME="_cx" VALUE="14552">
							<PARAM NAME="_cy" VALUE="2646">
							<PARAM NAME="Server" VALUE="ntsbs01">
							<PARAM NAME="Script" VALUE="/camelot_crm/forms/send_emailmerge.aspx">
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
					<td width="70%"><asp:textbox id="txtBody" runat="server" TextMode="MultiLine" CssClass="logon" AutoPostBack="false"
							width="100%" Rows="10"></asp:textbox></td>
				</tr>
				<tr>
					<td style="WIDTH: 30%" align="left" width="50%"><asp:button id="btnClose" runat="server" Width="145" CssClass="button" Text="Close"></asp:button></td>
					<td align="right" width="50%" colSpan="2"><INPUT class="button" style="WIDTH: 150px" type="button" value="Merge and Send" name="UPLOAD">
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
					if form1.txtCc.value <> "" then form1.Uploader.addFormItem "cc", form1.txtCc.value
					if form1.txtBcc.value <> "" then form1.Uploader.addFormItem "bcc", form1.txtBcc.value
					if form1.txtSubject.value <> "" then form1.Uploader.addFormItem "subject", form1.txtSubject.value
					if form1.txtBody.value <> "" then form1.Uploader.addFormItem "body", form1.txtBody.value
					if form1.txtMerge1.value <> "" then form1.Uploader.addFormItem "merge1", form1.txtMerge1.value
					if form1.txtMerge2.value <> "" then form1.Uploader.addFormItem "merge2", form1.txtMerge2.value
					if form1.txtMerge3.value <> "" then form1.Uploader.addFormItem "merge3", form1.txtMerge3.value
					if form1.txtMerge4.value <> "" then form1.Uploader.addFormItem "merge4", form1.txtMerge4.value
					if form1.txtMerge5.value <> "" then form1.Uploader.addFormItem "merge5", form1.txtMerge5.value
					if form1.txtMerge6.value <> "" then form1.Uploader.addFormItem "merge6", form1.txtMerge6.value
					form1.Uploader.Upload
				End Sub
				
				Sub Uploader_UploadFinish()
					alert("Email Sent !!")
				End Sub
			</SCRIPT>
		</form>
	</body>
</HTML>
