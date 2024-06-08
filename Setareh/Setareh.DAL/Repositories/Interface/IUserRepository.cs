

using Setareh.DAL.Entities.User;

namespace Setareh.DAL.Repositories.Interface
{
    public interface IUserRepository
    {
        Task InsertAsync(User user);

        Task SaveAsync();
    }
}
