<%@ Page language="c#" Codebehind="viewingdetails.aspx.cs" AutoEventWireup="false" Inherits="Camelot.viewingdetails" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 
<html>
<!--#include file="head.aspx" -->
  
<body MS_POSITIONING="GridLayout">
	<p>Declan Ryan, 23rd September 2004</p>
	<hr />
	<table width="100%" align="center" border="0">
		<tr>
			<td width="35%" class="logon">Date</td>
			<td width="65%" class="data">23rd September 2004</td>
		</tr>
		<tr>
			<td width="35%" class="logon">Attendees</td>
			<td width="65%" class="data">Declan Ryan</td>
		</tr>
		<tr>
			<td width="35%" class="logon">Reason</td>
			<td width="65%" class="data">Inspection</td>
		</tr>
		<tr>
			<td width="35%" class="logon" valign="top">Notes</td>
			<td width="65%" class="data">Did not like the mess in the Garden and hall way. Seemed to think that the place beede to be kept more tidy</td>
		</tr>
	</table>
	<hr/>
	<table width="98%" height="3%">
		<tr>
			<td width="100%" valign="middle", align="right">
				<input class="button" type="button" value="Edit" />
				<input class="button" type="button" value="Cancel" />
			</td>
		</tr></table>
    <form id="Property" method="post" runat="server">

     </form>
	
  </body>
</html>

