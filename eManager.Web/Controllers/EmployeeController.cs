using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eManager.Domain;
using eManager.Web.Infrastructure;
using eManager.Web.Models;

namespace eManager.Web.Controllers
{
    public class EmployeeController : Controller
    {

        IDepartmentDataSource _db;

        public EmployeeController(IDepartmentDataSource db)
        {
            _db = db; 
        }

        [HttpGet]
        public ActionResult Add(int departmentId)
        {
            var model = new CreateEmployeeViewModel();
            model.DepartmentId = departmentId;
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(CreateEmployeeViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                var department = _db.Departments.Single(x => x.Id == viewModel.DepartmentId);
                var employee = new Employee
                {
                    Name = viewModel.Name,
                    HiredDate = viewModel.HiredDate
                };
                department.Employees.Add(employee);

                _db.Save();
                return RedirectToAction("details", "department", new { id = viewModel.DepartmentId });
            }
            else
            {
                return View(viewModel);
            }
        }

    }
}
