using Microsoft.EntityFrameworkCore;
using Phonebook.Core.Models;
using Phonebook.Core.Repositories;
using Phonebook.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ContactRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task AddAsync(Contact contact)
        =>  await _applicationDbContext.Set<Contact>().AddAsync(contact);
        

        public async Task<IReadOnlyList<Contact>> GetAllContactsAsync()
        =>  await _applicationDbContext.Set<Contact>().ToListAsync();

        public async Task<Contact?> GetContactAsync(int id)
         =>  await _applicationDbContext.Contacts.FindAsync(id);

        public void Remove(Contact contact)
        => _applicationDbContext.Set<Contact>().Remove(contact);

        public async Task<int> SavaChangesAsync()
        =>  await _applicationDbContext.SaveChangesAsync();

        public async Task<IReadOnlyList<Contact>> SearchofContacts(string SearchValue)
       => await _applicationDbContext.Contacts
                              .Where(c => c.Name.Contains(SearchValue) || c.PhoneNumber.Contains(SearchValue) || c.Email.Contains(SearchValue))
                              .ToListAsync();

               
    }
}
