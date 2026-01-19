using AddressBook.Core.DTO;
using AddressBook.Core.Entities;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AddressBook.Mappings
{
	public class ContactMappingProfile : Profile
	{
		public ContactMappingProfile()
		{
			CreateMap<UserContactRequest, Contact>();
		}
	}
}