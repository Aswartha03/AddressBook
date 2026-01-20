using AddressBook.Core.DTO;
using AddressBook.Core.Entities;

namespace AddressBook.Core.Interfaces
{
	public interface IContactService
	{
		public ContactResponse GetContactById(int id);
		public List<ContactResponse> GetAllContacts();
		public bool DeleteContactById(int id);
		public ContactResponse UpdateContactById(int id, UpdateContactRequest request);
		public ContactResponse CreateContact(CreateContactRequest request);
	}
}