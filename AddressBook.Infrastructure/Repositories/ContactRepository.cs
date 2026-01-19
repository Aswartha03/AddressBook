using AddressBook.Core.DTO;
using AddressBook.Core.Entities;
using AddressBook.Core.Interfaces;
using AddressBook.Infrastructure.Data;

namespace AddressBook.Infrastructure.Repositories
{
	public class ContactRepository : IContactRepository
	{

		private readonly AppDbContext context;

		public ContactRepository(AppDbContext context)
		{
			this.context = context;
		}

		public Contact AddNewContact(Contact contact)
		{
			var res = context.Contacts.Add(contact);
			Console.WriteLine($"From Repo {res}"); 
			// mandotary to call SaveChanges to persist data
			// ACID properties 
			 context.SaveChanges();
			return contact;
		}

		public string DeleteContact(Contact contact)
		{
			context.Contacts.Remove(contact);
			context.SaveChanges();
			return "Contact Successfully Deleted";
		}

		public Contact EditContactById(ContactEditRequest newContact, Contact existingContact)
		{
			if (newContact.Name != null)
			{
				existingContact.Name = newContact.Name;
			}
			if (newContact.Email != null)
			{
				existingContact.Email = newContact.Email;
			}
			if (newContact.Phone != null)
			{
				existingContact.Phone = newContact.Phone;
			}
			if (newContact.Address != null)
			{
				existingContact.Address = newContact.Address;
			}
			context.SaveChanges();
			return existingContact;
		}

		public List<Contact> GetAllContacts()
		{
			List<Contact> contacts = context.Contacts.ToList();
			return contacts;
		}

		public Contact GetContactById(int id)
		{
			Contact? contact = context.Contacts.FirstOrDefault(c => c.ContactId == id);
			return contact;
		}
	}
}