<%@ Page language="c#" Codebehind="newInspection.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.NewInspection" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<%
Response.CacheControl="private";
Response.Expires=0;
Response.AddHeader("pragma", "no-cache");
%>
	<BODY onunload="parent.location.reload(true);">
		<!--#include file="head.aspx" -->
		<form id="Form2" runat="server">
			<table width="96%" height="54" align="center">
				<tr>
					<td class="logon">
						<asp:Label id="Label10" runat="server" Font-Size="20pt">New Inspection</asp:Label>
					</td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center">
				<tr>
					<td class="logon" width="30%" height="14"><asp:label id="lblTitle" runat="server"></asp:label></td>
					<td class="logon" width="70%" height="14"><asp:label id="lblMessage" runat="server" ForeColor="Red" Font-Size="Larger" Font-Names="Arial"
							Font-Bold="false"></asp:label></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center" border="0">
				<tr vAlign="top">
					<td width="50%" height="100%">
						<table width="100%">
							<tr>
								<td class="logon" width="147"><asp:label id="lblPropInsp" runat="server">Property Inspector</asp:label></td>
								<td class="data" width="60%"><asp:dropdownlist id="cmbPropInsp" runat="server" CssClass="logon" Width="184"></asp:dropdownlist><asp:label id="lblInspStar" runat="server" Font-Size="Larger" Font-Bold="True" Font-Names="Arial"
										ForeColor="Red">*</asp:label></td>
							</tr>
						</table>
					</td>
					<td width="50%" height="100%">
						<table width="100%">
							<tr>
								<td class="logon" id="Label2" width="147" runat="server">Inspection Date</td>
								<td class="data" width="60%"><asp:textbox id="txtDate" runat="server" CssClass="logon" Width="184"></asp:textbox><asp:label id="lblDateStar" runat="server" Font-Size="Larger" Font-Bold="True" Font-Names="Arial"
										ForeColor="Red">*</asp:label></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="96%" align="center">
				<tr>
					<td width="100%">
						<div style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 152px">
							<asp:datagrid id="dgMets" runat="server" Font-Bold="false" ForeColor="#56a80f" Width="100%" DataKeyField="reading_id"
								AutoGenerateColumns="False" GridLines="None" Font-Size="8pt" CellPadding="5" Font-Name="arial"
								HorizontalAlign="Center">
								<HeaderStyle BackColor="#56a80f" ForeColor="#dae7ca" Font-Bold="True" HorizontalAlign="Left" />
								<Columns>
									<asp:BoundColumn DataField="description" HeaderText="Meter Type">
										<ItemStyle Width="20%" Font-Bold="True" VerticalAlign="Top"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="reading_id" Visible="False"></asp:BoundColumn>
									<asp:BoundColumn DataField="meter_id" Visible="False"></asp:BoundColumn>
									<asp:BoundColumn DataField="rate_id" Visible="False"></asp:BoundColumn>
									<asp:BoundColumn DataField="serialnumber" HeaderText="Serial Number">
										<ItemStyle Width="20%" VerticalAlign="Top"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Rate_desc" HeaderText="Rate">
										<ItemStyle Width="20%" VerticalAlign="Top"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="reading" HeaderText="Last Reading">
										<ItemStyle Width="20%" VerticalAlign="Top"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="New Reading">
										<ItemTemplate>
											<asp:TextBox width="100%" runat="server" id="txtRead" />
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid></div>
					</td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center">
				<tr>
					<td class="logon" width="40%"><asp:label id="Label1" runat="server">Comments In Report</asp:label></td>
					<td width="10%"></td>
					<td class="logon" width="40%"><asp:label id="Label3" runat="server">Other Comments</asp:label></td>
				</tr>
				<tr>
					<td width="40%"><asp:listbox id="lbInRep" CssClass="data" runat="server" Width="100%" SelectionMode="Multiple"
							Rows="8"></asp:listbox></td>
					<td width="5%">
						<table height="30" width="96%" align="center">
							<tr>
								<td vAlign="middle" align="center"><asp:button id="btnMto" runat="server" Text="►" CssClass="button" Width="50"></asp:button></td>
							</tr>
							<tr>
								<td vAlign="middle" align="center"><asp:button id="btnMfrom" runat="server" Text="◄" CssClass="button" Width="50"></asp:button></td>
							</tr>
						</table>
					</td>
					<td width="40%"><asp:listbox id="lbNotRep" CssClass="data" runat="server" Width="100%" SelectionMode="Multiple"
							Rows="8"></asp:listbox></td>
				</tr>
			</table>
			<table align="center" width="96%">
				<tr>
					<td class="logon" width="100%"><asp:label id="Label4" runat="server">Further Comments for Report</asp:label></td>
				</tr>
				<tr>
					<td>
						<asp:textbox id="txtOther" runat="server" CssClass="logon" Width="100%" TextMode="MultiLine"
							Rows="4"></asp:textbox>
					</td>
				</tr>
			</table>
			<table height="30" width="96%" align="center">
				<tr>
					<td vAlign="middle" align="left" width="50%"><asp:button id="btnNote" runat="server" CssClass="button" Text="Add Note"></asp:button></td>
					<td vAlign="middle" align="right" width="100%"><asp:button id="btnUpdate" runat="server" CssClass="button" Text="Update"></asp:button>&nbsp;
						<asp:button id="btnCancel" runat="server" CssClass="button" Text="Cancel"></asp:button></td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
