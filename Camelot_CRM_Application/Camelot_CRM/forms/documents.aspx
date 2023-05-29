<%@ Page language="c#" Codebehind="documents.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.documents" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<%
Response.CacheControl="private";
Response.Expires=0;
Response.AddHeader("pragma", "no-cache");
%>
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

		window.onload = SetFocus;
		// -->;
	</script>
	<body onkeydown="keystroke()">
		<!--#include file="head.aspx" -->
		<script language="JavaScript" src="../functions/menu<%=Session["menu"]%>.js"></script>
		<script language="JavaScript" src="../functions/menu.js"></script>
		<script language="JavaScript">
					showToolbar();
		</script>
		<form ID="Form1" name="Form1" runat="server">
			<table width="96%" align="center" height="70">
				<tr valign="bottom">
					<td class="logon">
						<asp:Label id="LblProp" runat="server" Font-Size="20pt">Mail Merge Documents</asp:Label>
					</td>
				</tr>
			</table>
			<table width="96%" align="center">
				<tr>
					<td valign="top">
						<div style=" OVERFLOW:auto; WIDTH:100%; HEIGHT:500px">
							<asp:datagrid id="dgDocs" name="dgDocs" runat="server"
								Width="100%" AutoGenerateColumns="False" GridLines="None" CellPadding="5" Font-Name="arial" OnDeleteCommand="dgDocs_delete"
								Font-Size="8" ForeColor="#56a80f" Font-Bold="false" HorizontalAlign="Center" DataKeyField="doc_id"
								OnItemDataBound="dgDocs_ItemDataBound">
								<HeaderStyle BackColor="#56a80f" ForeColor="#dae7ca" Font-Bold="True" HorizontalAlign="Left" />
								<Columns>
									<asp:BoundColumn DataField="doc_id" Visible="False" >
									</asp:BoundColumn>
									<asp:ButtonColumn DataTextField="doc_list_name" HeaderText="Document">
										<ItemStyle Width="20%" VerticalAlign="top" Font-Bold="True"></ItemStyle>
									</asp:ButtonColumn>
									<asp:BoundColumn DataField="doc_type" HeaderText="Document Type">
										<ItemStyle Width="10%" VerticalAlign="top"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="description" HeaderText="Description">
										<ItemStyle Width="30%" VerticalAlign="top"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="doc_name" HeaderText="Document name">
										<ItemStyle Width="10%" VerticalAlign="top"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="date_entered" HeaderText="Date Entered" DataFormatString="{0:dd MMMM yyyy HH:mm}" SortExpression="rep_date">
										<ItemStyle Width="20%" VerticalAlign="top"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="record_manager" HeaderText="Record Manager">
										<ItemStyle Width="10%" VerticalAlign="top"></ItemStyle>
									</asp:BoundColumn>
									<asp:ButtonColumn Text="Delete" HeaderText="Delete Contact" CommandName="Delete">
										<ItemStyle Wrap="False"></ItemStyle>
										<HeaderStyle Wrap="False"></HeaderStyle>
									</asp:ButtonColumn>
								</Columns>
							</asp:datagrid>
						</div>
					</td>
				</tr>
			</table>
			<hr width="96%">
			<table width="96%" height="3%" align="center">
				<tr>
					<td width="50%" valign="middle" align="left">
						<input class="button" type="button" value="Merge Fields" id="btnMerge" name="btnMerge" runat="server">
					</td>
					<td width="50%" valign="middle" align="right">
						<input class="button" type="button" value="Add" id="Button1" name="Button1" runat="server">
						<!--<input class="button" type="button" value="Cancel" />-->
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>