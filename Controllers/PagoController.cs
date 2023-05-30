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

namespace myapp.Controllers
{

    public class PagoController : Controller
    {
        private readonly ILogger<PagoController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public PagoController(ILogger<PagoController> logger, UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Create(Decimal monto)
        {

            Pagos pagos = new Pagos();
            pagos.UserID = _userManager.GetUserName(User);
            pagos.MontoTotal = monto;
            return View(pagos);
        }

        [HttpPost]
        public IActionResult Pagar(Pagos pagos)
        {
            pagos.PaymentDate = DateTime.UtcNow;
            _context.Add(pagos);

            var itemsProforma = from o in _context.DataProformas select o;
            itemsProforma = itemsProforma.
                Include(p => p.Producto).
                Where(s => s.UserID.Equals(pagos.UserID) && s.Status.Equals("PENDIENTE"));

            Pedido pedido = new Pedido();
            pedido.UserID = pagos.UserID;
            pedido.Total = pagos.MontoTotal;
            pedido.pago = pagos;
            pedido.Status = "PENDIENTE";
            pedido.Date= DateTime.UtcNow;
            _context.Add(pedido);

            List<DetallePedido> itemsPedido = new List<DetallePedido>();
            foreach(var item in itemsProforma.ToList()){
                DetallePedido detallePedido = new DetallePedido();
                detallePedido.pedido=pedido;
                detallePedido.Precio = item.Precio;
                detallePedido.Producto = item.Producto;
                detallePedido.Cantidad = item.Cantidad;
                itemsPedido.Add(detallePedido);
            }


            _context.AddRange(itemsPedido);

            foreach (Proforma p in itemsProforma.ToList())
            {
                p.Status="PROCESADO";
            }

            _context.UpdateRange(itemsProforma);

            _context.SaveChanges();

            ViewData["Message"] = "El pago se ha registrado y su pedido nro "+ pedido.ID +" esta en camino";
            return View("Create");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}