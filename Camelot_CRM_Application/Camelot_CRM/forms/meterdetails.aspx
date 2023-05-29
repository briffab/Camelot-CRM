<%@ Page language="c#" Codebehind="meterdetails.aspx.cs" AutoEventWireup="false" Inherits="Camelot.meterdetails" %>
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
			<table width="96%" height="54" align="center">
				<tr>
					<td class="logon">
						<asp:Label id="Label3" runat="server" Font-Size="20pt">Meter Details</asp:Label>
					</td>
				</tr>
			</table>
			<table width="96%" align="center">
				<tr>
					<td class="logon" width="30%" height="14"><asp:label id="lblTitle" runat="server"></asp:label></td>
					<td class="logon" width="70%" height="14"><asp:label id="lblMessage" runat="server" ForeColor="Red" Font-Size="Larger" Font-Names="Arial"
							Font-Bold="false"></asp:label></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center" border="0">
				<tr>
					<td vAlign="top" width="50%">
						<table width="100%">
							<tr>
								<td class="logon" width="249" height="21"><asp:label id="lblfactype" runat="server">Meter Type</asp:label></td>
								<td class="data" width="60%" height="21"><asp:dropdownlist id="cmbmettype" runat="server" Width="184" CssClass="logon"></asp:dropdownlist>&nbsp;
									<asp:label id="Label12" runat="server" ForeColor="Red" Font-Size="Larger" Font-Names="Arial"
										Font-Bold="True">*</asp:label></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="lblfacdesc" runat="server">Location</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtloc" runat="server" Width="184px"></asp:textbox>&nbsp;<asp:label id="Label11" runat="server" ForeColor="Red" Font-Size="Larger" Font-Names="Arial"
										Font-Bold="True">*</asp:label></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label1" runat="server">Serial Number</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtmetsn" runat="server" Width="184px"></asp:textbox>&nbsp;
									<asp:label id="Label4" runat="server" ForeColor="Red" Font-Size="Larger" Font-Names="Arial"
										Font-Bold="True">*</asp:label></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="21"><asp:label id="Label5" runat="server">Supply</asp:label></td>
								<td class="data" width="60%" height="21"><asp:dropdownlist id="cmbsupp" runat="server" Width="184" CssClass="logon"></asp:dropdownlist>&nbsp;<asp:label id="Label16" runat="server" ForeColor="Red" Font-Size="Larger" Font-Names="Arial"
										Font-Bold="True">*</asp:label></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label7" runat="server">Start Date</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtStart" runat="server" Width="184px"></asp:textbox>&nbsp;<asp:label id="Label10" runat="server" ForeColor="Red" Font-Size="Larger" Font-Names="Arial"
										Font-Bold="True">*</asp:label></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="25"><asp:label id="Label9" runat="server">In Use</asp:label></td>
								<td class="data" width="60%" height="25"><asp:checkbox id="chkUse" runat="server" AutoPostBack="True"></asp:checkbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label15" runat="server">Finish Date</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtFinish" runat="server" Width="184px"></asp:textbox>&nbsp;<asp:label id="Label17" runat="server" ForeColor="Red" Font-Size="Larger" Font-Names="Arial"
										Font-Bold="True">*</asp:label></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="25"><asp:label id="lblUpBy" runat="server">Last Updated by</asp:label></td>
								<td class="data" width="60%" height="25"><asp:label id="lblUby" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td class="logon" width="249" height="25"><asp:label id="lblUpOn" runat="server">Last Updated on </asp:label></td>
								<td class="data" width="60%" height="25"><asp:label id="lblUDate" runat="server"></asp:label></td>
							</tr>
						</table>
					</td>
					<td vAlign="top" width="50%">
						<table cellPadding="0" width="100%">
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label6" runat="server">Notes</asp:label></td>
								<td class="data" width="60%" height="21"><asp:textbox id="txtnotes" runat="server" Width="272px" Height="72px" TextMode="MultiLine"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="249" height="21"><asp:label id="Label8" runat="server">Photo</asp:label></td>
								<td class="data" align="left" width="60%">&nbsp;<asp:image id="imgMainPhoto" CssClass="photo" runat="server" Width="240px" Height="160px"></asp:image></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<hr width="96%">
			<table height="30" width="96%" align="center">
				<tr vAlign="top">
					<td class="logon" width="100%" height="21"><asp:label id="Label2" runat="server">Readings</asp:label></td>
				</tr>
				<tr vAlign="top">
					<td width="100%" align="left">
						<div style="OVERFLOW: auto; WIDTH: 850px; HEIGHT: 240px" align="left"><asp:datagrid Width="100%" id="dgRead" runat="server" ForeColor="#56a80f" Font-Bold="false" OnUpdateCommand="dgRead_Update"
								OnCancelCommand="dgRead_Cancel" OnEditCommand="dgRead_Edit" HorizontalAlign="Center" Font-Name="arial" CellPadding="5" GridLines="None" ShowFooter="true" OnDeleteCommand="dgRead_Delete">
								<HeaderStyle BackColor="#56a80f" ForeColor="#dae7ca" Font-Bold="True" HorizontalAlign="Left" />
								<Columns>
									<asp:EditCommandColumn EditText="Edit" CancelText="Cancel" UpdateText="Update" HeaderText="Edit Item">
										<ItemStyle Wrap="False"></ItemStyle>
										<HeaderStyle Wrap="False"></HeaderStyle>
									</asp:EditCommandColumn>
									<asp:ButtonColumn Text="Delete" HeaderText="Delete Item" CommandName="Delete">
										<ItemStyle Wrap="False"></ItemStyle>
										<HeaderStyle Wrap="False"></HeaderStyle>
									</asp:ButtonColumn>
								</Columns>
							</asp:datagrid></div>
					</td>
				</tr>
			</table>
			<hr width="96%">
			<table height="30" width="96%" align="center">
				<tr>
					<td vAlign="middle" align="left" width="25%"><asp:button id="btnClose" runat="server" CssClass="button" Text="Close"></asp:button></td>
					<td vAlign="middle" align="center" width="25%"><asp:button id="btnRate" runat="server" CssClass="button" Text="Edit Rates"></asp:button></td>
					<td vAlign="middle" align="center" width="25%"><asp:button id="btnReadings" runat="server" CssClass="button" Text="New Reading"></asp:button>
					<td vAlign="middle" align="right" width="25%"><asp:button id="btnEdit" runat="server" CssClass="button" Text="Edit"></asp:button><asp:button id="btnUpdate" runat="server" CssClass="button" Text="Update"></asp:button>&nbsp;
						<asp:button id="btnCancel" runat="server" CssClass="button" Text="Cancel"></asp:button></td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
