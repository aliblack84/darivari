<?php 
include('dbcon.php');
$username = $_POST['username'];
$password = $_POST['password'];

$query = $conn->query("Select * from user where username = '$username' and password ='$password' ");
$count = $query->rowcount();
$row = $query->fetch();
if ($count > 0){
session_start();
$_SESSION['id'] = $row['user_id'];
header('location:home.php');
}else{
?>
<script>
	alert("اشتباه است اطباعات")
	window.location="index.php";
</script>
<?php 
}
?>