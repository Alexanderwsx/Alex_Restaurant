using System.ComponentModel.DataAnnotations;

namespace Alex_Restaurant.Models
{
    public class TypeMeal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
