<%@ Page language="c#" Codebehind="property.aspx.cs" AutoEventWireup="false" Inherits="Camelot.property" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
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

<form id=Form1 runat="server">
<table height=54 width="96%" align=center>
  <tr>
    <td class=logon><asp:label id=Label1 runat="server" Font-Size="20pt">Property Details</asp:Label></TD></TR></TABLE>
<hr width="96%">

<table width="96%" align=center>
  <tr>
    <td vAlign=bottom align=right width="10%" height="100%" 
      >Search</TD>
    <td vAlign=bottom align=left width="30%" height="100%" 
      >&nbsp; <asp:dropdownlist id=cmbFind runat="server" Width="167px">
							<asp:ListItem Value="OBJECT_NAME" Selected="True">Address Line 1</asp:ListItem>
							<asp:ListItem Value="STREETNAME">Street Name</asp:ListItem>
							<asp:ListItem Value="POSTALCODE">Post Code</asp:ListItem>
							<asp:ListItem Value="CITY">Town/ City</asp:ListItem>
							<asp:ListItem Value="PROPERTY_ID">Property Number</asp:ListItem>
						</asp:dropdownlist></TD>
    <td vAlign=bottom align=left width="40%" height="100%" 
      >&nbsp; for&nbsp;&nbsp;&nbsp; &nbsp; <asp:textbox id=txtFind runat="server" Width="192px"></asp:textbox></TD>
    <td vAlign=bottom align=left width="20%" height="100%" 
      >&nbsp;&nbsp; <asp:button id=btnSearch runat="server" Text="Search" CssClass="button"></asp:button></TD></TR></TABLE>
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
						</asp:datagrid></TD></TR></TABLE>
