<!DOCTYPE html>
<html>
	<head>
		<meta charset="utf-8">
		<meta name="viewport" content="width=device-width, initial-scale=1.0">
		<title>صفحه ورود</title>
			<?php require('dbcon.php'); ?>
			
	</head>
	<body>
	<center>
		<form method="post" action="login.php">
							<h3>ورود</h3> 
								<input type="text" name="username" placeholder="Username" required> <br><br>
                                <input name="password" type="password" placeholder="Password" required >     <br><br>  
                               <button type="submit" name="login">ورود</button>
		</form>
		<br>
		<hr> 
		
		<form method="post" action="register.php">
					<h3>رجیستر</h3> 
					     <input class="long"  name="username" required="required" type="text" placeholder="Username" />  <br> <br>                            
                                    <input name="password" required="required" type="password" placeholder="Password"/>     <br><br>                        
                                    <input name="firstname" required="required" type="text" placeholder="First Name"/>	<br><br>
                                    <input name="lastname" required="required" type="text" placeholder="Last Name"/> <br><br>
								<button type="submit" name="signup" onclick="signup()">ساخت حساب</button>	
								
		</form>
		</center>
	</body>
</html>

