﻿using System;
using ZoolandiaRazor.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZoolandiaRazor.Models;

namespace ZoolandiaRazor.Controllers
{
    public class HabitatController : Controller
    {
        // GET: Habitats
        public ActionResult Index()
        {
            ZoolandiaRepository repo = new ZoolandiaRepository();
            ViewBag.Habitats = repo.GetAllHabitats();
            ViewBag.HabitatCount = repo.GetAllHabitats().Count;
            return View();
        }

        // GET: Habitat/Details/5
        public ActionResult Details(int id)
        {
            ZoolandiaRepository repo = new ZoolandiaRepository();

            int HabitatCount = repo.GetAllHabitats().Count;

            if (id > 0 && id <= HabitatCount)
            {
                ViewBag.ValidHabitat = true;
                ViewBag.SpecificHabitat = repo.GetOneSpecificHabitat(id);
                return View();
            }
            else
            {
                ViewBag.ValidHabitat = false;
                return View();
            }
        }
    }
}
