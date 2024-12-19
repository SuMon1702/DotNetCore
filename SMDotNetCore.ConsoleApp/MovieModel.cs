using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMDotNetCore.ConsoleApp
{
    [Table("Tbl_Movie")]
    public class MovieModel
    {
        [Key]
        public int MovieID {  get; set; }
        public string MovieName { get; set; }
        public string MovieTitle { get; set; }
        public string MovieContent { get; set; }

    }
}
