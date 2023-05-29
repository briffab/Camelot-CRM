<%@ Page language="c#" Codebehind="applicants_held_IRE.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.applications_held_IRE" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
	<body>
		<!--#include file="head.aspx" -->
		<script language="JavaScript" src="../functions/menu<%=Session["menu"]%>.js"></script>
		<script language="JavaScript" src="../functions/menu.js"></script>
		<script language="JavaScript">
					showToolbar();
		</script>
		<form id="Form1" runat="server">
			<table width="96%" align="center">
				<tr>
					<td class="Logon" ><br>Held Guardian Applications</td>
				</tr>
			</table>
			<hr width="96%" align=center>
			<table width="96%" align="center">
				<tr>
					<td vAlign="right" align="right" width="100%"><input class="button" id="btnEmail" type="button" value="Email"
							name="btnEmail" runat="server"></td>
				</tr>
			</table>
			<table width="96%" align="center">
				<tr>
					<td><asp:datagrid id="dgApplicants" AllowSorting="True" runat="server" HorizontalAlign="Center" Font-Bold="false" ForeColor="#56a80f"
							Font-Name="arial" CellPadding="5" GridLines="None" AutoGenerateColumns="False" Width="100%"
							DataKeyField="app_id" OnItemDataBound="dgApplicants_ItemDataBound" Font-Size="8" OnSortCommand="SortApps" OnDeleteCommand="dgApp_delete">
							<HeaderStyle BackColor="#56a80f" ForeColor="#dae7ca" Font-Bold="True" HorizontalAlign="Left" />
							<Columns>
								<asp:BoundColumn DataField="app_id" visible="False"></asp:BoundColumn>
								<asp:BoundColumn DataField="location" HeaderText="Location" SortExpression="location">
									<ItemStyle Width="10%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="date" HeaderText="Date" SortExpression="date">
									<ItemStyle Width="15%"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn DataTextField="name" HeaderText="Name" SortExpression="name">
									<ItemStyle Width="15%" Font-Bold="True"></ItemStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn DataField="Email" HeaderText="Email">
									<ItemStyle Width="15%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Mobile" HeaderText="Mobile">
									<ItemStyle Width="8%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Occup" HeaderText="Occupation">
									<ItemStyle Width="15%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="dob" HeaderText="Date of Birth" SortExpression="dob" DataFormatString="{0:dd MMMM yyyy}">
									<ItemStyle Width="12%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Criminal" HeaderText="Criminal" SortExpression="crim" DataFormatString="{0:dd MMMM yyyy}">
									<ItemStyle Width="5%"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Delete" HeaderText="Delete Item" CommandName="Delete">
									<ItemStyle Wrap="False"></ItemStyle>
									<HeaderStyle Wrap="False"></HeaderStyle>
								</asp:ButtonColumn>
								<asp:TemplateColumn HeaderText="Action">
									<ItemTemplate>
										<asp:CheckBox width="5%" id="chk" runat="server"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>