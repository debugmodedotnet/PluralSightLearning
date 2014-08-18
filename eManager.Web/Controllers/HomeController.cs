using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eManager.Domain;
using eManager.Web.Infrastructure;
namespace eManager.Web.Controllers
{
    public class HomeController : Controller
    {

        IDepartmentDataSource _db = new DepartmentDb()   ; 
      
        public ActionResult Index()
        {

            var result = _db.Departments;
            return View(result);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
