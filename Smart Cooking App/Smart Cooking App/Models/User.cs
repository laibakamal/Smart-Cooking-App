using System.ComponentModel.DataAnnotations;
namespace Smart_Cooking_App.Models
{
    public class User
    {
        [Required(ErrorMessage = "Please enter name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter Email")]

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }

}
