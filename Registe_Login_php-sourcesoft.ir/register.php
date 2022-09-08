<?php
include('dbcon.php');
$username = $_POST['username'];
$password = $_POST['password'];
$firstname = $_POST['firstname'];
$lastname = $_POST['lastname'];

$conn->query("insert into user (username,password,firstname,lastname) values ('$username','$password','$firstname','$lastname')");	
?>
<script>
	alert('با موفقیت ثبت شد! اکنون می توانید وارد شوید!');
	window.location = 'index.php';
</script>