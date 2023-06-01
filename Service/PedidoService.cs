using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using myapp.Models;
using myapp.Data;


namespace myapp.Service
{
    public class PedidoService
    {
        private readonly ILogger<PedidoService> _logger;

        private readonly ApplicationDbContext _context;

        public PedidoService(ILogger<PedidoService> logger, ApplicationDbContext context){
            _logger = logger;
            _context = context;
        }

        public async Task<DetallePedido> CreateOrUpdate(DetallePedido p){
           if(PedidoExists(p.pedido.ID)){
                    _context.Update(p);
            }
            else{
                _context.Add(p);
            }
            await _context.SaveChangesAsync();
            return p;
        }

        public async Task<List<DetallePedido>?> GetAll(){
            if(_context.DataDetallePedido == null)
                return null;
            return await _context.DataDetallePedido.ToListAsync();
        }

        public async Task<DetallePedido?> Get(int? id){
              if (id == null || _context.DataDetallePedido == null)
            {
                return null;
            }

            var pedido = await _context.DataDetallePedido.FindAsync(id);
            if (pedido == null)
            {
                return null;
            }

             return pedido;
        }

        public async Task<DetallePedido?> FirstOrDefault(int? id){
             var pedido = await _context.DataDetallePedido
                .FirstOrDefaultAsync(m => m.pedido.ID == id);
            if (pedido == null)
            {
                return null;
            }

            return pedido;
        }

        public async Task Delete(int? id){
            var pedido = await _context.DataDetallePedido.FindAsync(id);
            if (pedido != null)
            {
                _context.DataDetallePedido.Remove(pedido);
            }
            
            await _context.SaveChangesAsync();

            
        }

        public bool PedidoExists(int id)
        {
          return (_context.DataDetallePedido?.Any(e => e.pedido.ID == id)).GetValueOrDefault();
        }

    }

  
}