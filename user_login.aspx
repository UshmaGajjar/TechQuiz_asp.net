<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_login.aspx.cs" Inherits="user_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TechQuiz | Login</title>
    <link href="css/style.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
    <script src="js/validations.js"></script>
</head>
<body id="page2">
    <div class="header_wrapper">
	<div style="float:left;width:50%;text-indent:-5000px;"> TechQuiz </div>
    <div style="float:left;width:42%;">
    	<ul id="menu">
        	<li><a href="index.aspx"> Home </a></li>
            <li id="menu_active"><a href="user_login.aspx"> Login </a></li>
            <li class="bg_none"><a href="user_signup.aspx"> Signup </a></li>
        </ul>
    </div>
	<div style="float:left;width:50%;"> 
        <br />
     <asp:Label ID="notify" runat="server" Text=""></asp:Label>
    <form id="form1" runat="server" onsubmit="return validate_login()">
      <table class="login">
        <tr><td colspan="2"><span id="message"></span></td></tr>
          <tr><td>
              <asp:TextBox ID="uname" runat="server"></asp:TextBox>
              </td></tr>
          <tr><td>
              <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
              </td></tr>
          <tr><td>
              <asp:Button ID="login" runat="server" Text="Login" CssClass="button" OnClick="login_Click"/>
              </td></tr>
      </table>
    </form>
  </div>
      <div style="float:left;width:50%" id="full_clock"></div>
      <div style="clear:both"></div>
</div>

</body>
</html>
