<%@ Page language="c#" Codebehind="property_rincidents.aspx.cs" AutoEventWireup="false" Inherits="Camelot.property_rincidents" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<%
Response.CacheControl="private";
Response.Expires=0;
Response.AddHeader("pragma", "no-cache");
%>
<HTML>
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
		
		function openfac(fac)
		{
			alert(fac);
			modalURL = "facilitydetails.aspx?fac=" + fac + "','facdets','dialogHeight: 510px; dialogWidth: 800px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;";
			parentURL = "property_facilities.aspx";
			
			varModalReturn = window.showModalDialog(modalURL)
			if(varModalReturn==true || varModalReturn==false ||varModalReturn==undefined)
			{
			     window.location = parentURL;
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
		<form ID="Form1" name="Form1" runat="server">
			<table width="96%" height="54" align="center">
				<tr>
					<td class="logon">
						<asp:Label id="Label1" runat="server" Font-Size="20pt">Resolved Property Incidents</asp:Label>
					</td>
				</tr>
			</table>
			<hr width="96%" align="center">
			<table width="96%" align="center">
				<tr>
					<td vAlign="bottom" align="right" width="10%" height="100%">Search</td>
					<td vAlign="bottom" align="left" width="30%" height="100%">&nbsp;
						<asp:dropdownlist id="cmbFind" runat="server" Width="167px">
							<asp:ListItem Value="OBJECT_NAME" Selected="True">Address Line 1</asp:ListItem>
							<asp:ListItem Value="POSTALCODE" >Post Code</asp:ListItem>
							<asp:ListItem Value="CITY">Town/ City</asp:ListItem>
							<asp:ListItem Value="PROPERTY_ID">Property Number</asp:ListItem>
						</asp:dropdownlist></td>
					<td vAlign="bottom" align="left" width="40%" height="100%">&nbsp; 
						for&nbsp;&nbsp;&nbsp; &nbsp;
						<asp:textbox id="txtFind" runat="server" Width="192px"></asp:textbox></td>
					<td vAlign="bottom" align="left" width="20%" height="100%">&nbsp;&nbsp;
						<asp:button id="btnSearch" runat="server" Text="Search" CssClass="button"></asp:button></td>
				</tr>
			</table>
			<hr width="96%">
			&nbsp;&nbsp;&nbsp;&nbsp;
			<table width="96%" align="center">
				<tr>
					<td>
						<asp:datagrid id="dgProps" runat="server" Width="100%" AutoGenerateColumns="False" GridLines="None"
							CellPadding="5" Font-Name="arial" ForeColor="#56a80f" Font-Bold="false" HorizontalAlign="Center"
							OnItemCommand="set_prop">
							<HeaderStyle BackColor="#56a80f" ForeColor="#dae7ca" Font-Bold="True" HorizontalAlign="Left" />
							<Columns>
								<asp:ButtonColumn DataTextField="name" HeaderText="Property">
									<ItemStyle Width="30%" Font-Bold="True"></ItemStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn DataField="name" Visible="False"></asp:BoundColumn>
								<asp:BoundColumn DataField="prop" Visible="False"></asp:BoundColumn>
								<asp:BoundColumn DataField="company_id" Visible="False"></asp:BoundColumn>
								<asp:BoundColumn DataField="Address" HeaderText="Address">
									<ItemStyle Width="40%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Owner" HeaderText="Owner">
									<ItemStyle Width="30%"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:datagrid>
					</td>
				</tr>
			</table>
			<table width="96%" align="center">
				<tr>
					<td class="logon">
						<asp:Label id="LblProp" runat="server"></asp:Label>
					</td>
				</tr>
			</table>
			<table width="96%" align="center">
				<tr>
					<td>
						<asp:datagrid id="dgIncs" name="dgIncs" runat="server" Width="100%" AutoGenerateColumns="False"
							GridLines="None" CellPadding="5" Font-Name="arial" Font-Size="8" ForeColor="#56a80f" Font-Bold="false" HorizontalAlign="Center"
							DataKeyField="inc" OnItemDataBound="dgIncs_ItemDataBound">
							<HeaderStyle BackColor="#56a80f" ForeColor="#dae7ca" Font-Bold="True" HorizontalAlign="Left" />
							<Columns>
								<asp:ButtonColumn DataTextField="Date_entered" HeaderText="Date Closed" DataTextFormatString="{0:dd MMMM yyyy HH:MM}">
									<ItemStyle Width="15%" VerticalAlign="top" Font-Bold="True"></ItemStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn DataField="inc" Visible="False"></asp:BoundColumn>
								<asp:BoundColumn DataField="inc_date" HeaderText="Reported" DataFormatString="{0:dd MMMM yyyy HH:MM}">
									<ItemStyle Width="15%" VerticalAlign="top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="description" HeaderText="Description">
									<ItemStyle Width="30%" VerticalAlign="top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="action_undertaken" HeaderText="Resolution">
									<ItemStyle Width="30%" VerticalAlign="top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="status" HeaderText="Status">
									<ItemStyle Width="10%" VerticalAlign="top"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:datagrid>
					</td>
				</tr>
			</table>
			<hr width="96%">
		</form>
	</BODY>
</HTML>
