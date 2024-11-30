using System.ComponentModel.DataAnnotations;

namespace ContactControl.Models
{
    public class ResetPasswordModel
    {
        [Required(ErrorMessage = "Login required!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Email required!")]
        public string Email { get; set; }
    }
}
