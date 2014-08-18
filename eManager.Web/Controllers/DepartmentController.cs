using eManager.Domain;
using eManager.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eManager.Web.Controllers
{
    public class DepartmentController : Controller
    {
        //
        // GET: /Department/
        IDepartmentDataSource _db = new DepartmentDb(); 

        public ActionResult Details(int id)
        {

            var result = _db.Departments.Single(x => x.Id == id);
           return View(result);
        }

        
    }
}
