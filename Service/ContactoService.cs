using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using myapp.Models;
using myapp.Data;


namespace myapp.Service
{
    public class ContactoService
    {
        private readonly ILogger<ContactoService> _logger;

        private readonly ApplicationDbContext _context;

        public ContactoService(ILogger<ContactoService> logger, ApplicationDbContext context){
            _logger = logger;
            _context = context;
        }

        public async Task<Contactos> CreateOrUpdate(Contactos p){
           if(ContactoExists(p.Id)){
                    _context.Update(p);
            }
            else{
                _context.Add(p);
            }
            await _context.SaveChangesAsync();
            return p;
        }

        public async Task<List<Contactos>?> GetAll(){
            if(_context.DataContacto == null)
                return null;
            return await _context.DataContacto.ToListAsync();
        }

        public async Task<Contactos?> Get(int? id){
              if (id == null || _context.DataContacto == null)
            {
                return null;
            }

            var contacto = await _context.DataContacto.FindAsync(id);
            if (contacto == null)
            {
                return null;
            }

             return contacto;
        }

        public async Task<Contactos?> FirstOrDefault(int? id){
             var contacto = await _context.DataContacto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contacto == null)
            {
                return null;
            }

            return contacto;
        }

        public async Task Delete(int? id){
            var contacto = await _context.DataContacto.FindAsync(id);
            if (contacto != null)
            {
                _context.DataContacto.Remove(contacto);
            }
            
            await _context.SaveChangesAsync();

            
        }

        public bool ContactoExists(int id)
        {
          return (_context.DataContacto?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }

  
}