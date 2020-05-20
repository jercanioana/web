package snake.controller;

import snake.domain.Move;
import snake.model.DBManager;
import snake.model.MoveManager;


import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;

public class MovesController extends HttpServlet {
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String action = request.getParameter("action");

        if ((action != null) && action.equals("add")) {
            Move move = new Move(Integer.parseInt(request.getParameter("id")), request.getParameter("name"));
            DBManager dbManager = new DBManager();
            dbManager.addMove(move);
            PrintWriter out = new PrintWriter(response.getOutputStream());

            out.flush();
        }
    }
}
