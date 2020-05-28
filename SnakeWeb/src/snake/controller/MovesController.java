package snake.controller;

import snake.domain.Move;
import snake.model.DBManager;


import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;

public class MovesController extends HttpServlet {
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String action = request.getParameter("action");

        if ((action != null) && action.equals("add")) {
            Move move = new Move(Integer.parseInt(request.getParameter("id")),Integer.parseInt(request.getParameter("userid")), request.getParameter("name"));
            DBManager dbManager = new DBManager();
            dbManager.addMove(move);
            PrintWriter out = new PrintWriter(response.getOutputStream());
            out.flush();
        }
    }
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

        String action = request.getParameter("action");
        if ((action != null) && action.equals("update")) {
            int userID = Integer.parseInt(request.getParameter("id"));
            String time = request.getParameter("time");
            DBManager dbManager = new DBManager();
            dbManager.updateTime(userID, time);
            PrintWriter out = new PrintWriter(response.getOutputStream());

            out.flush();
        }
    }
}
