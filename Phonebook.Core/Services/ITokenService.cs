using Phonebook.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Talabat.Core.Services
{
    public interface ITokenService
    {
        string CreateTokenAsync(string Username, string Role);
    }
}
