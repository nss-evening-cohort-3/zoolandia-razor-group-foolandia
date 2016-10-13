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

        // GET: Animal/Details/5
        public ActionResult Details(int id)
        {
            ZoolandiaRepository repo = new ZoolandiaRepository();

            int AnimalsCount = repo.GetAllAnimals().Count;

            if (id > 0 && id <= AnimalsCount)
            {
                ViewBag.ValidAnimal = true;
                ViewBag.SpecificAnimal = repo.GetOneSpecificAnimal(id);
                return View();
            }
            else
            {
                ViewBag.ValidAnimal = false;
                return View();
            }


        }
    }
}
