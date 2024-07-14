using Microsoft.EntityFrameworkCore;
using PAsswordRepos;
using PAsswordRepos.Services;
using PAsswordRepos.Services.DbModels;

namespace PAsswordRepos.Services
{
    public class TypePasswordDb
    {
        private readonly PasswordsDirectoryContext _context;
        public TypePasswordDb()
        {
            _context = new PasswordsDirectoryContext();
        }
        public List<TypePassword> GetTypePasswords()
        {
            return _context.TypePasswords.ToList();


        }
    }
}
