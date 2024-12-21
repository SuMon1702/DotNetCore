using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMDotNetCore.WebAPI.Model
{
    [Table("Tbl_Movie")]
    public class MovieModel
    {
        [Key]
        public int MovieID { get; set; }
        public string? MovieName { get; set; }
        public string? MovieTitle { get; set; }
        public string? MovieContent { get; set; }

    }
}
