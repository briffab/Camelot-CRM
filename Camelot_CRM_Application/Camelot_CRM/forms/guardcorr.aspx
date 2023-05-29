<%@ Page language="c#" Codebehind="guardcorr.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.guardcorr" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
	<body>
		<!--#include file="head.aspx" -->
		<form id="Form1" runat="server">
			<P>&nbsp;</P>
			<table width="96%" align="center">
				<tr>
					<td class="logon"><asp:label id="Label1" runat="server" Font-Size="20pt">Guardian Correspondence</asp:label></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center" border="0">
				<tr>
					<td class="logon" vAlign="top" width="25%" height="21"><asp:label id="Label2" runat="server" CssClass="logon">Correspondence Type</asp:label></td>
					<td class="logon" vAlign="top" width="75%" height="21"><asp:dropdownlist id="cmbCtype" runat="server" CssClass="logon" AutoPostBack="True" Width="100%"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td class="logon" vAlign="top" width="25%" height="21"><asp:label id="Label3" runat="server" CssClass="logon">Document</asp:label>
					<td class="logon" vAlign="top" width="75%" height="21"><asp:dropdownlist id="cmbDoc" runat="server" CssClass="logon" AutoPostBack="True" Width="100%"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td vAlign="bottom" align="right" width="100%" colSpan="2"><asp:button id="btnGen" runat="server" CssClass="button" Width="200" Text="Generate Correspondence"></asp:button></td>
				</tr>
			</table>
			<hr width="96%">
			<table id="tblRecipients" width="96%" align="center" border="0">
				<tr>
					<td align="left" width="50%" height=26><asp:label id="lblCount" CssClass="logon" Runat="server"></asp:label></td>
					<td align="right" width="50%" height=26><asp:button id="btnCheck" runat="server" CssClass="button" Text="Uncheck All"></asp:button>&nbsp; 
						&nbsp;
						<asp:button id="btnUncheck" runat="server" CssClass="button" Text="Check All"></asp:button></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" colSpan="2">
						<div style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 300px"><asp:datagrid id="dgGuardians" runat="server" Font-Size="8" Width="100%" AutoGenerateColumns="False"
								GridLines="None" CellPadding="5" Font-Name="arial" ForeColor="#56a80f" Font-Bold="false" HorizontalAlign="Center">
								<HeaderStyle BackColor="#56a80f" ForeColor="#dae7ca" Font-Bold="True" HorizontalAlign="Left" />
								<Columns>
									<asp:BoundColumn DataField="resident_id" Visible="False"></asp:BoundColumn>
									<asp:BoundColumn DataField="email" Visible="false"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Include">
										<ItemTemplate>
											<asp:CheckBox width="5%" id="gchk" runat="server"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="name" HeaderText="Guardian">
										<ItemStyle Width="20%" Font-Bold="True"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="email" HeaderText="Email">
										<ItemStyle Width="20%" Font-Bold="True"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="property" HeaderText="Property">
										<ItemStyle Width="20%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="room" HeaderText="Room">
										<ItemStyle Width="15%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Head" HeaderText="Head Guardian">
										<ItemStyle Width="15%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="date_from" HeaderText="Date Started" DataFormatString="{0:dd MMMM yyyy}">
										<ItemStyle Width="15%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="date_to" HeaderText="Date Finished" DataFormatString="{0:dd MMMM yyyy}">
										<ItemStyle Width="15%"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:datagrid>
						</div>
					</td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center" border="0">
				<tr>
					<td vAlign="middle" align="left" width="100%"><asp:button id="btnClose" runat="server" Text="Close" CssClass="button"></asp:button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>