using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace myapp.Models
{
    [Table("producto")]
    public class Producto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_prod")]
        public int Id_prod { get; set; }
        public string? prod { get; set; }

        public string? prec { get; set; }

        public Decimal tipo { get; set; }

        public Decimal desc{ get; set; }

        public string? categ { get; set; }

        public string? Spec_final { get; set; }
        public string? imgProd { get; set; }
    }
}