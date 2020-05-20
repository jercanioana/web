<%@ page import="snake.domain.User" %><%--
  Created by IntelliJ IDEA.
  User: ioana
  Date: 14.05.2020
  Time: 16:44
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>

<html>
<head>
    <title>Title</title>
    <link rel="stylesheet" href="styles.css">
    <script src="js/jquery-3.4.1.js"></script>
    <script src="js/ajax-utils.js"></script>

</head>
<body id="game" onload="generateFood(); generateObstacle(); main();">
<%! User user; %>
<%  user = (User) session.getAttribute("user");
    if (user != null) {
        out.println("Welcome "+user.getUsername());
%>
    <canvas id="board" width="600", height="600"></canvas>
    <script src="snake.js"></script>

</body>
<%
    }
%>

</html>
