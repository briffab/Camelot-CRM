<%@ Page language="c#" Codebehind="property_stat_hist.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.property_stat_hist" %>
<%@ OutputCache Location="None" VaryByParam="None"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
	<%
Response.CacheControl="private";
Response.Expires=0;
Response.AddHeader("pragma", "no-cache");
%>
	<BODY onunload="parent.location.reload(true);">
		<!--#include file="head.aspx" -->
		<form id="Form1" runat="server">
			<table width="96%" align="center" border="0">
				<tr>
					<td class="logon" width="30%" height="14">Status History</td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center" border="0">
				<tr>
					<td><asp:datagrid id="dgHist" runat="server" Font-Bold="false" ForeColor="#56a80f" DataKeyField="status_id"
							AutoGenerateColumns="False" GridLines="None" CellPadding="5"
							Font-Name="arial" HorizontalAlign="Center" Width="100%">
							<HeaderStyle BackColor="#56a80f" ForeColor="#dae7ca" Font-Bold="True" HorizontalAlign="Left" />
							<Columns>
								<asp:BoundColumn DataField="status_id" Visible="False"></asp:BoundColumn>
								<asp:BoundColumn DataField="status" HeaderText="Status">
									<ItemStyle Width="50%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="date" HeaderText="Date Changed To" DataFormatString="{0:dd MMMM yyyy}">
									<ItemStyle Width="50%"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:datagrid></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center" border="0">
				<tr>
					<td vAlign="middle" align="right" width="100%"><asp:button id="btnClose" runat="server" Text="Close" CssClass="button"></asp:button></td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
