using Humanizer;
using System.ComponentModel.DataAnnotations;

namespace ST10281011_PROG7311_POE_PART_2.Models
{
    //Improvements for data anotations and validation assisted by ChatGPT (OpenAI, 2025). See README File for Details.
    //OpenAI ChatGpt. 2025.
    //<https://chatgpt.com/share/68232d50-0be4-800d-b0f4-421cc236ce20>

    // ViewModel used to get inputed data when adding a new 'Farmer'
    public class AddFarmerViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [Phone(ErrorMessage = "Enter a valid phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$", ErrorMessage = "Password must be at least 8 characters and contain uppercase, lowercase, number, and special character.")]
        public string Password { get; set; }
    }
}
