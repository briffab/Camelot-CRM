<%@ Page language="c#" Codebehind="blankinspection.aspx.cs" AutoEventWireup="false" Inherits="Camelot.forms.blankinspection" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>blankinspection</title>
		<LINK href="../stylesheets/inspection.css" type="text/css" rel="stylesheet">
			<meta content="C#" name="CODE_LANGUAGE">
			<meta content="JavaScript" name="vs_defaultClientScript">
	</HEAD>
	<body>
		<table class="add_table" width="96%" align="center">
			<tr>
				<td vAlign="top" width="30%"><asp:image id="propImg" Height="160px" width="240px" runat="server"></asp:image></td>
				<td vAlign="top" align="right" width="70%">
					<table width="100%">
						<tr>
							<td class="blank_insp" align="left" width="30%">Property No. :</td>
							<td class="blank_insp" width="70%"><asp:label id="lblPropNo" Runat="server"></asp:label></td>
						</tr>
						<tr>
							<td class="blank_insp" align="left" width="30%">Address :</td>
							<td class="blank_insp" width="70%"><asp:label id="lblName" Runat="server"></asp:label></td>
						</tr>
						<tr>
							<td class="blank_insp" width="30%"></td>
							<td class="blank_insp" width="70%"><asp:label id="lblAddress" Runat="server"></asp:label></td>
						</tr>
						<tr>
							<td class="blank_insp" align="left" width="30%">Town :</td>
							<td class="blank_insp" width="70%"><asp:label id="lblTown" Runat="server"></asp:label></td>
						</tr>
						<tr>
							<td class="blank_insp" align="left" width="30%">Post Code :</td>
							<td class="blank_insp" width="70%"><asp:label id="lblPost" Runat="server"></asp:label></td>
						</tr>
						<tr>
							<td class="blank_insp" align="left" width="30%">Owner :</td>
							<td class="blank_insp" width="70%"><asp:label id="lblOwner" Runat="server"></asp:label></td>
						</tr>
						<tr>
							<td class="blank_insp" align="left" width="30%">Owner Contact :</td>
							<td class="blank_insp" width="70%"><asp:label id="lblCont" Runat="server"></asp:label></td>
						</tr>
						<tr>
							<td class="blank_insp" align="left" width="30%">Key No. :</td>
							<td class="blank_insp" width="70%"><asp:label id="lblKeyNo" Runat="server"></asp:label></td>
						</tr>
						<tr>
							<td class="blank_insp" align="left" width="30%">Calamity Limit :</td>
							<td class="blank_insp" width="70%"><asp:label id="lblCalam" Runat="server"></asp:label></td>
						</tr>
						<tr>
							<td class="blank_insp" vAlign="bottom" align="left" width="30%">Last Inspection :</td>
							<td class="blank_insp" width="70%"><asp:label id="lblLast" Runat="server"></asp:label></td>
						</tr>
						<tr>
							<td class="blank_insp" vAlign="bottom" align="left" width="30%">Max Occupancy :</td>
							<td class="blank_insp" width="70%"><asp:label id="lblMaxOccup" Runat="server"></asp:label></td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
		<table class="addr_table" height="40%" width="96%" align="center">
			<tr>
				<td vAlign="top" align="left" width="100%" height="100%">Overall Impression of the 
					property, its rooms and grounds.</td>
			</tr>
		</table>
		<hr align="center" width="96%">
		<table width="96%" align="center">
			<tr>
				<td vAlign="top" align="left" width="100%" height="100%"><strong>Internal Remarks</strong></td>
			</tr>
		</table>
		<%getNotes(Convert.ToInt32(lprop.Property_ID));%>
		<hr align="center" width="96%">
		<%getMeters(Convert.ToInt32(lprop.Property_ID));%>
		<BR>
		<%getSecurity(Convert.ToInt32(lprop.Property_ID));%>
		<BR>
		<%getFacility(Convert.ToInt32(lprop.Property_ID));%>
		<BR>
		<%getOpenIncidents(Convert.ToInt32(lprop.Property_ID));%>
		<BR>
		<%getInspIncidents(Convert.ToInt32(lprop.Property_ID));%>
		<BR>
		<%getGuardians(Convert.ToInt32(lprop.Property_ID));%>
		<script language="javascript">
				window.print();
				window.close();
		</script>
		</FORM>
	</body>
</HTML>
