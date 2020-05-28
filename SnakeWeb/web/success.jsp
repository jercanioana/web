<%@ page import="snake.domain.User" %><%--
  Created by IntelliJ IDEA.
  User: ioana
  Date: 14.05.2020
  Time: 16:44
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>

<html>
<%! User user; %>
<%  user = (User) session.getAttribute("user");
    if (user != null){

%>
<head>
    <title>Title</title>
    <link rel="stylesheet" href="styless.css">
    <script src="js/jquery-3.4.1.js"></script>
    <script src="js/ajax-utils.js"></script>
    <script>let userid = <%= user.getID()%>;
    </script>
</head>

<body id="game" onload="generateFood(); generateObstacle1(); generateObstacle2(); generateObstacle3(); main();">

    <canvas id="board" width="600", height="600"></canvas>
    <button id="logoutButton" onclick="destroySession()">Logout</button>
    <script src="snake.js"></script>

</body>
<%
    }
%>

</html>
