using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myapp.Models;
using myapp.Data;

namespace myapp.Controllers;

public class RegistroController : Controller {
     private readonly ILogger<RegistroController> _logger;
      private readonly ApplicationDbContext _context;

    
     public RegistroController(ILogger<RegistroController> logger,
         ApplicationDbContext context)
    {
        _logger = logger;
         _context = context;
    }

    public IActionResult Registro()
    {
        return View("Registro");
        
    }

    public IActionResult InicioSesion()
    {
        return View("InicioSesion");
    }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
      [HttpPost]
        public IActionResult Registro(Registro objContacto)
        {
            _context.Add(objContacto);
            _context.SaveChanges();
            ViewData["Message"] = "El contacto ya esta registrado";
            return View();
        }
}
