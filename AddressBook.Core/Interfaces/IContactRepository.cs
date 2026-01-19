
using AddressBook.Core.DTO;
using AddressBook.Core.Entities;

namespace AddressBook.Core.Interfaces
{
	public interface IContactRepository
	{
		public Contact AddNewContact(Contact contact);
		public string DeleteContact(Contact contact);
		public Contact EditContactById(UserContactRequest newContact, Contact existingContact);

		public List<Contact> GetAllContacts();
		public Contact GetContactById(int id);
	}
}