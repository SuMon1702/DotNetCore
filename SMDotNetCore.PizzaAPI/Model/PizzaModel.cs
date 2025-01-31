﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMDotNetCore.PizzaAPI.Model
{
    [Table("Tbl-Pizza")]
    public class PizzaModel
    {
        [Key]
        [Column("PizzaId")]
        public int Id { get; set; }

        [Column("Pizza")]
        public string name { get; set; }

        [Column("Price")]
        public decimal price { get; set; }


    }
}
