<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_home.aspx.cs" Inherits="user_home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>TechQuiz | User Home</title>
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<script src="../js/validations.js"></script>

</head>

<body id="user_page1">
    <form id="form1" runat="server">
<div class="header_wrapper">
	<div style="float:left;width:50%;text-indent:-5000px;"> TechQuiz </div>
    <div style="float:left;width:36%; text-align:right;padding:20px;color:white">
    	<asp:Label ID="user" runat="server" Text=""></asp:Label><a href="logout.aspx"><img src="../images/logout.png" /></a>
    </div>
	<div style="float:left;width:50%;"> 
        <img src="../images/TechQuiz.png"/>
        <br /><br /><br /><br /><br />
       <h1>Last played ...</h1>
    </div>     
	<div id="half_clock"></div>
  <div style="clear:both"></div>
</div>
<div class="header_wrapper">
    <div>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </div>
	<div id="menu_right"> 
    	<ul id="subject_menu">
        	<li><asp:LinkButton ID="php" runat="server" OnClick="php_Click"> Php </asp:LinkButton></li><br />
            <li><asp:LinkButton ID="dotnet" runat="server" OnClick="dotnet_Click"> .Net </asp:LinkButton></li><br />
            <li class="bg_none"><asp:LinkButton ID="datamining" runat="server" OnClick="datamining_Click"> Data Mining </asp:LinkButton></li><br />
        </ul>
         <div style="clear:both"></div>
    </div>
    <div style="clear:both"></div>
</div>

<div id="footer_wrapper">
<div id="footer"> hello </div>
<div style="clear:both"></div>
</div>
    </form>
</body>
</html>