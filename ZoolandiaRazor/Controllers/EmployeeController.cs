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

    }
}

