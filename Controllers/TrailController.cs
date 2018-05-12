using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using woods.Factories;
using woods.Models;

namespace woods.Controllers
{
    public class TrailController : Controller
    {
        private readonly TrailFactory trailfactory;
        public TrailController()
        {
            trailfactory = new TrailFactory();
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.allTrails = trailfactory.ViewTrails();
            Console.WriteLine(ViewBag.allTrails);
            return View();
        }

        [HttpGet]
        [Route("/newTrail")]
        public IActionResult NewTrail()
        {
            return View();
        }

        [HttpPost]
        [Route("/add_trail")]
        public IActionResult AddTrail(Trail trail)
        {
            trailfactory.AddNewTrail(trail);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("/trails/{id}")]
        public IActionResult Trail(int id)
        {
            ViewBag.thisTrail = trailfactory.FindTrail(id);
            return View();
        }
    }
}