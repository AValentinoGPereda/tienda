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




namespace myapp.Controllers
{
    
    public class CatalogoController : Controller
    {
        private readonly ILogger<CatalogoController> _logger;
        private readonly ApplicationDbContext _dbcontext;

        private readonly IDistributedCache _cache;
        private readonly UserManager<IdentityUser> _userManager;

        private readonly SignInManager<IdentityUser> _signInManager;

        public CatalogoController(ILogger<CatalogoController> logger,
                ApplicationDbContext context,
                IDistributedCache cache,
                 UserManager<IdentityUser> userManager,
                 SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _dbcontext = context;
            _cache = cache;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<IActionResult> Index(string? searchString)
        {
            
            var productos = from o in _dbcontext.DataProductos select o;
            //SELECT * FROM t_productos -> &
            if(!String.IsNullOrEmpty(searchString)){
                productos = productos.Where(s => s.prod.Contains(searchString)); //Algebra de bool
                // & + WHERE name like '%ABC%'
            }
            productos = productos.Where(s => s.Status.Contains("Activo"));
            
            return View(await productos.ToListAsync());
        }

         public async Task<IActionResult> Details(int? id){
            Producto objProduct = await _dbcontext.DataProductos.FindAsync(id);
            if(objProduct == null){
                return NotFound();
            }
            return View(objProduct);
        }

        public async Task<IActionResult> Add(int? id){
            var userID = _userManager.GetUserName(User); //sesion

            if(userID == null){
                ViewData["Message"] = "Por favor debe loguearse antes de agregar un producto";
                List<Producto> producto = new List<Producto>();
                return  View("Index",producto);
            }else{
                var producto = await _dbcontext.DataProductos.FindAsync(id);

                Proforma proforma = new Proforma();
                proforma.Producto = producto;
                proforma.Precio = producto.Prec_final; //precio del producto en ese momento
                proforma.Cantidad = 1;
                proforma.UserID = userID;
                _dbcontext.Add(proforma);
                await _dbcontext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}