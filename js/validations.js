// JavaScript Document

// login page
$(document).ready(function(){
		
		$('#uname').focus();
	});
	
function validate_login()
		{			
			$("#message").html("");
			var flag=0;
			if($("#uname").val()== "" && $("#password").val()=="")
			{				
				$('#uname').css({'background-color':'rgba(255,0,0,0.2)'});
				$('#password').addClass('bgRed');
				$("#message").show('slow').html("Both fields are required");
				flag=1;}
			else
			{
				if($("#uname").val()==""){
					$("#message").show('slow').html("Enter username");
					$('#uname').addClass('bgRed');
					flag=1;			}	
				if($("#password").val()==""){
					$("#message").show('slow').html("Enter password");
					$('#password').addClass('bgRed');
					flag=1;			}	
			}
			
			if(flag==0){
				return true;}
			else if(flag==1){
				return false;}	
		}	
		
// registeration page
	var alpha=/^[a-zA-Z]+$/;
	 
	var alphanum=/^(a-zA-Z0-9)+$/;
	var emailPattern = /^([a-z0-9_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})+$/;

	function fname_out() {
	    if (($("#fname").val().length == 0) || (!alpha.test($("#fname").val()))) {
	        $("#fname").addClass("bgRed");
	    }
	    else
	        $("#fname").removeClass("bgRed");
	}
	function lname_out() {
	    if (($("#lname").val().length == 0) || (!alpha.test($("#lname").val()))) {
	        $("#lname").addClass("bgRed");
	    }
	    else
	        $("#lname").removeClass("bgRed");
	}
	function email_out() {
	    if (($("#email").val().length == 0) || (!emailPattern.test($("#email").val()))) {
	        $("#email").addClass("bgRed");
	    }
	    else
	        $("#email").removeClass("bgRed");
	}
	function pass1_out() {
	    if ($("#passwd1").val().length == 0) {
	        $("#passwd1").addClass("bgRed");
	    }
	    else
	        $("#passwd1").removeClass("bgRed");
	}
	function pass2_out() {
	    if ($("#passwd2").val().length == 0) {
	        $("#passwd2").addClass("bgRed");
	    }
	    else
	        $("#passwd2").removeClass("bgRed");

	    if (($("#passwd1").val().length != 0) && ($("#passwd2").val().length != 0)) {
	        if ($("#passwd1").val() != $("#passwd2").val()) {
	            $("#passwd1").addClass("bgRed");
	            $("#passwd2").addClass("bgRed");
	        }
	        else {
	            $("#passwd1").removeClass("bgRed");
	            $("#passwd2").removeClass("bgRed");
	        }
	    }
	}
	function occ_out() {
	    if ($("#occupation").val() == 0) {
	        $("#occupation").addClass("bgRed");
	    }
	    else {
	        $("#occupation").removeClass("bgRed");
	    }
	}
function bdate_out()
{
	if($('#bdate').val().trim().length == 0)
	{
		$("#bdate").addClass("bgRed");
	}
	else
	{
		$("#bdate").removeClass("bgRed");
	}
}
function focusIn(field)
{
		$("#"+field).removeClass('bgRed');
}