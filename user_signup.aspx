<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_signup.aspx.cs" Inherits="user_signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TechQuiz | Signup</title>
    <link href="css/style.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
    <script src="js/validations.js"></script>
    <script>
        function set_visible(cid)
        {
            el = document.getElementById(cid);
            el.style.visibility = (el.style.visibility == "visible") ? "hidden" : "visible";
        }  
    </script>
    <style>
        #cal {
            visibility:hidden;
            position:absolute;
        }
    </style>
</head>
<body id="page2">
    <div class="header_wrapper">
	<div style="float:left;width:50%;text-indent:-5000px;"> TechQuiz </div>
    <div style="float:left;width:42%;">
    	<ul id="menu">
        	<li><a href="index.aspx"> Home </a></li>
            <li><a href="user_login.aspx"> Login </a></li>
            <li  id="menu_active" class="bg_none"><a href="user_signup.aspx"> Signup </a></li>
        </ul>
    </div>
	<div style="float:left;width:50%;"> 
        <br />
        <h2> Sign up</h2>
        <asp:Label ID="notify" runat="server"></asp:Label>
   <form id="form1" runat="server">
       <table class="register" CellPadding="5" CellSpacing="5">
           <tr><td colspan="2">Name :<br />
               <asp:TextBox ID="fname" runat="server" onblur="fname_out()" onfocus="focusIn(this.id)"></asp:TextBox><br /><br />
               <asp:TextBox ID="lname" runat="server" onblur="lname_out()" onfocus="focusIn(this.id)"></asp:TextBox></td></tr>
           <tr><td colspan="2">Email ID :<br />
               <asp:TextBox ID="email" runat="server" onblur="email_out()" onfocus="focusIn(this.id)"></asp:TextBox></td></tr>
           <tr><td colspan="2">Password :<br />
               <asp:TextBox ID="passwd1" runat="server" TextMode="Password" onblur="pass1_out()" onfocus="focusIn(this.id)"></asp:TextBox></td></tr>
	<tr><td colspan="2">Retype Password : <br/>
    		   <asp:TextBox ID="passwd2" runat="server" TextMode="Password" onblur="pass2_out()" onfocus="focusIn(this.id)"></asp:TextBox></td></tr>
    <tr><td>Occupation : <br />
        <asp:DropDownList ID="occupation" runat="server" onblur="occ_out()" onfocus="focusIn(this.id)">
            <asp:ListItem Value="0"> - SELECT -</asp:ListItem>
            <asp:ListItem Value="1">Student</asp:ListItem>
            <asp:ListItem Value="2">Employee</asp:ListItem>
            <asp:ListItem Value="3">Professional</asp:ListItem>
        </asp:DropDownList></td>
      <td> Gender : <br />
          <asp:RadioButtonList ID="gender" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
              <asp:ListItem Value="f" Text="Female"></asp:ListItem><asp:ListItem Value="m" Text="Male"></asp:ListItem>
          </asp:RadioButtonList>
      </td></tr>
       <tr><td colspan="2">Birth Date : <br />
           <asp:TextBox ID="bdate" runat="server" onfocus="focusIn(this.id)" onblur="bdate_out()"></asp:TextBox><img src="images/calendar.png" onclick="set_visible('cal')"/><br />
           <span id="cal"><asp:Calendar ID="Calendar1" runat="server" BackColor="White" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar></span>
           </td></tr>
       <tr><td> <asp:Button ID="reset" runat="server" Text="RESET" CssClass="button" OnClick="reset_Click" /></td>
           <td> <asp:Button ID="signup" runat="server" Text="SIGNUP" CssClass="button" OnClick="signup_Click" /></td></tr>
       </table>
    </form>
  </div>
      <div style="float:left;width:50%" id="full_clock"></div>
      <div style="clear:both"></div>
</div>

</body>
</html>
