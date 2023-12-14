using System.ComponentModel.DataAnnotations;
namespace projectZ.Models

{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Family { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(100)]
        public string Phone { get; set; }
        [Required]
        [StringLength(25)]
        public string password { get; set; }

    }
}
