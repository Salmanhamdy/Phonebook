using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Phonebook.Core.Models;
using Phonebook.Core.Repositories;
using System.Diagnostics.Metrics;
using Talabat.Apis.Helpers;

namespace Phonebook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            this._contactRepository = contactRepository;
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Contact>>> GetAllContacts(int page=1, int pageSize=10) 
        {
            var Contacts= await _contactRepository.GetAllContactsAsync();
            if (Contacts.Count == 0)
                return Ok("No Contacts to display");
            return Contacts is null ? NotFound() : Ok(new Pagination<Contact>(pageSize, page, Contacts.Count, Contacts));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> AddContact(Contact contact) 
        {
            await _contactRepository.AddAsync(contact);
            var Result= await _contactRepository.SavaChangesAsync();
            return Result > 0 ?Ok("Contact added successfully"):BadRequest("Contact Not added ");
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<ActionResult> RemoveContact(int id) 
        {
            var Contact = await _contactRepository.GetContactAsync(id);
             if(Contact is null)
                return BadRequest("The contact you want to delete does not exist");
            _contactRepository.Remove(Contact);
            await _contactRepository.SavaChangesAsync();
            return Ok("Contact deleted successfully");
        }

        [HttpGet("Search")]
        public async Task<ActionResult<IReadOnlyList<Contact>>> GetContactSearch([FromQuery]string SearchValue) 
        {
            var Contacts= await _contactRepository.SearchofContacts(SearchValue);
             return Contacts is null ? NotFound() : Ok(Contacts);

        }
    }
}
