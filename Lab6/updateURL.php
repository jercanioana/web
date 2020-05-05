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

      $existingQuery = "SELECT * FROM url WHERE UID = $uid";
      $exists = mysqli_query($connection, $existingQuery);
      if(!$exists){
        echo "Abort";
      }else{
        if(!empty($_POST["Link"])){
          $link = $_POST["Link"];
        }else{
          $row = mysqli_fetch_assoc(mysqli_query($connection, "SELECT Link FROM url WHERE UID = $uid"));
          $link = $row['Link'];
        }
        if(!empty($_POST["Description"])){
          $description = $_POST["Description"];

        }else{
          $row = mysqli_fetch_assoc(mysqli_query($connection, "SELECT * FROM url WHERE UID = $uid"));
          $description = $row['Description'];
        }
        if(!empty($_POST["Category"])){
          $category = $_POST["Category"];
        }else{
          $row = mysqli_fetch_assoc(mysqli_query($connection, "SELECT Category FROM url WHERE UID = $uid"));
          $category = $row['Category'];
        }
        $updateQuery = "UPDATE url SET Link='$link', Description='$description', Category='$category' WHERE UID = $uid";
        mysqli_query($connection, $updateQuery);
      }
    header('location: home.php');
  ?>
