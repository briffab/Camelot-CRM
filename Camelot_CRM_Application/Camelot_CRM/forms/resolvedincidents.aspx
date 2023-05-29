<%@ Page language="c#" Codebehind="resolvedincidents.aspx.cs" AutoEventWireup="false" Inherits="Camelot.reolvedincidents" %>
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
			<table width="96%" align="center">
				<tr>
					<td class="logon">
						<asp:Label id="LblProp" runat="server" Font-Size="20pt">All Resolved Incidents</asp:Label>
					</td>
				</tr>
			</table>
			<table width="96%" align="center">
				<tr>
					<td valign="top">
						<div style=" OVERFLOW:auto; WIDTH:100%; HEIGHT:500px">
						<asp:datagrid id="dgIncs" name="dgIncs" AllowSorting="true" OnSortCommand="SortIncs" runat="server" Width="100%" AutoGenerateColumns="False"
							GridLines="None" CellPadding="5" Font-Name="arial" Font-Size="8" ForeColor="#56a80f" Font-Bold="false" HorizontalAlign="Center"
							DataKeyField="inc" OnItemDataBound="dgIncs_ItemDataBound">
							<HeaderStyle BackColor="#56a80f" ForeColor="#dae7ca" Font-Bold="True" HorizontalAlign="Left" />
							<Columns>
								<asp:ButtonColumn DataTextField="inc" HeaderText="Incident No" SortExpression="inc">
									<ItemStyle Width="8%" VerticalAlign="top" Font-Bold="True"></ItemStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn DataField="inc_date" HeaderText="Reported" DataFormatString="{0:dd MMMM yyyy HH:MM}" SortExpression="rep_date">
									<ItemStyle Width="15%" VerticalAlign="top"></ItemStyle>
								</asp:BoundColumn>							
								<asp:BoundColumn DataField="urgency" HeaderText="Urgency" SortExpression="urg">
									<ItemStyle Width="10%" VerticalAlign="top"></ItemStyle>
								</asp:BoundColumn>								
								<asp:BoundColumn DataField="status" HeaderText="Status" SortExpression="status">
									<ItemStyle Width="10%" VerticalAlign="top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="act_desc" HeaderText="Last Action" SortExpression="last_action">
									<ItemStyle Width="22%" VerticalAlign="top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="act_date" HeaderText="Date of Action" DataFormatString="{0:dd MMMM yyyy HH:MM}" SortExpression="act_date">
									<ItemStyle Width="15%" VerticalAlign="top"></ItemStyle>
								</asp:BoundColumn>	
								<asp:BoundColumn DataField="type" HeaderText="Incident Type" SortExpression="inc_type">
									<ItemStyle Width="10%" VerticalAlign="top"></ItemStyle>
								</asp:BoundColumn>	
								<asp:BoundColumn DataField="resolution_date" HeaderText="Resolution Date" SortExpression="res_date">
									<ItemStyle Width="15%" VerticalAlign="top"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:datagrid>
						</div>
					</td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" height="3%">
				<tr>
					<td width="100%" valign="middle" align="right">
						<input class="button" type="button" value="Add" id="Button1" name="Button1" runat="server">
						<!--<input class="button" type="button" value="Cancel" />-->
					</td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
