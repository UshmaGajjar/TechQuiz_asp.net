<%@ Page Language="C#" AutoEventWireup="true" CodeFile="result.aspx.cs" Inherits="result" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <a href="logout.aspx"><img src="images/logout.png" /></a>

    <h3> QUIZ RESULT </h3>
    <form id="form1" runat="server">
   
    <asp:Panel ID="result_list" runat="server">  

    </asp:Panel>
        <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click" /> word       
        <br />
        <br />
        <asp:ImageButton ID="ImageButton2" runat="server" OnClick="ImageButton2_Click" />pdf
        <br />
        <br />
        <asp:ImageButton ID="ImageButton3" runat="server" OnClick="ImageButton3_Click" />txt
    </form>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>  
</body>
</html>
