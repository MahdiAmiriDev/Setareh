

using Setareh.DAL.Entities.User;
using Setareh.DAL.Repositories.Interface;
using Setareh.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Setareh.DAL.ViewModels;

namespace Setareh.DAL.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly SetarehContext _context;

        public UserRepository(SetarehContext context)
        {
            _context = context;
        }

        public async Task<bool> DuplicatedEmail(int id, string email)
        {
            return await _context.User.AnyAsync(user => user.Email == email && user.Id != id);
        }

        public async Task<bool> DuplicatedMobile(int id, string mobile)
        {
            return await _context.User.AnyAsync(user => user.Mobile == mobile && user.Id != id);
        }

        public async Task<UserFilterViewModel> FilterAsync(UserFilterViewModel model)
        {
            var query = _context.User.AsQueryable();

            if (!string.IsNullOrEmpty(model.Email))
                query = query.Where(user => user.Email == model.Email);

            if (!string.IsNullOrEmpty(model.Mobile))
                query = query.Where(user => user.Mobile == model.Mobile);

            await model.Paging(query.Select(user => new UserDetailViewModel()
            {
                Mobile = user.Mobile,
                CreateDate = user.CreateDate,
                FirstName = user.FirstName,
                Id = user.Id,
                Email = user.Email,
                IsActive = user.IsActive,
                LastName = user.LastName
            }));

            return model;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.User.FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task InsertAsync(User user)
        {
            await _context.User.AddAsync(user);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(User user)
        {
            _context.User.Update(user);
        }
    }
}
