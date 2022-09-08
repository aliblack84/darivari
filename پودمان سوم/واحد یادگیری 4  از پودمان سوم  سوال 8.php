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
public class LoginViewModel
 
    {
 
        [Display(Name = "رمز عبور")]
 
        //by this Attribute you define type of entry property value
 
        [DataType(DataType.Password)]
 
        [Required(ErrorMessage = "لطفا مقدار {۰} را پر کنید")]
 
        //define minimume lenght of property value
 
        [MinLength(5, ErrorMessage = "رمز عبور نمیتواند کمتر از ۵ کاراکتر باشد")]
 
        public string Password { get; set; }
 
        [Display(Name = "ایمیل")]
 
        //check email type for property value
 
        [EmailAddress]
 
        [Required(ErrorMessage = "لطفا مقدار {۰} را پر کنید")]
 
        public string Email { get; set; }
 
    }
    ?>
    </html>