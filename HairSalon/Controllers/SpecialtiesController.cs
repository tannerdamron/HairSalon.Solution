using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
    public class SpecialtiesController : Controller
    {

        [HttpGet("/specialties")]
        public ActionResult Index()
        {
            List<Specialty> allSpecialties = Specialty.GetAll();
            return View(allSpecialties);
        }

        [HttpGet("/specialties/new")]
        public ActionResult New(int stylistId)
        {
            return View();
        }

        [HttpPost("/specialties")]
        public ActionResult Create(string specialtyName)
        {
            Specialty newSpecialty = new Specialty(specialtyName);
            newSpecialty.Save();
            List<Specialty> allSpecialties = Specialty.GetAll();
            return View("Index", allSpecialties);
        }
    }
}