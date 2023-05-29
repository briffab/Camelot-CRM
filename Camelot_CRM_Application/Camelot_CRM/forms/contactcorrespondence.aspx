<%@ Page language="c#" Codebehind="contactcorrespondence.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.contactcorrespondence" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
	<%
Response.CacheControl="private";
Response.Expires=0;
Response.AddHeader("pragma", "no-cache");
%>
	<body onkeydown="keystroke()">
		<!--#include file="head.aspx" -->
		<form id="Form1" runat="server">
			<table width="96%" height="54" align="center">
				<tr>
					<td class="logon">
						<asp:Label id="Label1" runat="server" Font-Size="20pt">Contact Correspondence</asp:Label>
					</td>
				</tr>
				<tr>
					<td class="logon">
						<asp:Label id="lblCont" runat="server" CssClass="logon"></asp:Label>
					</td>
				</tr>
			</table>
			<hr width="96%" align="center">
			<table width="96%" align="center">
				<tr>
					<td><asp:datagrid id="dgCorrs" runat="server" Width="100%" Font-Size="8pt" HorizontalAlign="Center"
							Font-Bold="false" ForeColor="#56a80f" Font-Name="arial" CellPadding="5" GridLines="None" AutoGenerateColumns="False"
							OnItemDataBound="dgCorrs_ItemDataBound" DataKeyField="Corr_id">
							<HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="#dae7ca" BackColor="#56a80f"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="Corr_ID"></asp:BoundColumn>
								<asp:ButtonColumn DataTextField="C_date" HeaderText="Date" DataTextFormatString="{0:dd MMMM yyyy}">
									<ItemStyle Width="15%" VerticalAlign="Top"></ItemStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn DataField="type" HeaderText="Type">
									<ItemStyle Width="15%" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="target" HeaderText="Target">
									<ItemStyle Width="15%" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="dir" HeaderText="Direction">
									<ItemStyle Width="10%" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="sent_by" HeaderText="Sent by">
									<ItemStyle Width="15%" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="bulk" HeaderText="Bulk">
									<ItemStyle Width="5%" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="document" HeaderText="Document">
									<ItemStyle Width="25%" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:datagrid></td>
				</tr>
			</table>
			<hr width="96%">
			<table height="3%" width="96%" align="center">
				<tr>
					<td vAlign="middle" align="left" width="50%"><asp:button id="btnClose" runat="server" CssClass="button" Text="Close"></asp:button></td>
					<td vAlign="middle" align="right" width="50%"><input class="button" id="btnCorr" type="button" style="WIDTH:200px" value="Send Correspondence"
							name="btnCorr" runat="server">&nbsp;</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
