package snake.model;

import snake.domain.Move;
import snake.domain.User;

import java.sql.*;

public class DBManager {
    private Statement sqlStmt;
    private static Connection connection;

    public DBManager(){
            connect();
        }

    public static Connection getConnection() {
        return connection;
    }

    public void addMove(Move move) {
        String sql = "INSERT INTO Move(idMove,userID, Name) VALUES("+ move.getID() + "," + move.getUserid() + ",'" + move.getName() + "')";
        try{
            sqlStmt.execute(sql);


        }catch(SQLException e){
            e.printStackTrace();
        }

    }

    public void updateTime(int id, String time){
        int result = 0;
        try{
            result = sqlStmt.executeUpdate("UPDATE Users SET TimeSpent = '" + time + "' WHERE UID = " + id);

        }catch(SQLException e){
            e.printStackTrace();
        }
    }

    public User authenticate(String username, String password) {
        User validUser = null;
        try{
            String verifyUserQuery = "SELECT * FROM Users WHERE username = '" + username + "' AND password = '" + password + "'";
            ResultSet result = sqlStmt.executeQuery(verifyUserQuery);
            if(result.next()){
                validUser = new User(result.getInt("UID"), result.getString("username"), result.getString("password"));
            }
            result.close();

        }catch(Exception e){

            e.printStackTrace();
        }
        return validUser;
    }

    public void connect(){
        try{
            Class.forName(Driver.class.getName());
            Connection connection = DriverManager.getConnection("jdbc:mysql://localhost/snake", "root", "1234");
            this.sqlStmt = connection.createStatement();

        }catch(Exception ex){
            ex.printStackTrace();
        }
    }


}
