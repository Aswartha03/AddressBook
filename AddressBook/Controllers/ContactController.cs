using AddressBook.Core.DTO;
using AddressBook.Core.Entities;
using AddressBook.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
	[ApiController]
	[Route("contact")]
	public class ContactController : ControllerBase
	{
		private readonly IContactService contactService;
		public ContactController(IContactService contactService)
		{
			this.contactService = contactService;
		}
		[HttpPost("add-contact")]
		public IActionResult CreateContact(UserContactRequest newContact)
		{
			Contact addedContact = contactService.AddContact(newContact);
			// Will get newly added Contact
			return Created("", new ApiResponse<Contact>
			{
				Message = "Contact Successfully Added",
				Data = addedContact
			});
		}

		[HttpGet("all-contacts")]
		public IActionResult AllContacts()
		{
			List<Contact> contacts = contactService.GetAllContacts();
			// Will Get all contacts or empty array
			if (contacts.Count == 0)
			{
				var response = Ok(new ApiResponse<Object>
				{
					Message = "No Contacts Are Found",
					Data = null
				});
				return NotFound(response);
			}
			return Ok(new ApiResponse<List<Contact>>
			{
				Message = "Contacts Fetched Successfully",
				Data = contacts
			});
		}

		[HttpGet("byid")]
		public IActionResult ContactById(int id)
		{
			Contact contact = contactService.GetContact(id);
			// null or contact
			if (contact == null)
			{
				var response = new ApiResponse<Object>
				{
					Message = "Contact Not Found",
					Data = null
				};
				return NotFound(response);
			}
			return Ok(new ApiResponse<Contact>
			{
				Message = "Contact Fetched Successfully",
				Data = contact
			});
		}


		[HttpPatch("edit-contact/{id}")]
		public IActionResult UpdateContactById(int id, ContactEditRequest updatedRequest)
		{
			Contact updatedContact = contactService.UpdateContact(id, updatedRequest);
			// Will get null or updatedContact
			if (updatedContact == null)
			{
				var response = new ApiResponse<Object>
				{
					Message = "Contact Not Found to Update",
					Data = null
				};
				return NotFound(response);
			}
			return Ok(new ApiResponse<Contact>
			{
				Message = "Contact Updated Successsfully",
				Data = updatedContact
			});
		}

		[HttpDelete("delete-contact/{id}")]
		public IActionResult DeleteContactById(int id)
		{
			string result = contactService.RemoveContact(id);
			// will get not found or deleted
			if (result == "Contact Not Found to Delete")
			{
				var response = new ApiResponse<Object>
				{
					Message = result,
					Data = null
				};
				return NotFound(response);
			}

			return Ok(new ApiResponse<Object>
			{
				Message = result,
				Data = null
			});
		}

	}
}