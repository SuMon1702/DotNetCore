using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMDotNetCore.PizzaAPI.Model
{
    [Table("Tbl_Pizza")]
    public class PizzaModel
    {
        [Key]
        [Column("PizzaId")]
        public int id { get; set; }

        [Column("PizzaName")]
        public string name { get; set; }

        [Column("PizzaPrice")]
        public double price { get; set; }


    }
}
