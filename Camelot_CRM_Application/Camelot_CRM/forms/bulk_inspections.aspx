<%@ Page language="c#" Codebehind="bulk_inspections.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.bulk_inspections" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<body>
		<!--#include file="head.aspx" -->
		<script language="JavaScript" src="../functions/menu.js"></script>
		<script language="JavaScript" src="../functions/menu<%=Session["menu"]%>.js"></script>
		<script language="JavaScript">
					showToolbar();
		</script>
		<form id="Form1" name="Form1" method="post" runat="server">
			<table height="54" width="96%" align="center">
				<tr>
					<td class="logon"><asp:label id="Label3" runat="server" Font-Size="20pt">Bulk Inspection Reports</asp:label></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center">
				<tr>
					<td width="50%" valign="top">
						<table width="100%">
							<tr>
								<td class="logon" width="30%" height="25"><asp:label id="lblReps" runat="server">Report Count</asp:label></td>
								<td class="data" width="70%" height="25"><asp:label id="lblnrecs" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td style="WIDTH: 30%" vAlign="top" width="30%"><asp:label id="Label4" runat="server" CssClass="logon">Cc :</asp:label></td>
								<td width="70%"><asp:textbox id="txtCC" runat="server" Width="100%" TextMode="MultiLine"></asp:textbox></td>
							</tr>
							<tr>
								<td width="30%" valign="top" height="25"><asp:Label ID="lbl" Runat="server" CssClass="logon">Attachments :</asp:Label></td>
								<td width="70%" valign="top"><asp:listbox width="100%" SelectionMode="Multiple" Runat="server" ID="lbAtts" Rows="4"></asp:listbox><asp:Button cssclass="button" Text="Remove All" runat="server" id="btnAll" Width="80"></asp:Button></td>
							</tr>
						</table>
					</td>
					<td width="100%" valign="top">
						<table width="100%">
							<tr>
								<td align="right" width="50%" colSpan="2"><asp:Button cssclass="button" Text="Send Reports" runat="server" id="btnSend" Width="150"></asp:Button></td>
							</tr>
							<tr>
								<td style="WIDTH: 30%" vAlign="top" width="30%"><asp:label id="Label2" runat="server" CssClass="logon">Bcc :</asp:label></td>
								<td width="70%"><asp:textbox id="txtBcc" runat="server" Width="100%" TextMode="MultiLine"></asp:textbox></td>
							</tr>
							<tr>
								<td style="WIDTH: 30%" vAlign="top" width="30%"><asp:label id="Label7" runat="server" CssClass="logon">Upload</asp:label></td>
								<td width="70%">
									<OBJECT id="Uploader" codeBase="XUpload.ocx" height="100" width="100%" classid="CLSID:E87F6C8E-16C0-11D3-BEF7-009027438003"
										name="Uploader" VIEWASTEXT>
										<PARAM NAME="_cx" VALUE="7250">
										<PARAM NAME="_cy" VALUE="2646">
										<PARAM NAME="Server" VALUE="localhost">
										<PARAM NAME="Script" VALUE="/camelot/forms/upload_insp_att.aspx">
										<PARAM NAME="Directory" VALUE="">
										<PARAM NAME="Filter" VALUE="All Files(.*)|*.*">
										<PARAM NAME="Extensions" VALUE="">
										<PARAM NAME="Username" VALUE="">
										<PARAM NAME="Password" VALUE="">
										<PARAM NAME="RedirectURL" VALUE="">
										<PARAM NAME="HtmlForm" VALUE="">
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
						</table>
					</td>
				</tr>
			</table>
			<table width="96%" align="center">
				<tr>
					<td style="WIDTH: 15%" vAlign="top" width="30%"><asp:label id="Label5" runat="server" CssClass="logon">Subject :</asp:label></td>
					<td width="85%"><asp:textbox id="txtSubject" runat="server" Width="100%" TextMode="MultiLine"></asp:textbox></td>
				</tr>
				<tr>
					<td style="WIDTH: 15%" vAlign="top" width="30%"><asp:label id="Label1" runat="server" CssClass="logon">Body :</asp:label></td>
					<td width="85%"><asp:textbox id="txtBody" runat="server" TextMode="MultiLine" CssClass="logon" AutoPostBack="false"
							width="100%" Rows="5"></asp:textbox></td>
				</tr>
			</table>
			<hr width="96%" align="center">
			<table width="96%" align="center">
				<tr>
					<td align="left" width="50%"><asp:label id="lblCount" CssClass="logon" Runat="server"></asp:label></td>
					<td align="right" width="50%"><asp:button id="btnCheck" runat="server" CssClass="button" Text="Uncheck All"></asp:button>&nbsp; 
						&nbsp;
						<asp:button id="btnUncheck" runat="server" CssClass="button" Text="Check All"></asp:button></td>
				</tr>
				<tr>
					<td colspan="2">
						<div style=" OVERFLOW:auto; WIDTH:100%; HEIGHT:450px">
							<asp:datagrid id="dgInsps" runat="server" Font-Size="8" Width="100%" HorizontalAlign="Center"
								OnItemCommand="ShowReport" Font-Bold="false" ForeColor="#56a80f" Font-Name="arial" CellPadding="5"
								GridLines="None" AutoGenerateColumns="False">
								<HeaderStyle BackColor="#56a80f" ForeColor="#dae7ca" Font-Bold="True" HorizontalAlign="Left" />
								<Columns>
									<asp:BoundColumn DataField="insp_id" Visible="False"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Send">
										<ItemStyle Width="5%" VerticalAlign="Top"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox id="schk" runat="server"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="object_name" HeaderText="Property">
										<ItemStyle Width="20%" VerticalAlign="Top" Font-Bold="True"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="insp_date" HeaderText="Inspection Date" DataFormatString="{0:dd MMMM yyyy}">
										<ItemStyle Width="15%" VerticalAlign="Top"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="email" HeaderText="Email Recipients">
										<ItemStyle Width="10%" VerticalAlign="Top"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="paper" HeaderText="Printed Recipients">
										<ItemStyle Width="10%" VerticalAlign="Top"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Extra Text">
										<ItemStyle Width="30%" VerticalAlign="Top"></ItemStyle>
										<ItemTemplate>
											<asp:TextBox runat="server" id="txtEBody" Width="100%" Height="50" />
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:ButtonColumn Text="View" HeaderText="View" CommandName="View">
										<ItemStyle Wrap="False" Width="5%" VerticalAlign="Top"></ItemStyle>
										<HeaderStyle Wrap="False"></HeaderStyle>
									</asp:ButtonColumn>
								</Columns>
							</asp:datagrid>
						</div>
					</td>
				</tr>
			</table>
			<hr width="96%">
			<script language="vbscript">
				Sub Uploader_UploadFinish() document.Form1.submit() End Sub 
			</script>
		</form>
	</body>
</HTML>
