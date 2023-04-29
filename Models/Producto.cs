using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace myapp.Models
{
    [Table("t_productos")]
    public class Producto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_prod")]
        public int Id_prod { get; set; }

        public string? prod { get; set; }


        public Decimal prec { get; set; }


        public string? tipo { get; set; }


        public Decimal desc{ get; set; }

     
        public string? categ { get; set; }

        public Decimal Prec_final { get; set; }

        public string? imgProd { get; set; }
        
        public string? Status { get; set; }
    }
}