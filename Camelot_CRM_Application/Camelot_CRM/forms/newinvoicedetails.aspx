<%@ Page language="c#" Codebehind="newinvoicedetails.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.newinvoicedetails" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<%
Response.CacheControl="private";
Response.Expires=0;
Response.AddHeader("pragma", "no-cache");
%>
	<BODY>
		<!--#include file="head.aspx" -->
		<form id="Form1" runat="server">
			<table width="96%" align="center">
				<tr>
					<td class="logon" width="33%" height="14"><asp:label id="lblTitle" runat="server"></asp:label></td>
					<td class="logon" width="66%" height="14"><asp:label id="lblMessage" runat="server" ForeColor="Red" Font-Size="Larger" Font-Names="Arial"
							Font-Bold="false"></asp:label></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center" border="0">
				<tr>
					<td vAlign="top" width="50%">
						<table width="100%" valign="top">
							<tr vAlign="top">
								<td class="logon" width="33%" height="21"><asp:label id="lblfacdesc" runat="server">First Name</asp:label></td>
								<td class="data" width="66%" height="21">
									<asp:textbox id="txtComp" runat="server" Width="184px"></asp:textbox>&nbsp;</td>
							</tr>
							<TR>
								<td class="logon" width="33%" height="21"><asp:label id="Label4" runat="server">Status</asp:label></td>
								<td class="data" width="66%" height="21">
									<asp:dropdownlist id="cmbContact" runat="server" Width="184" CssClass="logon"></asp:dropdownlist>&nbsp;</td>
							</TR>
							<tr vAlign="top">
								<td class="logon" width="33%" height="21"><asp:label id="Label2" runat="server">Description</asp:label></td>
								<td class="data" width="66%" height="21">
									<asp:textbox id="txtDesc" runat="server" Width="184px" Height="72px" TextMode="MultiLine"></asp:textbox>&nbsp;</td>
							</tr>
							<TR>
								<td class="logon" width="33%" height="21"><asp:label id="Label1" runat="server">Payment Within</asp:label></td>
								<td class="data" width="66%" height="21">
									<asp:dropdownlist id="cmbPayBy" runat="server" Width="184" CssClass="logon">
										<asp:ListItem Value="7">7 Days</asp:ListItem>
										<asp:ListItem Value="14">14 Days</asp:ListItem>
										<asp:ListItem Value="21">21 Days</asp:ListItem>
										<asp:ListItem Value="28">28 Days</asp:ListItem>
									</asp:dropdownlist>&nbsp;</td>
							</TR>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table width="100%">
							<tr vAlign="top">
								<td class="logon" width="33%" height="21"><asp:label id="Label3" runat="server">Invoice Item</asp:label></td>
								<td class="logon" width="33%" height="21"><asp:label id="Label5" runat="server">Description</asp:label></td>
								<td class="logon" width="136" height="21"><asp:label id="Label6" runat="server">Value</asp:label></td>
								<td class="logon" width="11%" height="21"><asp:label id="Label8" runat="server">VAT</asp:label></td>
								<td class="logon" width="11%" height="21"></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="33%" height="21"></td>
								<td class="data" width="33%" height="21"><asp:textbox id="txtItemDesc" runat="server" Width="100%" Height="72px" TextMode="MultiLine"></asp:textbox>&nbsp;</td>
								<td class="data" width="136" height="21"><asp:textbox id="txtValue" runat="server" Width="89px"></asp:textbox></td>
								<td class="data" width="11%" height="21"><asp:textbox id="TxtVat" runat="server" Width="77px"></asp:textbox></td>
								<td class="data" width="11%" height="21"><asp:button id="btnAdd" runat="server" CssClass="button" Text="Add"></asp:button></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="33%" height="21"><asp:label id="Label7" runat="server">Invoice Items</asp:label></td>
								<td class="data" width="33%" height="21"><asp:listbox id="Textbox1" runat="server" Width="100%" Height="72px"></asp:listbox>&nbsp;</td>
								<td class="data" width="33%" height="21" colspan="3"><asp:button id="btnRemove" runat="server" CssClass="button" Text="Remove"></asp:button></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<hr width="96%">
			<table height="30" width="96%" align="center">
				<tr>
					<td vAlign="middle" align="left" width="50%"><asp:button id="btnClose" runat="server" CssClass="button" Text="Close"></asp:button></td>
					<td vAlign="middle" align="right" width="100%"><asp:button id="btnUpdate" runat="server" CssClass="button" Text="Update"></asp:button>&nbsp;
						<asp:button id="btnCancel" runat="server" CssClass="button" Text="Cancel"></asp:button></td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
