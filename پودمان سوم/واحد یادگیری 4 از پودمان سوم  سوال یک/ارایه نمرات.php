<form  method="post" action="" name="signup-form">
    <div class="form-element">
        <label>نام کاربری</label>
        <input type="text" name="username" pattern="[a-zA-Z0-9]+" required />
    </div>
    <div class="form-element">
        <label>ایمیل</label>
        <input type="email" name="email" required />
    </div>
    <div class="form-element">
        <label>رمز عبور</label>
        <input type="password" name="password" required />
    </div>
    <button type="submit" name="register" value="register">ریجستر</button>
</form>
<form method="post" action="" name="signin-form">
    <div class="form-element">
        <label>نام کاربری</label>
        <input type="text" name="username" pattern="[a-zA-Z0-9]+" required />
    </div>
    <div class="form-element">
        <label>رمز عبور</label>
        <input type="password" name="password" required />
    </div>
    <button type="submit" name="login" value="login">ورود</button>
</form>
<?php
define('USER', 'root');
define('PASSWORD', '');
define('HOST', 'localhost');
define('DATABASE', 'test');
 
try {
    $connection = new PDO("mysql:host=".HOST.";dbname=".DATABASE, USER, PASSWORD);
} catch (PDOException $e) {
    exit("Error: " . $e->getMessage());
}
?>

<style>

body {

}
 
h1 {
    font-family: 'Passion One';
    font-size: 2rem;
    text-transform: uppercase;
}
 
label {
    width: 150px;
    display: inline-block;
    text-align: left;
    font-size: 1.5rem;
    font-family: 'Lato';
}
 
input {
    border: 2px solid #ccc;
    font-size: 1.5rem;
    font-weight: 100;
    font-family: 'Lato';
    padding: 10px;
}
 
form {
    margin: 25px auto;
    padding: 20px;
    border: 5px solid #ccc;
    width: 500px;
    background: #eee;
}
 
div.form-element {
    margin: 20px 0;
}
 
button {
    padding: 10px;
    font-size: 1.5rem;
    font-family: 'Lato';
    font-weight: 100;
    background: yellowgreen;
    color: white;
    border: none;
}
 
p.success,
p.error {
    color: white;
    font-family: lato;
    background: yellowgreen;
    display: inline-block;
    padding: 2px 10px;
}
 
p.error {
    background: orangered;

}

</style>
