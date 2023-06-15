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

        public  async Task<IActionResult>  Index(string? searchUsername,string? orderStatus)
        {
            var pedidos = from o in _context.DataPedido select o;

            if(!String.IsNullOrEmpty(searchUsername) && !String.IsNullOrEmpty(orderStatus)){
                pedidos = pedidos.Where(s => s.UserID.Contains(searchUsername) && s.Status.Contains(orderStatus));
            }else if (!String.IsNullOrEmpty(searchUsername) ){
                pedidos = pedidos.Where(s => s.UserID.Contains(searchUsername));
            }else if (!String.IsNullOrEmpty(orderStatus)){
                pedidos = pedidos.Where(s => s.Status.Contains(orderStatus));
            }else{
                pedidos = from o in _context.DataPedido select o;
            }



            return View(await pedidos.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            var detallesPedido = await _context.DataDetallePedido
                .Where(dp => dp.pedido.ID == id)
                .Include(dp => dp.Producto)
                .ToListAsync();

            return View(detallesPedido);
        }
        




        // GET: Producto/Edit/5
       [HttpGet] 
        public async Task<IActionResult> Edit(int? id)
        {
            var producto = await _pedidoService.Gets(id);

            if(producto == null){
                return NotFound();
            }
            return View(producto);
        }
       


        // POST: Producto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
public async Task<IActionResult> Edit(int ID, [Bind("ID,UserID,Total,pago,Status,Date")] Pedido pedido)
{
    if (ID != pedido.ID)
    {
        return NotFound();
    }

    if (ModelState.IsValid)
    {
        try
        {
            // Establecer el Kind del objeto DateTime en Utc
            pedido.Date = DateTime.SpecifyKind(pedido.Date, DateTimeKind.Utc);
            
            await _pedidoService.CreateOrUpdates(pedido);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_pedidoService.PedidoExists(pedido.ID))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return RedirectToAction(nameof(Index));
    }
    return View(pedido);
}

        // GET: Producto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
           var producto = await _pedidoService.Gets(id);

            if(producto == null){
                return NotFound();
            }
            return View(producto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            await _pedidoService.Deletes(id);
            return RedirectToAction(nameof(Index));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }



    }
}