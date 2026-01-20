using AddressBook.Core.Common;
using AddressBook.Core.DTO;
using AddressBook.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.WebApi.Controllers
{
	[ApiController]
	[Route("api/contacts")] 
	public class ContactController : ControllerBase
	{
		private readonly IContactService contactService;
		public ContactController(IContactService contactService)
		{
			this.contactService = contactService;
		} 

		[HttpPost("add")] 
		public IActionResult CreateContact(CreateContactRequest request)
		{
			ContactResponse createdContact = this.contactService.CreateContact(request);
			return Created("",new ApiResponse<ContactResponse>
			{
				Message = "Contact Created Successfully",
				Data = createdContact
			});
		}

		[HttpGet("all")]
		public IActionResult GetContacts()
		{
			List<ContactResponse> contactsResponse = this.contactService.GetAllContacts();
			if (contactsResponse.Count == 0) 
			{
				var response = Ok(new ApiResponse<string>
				{
					Message = "No Contacts Are Found",
					Data = null
				});
				return NotFound(response);
			}
			return Ok(new ApiResponse<List<ContactResponse>>
			{
				Message = "Contacts Fetched Successfully",
				Data = contactsResponse
			}); 
		}

		[HttpGet]
		// Will Get id by Query Parameter 
		public IActionResult GetContact(int id) 
		{
			ContactResponse contact = this.contactService.GetContactById(id);
			if (contact == null) 
			{
				var response = new ApiResponse<string>
				{
					Message = "Contact Not Found",
					Data = null  
				};
				return NotFound(response);
			}
			return Ok(new ApiResponse<ContactResponse>
			{
				Message = "Contact Fetched Successfully",
				Data = contact
			});
		}


		[HttpPatch("edit/{id}")] 
		public IActionResult UpdateContact(int id, UpdateContactRequest updatedRequest)
		{
			ContactResponse updatedContact = this.contactService.UpdateContactById(id, updatedRequest);
			if (updatedContact == null)
			{
				var response = new ApiResponse<string>
				{
					Message = "Contact Not Found to Update",
					Data = null
				};
				return NotFound(response);
			}
			return Ok(new ApiResponse<ContactResponse>
			{
				Message = "Contact Updated Successsfully",
				Data = updatedContact
			});
		}

		[HttpDelete("delete/{id}")] 
		public IActionResult DeleteContact(int id)
		{
			bool deleted = this.contactService.DeleteContactById(id);
			if (!deleted)
			{
				var response = new ApiResponse<string>
				{
					Message = "Contact Not Found To Delete",
					Data = null
				}; 
				return NotFound(response); 
			}
			return Ok(new ApiResponse<string>
			{
				Message = "Contact Successfully Deleted",
				Data = null
			});
		}
	}
}