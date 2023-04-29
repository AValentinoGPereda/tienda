﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myapp.Models;

namespace myapp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View("Index");
    }

    public IActionResult Nosotros()
    {
        return View();
    }

    public IActionResult Cuenta()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

// Nicole 16/04
//  lEO 19/04
