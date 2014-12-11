<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TechQuiz | Index</title>
    <link href="css/style.css" type="text/css" rel="stylesheet" />
    <script src="js/validations.js"></script>

</head>
<body id="page1">
    <div class="header_wrapper">
	<div style="float:left;width:50%;text-indent:-5000px;"> TechQuiz </div>
    <div style="float:left;width:42%;">
    	<ul id="menu">
        	<li id="menu_active"><a href="index.aspx"> Home </a></li>
            <li><a href="user_login.aspx"> Login </a></li>
            <li class="bg_none"><a href="user_signup.aspx"> Signup </a></li>
        </ul>
    </div>
	<div style="float:left;width:50%;"> 
    	
        <img src="images/TechQuiz.png"/>
        </div>     
	<div style="float:left;width:50%" id="full_clock"></div>
  <div style="clear:both"></div>
</div>

<div id="footer_wrapper">
<div id="footer"> hello </div>
<div style="clear:both"></div>
</div>
</body>
</html>
