using Phonebook.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Core.Repositories
{
    public interface IContactRepository
    {
        Task<IReadOnlyList<Contact>> SearchofContacts(string SearchValue); 
        Task<Contact?> GetContactAsync(int id);
        Task<IReadOnlyList<Contact>> GetAllContactsAsync();
        Task AddAsync(Contact contact);
        void Remove(Contact contact);
        Task<int> SavaChangesAsync();
    }
}
