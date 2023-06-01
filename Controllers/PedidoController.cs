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
using myapp.Service;
using Microsoft.EntityFrameworkCore;

namespace myapp.Controllers
{
    public class PedidoController : Controller
    {
        private readonly ILogger<PedidoController> _logger;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly PedidoService _pedidoService;

        public PedidoController(ILogger<PedidoController> logger, UserManager<IdentityUser> userManager, ApplicationDbContext context, PedidoService pedidoService)
        {
            
            _pedidoService = pedidoService;
            _logger = logger;
            _userManager = userManager;
            _context = context;
        }

        public  async Task<IActionResult>  Index()
        {
             var pedidos = from o in _context.DataPedido select o;
             pedidos = pedidos.Where(s => s.Status.Contains("PENDIENTE"));

            return View(await pedidos.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            var lista = _context.DataDetallePedido.Where(s => s.pedido.ID == (id));

            return View(await lista.ToListAsync());
        }
        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}