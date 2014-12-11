<%@ Page Language="C#" AutoEventWireup="true" CodeFile="questions.aspx.cs" Inherits="questions" EnableViewState="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TechQuiz | questions</title>
    <link href="css/style.css" type="text/css" rel="stylesheet" />
    <script src="js/jquery-1.7.2.min.js"></script>
<script>
    function time_up(code2show) {
      /*  var inputs = new Array();
        var total = 0;
        inputs = document['form1'].getElementsByTagName('input');
        for (var i = 0; i < inputs.length; i++) {
            if (inputs[i].type == 'radio') {
                if (inputs[i].checked == true)
                    total++;
            }
        }*/
        if (code2show == 'overlay') {
            //$('#stat').html('Total questions answered : ' + total + ' / 10');
        }
        else if (code2show == 'submit_form') {
            $('#message').html("You still have time.<br>Do you really want to submit your quiz?");
           // $('#statistics').html('Total questions answered : ' + total + ' / 10');
        }
        overlay_on(code2show);
    }
    function start_quiz(ans) {
        if (ans == true) {
            overlay('start_quiz');
            m = 9;
            s = 59;
            setTimeout("timer()", 1000);
        }
        else {
            //window.location.replace("user_home.php");	
            window.location = "user_home.aspx";
        }
    }
    function window_load() {
        overlay('start_quiz');
    }
    function timer() {
        $('#time').html(m + ' : ' + s);
        if (s > 0) {
            s = s - 1;
            setTimeout("timer()", 1000);
        }
        else if (s == 0) {
            if (s == 0 && m == 0) {
                setTimeout("time_up('overlay')", 1000);
            }
            else {
                s = 59; m = m - 1;
                setTimeout("timer()", 1000);
            }
        }
    }
    function overlay(code2show) {
        el = document.getElementById(code2show);
        el.style.visibility = (el.style.visibility == "visible") ? "hidden" : "visible";
    }
    function overlay_on(code2show) {
        el = document.getElementById(code2show);
        el.style.visibility = "visible";
    }
    function loading(code2show) {
        overlay(code2show);
        setTimeout("overlay_on('loading')", 1);
        setTimeout("", 50000);
        setTimeout("submit_quiz", 1);
    }

    function GetSelectedRadioButtonValue(strGroupName) {
    var arrInputs = document.getElementsByTagName("input");
    for (var i = 0; i < arrInputs.length; i++) {
        var oCurInput = arrInputs[i];
        if (oCurInput.type == "radio" && oCurInput.name == strGroupName && oCurInput.checked)
            return oCurInput.value;
    }
    return "";
}

</script>
<style>
	#overlay,#submit_form,#start_quiz,#loading {
     background:rgba(0,0,0,0.9);
	 visibility: hidden;
    /* position: absolute;*/
     left: 0px;
    /* top: 0px;
     width:100%;
     height:100%;
     text-align:center;
     z-index: 1000;*/
	 
	 width: 100%;
    position: fixed;
    bottom: 0px;
   /*left: 50%;*/
    margin-left:0px;
}
#overlay div ,#submit_form div,#start_quiz div,#loading div{
      width:300px;
	 height:auto;
     margin: 100px auto;
     background-color: #fff;
     border:1px solid #000;
     padding:20px;
     text-align:center;
}
</style>
</head>
<body onload="window_load()" id="page2">
    <asp:Label ID="lbl" runat="server" Text="Label"></asp:Label><br /><br />
    <asp:Label ID="user" runat="server" Text="Label"></asp:Label><br /><br />
    <b> time left - </b>

<span id="time">  10 : 00 </span><br />
<br />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />
    <form id="form1" runat="server">
        <asp:Panel ID="ques_list" runat="server">
            
        </asp:Panel>  
        <br />      
        <asp:Button ID="submit_tq" runat="server" Text="Button" OnClick="submit_tq_Click" CssClass="button"/><br />
    
    <div id="overlay">
     				<div>
          				<p id="mssg"> Sorry! Your time's up.</p>
                        <p id="stat"></p>
                         <asp:Button ID="Button2" runat="server" Text="OK" OnClick="submit_tq_Click" CssClass="button"/>
     				</div>
				</div>
                <div id="submit_form">
                	<div>
                    	<p id="message"></p>
                        <p id="statistics"></p>
                        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="submit_tq_Click" CssClass="button"/>				
                        <button type="button" name="submit" value="cancel_quiz" onclick="overlay('submit_form')"> CANCEL </button>
                    </div>
                </div>
    </form>
    <div id="start_quiz">
     				<div>
          				<p id="msg">Do you really want to start the quiz?</p>
        			    <button type="button" name="ok" onclick="start_quiz(true)"> YES </button>
                        <button type="button" name="cancel" onclick="start_quiz(false)"> NO </button>
     				</div>
	</div>
    <div id="loading">
     				<div>
                    	<img src="images/animated.gif" alt="loading..."/>
          				<p id="process">Please wait...<br/> Your result is being prepared</p>
     				</div>
	</div>
</body>
</html>
