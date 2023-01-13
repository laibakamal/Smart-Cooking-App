using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Smart_Cooking_App.Models
{
    public class Recipe : FullAuditModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter recipe name")]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please enter recipe detail")]
        public string? Detail { get; set; }

        [Required(ErrorMessage = "Please enter recipe ingredients")]
        public string? Ingredients { get; set; }

        [Required(ErrorMessage = "Please enter text to display on thumbnail")]
        public string? ThumbnailText { get; set; }

        public string? ImagePath { get; set; }
    }
}
