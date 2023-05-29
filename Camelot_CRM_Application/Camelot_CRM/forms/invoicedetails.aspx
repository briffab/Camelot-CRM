<%@ Page language="c#" Codebehind="invoicedetails.aspx.cs" AutoEventWireup="false" Inherits="Camelot.invoicedetails" %>
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
			<table width="96%" align="center">
				<tr>
					<td class="logon" width="315" height="14"><asp:label id="lblTitle" runat="server"></asp:label></td>
					<td class="logon" width="70%" height="14"><asp:label id="lblMessage" runat="server" ForeColor="Red" Font-Size="Larger" Font-Names="Arial"
							Font-Bold="false"></asp:label></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center" border="0">
				<tr>
					<td vAlign="top" width="50%">
						<table width="100%" valign="top">
							<tr vAlign="top">
								<td class="logon" width="33%" height="21"><asp:label id="lblfacdesc" runat="server">Date</asp:label></td>
								<td class="data" width="66%" height="21"><asp:textbox id="txtDate" runat="server" Width="296px"></asp:textbox>&nbsp;
									<asp:label id="lblDateStar" runat="server" ForeColor="Red" Font-Size="Larger" Font-Names="Arial"
										Font-Bold="True">*</asp:label></td>
							</tr>
							<TR>
								<td class="logon" width="33%" height="21"><asp:label id="Label4" runat="server">Recipient</asp:label></td>
								<td class="data" width="66%" height="21"><asp:dropdownlist id="cmbContact" runat="server" Width="296px" CssClass="logon"></asp:dropdownlist>&nbsp;</td>
							</TR>
							<tr vAlign="top">
								<td class="logon" width="33%" height="21"><asp:label id="Label2" runat="server">Description</asp:label></td>
								<td class="data" width="66%" height="21"><asp:textbox id="txtDesc" runat="server" Width="296px" Height="72px" TextMode="MultiLine"></asp:textbox>&nbsp;</td>
							</tr>
							<TR>
								<td class="logon" width="33%" height="21"><asp:label id="Label1" runat="server">Payment Within</asp:label></td>
								<td class="data" width="66%" height="21"><asp:dropdownlist id="cmbPayBy" runat="server" Width="296px" CssClass="logon"></asp:dropdownlist>&nbsp;</td>
							</TR>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table width="100%">
							<tr vAlign="top">
								<td class="logon" width="33%" height="21"><asp:label id="Label12" runat="server">Total</asp:label></td>
								<td class="logon" width="22%" height="21"><asp:label id="Label9" runat="server">Value</asp:label></td>
								<td class="logon" width="22%" height="21"><asp:label id="Label10" runat="server">VAT</asp:label></td>
								<td class="logon" width="22%" height="21"><asp:label id="Label11" runat="server">Total</asp:label></td>
							</tr>
							<tr>
								<td class="data" width="22%" height="21"></td>
								<td class="data" width="22%" height="21"><asp:textbox id="txtTValue" runat="server"></asp:textbox>&nbsp;</td>
								<td class="data" width="22%" height="21"><asp:textbox id="txtTVat" runat="server"></asp:textbox>&nbsp;</td>
								<td class="data" width="22%" height="21"><asp:textbox id="txtTotal" runat="server"></asp:textbox>&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table width="100%">
							<tr vAlign="top">
								<td class="logon" width="33%" height="21"><asp:label id="Label7" runat="server">Invoice Items</asp:label></td>
								<td class="data" width="33%" height="21"><asp:listbox id="lbItems" runat="server" Width="100%" Height="72px"></asp:listbox>&nbsp;</td>
								<td class="data" width="33%" colSpan="3" height="21"><asp:button id="btnView" runat="server" CssClass="button" Text="View"></asp:button>&nbsp;<asp:button id="btnRemove" runat="server" CssClass="button" Text="Remove"></asp:button></td>
							</tr>
							<tr vAlign="top">
								<td class="logon" width="33%" height="21"><asp:label id="Label3" runat="server">Invoice Item</asp:label></td>
								<td class="logon" width="33%" height="21"><asp:label id="Label5" runat="server">Description</asp:label></td>
								<td class="logon" width="11%" height="21"><asp:label id="Label6" runat="server">Value</asp:label></td>
								<td class="logon" width="22%" colSpan="2" height="21"><asp:label id="Label8" runat="server">VAT</asp:label></td>
							</tr>
							<tr vAlign="top">
								<td class="data" width="33%" height="21"><asp:label id="Label14" runat="server"></asp:label></td>
								<td class="data" width="33%" height="21"><asp:textbox id="txtItemDesc" runat="server" Width="100%" Height="72px" TextMode="MultiLine"></asp:textbox>&nbsp;</td>
								<td class="data" width="11%" height="21"><asp:textbox id="txtValue" runat="server" Width="65px"></asp:textbox></td>
								<td class="data" width="11%" height="21"><asp:textbox id="txtVat" runat="server" Width="65px"></asp:textbox></td>
								<td class="data" width="11%" height="21"><asp:button id="btnAdd" runat="server" CssClass="button" Text="Add"></asp:button></td>
							</tr>
							<tr>
								<td class="logon" width="33%" height="25"><asp:label id="lblUpBy" runat="server">Sent by</asp:label></td>
								<td class="data" width="66%" colSpan="4" height="25"><asp:label id="lblUby" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td class="logon" width="33%" height="25"><asp:label id="Label13" runat="server">Paid on</asp:label></td>
								<td class="data" width="66%" colSpan="4" height="25"><asp:textbox id="txtPaid" runat="server" Width="296px"></asp:textbox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<hr width="96%">
			<table height="30" width="96%" align="center">
				<tr>
					<td vAlign="middle" align="left" width="50%"><asp:button id="btnClose" runat="server" CssClass="button" Text="Close"></asp:button></td>
					<td vAlign="middle" align="right" width="100%"><asp:button id="btnEdit" runat="server" CssClass="button" Text="Edit"></asp:button><asp:button id="btnUpdate" runat="server" CssClass="button" Text="Update"></asp:button>&nbsp;
						<asp:button id="btnCancel" runat="server" CssClass="button" Text="Cancel"></asp:button></td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
