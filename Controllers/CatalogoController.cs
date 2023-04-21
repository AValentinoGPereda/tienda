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

namespace myapp.Controllers;

public class CatalogoController : Controller
{

    private readonly ILogger<CatalogoController> _logger;
    private readonly ApplicationDbContext _dbcontext;

    public CatalogoController(ILogger<CatalogoController> logger,
                ApplicationDbContext context)
        {
            _logger = logger;
            _dbcontext = context;
            
        }

    public IActionResult Producto()
    {
        
        return View();
    }

       public IActionResult Productos(string? searchString)
        {
            var productos = from o in _dbcontext.DataProducto select o;
            //SELECT * FROM t_productos -> &
            if(!String.IsNullOrEmpty(searchString)){
                productos = productos.Where(s => s.prod.Contains(searchString)); //Algebra de bool
                // & + WHERE name like '%ABC%'
            }
            Response.Headers["Cache-Control"] = "max-age=3600, public";
            return View(productos.ToList());
        }

public IActionResult Index()
    {
        
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}