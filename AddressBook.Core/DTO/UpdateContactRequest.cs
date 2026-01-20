using System.ComponentModel.DataAnnotations;

namespace AddressBook.Core.DTO
{
    public class UpdateContactRequest
    {
        [MinLength(3 , ErrorMessage ="Name must be atleast 3 letters")]
        public string? Name { get; set; }

		[RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Invalid Mobile Number")]
		public string ? Phone { get; set; } 

		[EmailAddress(ErrorMessage = "Invalid Email Format")]
		[RegularExpression(@"^[a-zA-Z0-9._%+-]+@gmail\.com$",ErrorMessage = "Only Gmail addresses are allowed")]
		public string ? Email { get; set; }

		[StringLength(50,MinimumLength = 5, ErrorMessage = "Address must be between 5 to 50 characters long")]
        public string ? Address { get; set; } 

		[StringLength(15, MinimumLength = 2, ErrorMessage = "Company name must be between 2 to 15 characters long")]
        public string ? Company { get; set; } 

		[RegularExpression(@"^\d{12}$", ErrorMessage = "Adhaar must be a 12-digit number")]
		public string? Adhaar { get; set; }  
	}
}
