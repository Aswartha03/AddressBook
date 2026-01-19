
using AddressBook.Core.DTO;
using AddressBook.Core.Entities;
using AddressBook.Core.Interfaces;
using AutoMapper;

namespace AddressBook.Infrastructure.Services
{
	public class ContactService : IContactService
	{
		private readonly IContactRepository contactRepository;
		private readonly IMapper mapper;
		public ContactService(IContactRepository contactRepo, IMapper mapper)
		{
			this.contactRepository = contactRepo;
			this.mapper = mapper;
		}

		public Contact AddContact(UserContactRequest request)
		{
			// Auto Mapping
			Contact newContact = mapper.Map<Contact>(request);
			newContact.CreatedAt = DateTime.Now;
			// Adding Contact
			Contact AddedContact = contactRepository.AddNewContact(newContact);
			return AddedContact;
		}

		public List<Contact> GetAllContacts()
		{
			List<Contact> contacts = contactRepository.GetAllContacts();
			return contacts;
		}

		public Contact GetContact(int id)
		{
			Contact contact = contactRepository.GetContactById(id);
			if (contact == null)
			{
				return null;
			}
			return contact;
		}

		public string RemoveContact(int id)
		{
			Contact contact = contactRepository.GetContactById(id);
			if (contact == null)
			{
				return "Contact Not Found to Delete";
			}
			string result = contactRepository.DeleteContact(contact);
			return result;
		}

		public Contact UpdateContact(int id, UserContactRequest newContact)
		{
			Contact contact = contactRepository.GetContactById(id);
			if (contact == null)
			{
				return null;
			}
			Contact updatedContact = contactRepository.EditContactById(newContact, contact);
			return updatedContact;
		}

	}
}