<table id=tblDetails width="96%" align=center border=0>
  <tr vAlign=top>
    <td class=logon colSpan=2><asp:label id=lblMessage runat="server" Font-Size="Larger" Font-Bold="false" ForeColor="Red" Font-Names="Arial"></asp:label></TD></TR>
  <tr vAlign=top>
    <td width="50%" height="100%">
      <table width="100%">
        <tr>
          <td class=logon width=249 height=14><asp:label id=lblPropID runat="server">Property ID</asp:label></TD>
          <td class=data width="60%" height=14>&nbsp; <asp:textbox id=txtPropID runat="server" Width="184px"></asp:textbox></TD></TR>
        <tr>
          <td class=logon width=249 height=14><asp:label id=lblKey runat="server">Key Number</asp:label></TD>
          <td class=data width="60%" height=14>&nbsp; <asp:textbox id=txtKey runat="server" Width="184px"></asp:textbox></TD></TR>
        <tr>
          <td class=logon width=249 height=14><asp:label id=lblAddress runat="server">Address</asp:label></TD>
          <td class=data width="60%" height=14>&nbsp; <asp:textbox id=txtAddress1 runat="server" Width="184px"></asp:textbox><asp:label id=lblPropStar runat="server" Font-Size="Larger" Font-Bold="True" ForeColor="Red" Font-Names="Arial">*</asp:label></TD></TR>
        <tr>
          <td width=249 height=24></TD>
          <td class=data width="60%" height=24>&nbsp; <asp:textbox id=txtAddress2 runat="server" Width="184px"></asp:textbox></TD></TR>
        <tr>
          <td width=249></TD>
          <td class=data width="60%">&nbsp; <asp:textbox id=txtAddress3 runat="server" Width="184px"></asp:textbox></TD></TR>
        <tr>
          <td width=249></TD>
          <td class=data width="60%">&nbsp; <asp:textbox id=txtAddress4 runat="server" Width="184px"></asp:textbox></TD></TR>
        <tr>
          <td class=logon width=249><asp:label id=lblTown runat="server">Town/City</asp:label></TD>
          <td class=data width="60%">&nbsp; <asp:textbox id=txtTown runat="server" Width="184px"></asp:textbox></TD></TR>
        <tr>
          <td class=logon width=249><asp:label id=lblPost runat="server">Post Code</asp:label></TD>
          <td class=data width="60%">&nbsp; <asp:textbox id=txtPost runat="server" Width="184px"></asp:textbox></TD></TR>
        <tr>
          <td class=logon width=249 height=21><asp:label id=lblCounty runat="server">County</asp:label></TD>
          <td class=data width="60%" height=21>&nbsp; <asp:textbox id=txtCounty runat="server" Width="184px"></asp:textbox></TD></TR>
        <tr>
          <td class=logon width=249 height=21><asp:label id=lblArea runat="server">Area</asp:label></TD>
          <td class=data width="60%" height=21>&nbsp; <asp:dropdownlist id=cmbArea runat="server" Width="184" CssClass="logon"></asp:dropdownlist></TD></TR>
        <tr>
          <td class=logon width=249 height=21><asp:label id=lblCountry runat="server">Country</asp:label></TD>
          <td class=data width="60%" height=21>&nbsp; <asp:textbox id=txtCountry runat="server" Width="184px"></asp:textbox></TD></TR>
        <tr>
          <td class=logon width=249 height=21><asp:label id=lblProptype runat="server">Property Type</asp:label></TD>
          <td class=data width="60%" height=21>&nbsp; <asp:dropdownlist id=cmbPropType runat="server" Width="184" CssClass="logon"></asp:dropdownlist></TD></TR>
        <tr>
          <td class=logon width=249 height=14><asp:label id=lblRegMan runat="server">Regional Manager</asp:label></TD>
          <td class=data width="60%" height=14>&nbsp; <asp:dropdownlist id=cmbRegMan runat="server" Width="184" CssClass="logon"></asp:dropdownlist></TD></TR>
        <tr>
          <td class=logon width=249 height=31><asp:label id=lblMaxOcc runat="server" Width="152px">Maximum Occupancy</asp:label></TD>
          <td class=data width="60%" height=31>&nbsp; <asp:textbox id=txtMaxOcc runat="server" Width="184px"></asp:textbox></TD></TR>
        <tr>
          <td class=logon align=left width=249><asp:label id=lblCurrOcc runat="server">Current Occupancy</asp:label></TD>
          <td class=data width="60%">&nbsp; <asp:textbox id=txtCurrOcc runat="server" Width="184px"></asp:textbox></TD></TR>
        <tr>
          <td class=logon width=249 height=24><asp:label id=lblPercOcc runat="server">Percentage Occupied </asp:label></TD>
          <td class=data width="60%" height=24>&nbsp; <asp:textbox id=txtPercOcc runat="server" Width="184"></asp:textbox></TD></TR>
        <tr>
          <td class=logon align=left width=249 height=21><asp:label id=lblStatus runat="server">Status</asp:label></TD>
          <td class=data width="60%" height=31>&nbsp; <asp:dropdownlist id=cmbStatus runat="server" Width="184" CssClass="logon"></asp:dropdownlist><asp:label id=lblStatusStar runat="server" Font-Size="Larger" Font-Bold="True" ForeColor="Red" Font-Names="Arial">*</asp:label><asp:button id=btnHist runat="server" Width="50" Text="History" CssClass="button"></asp:button>&nbsp;</TD></TR>
        <tr>
          <td class=logon width=249><asp:label id=lblStatEff runat="server">Status Effective </asp:label></TD>
          <td class=data width="60%">&nbsp; <asp:textbox id=txtStatEff runat="server" Width="184px"></asp:textbox><asp:label id=lblStatstar runat="server" Font-Size="Larger" Font-Bold="True" ForeColor="Red" Font-Names="Arial">*</asp:label></TD></TR></TABLE></TD>
    <td vAlign=top width="50%" height="100%">
      <table width="100%">
        <tr>
          <td class=logon width=249><asp:label id=lblCalam runat="server">Calamity Limit</asp:label></TD>
          <td class=data width="60%"><asp:textbox id=txtCalam runat="server" Width="184px"></asp:textbox></TD></TR>
        <tr>
          <td class=logon width=249><asp:label id=lblMF runat="server">Weekly Fee </asp:label></TD>
          <td class=data width="60%"><asp:textbox id=txtMfee runat="server" Width="184px"></asp:textbox></TD></TR>
        <tr>
          <td class=logon width=249><asp:label id=lblLF runat="server">License Fee </asp:label></TD>
          <td class=data width="60%"><asp:textbox id=txtLfee runat="server" Width="184px"></asp:textbox></TD></TR>
        <tr>
          <td class=logon width=249><asp:label id=lblDtStart runat="server">Date Started</asp:label></TD>
          <td class=data width="60%"><asp:textbox id=txtDtStart runat="server" Width="184px"></asp:textbox><asp:label id=lblstartstar runat="server" Font-Size="Larger" Font-Bold="True" ForeColor="Red" Font-Names="Arial">*</asp:label></TD></TR>
        <tr>
          <td class=logon width=249><asp:label id=lblDtStop runat="server">Date Finished</asp:label></TD>
          <td class=data width="60%"><asp:textbox id=txtDtStop runat="server" Width="184px"></asp:textbox><asp:label id=lblstopstar runat="server" Font-Size="Larger" Font-Bold="True" ForeColor="Red" Font-Names="Arial">*</asp:label></TD></TR>
        <tr>
          <td class=logon width=147 height=17><asp:label id=lblAccMan runat="server">Account Manager </asp:label></TD>
          <td class=data width="60%" height=17><asp:dropdownlist id=cmbAccMan runat="server" Width="184" CssClass="logon"></asp:dropdownlist></TD></TR>
        <tr>
          <td class=logon width=147 height=17><asp:label id=lblPropMan runat="server">Property Manager</asp:label></TD>
          <td class=data width="60%" height=17><asp:dropdownlist id=cmbPropMan runat="server" Width="184" CssClass="logon"></asp:dropdownlist></TD></TR>
        <tr>
          <td class=logon width=147 height=14><asp:label id=lblPropInsp runat="server">Property Inspector</asp:label></TD>
          <td class=data width="60%" height=14><asp:dropdownlist id=cmbPropInsp runat="server" Width="184" CssClass="logon"></asp:dropdownlist></TD></TR>
        <tr>
          <td class=logon width=147><asp:label id=lblGuardMan runat="server" Width="136px">Guardian Manager</asp:label></TD>
          <td class=data width="60%"><asp:dropdownlist id=cmbGuardMan runat="server" Width="184" CssClass="logon"></asp:dropdownlist></TD></TR>
        <tr>
          <td class=logon width=147><asp:label id=lblUpBy runat="server">Last Updated by</asp:label></TD>
          <td class=data width="60%"><asp:label id=lblUby runat="server"></asp:label></TD></TR>
        <tr>
          <td class=logon width=147><asp:label id=lblUpOn runat="server">Last Updated on </asp:label></TD>
          <td class=data width="60%"><asp:label id=lblUDate runat="server"></asp:label></TD></TR>
        <tr>
          <td class=data align=center width="100%" colSpan=2 
          ><asp:image id=imgMainPhoto onclick=openphotos() runat="server" Width="240px" CssClass="photo" Height="160px"></asp:Image>&nbsp; 
          </TD></TR></TABLE></TD></TR></TABLE>
<hr width="96%">

<table height=30 width="96%" align=center>
  <tr>
    <td vAlign=middle align=left width="50%"><asp:button id=btnAdd runat="server" Text="Add" CssClass="button"></asp:button></TD>
    <td vAlign=middle align=left width="50%"><asp:button id=btnChange runat="server" Text="Change Owner" CssClass="button"></asp:button></TD>
    <td vAlign=middle align=right width="100%"><asp:button id=btnEdit runat="server" Text="Edit" CssClass="button"></asp:button><asp:button id=btnUpdate runat="server" Text="Update" CssClass="button"></asp:button>&nbsp; 
<asp:button id=btnCancel runat="server" Text="Cancel" CssClass="button"></asp:button>&nbsp; 
    </TD></TR></TABLE>
<script language=javascript>
					function openphotos()
					{					
						window.showModalDialog('photo_frame.aspx','newprop','dialogHeight:650px; dialogWidth: 900px; dialogTop: 100px; dialogLeft:100px; edge: Raised; center: No; help: No; resizable: No; status: No;');
						self.document.location.href = 'property.aspx';
					}
			</script>
</FORM>
	</body>
</HTML>