

using Setareh.DAL.Entities.User;

namespace Setareh.DAL.Repositories.Interface
{
    public interface IUserRepository
    {
        Task InsertAsync(User user);

        Task SaveAsync();

        Task<User> GetByIdAsync(int id);

        Task<bool> DuplicatedEmail(int id , string email);
        Task<bool> DuplicatedMobile(int id , string mobile);

        void Update(User user);
    }
}
