using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMDotNetCore.PizzaAPI.Model
{
    [Table("Tbl_Extra")]
    public class PizzaExtraModel
    {
        [Key]
        [Column("PizzaExtraId")]
        public int id { get; set; }

        [Column("PizzaExtraName")]
        public required string Name { get; set; }

        public decimal Price { get; set; }
        [NotMapped]
        public string PriceStr { get { return "$"+ Price; } }

    }
}
