
using System.ComponentModel.DataAnnotations;

namespace AddressBook.Core.DTO
{
	public class UserContactRequest

	{

		[Required(ErrorMessage = "Name is Required")]
		public string Name
		{
			get;
			set;
		}
		[EmailAddress(ErrorMessage = "Invalid Email Format")]
		public string Email
		{
			get;
			set;
		}

		[Required(ErrorMessage = "Phone is Required")]
		public string Phone
		{
			get;
			set;
		}

		[Required(ErrorMessage = "Address is Required")]
		public string Address
		{
			get;
			set;
		}
	}
}