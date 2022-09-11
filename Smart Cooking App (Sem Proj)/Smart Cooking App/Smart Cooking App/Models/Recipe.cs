using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Smart_Cooking_App.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter recipe name")]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please enter recipe detail")]
        public string? Detail { get; set; }

        [Required(ErrorMessage = "Please enter recipe ingredients")]
        public string? Ingredients { get; set; }

        public string? ImagePath { get; set; }
    }
}
