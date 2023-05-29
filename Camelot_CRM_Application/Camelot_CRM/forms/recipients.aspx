<%@ Page language="c#" Codebehind="recipients.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.recipients" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<%
Response.CacheControl="private";
Response.Expires=0;
Response.AddHeader("pragma", "no-cache");
%>
	<BODY>
		<!--#include file="head.aspx" -->
		<form id="Form1" runat="server">
			<table width="96%" align="center">
				<tr>
					<td class="logon">
						<asp:Label id="Label10" runat="server" Font-Size="20pt">Recipients</asp:Label>
					</td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center" border="0">
				<tr vAlign="top">
					<td class="logon" width="50%"><asp:label id="Label6" runat="server">Type Name or Select from List</asp:label></td>
					<td class="logon" width="50%"><asp:label id="Label9" runat="server">Show Names from :</asp:label></td>
				</tr>
				<tr>
					<td class="data" width="50%"><asp:textbox id="txtName" OnTextChanged="txtName_TextChanged" runat="server" Width="100%" AutoPostBack="True"></asp:textbox></td>
					<td class="data" width="50%"><asp:DropDownList Runat="server" CssClass="data" width="100%" id="cmbRecs" AutoPostBack="True">
							<asp:ListItem Value="0">Camelot</asp:ListItem>
							<asp:ListItem Value="1">Companies</asp:ListItem>
							<asp:ListItem Value="2">Guardians</asp:ListItem>
						</asp:DropDownList>
					</td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td width="100%">
						<div style=" OVERFLOW:auto; WIDTH:100%; HEIGHT:152px">
							<asp:datagrid id="dgGuards" runat="server" Width="100%" Font-Size="8pt" AutoGenerateColumns="False"
								GridLines="None" CellPadding="5" Font-Name="arial" ForeColor="#56a80f" Font-Bold="false" HorizontalAlign="Center">
								<HeaderStyle BackColor="#56a80f" ForeColor="#dae7ca" Font-Bold="True" HorizontalAlign="Left" />
								<Columns>
									<asp:ButtonColumn DataTextField="name" HeaderText="Property">
										<ItemStyle Width="30%" Font-Bold="True"></ItemStyle>
									</asp:ButtonColumn>
									<asp:BoundColumn DataField="name" Visible="False"></asp:BoundColumn>
									<asp:BoundColumn DataField="resident_id" Visible="False"></asp:BoundColumn>
									<asp:BoundColumn DataField="object_name" HeaderText="Property">
										<ItemStyle Width="35%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="email" HeaderText="Email">
										<ItemStyle Width="35%"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:datagrid>
						</div>
					</td>
				</tr>
			</table>
			<hr width="96%">
			<table height="20" width="96%" align="center">
				<tr>
					<td vAlign="middle" align="left" width="50%"><asp:button id="btnClose" runat="server" CssClass="button" Text="Close"></asp:button></td>
					<td vAlign="middle" align="right" width="100%">
						<asp:button id="btnOK" runat="server" CssClass="button" Text="OK"></asp:button></td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
