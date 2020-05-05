<?php
    session_start();
    $server = "localhost";
    $user = "ioana";
    $password = "1234";
    $db = "lab7";
    $connection = mysqli_connect($server, $user, $password, $db);
    if (!$connection){
      die("Could not connect: ");
    }
    $username = $_POST["username"];

    $password2 = $_POST["password"];

    $query = "SELECT * FROM users WHERE username = '$username' AND password = '$password2'";
    $validuser = mysqli_query($connection, $query);
    $users = mysqli_fetch_array($validuser);
    if(!is_null($users)){
      $_SESSION['validuser'] = $users;
    }else{
      unset($_SESSION['validuser']);
    }

    header('Location: secure_page.php');
?>

