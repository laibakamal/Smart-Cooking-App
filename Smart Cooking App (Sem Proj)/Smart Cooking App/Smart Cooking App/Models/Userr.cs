using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Smart_Cooking_App.Models
{
    public partial class Userr
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please enter a username")]
        [StringLength(50)]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        [StringLength(50)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Please re-enter password")]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }


        public string Role { get; set; }
    }
}
