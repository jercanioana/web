<?php

    session_start();

    if (!isset($_SESSION['validuser'])) {
      header('Location: index.html');
    } else {
      header('Location: home.php');
    }
