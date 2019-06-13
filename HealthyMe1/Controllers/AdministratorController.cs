using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HealthyMe1.DAL;
using HealthyMe1.Models;

namespace HealthyMe1.Controllers
{
    public class AdministratorController : Controller
    {
        private readonly HealthyMeContext _context;

        public AdministratorController(HealthyMeContext context)
        {
            _context = context;
        }
    }

}
