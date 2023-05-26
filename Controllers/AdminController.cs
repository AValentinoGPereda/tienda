using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;

using myapp.Data;
using myapp.Models;
using Microsoft.EntityFrameworkCore;

namespace myapp.Controllers;

public class AdminController : Controller {
     private readonly ILogger<AdminController> _logger;

     private readonly UserManager<IdentityUser> _userManager;

    public AdminController(ILogger<AdminController> logger, UserManager<IdentityUser> userManager)
    {
        _logger = logger;
        _userManager = userManager;
    }


   public IActionResult Index()
    {
        return View();
    }
    public IActionResult ListarCuentas()
    {
        return View();
    }
    public IActionResult ListarOferta()
    {
        return View();
    }
    public IActionResult ListarProducto()
    {
        return View();
    }
    public IActionResult ListarTransacciones()
    {
        return View();
    }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

   