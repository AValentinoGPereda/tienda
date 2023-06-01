using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using myapp.Models;
using myapp.Data;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using myapp.Service;



namespace myapp.Controllers
{
    public class ContactoController : Controller
    {
        private readonly ILogger<ContactoController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        private readonly ContactoService _contactoService;

        public ContactoController(ILogger<ContactoController> logger, ApplicationDbContext context,ContactoService contactoService)
        {
            _logger = logger;
            _context = context; 
            _contactoService= contactoService;
            
        }

        public IActionResult Index()
        {
            return View("Create");
        }

    public async Task<IActionResult> ConsultaAdmin(string? searchString)
        {
            
            var consultas = from o in _context.DataContacto select o;           
              consultas = consultas.Where(s => s.Nombre != null);
            
            return View(await consultas.ToListAsync());
        }

public async Task<IActionResult> Details(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

    var contacto = await _context.DataContacto.FirstOrDefaultAsync(c => c.Id == id);

    if (contacto == null)
    {
        return NotFound();
    }

    return View(contacto);
}



        [HttpPost]
        public IActionResult Create(Contactos objContacto)
        {
            _context.Add(objContacto);
            _context.SaveChanges();
            ViewData["Message"] = "El contacto ya esta registrado";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}