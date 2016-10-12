using System;
using ZoolandiaRazor.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZoolandiaRazor.Models;

namespace ZoolandiaRazor.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            ZoolandiaRepository repo = new ZoolandiaRepository();
            ViewBag.Employees = repo.GetAllEmployees();
            return View();
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            ZoolandiaRepository repo = new ZoolandiaRepository();

            int EmployeeCount = repo.GetAllEmployees().Count;

            if (id > 0 && id <= EmployeeCount)
            {
                ViewBag.ValidEmployee = true;

                var SpecificEmployee = repo.GetOneSpecificEmployee(id);

                ViewBag.SpecificEmployee = SpecificEmployee;
                return View();
            }
            else
            {
                ViewBag.ValidEmployee = false;
                return View();
            }
        }
    }
}

