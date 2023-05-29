<%@ Page language="c#" Codebehind="incidentdetails.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.incidentdetails" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<%
Response.CacheControl="private";
Response.Expires=0;
Response.AddHeader("pragma", "no-cache");
%>
	<BODY onunload="parent.location.reload(true);">
		<!--#include file="head.aspx" -->
		<form id="Form1" runat="server">
			<table height="54" width="96%" align="center">
				<tr>
					<td class="logon" width="30%"><asp:label id="Label4" runat="server" Font-Size="20pt">Incident Details</asp:label></td>
					<td class="logon" width="70%"><asp:label id="lblMessage" runat="server" Font-Size="10pt" ForeColor="red" Font-Bold="True"></asp:label></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center" border="0">
				<tr>
					<td vAlign="top" width="50%">
						<table width="100%">
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label7" runat="server">Incident Date</asp:label></td>
								<td class="data" width="60%" height="25"><asp:label id="lblIncDate" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="21"><asp:label id="Label5" runat="server">Urgency</asp:label></td>
								<td class="data" width="60%" height="21"><asp:dropdownlist id="cmbUrg" runat="server" AutoPostBack="True" CssClass="logon" Width="184"></asp:dropdownlist>&nbsp;<asp:label id="lblUrgStar" runat="server" Font-Size="Larger" ForeColor="Red" Font-Bold="True"
										Font-Names="Arial">*</asp:label></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="21"><asp:label id="Label6" runat="server">Property</asp:label></td>
								<td class="data" width="60%" height="21"><asp:dropdownlist id="cmbProp" runat="server" AutoPostBack="True" CssClass="logon" Width="184"></asp:dropdownlist>&nbsp;<asp:label id="lblPropStar" runat="server" Font-Size="Larger" ForeColor="Red" Font-Bold="True"
										Font-Names="Arial">*</asp:label></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="25"><asp:label id="Label8" runat="server">On Website</asp:label></td>
								<td class="data" width="60%" height="25"><asp:checkbox id="chkWeb" runat="server"></asp:checkbox></td>
							</tr>
						</table>
					</td>
					<td vAlign="top" width="50%">
						<table cellPadding="0" width="100%">
							<tr>
								<td class="logon" width="249" height="21"><asp:label id="lblfactype" runat="server">Incident Type</asp:label></td>
								<td class="data" width="60%" height="21"><asp:dropdownlist id="cmbinctype" runat="server" CssClass="logon" Width="184"></asp:dropdownlist>&nbsp;<asp:label id="lblIncStar" runat="server" Font-Size="Larger" ForeColor="Red" Font-Bold="True"
										Font-Names="Arial">*</asp:label></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="16"><asp:label id="Label11" runat="server">Incident Source</asp:label></td>
								<td class="data" width="60%" height="16"><asp:dropdownlist id="cmbincsource" runat="server" AutoPostBack="True" CssClass="logon" Width="184"></asp:dropdownlist>&nbsp;<asp:label id="lblSrcStar" runat="server" Font-Size="Larger" ForeColor="Red" Font-Bold="True"
										Font-Names="Arial">*</asp:label></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label1" runat="server">Resolution Date</asp:label></td>
								<td class="data" width="60%" height="25"><asp:label id="lblResDate" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="25"><asp:label id="lblUpBy" runat="server">Entered by</asp:label></td>
								<td class="data" width="60%" height="25"><asp:label id="lblUby" runat="server"></asp:label></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center" border="0">
				<tr>
					<td vAlign="top" width="50%">
						<table width="100%">
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label3" runat="server">Name</asp:label></td>
								<td width="60%" height="21"><asp:textbox class="data" id="txtName" runat="server" Width="184px"></asp:textbox><asp:dropdownlist id="cmbName" runat="server" AutoPostBack="True" CssClass="logon" Width="184"></asp:dropdownlist>&nbsp;<asp:label id="lblNameStar" runat="server" Font-Size="Larger" ForeColor="Red" Font-Bold="True"
										Font-Names="Arial">*</asp:label></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label13" runat="server">Email</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox class="data" id="txtEmail" runat="server" Width="184px"></asp:textbox>&nbsp;</td>
							</tr>
						</table>
					</td>
					<td vAlign="top" width="50%">
						<table cellPadding="0" width="100%">
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label17" runat="server">Telephone</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox class="data" id="txtPhone" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label19" runat="server">Mobile</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox class="data" id="txtMobile" runat="server" Width="184px"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label21" runat="server">Wk Phone</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox class="data" id="txtWkPhone" runat="server" Width="184px"></asp:textbox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center" border="0">
				<tr>
					<td class="logon" vAlign="top" width="20%" height="21"><asp:label id="Label25" runat="server">Incident Description</asp:label></td>
					<td vAlign="top" width="80%"><asp:textbox id="txtDesc" runat="server" Width="100%" Height="72px" TextMode="MultiLine"></asp:textbox></td>
				</tr>
				<tr>
					<td class="logon" vAlign="top" width="20%" height="21"><asp:label id="Label26" runat="server">Proprosed Resolution</asp:label></td>
					<td vAlign="top" width="80%"><asp:textbox id="txtPRes" runat="server" Width="100%" Height="72px" TextMode="MultiLine"></asp:textbox></td>
				</tr>
			</table>
			<hr width="96%">
			<table height="30" width="96%" align="center">
				<tr vAlign="top">
					<td class="logon" width="100%" height="21"><asp:label id="Label2" runat="server">Actions Taken</asp:label></td>
				</tr>
				<tr vAlign="top">
					<td width="100%">
						<div style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 130px"><asp:datagrid id="dgAction" runat="server" Font-Size="8pt" ForeColor="#56a80f" Font-Bold="false"
								Width="100%" OnItemDataBound="dgAction_ItemDataBound" DataKeyField="action_id" AutoGenerateColumns="False" HorizontalAlign="Center" Font-Name="arial"
								CellPadding="5" GridLines="None" ShowFooter="true">
								<HeaderStyle BackColor="#56a80f" ForeColor="#dae7ca" Font-Bold="True" Font-Size="8" HorizontalAlign="Left" />
								<Columns>
									<asp:ButtonColumn DataTextField="date_entered" HeaderText="Action Date" DataTextFormatString="{0:dd MMMM yyyy HH:mm}">
										<ItemStyle Width="20%" VerticalAlign="top" Font-Bold="True"></ItemStyle>
									</asp:ButtonColumn>
									<asp:BoundColumn DataField="action_id" Visible="False"></asp:BoundColumn>
									<asp:BoundColumn DataField="action_undertaken" HeaderText="Action">
										<ItemStyle Width="10%" VerticalAlign="top"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="description" HeaderText="Description">
										<ItemStyle Width="40%" VerticalAlign="top"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="responsible" HeaderText="Responsible">
										<ItemStyle Width="15%" VerticalAlign="top"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="status" HeaderText="Status">
										<ItemStyle Width="15%" VerticalAlign="top"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:datagrid></div>
					</td>
				</tr>
			</table>
			<hr width="96%">
			<table height="30" width="96%" align="center">
				<tr>
					<td vAlign="middle" align="left" width="33%"><asp:button id="btnClose" runat="server" CssClass="button" Text="Close"></asp:button></td>
					<td vAlign="middle" align="center" width="33%"><asp:button id="btnAction" runat="server" CssClass="button" Text="New Action"></asp:button></td>
					<td vAlign="middle" align="right" width="34%"><asp:button id="btnEdit" runat="server" CssClass="button" Text="Edit"></asp:button><asp:button id="btnUpdate" runat="server" CssClass="button" Text="Update"></asp:button>&nbsp;
						<asp:button id="btnCancel" runat="server" CssClass="button" Text="Cancel"></asp:button></td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
