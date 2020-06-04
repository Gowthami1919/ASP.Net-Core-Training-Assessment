using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MovieCrudOpe.DTOS
{
    public class UserForRegiserDto
    {
        [Required(ErrorMessage = "UserName Is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [RegularExpression("([1-9][0-9]*)")]
        public int Age { get; set; }

        [StringLength(1, MinimumLength = 1, ErrorMessage = "The Gender must be 1 characters.")]
        [RegularExpression("M|F", ErrorMessage = "The Gender must be either 'M' or 'F' only.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public int phoneNumber { get; set; }

        [Required(ErrorMessage = "Address ids required")]
        public string Address { get; set; }

    }
}
