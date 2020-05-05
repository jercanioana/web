<?php
    $server = "localhost";
    $user = "ioana";
    $password = "1234";
    $db = "lab7";
    $connection = mysqli_connect($server, $user, $password, $db);
    if (!$connection){
      die("Could not connect: ");
    }
    $uid = $_POST["UID"];

    $query = "DELETE FROM url WHERE UID = $uid";
    mysqli_query($connection, $query);
    header('location: home.php');

