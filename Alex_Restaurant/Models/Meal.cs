using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Alex_Restaurant.Models
{
    public class Meal
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ValidateNever]
        public string? ImageUrl { get; set; }
        public int TypeMealId { get; set; }
        [ValidateNever]
        public TypeMeal TypeMeal { get; set; }
    }
}
