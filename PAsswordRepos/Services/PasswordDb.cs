using PAsswordRepos.Services;
using PAsswordRepos.Services.DbModels;

namespace ProjectPAsswordReposTest.Services
{
    public class PasswordDb
    {
        private readonly PasswordsDirectoryContext _context;
        public PasswordDb()
        {
            _context = new PasswordsDirectoryContext();
        }

        public List<Password> GetPasswords(PasswordSearchParams search)
        {
            var entities = _context.Passwords.ToList();
            if (search.Name != null)
            {
                entities = entities.Where(i => i.Name == search.Name).ToList();
            }
            return entities.OrderByDescending(i => i.Date).ToList();
        }

        public void AddPassword(Password entity)
        {
            if (entity != null)
            {

                _context.Passwords.Add(entity);
                _context.SaveChanges();
            }
        }
    }
}
