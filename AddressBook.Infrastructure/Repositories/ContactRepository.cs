using AddressBook.Core.DTO;
using AddressBook.Core.Entities;
using AddressBook.Core.Interfaces;
using AddressBook.Infrastructure.Data;
using AutoMapper;

namespace AddressBook.Infrastructure.Repositories
{
	public class ContactRepository : IContactRepository
	{
		private readonly AppDbContext context;
		private readonly IMapper mapper;
		public ContactRepository(AppDbContext context , IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public Contact Add(Contact contact)
		{
			this.context.Contacts.Add(contact);
			this.context.SaveChanges();
			return contact;
		}

		public bool Delete(Contact contact)
		{
			this.context.Contacts.Remove(contact);
			this.context.SaveChanges();
			return true;
		}

		public Contact Update(UpdateContactRequest updateRequest, Contact existingContact)
		{
			// Map the updated fields from updateRequest to existingContact
			this.mapper.Map(updateRequest, existingContact);
			this.context.SaveChanges();
			return existingContact;
		}

		public List<Contact> GetAll()
		{
			List<Contact> contacts = this.context.Contacts.ToList();
			return contacts;
		}

		public Contact GetById(int id)
		{
			Contact? contact = this.context.Contacts.SingleOrDefault(c => c.ContactId == id);
			return contact;
		}
	}
}