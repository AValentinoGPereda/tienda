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
    [Route("api/contacto")]
    public class ContactoApiController : ControllerBase
    {
       private readonly ContactoService _contactoService;

        public ContactoApiController(
                                  ContactoService contactoService)
        {
            
            _contactoService = contactoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contactos>>> List(){
            var contacto = await _contactoService.GetAll();
            if(contacto == null){
                return NotFound();
            }
            return Ok(contacto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contactos>> GetContacto(int? id){
            var contacto = await _contactoService.Get(id);
            if(contacto == null){
                return NotFound();
            }
            return Ok(contacto);
        }

        [HttpPost]
        public async Task<ActionResult<Contactos>> CreateContacto(Contactos contacto){
            if (contacto == null)
            {
                return BadRequest();
            }
            
            await _contactoService.CreateOrUpdate(contacto);
            return Ok(contacto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContacto(int? id)
        {
            await _contactoService.Delete(id);
            return Ok();
        } 
    }
}