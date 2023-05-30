using System.ComponentModel.DataAnnotations.Schema;


namespace myapp.Models
{
     [Table("t_order")]
    public class Pedido
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID {get; set;}

        public string? UserID{ get; set; }

        public Decimal Total { get; set; }

        public Pagos? pago { get; set; }

        public string? Status { get; set; }
        public DateTime Date { get; set; }
    }
}