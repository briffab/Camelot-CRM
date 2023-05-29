<%@ Page language="c#" Codebehind="employees.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.employees" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<%
Response.CacheControl="private";
Response.Expires=0;
Response.AddHeader("pragma", "no-cache");
%>
	<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
	<body onkeydown="keystroke()">
		<!--#include file="head.aspx" -->
		<script language="JavaScript" src="../functions/menu<%=Session["menu"]%>.js"></script>
		<script language="JavaScript" src="../functions/menu.js"></script>
		<script language="JavaScript">
					showToolbar();
		</script>
		<form ID="Form1" name="Form1" runat="server">
			<table width="96%" align="center">
				<tr>
					<td class="logon">
						<asp:Label id="LblProp" runat="server" Font-Size="20pt">Employees</asp:Label>
					</td>
				</tr>
			</table>
			<table width="96%" align="center">
				<tr>
					<td valign="top">
						<div style=" OVERFLOW:auto; WIDTH:100%; HEIGHT:500px">
							<asp:datagrid id="dgEmps" runat="server" Width="100%" AutoGenerateColumns="False" GridLines="None" CellPadding="5" Font-Name="arial"
								ForeColor="#56a80f" Font-Bold="false" HorizontalAlign="Center" DataKeyField="employee_id"
								OnItemDataBound="dgEmps_ItemDataBound">
								<HeaderStyle BackColor="#56a80f" ForeColor="#dae7ca" Font-Bold="True" HorizontalAlign="Left" />
								<Columns>
									<asp:BoundColumn DataField="employee_id" HeaderText="Employee ID" Visible="False">
									</asp:BoundColumn>
									<asp:ButtonColumn DataTextField="name" HeaderText="Employee">
										<ItemStyle Width="30%" VerticalAlign="top"></ItemStyle>
									</asp:ButtonColumn>
									<asp:BoundColumn DataField="active" HeaderText="Active" SortExpression="status">
										<ItemStyle Width="10%" VerticalAlign="top"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="job_title" HeaderText="Job Title" >
										<ItemStyle Width="30%" VerticalAlign="top"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="mobile_PHONE" HeaderText="Mobile" >
										<ItemStyle Width="30%" VerticalAlign="top"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:datagrid>
						</div>
					</td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" height="3%" align="center">
				<tr>
					<td width="100%" valign="middle" align="right">
						<input class="button" type="button" value="Add" id="Button1" name="Button1" runat="server">
						<!--<input class="button" type="button" value="Cancel" />-->
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
