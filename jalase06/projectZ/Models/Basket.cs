using System.ComponentModel.DataAnnotations;
namespace projectZ.Models
{
    public class Basket
    {
        [Key]
        public int PId { get; set; }
        [Required]
        [StringLength(100)]
        public string PName { get; set; }
        [StringLength(75)]
        public string PCategory { get; set; }
        public int Price { get; set; }
    }
}
