using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthyMe.Models.enums;
using HealthyMe1.DAL;
using HealthyMe1.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthyMe1.Controllers
{
    [Route("api/[controller]")]
    public class GlavniController : Controller
    {

        private static readonly HealthyMeContext context = HealthyMeContext.GetInstance();

        [HttpGet]
        public ActionResult Registracija()
        {
            return View("CreateUser");
        }

        [HttpPost]
        public IActionResult Validacija(string etIme, string etEmail, string etPassword, string etPotvrdniPassword, string etVisina, string etTezina, Spol etSpol)
        {
            Boolean validationOk = true;
            if (etIme.Equals("") || etPassword.Equals("") || etPotvrdniPassword.Equals("") || etEmail.Equals("") || etVisina.Equals("") || etTezina.Equals("") || etSpol.Equals("")) validationOk = false;
            if (!etPassword.Equals(etPotvrdniPassword)) validationOk = false;

            var korisnik = context.Registrovani.Where((Registrovani k) => k.Email.Equals(etEmail));
            var administrator = context.Administratori.Where((Administrator admin) => admin.Email.Equals(etEmail));
            if (korisnik.Count() != 0 || administrator.Count() != 0) validationOk = false;

            if (validationOk)
            {
                context.Registrovani.Add(new Registrovani
                {
                    Ime = etIme,
                    Password = etPassword,
                    Email = etEmail,
                    Visina = double.Parse(etVisina),
                    Tezina = double.Parse(etTezina),
                    Spol = etSpol
                });

                context.SaveChanges();
            }
            return View("CreateUser");
        }
    }
}

