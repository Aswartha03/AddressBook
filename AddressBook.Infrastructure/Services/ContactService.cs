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

		public ContactResponse CreateContact(CreateContactRequest request)
		{
			// Auto Mapping from ContactRequest to Contact Entity
			Contact contact = this.mapper.Map<Contact>(request);
			contact.CreatedAt = DateTime.Now;
			Contact createdContact = this.contactRepository.Add(contact);
			// Auto Mapping from Contact Entity to ContactResponse
			ContactResponse contactResponse = this.mapper.Map<ContactResponse>(createdContact);
			return contactResponse;
		}

		public List<ContactResponse> GetAllContacts()
		{
			List<Contact> contacts = this.contactRepository.GetAll();
			// mappping from Contact Entity to ContactResponse for each contact in contacts list 
			List<ContactResponse> contactResponses = contacts.Select(contact => this.mapper.Map<ContactResponse>(contact)).ToList();
			return contactResponses; 
		}

		public ContactResponse GetContactById(int id) 
		{
			Contact contact = this.contactRepository.GetById(id); 
			if (contact == null)
			{
				return null;
			}
			// Auto Mapping from Contact Entity to ContactResponse
			ContactResponse contactResponse = this.mapper.Map<ContactResponse>(contact);
			return contactResponse;
		}

		public bool DeleteContactById(int id)
		{
			Contact contact = this.contactRepository.GetById(id);
			if (contact == null) 
			{
				return false;
			}
			this.contactRepository.Delete(contact);
			return true;
		}

		public ContactResponse UpdateContactById(int id, UpdateContactRequest request)
		{
			Contact contact = this.contactRepository.GetById(id);
			if (contact == null)
			{
				return null; 
			}
			Contact updatedContact = this.contactRepository.Update(request, contact);
			// Auto Mapping from Contact Entity to ContactResponse
			ContactResponse contactResponse = this.mapper.Map<ContactResponse>(updatedContact);
			return contactResponse;
		}

	}
}