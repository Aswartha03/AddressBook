using AddressBook.Core.DTO;
using AddressBook.Core.Entities;
using AutoMapper;

namespace AddressBook.Core.Mappings
{
	public class ContactProfile : Profile
	{
		public ContactProfile()
		{
			// Mapping From UserRequest to User Entity
			CreateMap<CreateContactRequest, Contact>();
			// Mapping From User Entity to UserResponse
			CreateMap<Contact, ContactResponse>();
			// For Update, only map the properties which are not null in the request
			CreateMap<UpdateContactRequest, Contact>()
				.ForAllMembers(options => options.Condition((source, destincation, srcProperty) => srcProperty != null));
		}   
	}
}