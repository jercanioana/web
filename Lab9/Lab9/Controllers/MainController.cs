using Lab9.DataAbstractionLayer;
using Lab9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab9.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View("LoginView");
        }
        public string Test()
        {
            return "It's working";
        }
        public string GetURLs()
        {
            
            DAL dal = new DAL();
            int pagenumber = int.Parse(Request["pageNumber"]);
            List<URL> urls = dal.GetAllURLs(pagenumber);
            ViewData["URLsList"] = urls;
            double totalPages =  dal.getTotalPages();
            string result = "<table id='urlsTable' onclick='fillInputs()' border='1'><thead><th>Id</th><th>Link</th><th>Description</th><th>Category</th></thead>";

            foreach (URL url in urls)
            {
                result += "<tr><td>" + url.Id + "</td><td>" + url.link + "</td><td>" + url.description + "</td><td>" + url.category + "</td><td></tr>";
            }
            
            result += "</table>";
            result += "<p id='totalPages'>" + totalPages + "</p>";
            return result;
        }
    
        public ActionResult Logout()
        {
            Session.Abandon();
            return View("LoginView");
        }
        public ActionResult Login()
        {
            DAL dal = new DAL();
            LoginModel loginModel = new LoginModel();
            loginModel.Username = Request.Params["username"];
            loginModel.Password = Request.Params["password"];
            bool validuser = dal.Authenticate(loginModel);
            if (validuser) {
                Session["user"] = validuser;
                return View("LoggedIn");
            }
            else
                return View("LoginView");
        }
        public ActionResult AddURL()
        {
            return View("LoggedIn");
        }

        public ActionResult SaveURL()
        {
            URL url = new URL();

            url.link = Request.Params["link"];
            url.description = Request.Params["description"];
            url.category = Request.Params["category"];

            DAL dal = new DAL();

            bool added = dal.SaveURL(url);
            ViewData["added"] = added;
            return View("LoggedIn");

        }

        public ActionResult UpdateURL()
        {
            URL url = new URL();

            url.Id = int.Parse(Request.Params["id"]);
            url.link = Request.Params["link"];
            url.description = Request.Params["description"];
            url.category = Request.Params["category"];

            DAL dal = new DAL();
            dal.UpdateURL(url);
            return View("LoggedIn");
        }

        public ActionResult DeleteURL()
        {
            URL url = new URL();
            url.Id = int.Parse(Request.Params["deleteID"]);
            url.link = Request.Params["link"];
            DAL dal = new DAL();
            dal.DeleteURL(url);
            return View("LoggedIn");

        }

        public string GetURlsByCategory()
        {
            string category = Request.Params["category"];
            DAL dal = new DAL();
            int pagenumber = int.Parse(Request["pageNumber"]);
            List<URL> fileteredURLs = dal.GetURLByCategory(category, pagenumber);
            ViewData["URLsList"] = fileteredURLs;

            string result = "<table id='urlsTable' onclick='fillInputs()' border='1'><thead><th>Id</th><th>Link</th><th>Description</th><th>Category</th></thead>";

            foreach (URL url in fileteredURLs)
            {
                result += "<tr><td>" + url.Id + "</td><td>" + url.link + "</td><td>" + url.description + "</td><td>" + url.category + "</td><td></tr>";
            }

            result += "</table>";
            return result;
        }
        
    }
}