using System.ComponentModel.DataAnnotations;

namespace Momentum.Models
{
    public class Goal
    {
        public int GoalId { get; set; }

        [Required(ErrorMessage = "Please enter a goal title.")]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a description.")]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a category.")]
        [StringLength(50)]
        public string Category { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a target date.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:M/d/yyyy}")]
        public DateTime TargetDate { get; set; }
    }
}