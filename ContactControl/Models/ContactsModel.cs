using System.ComponentModel.DataAnnotations;

namespace ContactControl.Models
{
    public class ContactsModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name field required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email field required.")]
        [EmailAddress(ErrorMessage = "Invalid email address. Please, provide an existing email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone field required!")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Postal code field required.")]
        public string Postalcode {get ; set; }
        [Required(ErrorMessage = "State field required.")]
        public string State { get; set; }
        [Required(ErrorMessage = "City field required.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Neighborhood field required.")]
        public string Neighborhood { get; set; }
        [Required(ErrorMessage = "Address field required.")]
        public string Address { get; set; }
    }
}
