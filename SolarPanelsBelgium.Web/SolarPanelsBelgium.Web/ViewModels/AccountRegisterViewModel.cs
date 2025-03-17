using System.ComponentModel.DataAnnotations;

namespace SolarPanelsBelgium.Web.ViewModels
{
    public class AccountRegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First Name can only contain letters.")]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last Name can only contain letters.")]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        public string RepeatPassword { get; set; }
    }
}
