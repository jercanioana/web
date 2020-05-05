<!doctype html>

<html>
  <head>
    <title>
      Home
    </title>
    <script src="jquery-3.4.1.js"></script>
    <script>
      $(document).ready(function(){
        $('#pagination').html("1");
        $("#getButton").click(function(){

          $.ajax({
            url:"getURLs.php",
            type: "GET",
            data: {pageNumber: "1"},
            success: function (data, status) {
              $("#urlDiv").html(data);
            }
            })
          })
        })
    </script>
    <script>
      $(document).ready(function(){
        $("#Prev").click(function(){
          var pageNumber = Number($('#pagination').text());
          pageNumber = pageNumber-1;
          if(pageNumber <= 1)
            pageNumber = 1;
          $('#pagination').html(pageNumber);
          $.ajax({
            url:"getURLs.php",
            type: "GET",
            data: {pageNumber: pageNumber},
            success: function (data, status) {
              $("#urlDiv").html(data);
            }
          })
        })
      })
    </script>
    <script>
      $(document).ready(function(){
        $("#Next").click(function(){
          var pageNumber =  Number($('#pagination').text());

          var totalPages = Number($('#totalPages').text());
          pageNumber = pageNumber+1;
          if(pageNumber >= totalPages)
            pageNumber = totalPages;
          $('#pagination').html(pageNumber);
          $.ajax({
            url:"getURLs.php",
            type: "GET",
            data: {pageNumber: pageNumber},
            success: function (data, status) {
              $("#urlDiv").html(data);

            }
          })
        })
      })
    </script>
    <style>
      #totalPages{
        visibility: hidden;
      }
    </style>

  </head>
<body>
  <p>
    Add a new URL to the list:
  </p>
  <form action="addURL.php" method="post">
    <label for="Link">Link</label>
    <input type="text" id="Link" name="Link">
    <label for="Description">Description</label>
    <input type="text" id="Description" name="Description">
    <label for="Category">Category</label>
    <input type="text" id="Category" name="Category">
    <button type="submit">Add</button>
  </form>
  <p>
    Update a URL:
  </p>
  <form action="updateURL.php" method="post">
    <label for="UID">ID</label>
    <input type="text" name="UID" id="UID">
    <label for="Link">Link</label>
    <input type="text" id="Link" name="Link">
    <label for="Description">Description</label>
    <input type="text" id="Description" name="Description">
    <label for="Category">Category</label>
    <input type="text" id="Category" name="Category">
    <button type="submit">Update</button>
  </form>

  <p>Delete By ID</p>
  <form action="deleteURL.php" method="post">
    <label for="UID">ID</label>
    <input type="text" id="UID" name="UID">
    <button type="submit">Delete</button>
  </form>
  <br><br>
  <button id="getButton">Get All URLs</button>

<div id="urlDiv">

</div>
  <button id="Prev">Prev</button>
  <button id="Next">Next</button>
  <p id="pagination">1</p>
<!--<form action = "getURLs.php" method="get">-->
<!--  <ul class="pagination">-->
<!---->
<!--    <li>-->
<!--      <a href="--><?php //if($pageNumber <= 1){ echo '#'; } else { echo "?pageNumber=".($pageNumber - 1); } ?><!--">Prev</a>-->
<!--    </li>-->
<!--    <li>-->
<!--      <a href="--><?php //if($pageNumber >= $total_pages){ echo '#'; } else { echo "?pageNumber=".($pageNumber + 1); } ?><!--">Next</a>-->
<!--    </li>-->
<!---->
<!--  </ul>-->
<!--</form>-->
  <form action='destroy_session.php' method='POST'>
    <input type='submit' value='Logout' name='logout' />
    </form>

</body>
</html>



