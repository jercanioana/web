<?php
    global $pageNumber;
    $server = "localhost";
    $user = "ioana";
    $password = "1234";
    $db = "lab7";
    $connection = mysqli_connect($server, $user, $password, $db);
    if (!$connection){
      die("Could not connect: ");
    }

    $numberOfRecords = 4;

    $countquery = "SELECT COUNT(*) FROM url";

    $totalNumberOfURLs = mysqli_query($connection, $countquery);
    $total_rows = mysqli_fetch_array($totalNumberOfURLs)[0];
    $total_pages = ceil($total_rows / $numberOfRecords);
    $pageNumber = $_GET["pageNumber"];
      if($pageNumber >= $total_pages){
        $pageNumber = $total_pages;
      }


    $start = ($pageNumber-1)*$numberOfRecords;

    $query = "SELECT * FROM url ORDER BY Category LIMIT $start, $numberOfRecords";
    $resultset = mysqli_query($connection, $query);
    echo "<table border='1'><tr><th>ID</th><th>Link</th><th>Description</th><th>Category</th></tr>";
    while($row = mysqli_fetch_array($resultset)){
      echo "<tr>";
      echo "<td>" . $row['UID'] . "</td>";
      echo "<td>" . $row['Link'] . "</td>";
      echo "<td>" . $row['Description'] . "</td>";
      echo "<td>" . $row['Category'] . "</td>";
      echo "</tr>";
    }
    echo "</table>";
    echo "<p id='totalPages'>$total_pages</p>";





?>
