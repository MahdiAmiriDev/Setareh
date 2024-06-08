

using Setareh.DAL.Entities.User;
using Setareh.DAL.Repositories.Interface;
using Setareh.DAL.Context;

namespace Setareh.DAL.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly SetarehContext _context;

        public UserRepository(SetarehContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(User user)
        {
            await _context.User.AddAsync(user);            
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
