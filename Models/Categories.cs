using System.ComponentModel.DataAnnotations;

namespace Mission08Group4_7.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string Category { get; set; }
    }
}
