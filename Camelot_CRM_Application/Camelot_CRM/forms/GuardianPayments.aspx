<%@ Page language="c#" Codebehind="GuardianPayments.aspx.cs" AutoEventWireup="false" Inherits="Camelot.GuardianPayments" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
<!--#include file="head.aspx" -->
  
<body MS_POSITIONING="GridLayout">
	<p>Make a Payment</p>
	<hr >
	<table width="100%" align="center" border="0">
		<tr>
			<td width="35%" class="logon">Property</td>
			<td width="65%" class="data"><select><option>Woodlands Rise</option></select></td>
		</tr>
		<tr>
			<td width="35%" class="logon">Guardian</td>
			<td width="65%" class="data"><select><option>Declan Ryan</option></select></td>
		</tr>
		<tr>
			<td width="35%" class="logon">Amount Outstanding</td>
			<td width="65%" class="data">£145.89</td>
		</tr>
		<tr>
			<td width="35%" class="logon">Payment</td>
			<td width="65%" class="data"><input type="text">
				<input class="button" type="button" value="Save" ></td>
		</tr>
		<tr>
			<td width="35%" class="logon">Payment Date</td>
			<td width="65%" class="data"><input type="text"></td>
		</tr>
		<tr>
			<td width="35%" class="logon">Build DD for</td>
			<td width="65%" class="data"><input type="text">
				<input class="button" type="button" value="Build" ></td>
		</tr>
		<tr>
			<td width="35%" class="logon">Import DD report</td>
			<td width="65%" class="data"><input type="text">
				<input class="button" type="button" value="Browse" ></td>
		</tr>
	</table>
	<hr>
	<table width="98%" height="3%">
		<tr>
			<td width="75%" valign="middle" align="right">
				<input class="button" type="button" value="Cancel" >
			</td>
		</tr></table>
    <form id="Property" method="post" runat="server">

     </form>
	
  </body>
</HTML>
