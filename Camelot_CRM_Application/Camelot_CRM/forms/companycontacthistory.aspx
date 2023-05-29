<%@ Page language="c#" Codebehind="companycontacthistory.aspx.cs" AutoEventWireup="false" Inherits="Camelot.companycontacthistory" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<%
Response.CacheControl="private";
Response.Expires=0;
Response.AddHeader("pragma", "no-cache");
%>
	<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
	<script language='JavaScript'>
		<!--
		function SetFocus()
		{
			document.Form1['txtFind'].focus();
		}

		function keystroke()
		{
			if (window.event.keyCode == 13) 
			{
				event.returnValue=false;
				event.cancel = true;
				document.Form1.btnSearch.click();
			}
		}

		window.onload = SetFocus;
		// -->;
	</script>
	<body onkeydown="keystroke()">
		<!--#include file="head.aspx" -->
		<script language="JavaScript" src="../functions/menu.js"></script>
		<script language="JavaScript" src="../functions/menu<%=Session["menu"]%>.js"></script>
		<script language="JavaScript">
					showToolbar();
		</script>
		<form id="Form1" runat="server">
			<table width="96%" height="54" align="center">
				<tr>
					<td class="logon">
						<asp:Label id="Label1" runat="server" Font-Size="20pt">Company Contact History</asp:Label>
					</td>
				</tr>
			</table>
			<hr width="96%" align="center">
			<table width="96%" align="center">
				<tr>
					<td vAlign="bottom" align="right" width="10%" height="100%">Search</td>
					<td vAlign="bottom" align="left" width="30%" height="100%">&nbsp;
						<asp:dropdownlist id="cmbFind" runat="server" Width="167px">
							<asp:ListItem Value="Company_Name" Selected="True">Owner Name</asp:ListItem>
							<asp:ListItem Value="Contact_name">Contact Name</asp:ListItem>
							<asp:ListItem Value="POSTALCODE">Post Code</asp:ListItem>
							<asp:ListItem Value="CITY">Town/ City</asp:ListItem>
							<asp:ListItem Value="COUNTY">County</asp:ListItem>
							<asp:ListItem Value="DESCRIPTION">Area</asp:ListItem>
						</asp:dropdownlist></td>
					<td vAlign="bottom" align="left" width="40%" height="100%">&nbsp; 
						for&nbsp;&nbsp;&nbsp; &nbsp;
						<asp:textbox id="txtFind" runat="server" Width="192px"></asp:textbox></td>
					<td vAlign="bottom" align="left" width="20%" height="100%">&nbsp;&nbsp;
						<asp:button id="btnSearch" runat="server" Text="Search" CssClass="button"></asp:button></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center">
				<tr>
					<td>
						<asp:datagrid id="dgComps" runat="server" Width="100%" OnItemCommand="set_comp" HorizontalAlign="Center"
							Font-Bold="false" ForeColor="#56a80f" Font-Name="arial" CellPadding="5" GridLines="None" AutoGenerateColumns="False">
							<HeaderStyle BackColor="#56a80f" ForeColor="#dae7ca" Font-Bold="True" HorizontalAlign="Left" />
							<Columns>
								<asp:ButtonColumn DataTextField="company_name" HeaderText="Company">
									<ItemStyle Width="30%" Font-Bold="True"></ItemStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn DataField="company_id" Visible="False"></asp:BoundColumn>
								<asp:BoundColumn DataField="description" HeaderText="Type">
									<ItemStyle Width="20%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="address" HeaderText="Address">
									<ItemStyle Width="50%"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:datagrid></td>
				</tr>
			</table>
			<table width="96%" align="center">
				<tr>
					<td class="logon" width="70%" align="left">
						<asp:Label id="lblComp" runat="server"></asp:Label>
					</td>
					<td vAlign="middle" align="right" width="15%"><input class="button" id="btnRec" type="button" style="WIDTH:200px" value="Received Correspondence"
							name="btnCorr" runat="server">&nbsp;</td>
					<td vAlign="middle" align="right" width="15%"><input class="button" id="btnCorr" type="button" style="WIDTH:200px" value="Send Correspondence"
							name="btnCorr" runat="server">&nbsp;</td>
				</TR>
			</table>
			<table width="96%" align="center">
				<tr>
					<td><asp:datagrid id="dgCorrs" runat="server" Width="100%" Font-Size="8pt" HorizontalAlign="Center"
							Font-Bold="false" ForeColor="#56a80f" Font-Name="arial" CellPadding="5" GridLines="None" AutoGenerateColumns="False"
							OnItemDataBound="dgCorrs_ItemDataBound" DataKeyField="Corr_id">
							<HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="#dae7ca" BackColor="#56a80f"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="Corr_ID"></asp:BoundColumn>
								<asp:ButtonColumn DataTextField="C_date" HeaderText="Date" DataTextFormatString="{0:dd MMMM yyyy}">
									<ItemStyle Width="11%" VerticalAlign="Top"></ItemStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn DataField="type" HeaderText="Type">
									<ItemStyle Width="10%" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="target" HeaderText="Target">
									<ItemStyle Width="7%" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="dir" HeaderText="Direction">
									<ItemStyle Width="7%" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="sent_by" HeaderText="Sent by">
									<ItemStyle Width="15%" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="bulk" HeaderText="Bulk">
									<ItemStyle Width="15%" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="document" HeaderText="Document">
									<ItemStyle Width="35%" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:datagrid></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
