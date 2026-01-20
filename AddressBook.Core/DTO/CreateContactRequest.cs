using System.ComponentModel.DataAnnotations;

namespace AddressBook.Core.DTO
{
	public class CreateContactRequest  
	{
		[Required(ErrorMessage = "Name is Required")]
		[MinLength(3, ErrorMessage = "Name must be atleast 3 letters")]
		public string Name { get; set; }  

		[Required(ErrorMessage = "Email is Required")] 
		[EmailAddress(ErrorMessage = "Invalid Email Format")]
		[RegularExpression(@"^[a-zA-Z0-9._%+-]+@gmail\.com$",ErrorMessage = "Only Gmail addresses are allowed")]
		public string Email { get; set; }  

		[Required(ErrorMessage = "Phone is Required")] 
		[RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Invalid Mobile Number")]
		public string Phone { get; set; }   

		[Required(ErrorMessage = "Address is Required")] 
		[StringLength(50, MinimumLength = 5, ErrorMessage = "Address must be between 5 to 50 characters long")]
		public string Address { get; set; } 

		[Required(ErrorMessage = "Company is Required")] 
		public string Company { get; set; }

		[Required(ErrorMessage = "Adhaar is Required")]
		[RegularExpression(@"^\d{12}$", ErrorMessage = "Adhaar must be a 12-digit number")]
		public string Adhaar { get; set; } 
	}
}
