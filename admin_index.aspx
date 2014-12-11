<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_index.aspx.cs" Inherits="admin_index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TechQuiz | Admin Login</title>
   <%-- <link href="../css/style.css" type="text/css" rel="stylesheet" />--%>
    <script type="text/javascript" src="../js/jquery-1.7.2.min.js"></script>
    <script src="js/validations.js"></script>
    <style type="text/css">
body
{
	margin:0;
	padding:110px;
	background:url(images/back.png) no-repeat center;
	color:#38294a;
	letter-spacing:1.5px;
	font:15px Arial, Helvetica, sans-serif;
}
.button
{
	border-style:solid;
	border: 2px solid rgba(200,200,200,1);
	font-weight:bold;
	height:30px;
	width:80px;
}
#login
{
	background-color: #38294a;
	color:rgba(255,255,255,1);
}
#login:hover
{
	background-color: rgba(240,240,240,1);
	color: #38294a;
	cursor:pointer;
}
.une {
    background-image:url(images/user.png);
    background-repeat:no-repeat;
	height:30px;
	border:1px solid gray;
	border-radius: 5px 5px 5px 5px;
	width:200px;
	font-size:15px;
	padding-left:35px;
}
        .pwd {
            background-image: url(images/pass.png);
            background-repeat: no-repeat;
            height: 30px;
            border: 1px solid gray;
            border-radius: 5px 5px 5px 5px;
            width: 200px;
            font-size: 15px;
            padding-left: 35px;
        }
/* awesomw blue : rgba(39,32,104,1) */
</style>
</head>
<body>
    <form id="form1" runat="server">
	<div style="height: 75px; width:310px; margin:0 auto;" >
     	<div style="float:left;padding:10px 5px 10px 0px"><img src="images/techquiz.png" width="200"/></div>
     	</div>
    <div style="width:299px; background-color:rgba(250,250,250,1);border-radius:0px 52px 0px 52px;margin:0 auto;padding:1px;border: 2px solid #38294a;">  
    <div style="width:235px; background-color:rgba(225,225,225,1);border-radius:0px 50px 0px 50px;margin:0 auto;padding:30px;border: 2px solid rgba(0,0,0,0.4);">  
    
      <div style="float:left;">
		<div style="height:35px; width:auto;text-align:right">
              <b>| ADMIN SIGN IN |</b>
		</div>
          <asp:Label ID="notify" runat="server" Text="" ForeColor="#990000"></asp:Label>
	    <div style="height:50px; width:auto">
              <asp:TextBox ID="uname" runat="server" CssClass="une"></asp:TextBox>
		</div>
		
		<div style="height:50px;width:auto"> 
              <asp:TextBox ID="password" runat="server" TextMode="Password" CssClass="pwd"></asp:TextBox>
  		</div>
  		
  		<div style="height:29px; width:233px">
  			<div style="float:right;padding-top:20px"> <asp:Button ID="admin_login" runat="server" Text="Login" CssClass="button" OnClick="login_Click"/></div>   
  		</div>
  		
       </div>
  	<div style="clear:both"/>
	</div>
	<div style="clear:both"/>
	</div>
    </form>
</body>
</html>
