<%@ OutputCache Location="None" VaryByParam="None"%>
<%@ Page language="c#" Codebehind="meterreadings.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.meterreadings" %>
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
			<table width="96%" height="54" align="center">
				<tr>
					<td class="logon">
						<asp:Label id="Label1" runat="server" Font-Size="20pt">Meter Readings</asp:Label>
					</td>
				</tr>
			</table>
			<table width="96%" align="center" border="0">
				<tr>
					<td class="logon" width="30%" height="14"><asp:label id="lblTitle" runat="server"></asp:label></td>
					<td class="logon" width="70%" height="14"><asp:label id="lblMessage" runat="server" Font-Size="Larger" Font-Names="Arial" Font-Bold="false"
							ForeColor="Red"></asp:label></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center" border="0">
				<tr>
					<td><asp:datagrid id="dgMets" runat="server" Font-Bold="false" ForeColor="#56a80f" DataKeyField="reading_id"
							OnItemDataBound="dgmets_ItemDataBound" AutoGenerateColumns="False" GridLines="None" CellPadding="5"
							Font-Name="arial" HorizontalAlign="Center" Width="100%">
							<HeaderStyle BackColor="#56a80f" ForeColor="#dae7ca" Font-Bold="True" HorizontalAlign="Left" />
							<Columns>
								<asp:ButtonColumn DataTextField="dated" HeaderText="Reading Date" DataTextFormatString="{0:dd MMMM yyyy}">
									<ItemStyle Width="25%" Font-Bold="True"></ItemStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn DataField="reading_id" Visible="False"></asp:BoundColumn>
								<asp:BoundColumn DataField="reading" HeaderText="Reading">
									<ItemStyle Width="25%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="inspector" HeaderText="Inspector">
									<ItemStyle Width="25%"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:datagrid></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center" border="0">
				<tr>
					<td vAlign="middle" align="left" width="50%"><asp:button id="btnClose" runat="server" Text="Close" CssClass="button"></asp:button></td>
					<td vAlign="middle" align="right" width="100%"><input class="button" id="btnAdd" type="button" value="Add" name="Button1" runat="server">
						<!--<input class="button" type="button" value="Cancel" />--></td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
