<%@ Page language="c#" Codebehind="meterreading.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.meterreading" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<%
Response.CacheControl="private";
Response.Expires=0;
Response.AddHeader("pragma", "no-cache");
%>
	<!--#include file="head.aspx" -->
	<BODY onunload="parent.location.reload(true);">
		<form id="Form1" runat="server">
			<table width="96%" height="54" align="center">
				<tr>
					<td class="logon">
						<asp:Label id="Label1" runat="server" Font-Size="20pt">Meter Reading</asp:Label>
					</td>
				</tr>
			</table>
			<table width="96%" align="center" border="0">
				<tr>
					<td class="logon" width="30%" height="14"><asp:label id="lblTitle" runat="server"></asp:label></td>
					<td class="logon" width="70%" height="14"><asp:label id="lblMessage" runat="server" ForeColor="Red" Font-Bold="false" Font-Names="Arial"
							Font-Size="Larger"></asp:label></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center" valign="top">
				<tr vAlign="top">
					<td class="logon" width="50%" height="21"><asp:label id="lbldate" runat="server">Date</asp:label></td>
					<td class="data" width="50%" height="21">&nbsp;
						<asp:textbox id="txtDate" runat="server" Width="184px"></asp:textbox>&nbsp;<asp:label id="Label11" runat="server" ForeColor="Red" Font-Bold="True" Font-Names="Arial"
							Font-Size="Larger">*</asp:label></td>
				</tr>
				<tr>
					<td colSpan="2">
						<hr>
					</td>
				</tr>
				<tr>
					<td width="100%" colSpan="2">
						<div style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 200px"><asp:datagrid id="dgRates" runat="server" ForeColor="#56a80f" Font-Bold="false" Width="100%" AutoGenerateColumns="False"
								GridLines="None" CellPadding="5" Font-Name="arial" HorizontalAlign="Center" DataKeyField="rate_id">
								<HeaderStyle BackColor="#56a80f" ForeColor="#dae7ca" Font-Bold="True" HorizontalAlign="Left" />
								<Columns>
									<asp:BoundColumn DataField="rate_id" Visible="False"></asp:BoundColumn>
									<asp:BoundColumn DataField="rate_desc" HeaderText="Rate">
										<ItemStyle Width="50%" VerticalAlign="Top"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Reading">
										<ItemTemplate>
											<asp:TextBox runat="server" id="txtReading" />
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid></div>
					</td>
				</tr>
			</table>
			<hr width="96%">
			<table height="30" width="96%" align="center">
				<tr>
					<td vAlign="middle" align="right" width="100%"><asp:button id="btnUpdate" runat="server" Text="Update" CssClass="button"></asp:button>&nbsp;
						<asp:button id="btnCancel" runat="server" Text="Cancel" CssClass="button"></asp:button></td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
