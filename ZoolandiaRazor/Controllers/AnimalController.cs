﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZoolandiaRazor.Controllers
{
    public class AnimalController : Controller
    {
        // GET: Animal
        public ActionResult Index()
        {
            return View();
        }

        // GET: Animal/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

    }
}
