using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace myapp.Models
{
    [Table("usuario")]
    public class Registro
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_usu")]
        public int Id { get; set; }

        [Column("correo")]
        public string? Correo { get; set; }

        [Column("pais")]
        public string? Pais { get; set; }

        [Column("contrasena")]
        public string? Contrasena { get; set; }

        [Column("nom_usu")]
        public string? NombreUsu { get; set; }

        [Column("nombres")]
        public string? Nombre { get; set; }

        [Column("telf")]
        public string? Telefono { get; set; }
    }
}