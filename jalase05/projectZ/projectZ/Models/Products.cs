using System.ComponentModel.DataAnnotations;

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
        public string Specification { get; set; }
        [MaxLength]
        public string Description { get; set; }
        [Required]
        [StringLength(75)]
        public string Category { get; set; }
        public int Price { get; set; }
        [Required]
        public bool Exist { get; set; }

    }
}
