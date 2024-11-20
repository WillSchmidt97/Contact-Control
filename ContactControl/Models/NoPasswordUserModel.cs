using ContactControl.Enums;
using System.ComponentModel.DataAnnotations;

namespace ContactControl.Models
{
    public class NoPasswordUserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name field required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Login field required!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Email field required.")]
        [EmailAddress(ErrorMessage = "Invalid email address. Please, provide an existing email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Select the user's profile type!")]
        public ProfileEnum? Profile { get; set; }
    }
}
