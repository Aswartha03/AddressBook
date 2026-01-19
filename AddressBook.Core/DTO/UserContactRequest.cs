using System.ComponentModel.DataAnnotations;

namespace AddressBook.Core.DTO
{
	public class UserContactRequest
	{
		[Required(ErrorMessage = "Name is Required")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Email is Required")]
		[EmailAddress(ErrorMessage = "Invalid Email Format")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Phone is Required")]
		[RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Invalid Mobile Number")]
		public string Phone { get; set; }

		[Required(ErrorMessage = "Address is Required")]
		public string Address { get; set; }

		[Required(ErrorMessage = "Company is Required")]
		public string Company { get; set; }
	}
}
