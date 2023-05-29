<%@ Page language="c#" Codebehind="vettingscans.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.vettingscans" %>
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
					<td class="logon" width="100%" height="14"><asp:label id="Label20" runat="server" Font-Size="20pt">Vetting Scans</asp:label></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center">
				<tr>
					<td class="logon" width="30%" height="14"><asp:label id="lblTitle" runat="server"></asp:label></td>
					<td class="logon" width="70%" height="14"><asp:label id="lblMessage" runat="server" Font-Size="Larger" Font-Bold="false" Font-Names="Arial"
							ForeColor="Red"></asp:label></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center">
				<tr>
					<td class="logon" width="30%" height="14"><asp:label id="Label1" runat="server" CssClass="logon">Upload Scan</asp:label></td>
					<td><INPUT id="scan" type="file" runat="server" width="250px">
					</td>
				</tr>
				<tr>
					<td class="logon" width="30%" height="14"><asp:label id="Label2" runat="server" CssClass="logon">Description</asp:label></td>
					<td><asp:textbox id="txtScan" runat="server" Width="250px"></asp:textbox><asp:label id="lblstar" runat="server" Font-Size="Larger" Font-Bold="True" Font-Names="Arial"
							ForeColor="Red">*</asp:label></td>
				</tr>
				<tr>
					<td align="right" colSpan="2"><input class="Button" id="upload" type="submit" value="Upload" runat="server">
					</td>
				</tr>
			</table>
			<TABLE width="96%" align="center" border="0">
				<TR>
					<TD vAlign="top" width="50%">
						<TABLE width="100%" align="left" border="0">
							<TR>
								<TD vAlign="top">
									<DIV style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 200px"><asp:datagrid id="dgScans" runat="server" Font-Bold="false" ForeColor="#56a80f" Width="100%" GridLines="None"
											CellPadding="5" Font-Name="arial" HorizontalAlign="Center" AutoGenerateColumns="False" DataKeyField="vs_id" OnDeleteCommand="dgScans_Delete" OnItemCommand="ShowScan">
											<HeaderStyle BackColor="#56a80f" ForeColor="#dae7ca" Font-Bold="True" HorizontalAlign="Left" />
											<Columns>
												<asp:BoundColumn DataField="vs_id" Visible="False"></asp:BoundColumn>
												<asp:ButtonColumn Text="Delete" HeaderText="Delete" CommandName="Delete">
													<ItemStyle Wrap="False" Width="10%"></ItemStyle>
													<HeaderStyle Wrap="False"></HeaderStyle>
												</asp:ButtonColumn>
												<asp:ButtonColumn Text="Show" HeaderText="View" CommandName="View">
													<ItemStyle Wrap="False" Width="10%"></ItemStyle>
													<HeaderStyle Wrap="False"></HeaderStyle>
												</asp:ButtonColumn>
												<asp:BoundColumn DataField="description" HeaderText="Description">
													<ItemStyle Wrap="False" Width="80%"></ItemStyle>
													<HeaderStyle Wrap="False"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="date_entered" HeaderText="Scan Date" DataFormatString="{0:dd MMMM yyyy}">
													<ItemStyle Wrap="False" Width="80%"></ItemStyle>
													<HeaderStyle Wrap="False"></HeaderStyle>
												</asp:BoundColumn>
											</Columns>
										</asp:datagrid></DIV>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<HR width="96%">
			<TABLE height="30" width="96%" align="center">
				<TR>
					<TD vAlign="middle" align="left" width="33%"><asp:button id="btnClose" runat="server" CssClass="button" Text="Close"></asp:button></TD>
				</TR>
			</TABLE>
		</form>
	</BODY>
</HTML>
