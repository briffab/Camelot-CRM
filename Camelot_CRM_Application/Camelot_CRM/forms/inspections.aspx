<%@ Page language="c#" Codebehind="inspections.aspx.cs" AutoEventWireup="false" Inherits="Camelot.inspections" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<%
Response.CacheControl="private";
Response.Expires=0;
Response.AddHeader("pragma", "no-cache");
%>
	<META http-equiv=Content-Type content="text/html; charset=windows-1252">
<script language=JavaScript>
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
		
		function openfac(insp)
		{
			alert(fac);
			modalURL = "inspection.aspx?insp=" + insp + "','inspdets','dialogHeight: 510px; dialogWidth: 800px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;";
			parentURL = "inspections.aspx";
			
			varModalReturn = window.showModalDialog(modalURL)
			if(varModalReturn==true || varModalReturn==false ||varModalReturn==undefined)
			{
			     window.location = parentURL;
			}
		}     

		window.onload = SetFocus;
		// -->;
	</script>

<body onkeydown=keystroke()>
		<!--#include file="head.aspx" -->
<script language=JavaScript src="../functions/menu.js"></script>
<script language="JavaScript" src="../functions/menu<%=Session["menu"]%>.js"></script>
<script language=JavaScript>
					showToolbar();
		</script>

<form id=Form1 name=Form1 runat="server">
<table width="96%" height="54" align="center">
				<tr>
					<td class="logon">
						<asp:Label id="Label1" runat="server" Font-Size="20pt">Property Inspections</asp:Label>
					</td>
				</tr>
			</table>
<table height=54 width="96%" align=center>
  <tr>
    <td vAlign=bottom align=right width="10%" height="100%" 
      >Search</td>
    <td vAlign=bottom align=left width="30%" height="100%" 
      >&nbsp; <asp:dropdownlist id=cmbFind runat="server" Width="167px">
							<asp:ListItem Value="OBJECT_NAME" Selected="True">Address Line 1</asp:ListItem>
							<asp:ListItem Value="POSTALCODE">Post Code</asp:ListItem>
							<asp:ListItem Value="CITY">Town/ City</asp:ListItem>
						</asp:dropdownlist></td>
    <td vAlign=bottom align=left width="40%" height="100%" 
      >&nbsp; for&nbsp;&nbsp;&nbsp; &nbsp; <asp:textbox id=txtFind runat="server" Width="192px"></asp:textbox></td>
    <td vAlign=bottom align=left width="20%" height="100%" 
      >&nbsp;&nbsp; <asp:button id=btnSearch runat="server" CssClass="button" Text="Search"></asp:button></td></tr></table>
<hr width="96%">
&nbsp;&nbsp;&nbsp;&nbsp; 
<table width="96%" align=center>
  <tr>
    <td><asp:datagrid id=dgProps runat="server" Width="100%" OnItemCommand="set_prop" HorizontalAlign="Center" Font-Bold="false" ForeColor="#56a80f" Font-Name="arial" CellPadding="5" GridLines="None" AutoGenerateColumns="False">
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
						</asp:datagrid></td></tr></table>
<table width="96%" align=center>
  <tr>
    <td class=logon><asp:label id=LblProp runat="server"></asp:label></td>
    <td vAlign=middle align=right><input class=button id="btnPrint" style="WIDTH:150px" type=button value="Print Blank Form" name=btnPrint runat="server">&nbsp;<input class=button id=Button1 type=button value=Add name=Button1 runat="server">
						<!--<input class="button" type="button" value="Cancel" />--></td>
</tr></table>
<table width="96%" align=center>
  <tr>
    <td><asp:datagrid id=dgInps runat="server" Width="100%" HorizontalAlign="Center" ForeColor="#56a80f" Font-Name="arial" CellPadding="5" GridLines="None" AutoGenerateColumns="False" Font-Names="arial" OnItemDataBound="dgInps_ItemDataBound" DataKeyField="object_check_id">
							<HeaderStyle Font-Size="8pt" Font-Bold="True" HorizontalAlign="Left" ForeColor="#dae7ca" BackColor="#56a80f"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn DataTextField="DATE_CHECK" HeaderText="Date" DataTextFormatString="{0:dd MMMM yyyy}">
									<ItemStyle Font-Bold="True" Width="15%" VerticalAlign="Top"></ItemStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn Visible="False" DataField="object_check_id"></asp:BoundColumn>
								<asp:BoundColumn DataField="Remarks" HeaderText="Impression">
									<ItemStyle Width="60%" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="sent" HeaderText="Sent" DataFormatString="{0:dd MMMM yyyy}">
									<ItemStyle Width="15%" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="inspector" HeaderText="Inspector">
									<ItemStyle Width="10%" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:datagrid></td></tr></table>
<hr width="96%">

<table height="3%" width="96%" align="center">
  </table></form>
	</body>
</HTML>