<%@ Page language="c#" Codebehind="ecorrdetail.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.ecorrdetail" %>
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
					<td class="logon"><asp:label id="Label4" runat="server" Font-Size="20pt">Property Correspondence</asp:label></td>
				</tr>
			</table>
			<table width="96%" align="center">
				<tr>
					<td class="logon" width="30%" height="14"><asp:label id="lblTitle" runat="server"></asp:label></td>
					<td class="logon" width="70%" height="14"></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center" border="0">
				<tr vAlign="top">
					<td class="logon" width="249" height="21"><asp:label id="lblfacdesc" runat="server">Type</asp:label></td>
					<td class="data" width="60%" height="21">
						<asp:label id="lblType" runat="server" Width="224px"></asp:label></td>
				</tr>
				<tr vAlign="top">
					<td class="logon" width="249" height="21"><asp:label id="Label1" runat="server">Date</asp:label></td>
					<td class="data" width="60%" height="21">
						<asp:label id="lblDate" runat="server" Width="224px"></asp:label></td>
				</tr>
				<tr vAlign="top">
					<td class="logon" width="249" height="21"><asp:label id="Label3" runat="server">Direction</asp:label></td>
					<td class="data" width="60%" height="21">
						<asp:label id="lblDir" runat="server" Width="224px"></asp:label></td>
				</tr>
				<tr vAlign="top">
					<td class="logon" width="249" height="21"><asp:label id="Label5" runat="server">Bulk</asp:label></td>
					<td class="data" width="60%" height="21">
						<asp:label id="lblBulk" runat="server" Width="224px"></asp:label></td>
				</tr>
				<tr vAlign="top">
					<td class="logon" width="249" height="21"><asp:label id="Label6" runat="server">Subject</asp:label></td>
					<td class="data" width="60%" height="30">
						<asp:label id="lblSubject" runat="server" Width="100%"></asp:label></td>
				</tr>
				<tr vAlign="top">
					<td class="logon" width="249" height="21"><asp:label id="Label7" runat="server">Body</asp:label></td>
					<td class="data" width="60%" height="100"><asp:textbox width="100%" runat="server" TextMode="MultiLine" Rows="5" id="txtBody"></asp:textbox></td>
				<tr>
					<td class="logon" width="249" height="25"><asp:label id="lblUpBy" runat="server">Sent by</asp:label></td>
					<td class="data" width="60%" height="25"><asp:label id="lblUby" runat="server"></asp:label></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center" border="0">
				<tr vAlign="top">
					<td class="logon" width="50%" height="25"><asp:label id="Label11" runat="server">Recipients in CRM</asp:label></td>
					<td class="logon" width="50%" height="25"><asp:label id="Label2" runat="server">Recipients not in CRM</asp:label></td>
				</tr>
				<tr>
					<td class="logon" width="50%"><asp:listbox id="lbRecipients" Width="100%" Height="100px" runat="server"></asp:listbox></td>
					<td class="logon" width="50%"><asp:listbox id="lbnCRM" Width="100%" Height="100px" runat="server"></asp:listbox></td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" align="center" border="0">
				<tr>
					<td width="100%" class="logon">Attachments</td>
				</tr>
				<tr>
					<td>
						<DIV style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 150px">
							<asp:datagrid id="dgImgs" runat="server" ForeColor="#56a80f" Font-Bold="false" OnItemCommand="ShowAttachment"
								DataKeyField="doc_id" AutoGenerateColumns="False" HorizontalAlign="Center" Font-Name="arial"
								CellPadding="5" GridLines="None" Width="100%">
								<HeaderStyle BackColor="#56a80f" ForeColor="#dae7ca" Font-Bold="True" HorizontalAlign="Left" />
								<Columns>
									<asp:BoundColumn DataField="doc_id" Visible="False"></asp:BoundColumn>
									<asp:ButtonColumn Text="View" HeaderText="View" CommandName="View">
										<ItemStyle Wrap="False"></ItemStyle>
										<HeaderStyle Wrap="False"></HeaderStyle>
									</asp:ButtonColumn>
									<asp:BoundColumn DataField="attachment" HeaderText="Attachment">
										<ItemStyle Width="80%" VerticalAlign="Top"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:datagrid>
						</DIV>
					</td>
				</tr>
			</table>
			<hr width="96%" align="center">
			<table height="30" width="96%" align="center">
				<tr>
					<td vAlign="middle" align="left" width="50%"><asp:button id="btnClose" runat="server" CssClass="button" Text="Close"></asp:button></td>
					<td vAlign="middle" align="right" width="50%"><asp:button id="btnCall" runat="server" CssClass="button" Text="Callback"></asp:button></td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
