<%@ Page language="c#" Codebehind="ccdetails.aspx.cs" AutoEventWireup="false" Inherits="Camelot.ccdetails" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 
<html>
<!--#include file="head.aspx" -->
  
<body MS_POSITIONING="GridLayout">
	<p>Gas Meter, In the Porch</p>
	<hr />
	<table width="100%" align="center" border="0">
		<tr>
			<td width="35%" class="logon">Meter Type</td>
			<td width="65%" class="data">Gas</td>
		</tr>
		<tr>
			<td width="35%" class="logon">Location</td>
			<td width="65%" class="data">In the Porch</td>
		</tr>
		<tr>
			<td width="35%" class="logon">Serial Number</td>
			<td width="65%" class="data">gj7783hg999</td>
		</tr>
		<tr>
			<td width="35%" class="logon">Supplier</td>
			<td width="65%" class="data">Powergen</td>
		</tr>
		<tr>
			<td width="35%" class="logon">Last Meter Reading</td>
			<td width="65%" class="data">1st January 2005</td>
		</tr>
		<tr>
			<td width="35%" class="logon">Meter Reading</td>
			<td width="65%" class="data">003421</td>
		</tr>
		<tr>
			<td width="35%" class="logon">Notes</td>
			<td width="65%" class="data">Meter will be replaced next year</td>
		</tr>
		<tr>
			<td width="35%" class="logon" valign="top">Photo</td>
			<td width="65%" class="data"><img src="images/gasmeter.jpg" class="main_photo" width="250" height="187"></td>
		</tr>
	</table>
	<hr/>
	<table width="98%" height="3%">
		<tr>
			<td width="100%" valign="middle", align="right">
				<input class="button" width="200px" type="button" value="Readings" />
				<input class="button" type="button" value="Edit" />
				<input class="button" type="button" value="Cancel" />
			</td>
		</tr></table>
    <form id="Property" method="post" runat="server">

     </form>
	
  </body>
</html>
