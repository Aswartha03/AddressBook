
using AddressBook.Core.DTO;
using AddressBook.Core.Entities;

namespace AddressBook.Core.Interfaces
{
	public interface IContactService
	{
		public Contact GetContact(int id);
		public List<Contact> GetAllContacts();
		public string RemoveContact(int id);
		public Contact UpdateContact(int id, UserContactRequest request);
		public Contact AddContact(UserContactRequest request);
	}
}