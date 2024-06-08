
using Setareh.DAL.ViewModels;

namespace Setareh.Bussines.Services.Interface
{
    public interface IUserService
    {

        Task<CreateUserResult> CreateUserAsync(CreateUserModel model);

    }
}
