<%@ Page language="c#" Codebehind="ReportReview.aspx.cs" AutoEventWireup="false" Inherits="Camelot.ReportReview" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<html>
<!--#include file="head.aspx" -->
  <head>
    <title>Report Review</title>
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
  </head>
  <script language="JavaScript" src="functions/menu.js"></script>
	<script language="JavaScript" src="functions/menuPIcontext.js"></script>
	<script language="JavaScript">
	showToolbar();
	</script>
	<script language="JavaScript">
	function UpdateIt(){
	if (ie&&keepstatic&&!opr6)
	document.all["MainTable"].style.top = document.body.scrollTop;
	setTimeout("UpdateIt()", 200);
	}
	UpdateIt();
	</script>
	
<body>
<form>
<br>	
<table width="94%" height="52%" align="center">
<tr>
<td>
	<div class="outerframe">
	<div class="innerframe">
    <table width="100%" border="0">
		<tr valign="top">
			<td >Property</td>
			<td >Investigator</td>
			<td >Investigation Date</td>
			<td >Individual Email text</td>
			<td >Individual Attachments</td>
			<td >Send</td>		
		</tr>
		<tr valign="top">
			<td >Woodlands Rise</td>
			<td >Rob</td>
			<td >1st April 2005</td>
			<td ><textarea rows="2"></textarea></td>
			<td ><select size="3" style="width:200px;"><option>Woodlands Rise 1-04-2005.doc</option></select></td>
			<td ><input type="checkbox" /></td>
		</tr>
		<tr valign="top">
			<td >Queens Drive</td>
			<td >Rob</td>
			<td >1st April 2005</td>
			<td ><textarea rows="2"></textarea></td>
			<td ><select size="3" style="width:200px;"><option>Queens Drive 1-04-2005.doc</option></select></td>
			<td ><input type="checkbox" /></td>
		</tr>
		<tr valign="top">
			<td >Pond Square</td>
			<td >Rob</td>
			<td >1st April 2005</td>
			<td ><textarea rows="2"></textarea></td>
			<td ><select size="3" style="width:200px;"><option>Pond Square 1-04-2005.doc</option></select></td>
			<td ><input type="checkbox" /></td>
		</tr>
    </table>
</div>
</div>
</td>
</tr>
<tr>
	<td>
		<hr />
	</td>
</tr>
<tr>
	<td>
		<table width="100%">
			<tr valign="top">
				<td align="left" class="logon">Add to all emails</td>
				<td align="left" class="data"><textarea style="width:300px;"></textarea></td>
				<td align="right" class="logon">Attachments</td>
				<td align="right" class="data"><select size="3" style="width:300px;"></select></td>
			</tr>
		</table>
	</td>
</tr>
</table>    
<hr >
	<table width="98%" height="3%">
		<tr>
			<td width="100%" valign="middle" align="right",>
				<input class="button" type="button" value="Send" >
				<!--<input class="button" type="button" value="Cancel" />-->
			</td>
		</tr></table>
</form>>
 </body>
</html>
