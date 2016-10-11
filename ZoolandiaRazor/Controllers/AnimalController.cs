using System;
using ZoolandiaRazor.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZoolandiaRazor.Models;

namespace ZoolandiaRazor.Controllers
{
    public class AnimalController : Controller
    {
        // GET: Animal
        public ActionResult Index()
        {
            ZoolandiaRepository repo = new ZoolandiaRepository();
            ViewBag.Animals = repo.GetAllAnimals();
            return View();
        }

    }
}
