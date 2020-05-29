using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using System.Diagnostics;
using System.Data.Common;
using MySql.Data.MySqlClient;
using Lab9.Models;

namespace Lab9.Controllers
{
    public class HomeController : Controller
    {
        public static string username, password;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
    }
}