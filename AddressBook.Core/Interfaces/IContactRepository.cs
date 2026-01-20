using AddressBook.Core.DTO;
using AddressBook.Core.Entities;

namespace AddressBook.Core.Interfaces
{
	public interface IContactRepository
	{
		public Contact Add(Contact contact);
		public bool Delete(Contact contact);
		public Contact Update(UpdateContactRequest newContact, Contact existingContact);

		public List<Contact> GetAll();
		public Contact GetById(int id);
	}
}