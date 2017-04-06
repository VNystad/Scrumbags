$(document).ready(function(){
    //If user submits the form
	$("#submitmessage").click(function(){	
	    var clientmsg = $("#chatmessage").val();
	    $.post("post.php", {text: clientmsg});				
	    $("#chatmessage").attr("value", "");
	    return false;
    });
});
