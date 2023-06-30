
    function formvalidate(){
          
          
    var email=document.getElementById("email").value;


    if(email==""){
        document.getElementById('email_error').style.display = "block";

    document.getElementById('email_error').innerHTML="**Please Enter  Email";
    return false;
            }
    
   
          
    else{
        document.getElementById('email_error').style.display = "none";
    return true;
          }
          
          
      }
    function passwordform(){
        var password=document.getElementById('password').value.trim();
    if(password=="")
    {
        document.getElementById('password_error').style.display = "block";
    document.getElementById('password_error').innerHTML="**Please Enter password";
    return false;
            } 
        
    else{
        document.getElementById('password_error').style.display = "none";

    return true;
                
            }
          }








