<?php

$server = "localhost";
$user = "ioana";
$password = "1234";
$db = "lab7";
$connection = mysqli_connect($server, $user, $password, $db);
if (!$connection){
  die("Could not connect: ");
}
$link = mysqli_real_escape_string($connection, $_POST["Link"]);
$description = mysqli_real_escape_string($connection, $_POST["Description"]);
$category = mysqli_real_escape_string($connection, $_POST["Category"]);
$query = "INSERT INTO url (Link, Description, Category) VALUES('$link', '$description', '$category')";
mysqli_query($connection, $query);
header('location: home.php');

