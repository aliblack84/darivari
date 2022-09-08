
 <!DOCTYPE html>
<html>
	<head>
		<meta charset="utf-8">
		<meta name="viewport" content="width=device-width, initial-scale=1.0">
		<title>صفحه ورود</title>
			<?php include('dbcon.php'); ?>
			
			<?php
session_start();
if (!isset($_SESSION['id'])){
header('location:index.php');
}
$session_id = $_SESSION['id'];
$session_query = $conn->query("select * from user where user_id = '$session_id'");
$user_row = $session_query->fetch();
?>

	</head>
	<body>
		<center><h1> خوش امدید </h1> <h2><a href="#"><?php echo $user_row['firstname']." ".$user_row['lastname']; ?></a></h2> 
		
		<br><hr><br>
		
		<a href="logout.php"><button type="submit">خروج</button></a>
		
		</center>
	</body>
</html>


   
	