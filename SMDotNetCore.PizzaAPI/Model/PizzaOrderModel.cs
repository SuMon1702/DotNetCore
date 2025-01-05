using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMDotNetCore.PizzaAPI.Model
{
    [Table("Tbl_PizzaOrder")]
    public class PizzaOrderModel
    {
        [Key]

        public int PizzaOrderId { get; set; }
        public required string PizzaOrderInvoiceNo { get; set; }

        public int PizzaId { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
