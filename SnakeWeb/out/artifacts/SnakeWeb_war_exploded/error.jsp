<%--
  Created by IntelliJ IDEA.
  User: ioana
  Date: 20.05.2020
  Time: 09:26
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Login</title>
    <script>alert("Invalid credentials")</script>
    <link rel="stylesheet" href="styless.css">
</head>
<body id="home">
<h1>Welcome to Snake</h1>
<p>Try again</p>
<form action="LoginController" method="post">
    <b>Enter username :</b> <input type="text" name="username">
    <br><br>
    <b>Enter password :</b> <input type="password" name="password">
    <br><br>
    <input id="loginbutton" type="submit" value="Login"/>

</form>

</body>
</html>
