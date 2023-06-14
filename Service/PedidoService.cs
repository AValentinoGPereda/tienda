using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using myapp.Models;
using myapp.Data;
using Microsoft.Extensions.Logging;

namespace myapp.Service
{
    public class PedidoService
    {
        private readonly ILogger<PedidoService> _logger;
        private readonly ApplicationDbContext _context;

        public PedidoService(ILogger<PedidoService> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

            public async Task<DetallePedido> CreateOrUpdate(DetallePedido p)
            {
                if (PedidoExists(p.pedido.ID))
                {
                    _context.Update(p);
                }
                else
                {
                    // Asegurarse de que la fecha tenga Kind=Utc
                    p.pedido.Date = DateTime.SpecifyKind(p.pedido.Date , DateTimeKind.Utc);
                    _context.Add(p);
                }
                await _context.SaveChangesAsync();
                return p;
            }

        public async Task<List<DetallePedido>> GetAll()
        {
            return await _context.DataDetallePedido.ToListAsync();
        }

        public async Task<DetallePedido> Get(int? id)
        {
            return await _context.DataDetallePedido.FindAsync(id);
        }

        public async Task Delete(int? id)
        {
            var pedido = await _context.DataDetallePedido.FindAsync(id);
            if (pedido != null)
            {
                _context.DataDetallePedido.Remove(pedido);
            }
            await _context.SaveChangesAsync();
        }

        public bool PedidoExists(int id)
        {
            return _context.DataDetallePedido.Any(e => e.pedido.ID == id);
        }

        public async Task<Pedido> CreateOrUpdates(Pedido p)
        {
            if (PedidoExistss(p.ID))
            {
                _context.Update(p);
            }
            else
            {
                _context.Add(p);
            }
            await _context.SaveChangesAsync();
            return p;
        }

        public async Task<List<Pedido>> GetAlls()
        {
            return await _context.DataPedido.ToListAsync();
        }

        public async Task<Pedido> Gets(int? id)
        {
            return await _context.DataPedido.FindAsync(id);
        }

        public async Task Deletes(int? id)
        {
            var pedido = await _context.DataPedido.FindAsync(id);
            if (pedido != null)
            {
                _context.DataPedido.Remove(pedido);
            }
            await _context.SaveChangesAsync();
        }

        public bool PedidoExistss(int id)
        {
            return _context.DataPedido.Any(e => e.ID == id);
        }
    }
}
