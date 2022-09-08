<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>Document</title>
</head>
<body>
  
</body>
<?php
if(isset($_POST['submit_registration'])){
  $username = $_POST['username'];
  $userfirstname = $_POST['userfirstname'];
  $userlastname = $_POST['userlastname'];
  $email = $_POST['email'];
  $user_password = $_POST['password'];
  //start hash password
    $encode_password = urlencode($user_password);
    $password = crypt($encode_password , "salt");
  //end hash password
  $usergrade = $_POST['usergrade'];

  $username = mysqli_real_escape_string($connection, $username);
  $userfirstname = mysqli_real_escape_string($connection, $userfirstname);
  $userlastname = mysqli_real_escape_string($connection, $userlastname);
  $email = mysqli_real_escape_string($connection, $email);
  $password = mysqli_real_escape_string($connection, $password);
  $usergrade = mysqli_real_escape_string($connection, $usergrade);

  function repeat_username($username){
    global $connection;
    $query = mysqli_query($connection, "SELECT * FROM users WHERE username='$username'");
    return $query;
  }
  function repeat_useremail($email){
    global $connection;
    $query = mysqli_query($connection, "SELECT * FROM users WHERE user_email='$email'");
    return $query;
  }
  if(mysqli_num_rows(repeat_username($username)) > 0 && mysqli_num_rows(repeat_useremail($email)) > 0){
    $err = "<script type="rocketlazyloadscript"> alert('نام کاربری و رمز عبور تکراری است'); </script>";
    echo $err;
  }else if (mysqli_num_rows(repeat_username($username)) > 0) {
    $err = "<script type="rocketlazyloadscript"> alert('نام کاربری تکراری است. لطفا نام کاربری دیگری انتخاب کنید'); </script>";
    echo $err;
 }else if(mysqli_num_rows(repeat_useremail($email)) > 0){
  $err = "<script type="rocketlazyloadscript"> alert('ایمیل تکراری است'); </script>";
  echo $err;
 }else{
  $queryRegister = "INSERT INTO users(username, user_firstname, user_lastname, user_email, user_password, user_role , user_grade)
                    VALUES('{$username}', '{$userfirstname}' , '{$userlastname}' , '{$email}', '{$password}' , 'user' , '{$usergrade}')";
  $register_query = mysqli_query($connection, $queryRegister);

  if(!$register_query){
    die('خطای پایگاه داده: '. mysqli_error($connection));
  }else{
    echo "<p class='alert alert-success'>ثبت نام شما با موفقیت انجام شد.</p>";
  }
 }
}
?>
</html>