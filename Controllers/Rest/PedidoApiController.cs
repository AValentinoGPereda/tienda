using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using myapp.Service;
using myapp.Models;

namespace myapp.Controllers.Rest
{
    [ApiController]
    [Route("api/pedido")]
    public class PedidoApiController : ControllerBase
    {
       private readonly PedidoService _pedidoService;

        public PedidoApiController(
                                  PedidoService pedidoService)
        {
            
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DetallePedido>>> List(){
            var pedido = await _pedidoService.GetAll();
            if(pedido == null){
                return NotFound();
            }
            return Ok(pedido);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetallePedido>> GetProducto(int? id){
            var pedido = await _pedidoService.Get(id);
            if(pedido == null){
                return NotFound();
            }
            return Ok(pedido);
        }

        [HttpPost]
        public async Task<ActionResult<DetallePedido>> CreatePedido(DetallePedido pedido){
            if (pedido == null)
            {
                return BadRequest();
            }
            
            await _pedidoService.CreateOrUpdate(pedido);
            return Ok(pedido);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePedido(int? id)
        {
            await _pedidoService.Delete(id);
            return Ok();
        } 
    }
}