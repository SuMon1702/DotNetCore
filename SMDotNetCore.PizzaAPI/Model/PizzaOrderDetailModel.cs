using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMDotNetCore.PizzaAPI.Model
{
    [Table("Tbl_PizzaOrderDetail")]
    public class PizzaOrderDetailModel
    {
        [Key]
        public int PizzaOrderDetailId { get; set; }
        public required string PizzaOrderInvoiceNo { get; set; }
        public int PizzaExtraId { get; set; }

    }
}
