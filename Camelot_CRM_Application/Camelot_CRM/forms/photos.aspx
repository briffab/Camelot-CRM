<%@ Page language="c#" Codebehind="photos.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.photos" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<%
Response.CacheControl="private";
Response.Expires=0;
Response.AddHeader("pragma", "no-cache");
%>
	<BODY onunload="parent.location.reload(true);">
		<!--#include file="head.aspx" -->
		<FORM id="Form1" runat="server">
			<TABLE height="54" width="96%" align="center">
				<TR>
					<TD class="logon"><asp:label id="Label1" runat="server" Font-Size="20pt">Photos</asp:label></TD>
				</TR>
			</TABLE>
			<TABLE width="96%" align="center">
				<TR>
					<TD class="logon" width="100%" height="14"><asp:label id="lblTitle" runat="server"></asp:label></TD>
				</TR>
			</TABLE>
			<HR width="96%">
			<TABLE width="96%" align="center" border="0">
				<TR>
					<TD vAlign="top" width="50%">
						<TABLE width="100%" align="left" border="0">
							<TR>
								<TD vAlign="top">
									<DIV style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 300px"><asp:datagrid id="dgImgs" runat="server" ForeColor="#56a80f" Font-Bold="false" OnItemCommand="ShowPhoto"
											OnDeleteCommand="dgImgs_Delete" DataKeyField="photo_id" AutoGenerateColumns="False" HorizontalAlign="Center" Font-Name="arial" CellPadding="5"
											GridLines="None" Width="100%">
											<HeaderStyle BackColor="#56a80f" ForeColor="#dae7ca" Font-Bold="True" HorizontalAlign="Left" />
											<Columns>
												<asp:BoundColumn DataField="photo_id" Visible="False"></asp:BoundColumn>
												<asp:BoundColumn DataField="Default" Visible="False"></asp:BoundColumn>
												<asp:ButtonColumn Text="Delete" HeaderText="Delete" CommandName="Delete">
													<ItemStyle Wrap="False"></ItemStyle>
													<HeaderStyle Wrap="False"></HeaderStyle>
												</asp:ButtonColumn>
												<asp:ButtonColumn Text="Show" HeaderText="View" CommandName="View">
													<ItemStyle Wrap="False"></ItemStyle>
													<HeaderStyle Wrap="False"></HeaderStyle>
												</asp:ButtonColumn>
												<asp:ButtonColumn Text="Set Default" HeaderText="Default" CommandName="Def">
													<ItemStyle Wrap="False"></ItemStyle>
													<HeaderStyle Wrap="False"></HeaderStyle>
												</asp:ButtonColumn>
												<asp:TemplateColumn HeaderText="Image">
													<ItemTemplate>
														<asp:Image Width="120" Height="80" Runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"ThumbName") %>' />
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
										</asp:datagrid></DIV>
								</TD>
							</TR>
						</TABLE>
					</TD>
					<TD width="50%">
						<TABLE width="100%" align="right" border="0">
							<TR>
								<TD align="center"><IMG id=imgMainPhoto 
            height=300 src="<%=imgUrl%>" width=400>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<HR width="96%">
			<table width="550" align="center">
				<OBJECT id="upload" codeBase="XUpload.ocx" height="100" width="550" align="middle" classid="CLSID:E87F6C8E-16C0-11D3-BEF7-009027438003"
					name="upload" VIEWASTEXT>
					<PARAM NAME="_cx" VALUE="14552">
					<PARAM NAME="_cy" VALUE="2646">
					<PARAM NAME="Server" VALUE="ntsbs01">
					<PARAM NAME="Script" VALUE="/camelot_crm/forms/upload.aspx">
					<PARAM NAME="Directory" VALUE="">
					<PARAM NAME="Filter" VALUE="Images (.jpg)|*.jpg">
					<PARAM NAME="Extensions" VALUE="">
					<PARAM NAME="Username" VALUE="">
					<PARAM NAME="Password" VALUE="">
					<PARAM NAME="RedirectURL" VALUE="http://ntsbs01/camelot_crm/forms/photos.aspx">
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
					<PARAM NAME="RedirectTarget" VALUE="_self">
				</OBJECT>
				</TD></TR></table>
			<script src="../functions/ie_workaround.js" type="text/javascript"></script>
			<HR width="96%">
			<TABLE height="30" width="96%" align="center">
				<TR>
					<TD vAlign="middle" align="left" width="33%">
						<asp:button id="btnClose" runat="server" Text="Close" CssClass="button"></asp:button></TD>
				</TR>
			</TABLE>
			<script language=vbscript>
				sub upload_UploadFinish()
					document.Form1.submit()
				end sub
			</script>
		</FORM>
	</BODY>
</HTML>
