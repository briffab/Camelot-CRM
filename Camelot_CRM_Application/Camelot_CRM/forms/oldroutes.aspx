<%@ Page language="c#" Codebehind="oldroutes.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.oldroutes" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
	<body>
		<!--#include file="head.aspx" -->
		<script language="JavaScript" src="../functions/menu.js"></script>
		<script language="JavaScript" src="../functions/menu<%=Session["menu"]%>.js"></script>
		<script language="JavaScript">
					showToolbar();
		</script>
		<form id="Form1" runat="server">
			<table width="96%" align="center">
				<tr>
					<td class="Logon" style="FONT-SIZE: 20pt"><br>
						Current Routes</td>
				</tr>
			</table>
			<hr width="96%" align="center">
			<table width="96%" align="center">
				<tr>
					<td><asp:datagrid id="dgRoutes" AllowSorting="True" runat="server" HorizontalAlign="Center" Font-Bold="false"
							ForeColor="#56a80f" Font-Name="arial" CellPadding="5" GridLines="None" AutoGenerateColumns="False"
							Width="100%" DataKeyField="route_id" OnItemDataBound="dgRoutes_ItemDataBound" Font-Size="8" OnItemCommand="Print">
							<HeaderStyle BackColor="#56a80f" ForeColor="#dae7ca" Font-Bold="True" HorizontalAlign="Left" />
							<Columns>
								<asp:ButtonColumn DataTextField="name" HeaderText="Route">
									<ItemStyle Width="15%" Font-Bold="True"></ItemStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn DataField="route_id" visible="False"></asp:BoundColumn>
								<asp:BoundColumn DataField="firstprop" HeaderText="First Property">
									<ItemStyle Width="20%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="lastprop" HeaderText="Last Property">
									<ItemStyle Width="20%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="num_prop" HeaderText="Number of Properties">
									<ItemStyle Width="10%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="lastinsp" HeaderText="Last Inspected" DataFormatString="{0:dd MMMM yyyy}">
									<ItemStyle Width="20%"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Print" HeaderText="Print" CommandName="Print">
										<ItemStyle Wrap="False"></ItemStyle>
										<HeaderStyle Wrap="False"></HeaderStyle>
								</asp:ButtonColumn>
							</Columns>
						</asp:datagrid></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>