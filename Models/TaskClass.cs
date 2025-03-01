using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08Group4_7.Models
{
    public class TaskClass
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string TaskName { get; set; }
        public DateTime? DueDate { get; set; }
        [Required]
        public int Quadrant { get; set; }
        public bool? Completed { get; set; }


        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Categories? Category { get; set; }
    }
}

