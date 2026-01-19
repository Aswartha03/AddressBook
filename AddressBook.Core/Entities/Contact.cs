
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AddressBook.Core.Entities
{
	public class Contact
	{
		[Key]

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ContactId
		{
			get;
			set;
		}
		public string Name
		{
			get;
			set;
		}
		public string Phone
		{
			get;
			set;
		}
		public string Email
		{
			get;
			set;
		}
		public string Address
		{
			get;
			set;
		}
		public DateTime CreatedAt
		{
			get;
			set;
		}
	}
}