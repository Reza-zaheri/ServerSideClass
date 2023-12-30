using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectZ.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [MaxLength]
        public string imagepath { get; set; }
        public int price { get; set; }
        public int Percent { get; set; }
        [NotMapped]
        public IFormFile image { get; set; }
        public ICollection<Basket>Baskets { get; set; }

    }
}
