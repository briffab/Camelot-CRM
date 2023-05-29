<%@ Page language="c#" Codebehind="Bankdetails.aspx.cs" AutoEventWireup="false" Inherits="Camelot.Bankdetails" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<!--#include file="head.aspx" -->
	<body>
			<form id="Form1" method="post" runat="server">
				<table width="96%" height="54" align="center">
				<tr>
					<td class="logon">
						<asp:Label id="Label3" runat="server" Font-Size="20pt">Bank Details</asp:Label>
					</td>
				</tr>
			</table>
				<table width="96%" align="center" height="27">
					<tr>
						<td class="logon" width="30%" height="14"><asp:label id="lblTitle" runat="server"></asp:label></td>
						<td class="logon" width="70%" height="14"><asp:label id="lblMessage" runat="server" ForeColor="Red" Font-Size="Larger" Font-Names="Arial"
								Font-Bold="false"></asp:label></td>
					</tr>
				</table>
				<table width="96%" align="center" border="0" height="209">
					<tr>
						<td width="30%" class="logon">Sort Code</td>
						<td width="70%" class="data"><asp:textbox id="txtSortCode" runat="server"></asp:textbox>
<asp:label id=Label2 runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Larger" ForeColor="Red">*</asp:label></td>
					</tr>
					<tr>
						<td width="30%" class="logon">Account Number</td>
						<td width="70%" class="data"><asp:textbox id="txtAccount" runat="server" Width="272px"></asp:textbox>
<asp:label id=Label1 runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Larger" ForeColor="Red">*</asp:label></td>
					</tr>
					<tr>
						<td width="30%" class="logon" height=25>Account Name</td>
						<td width="70%" class="data" height=25><asp:textbox id="txtAName" runat="server" Width="272px"></asp:textbox></td>
					</tr>
					<tr>
						<td width="30%" class="logon">Day of Debit</td>
						<td width="70%" class="data"><asp:textbox id="txtDDate" runat="server" Width="272px"></asp:textbox>
<asp:label id=Label29 runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Larger" ForeColor="Red">*</asp:label></td>
					</tr>
					<tr>
						<td class="logon" width="30%" height="14"><asp:label id="lblAddress" runat="server">Address</asp:label></td>
						<td class="data" width="70%" height="14">
							<asp:textbox id="txtAddress1" runat="server" Width="184px"></asp:textbox></td>
					</tr>
					<tr>
						<td width="30%" height="24"></td>
						<td class="data" width="70%" height="24">
							<asp:textbox id="txtAddress2" runat="server" Width="184px"></asp:textbox></td>
					</tr>
					<tr>
						<td width="30%"></td>
						<td class="data" width="70%">
							<asp:textbox id="txtAddress3" runat="server" Width="184px"></asp:textbox></td>
					</tr>
					<tr>
						<td class="logon" width="30%"><asp:label id="lblTown" runat="server">Town/City</asp:label></td>
						<td class="data" width="70%">
							<asp:textbox id="txtTown" runat="server" Width="184px"></asp:textbox></td>
					</tr>
					<tr>
						<td class="logon" width="30%"><asp:label id="lblPost" runat="server">Post Code</asp:label></td>
						<td class="data" width="70%">
							<asp:textbox id="txtPost" runat="server" Width="184px"></asp:textbox></td>
					</tr>
					<tr>
						<td class="logon" width="30%" height="21"><asp:label id="lblCounty" runat="server">County</asp:label></td>
						<td class="data" width="70%" height="21">
							<asp:textbox id="txtCounty" runat="server" Width="184px"></asp:textbox></td>
					</tr>
				</table>
				<table width="96%" height="30" align="center">
					<tr>
						<td vAlign="middle" align="left" width="50%"><asp:button id="btnClose" runat="server" CssClass="button" Text="Close"></asp:button></td>
						<td width="50%" valign="middle" align="right"><asp:button id="btnEdit" runat="server" CssClass="button" Text="Edit"></asp:button>&nbsp;<asp:button id="btnUpdate" runat="server" CssClass="button" Text="Update"></asp:button>&nbsp;
							<asp:button id="btnCancel" runat="server" CssClass="button" Text="Cancel"></asp:button></td>
					</tr>
				</table>
		</form>
	</body>
</HTML>
