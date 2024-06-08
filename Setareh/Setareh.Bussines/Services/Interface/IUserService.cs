
using Setareh.DAL.ViewModels;

namespace Setareh.Bussines.Services.Interface
{
    public interface IUserService
    {

        Task<CreateUserResult> CreateUserAsync(CreateUserModel model);

        Task<UserEditModel> GetForEditByIdAsync(int id);

        Task<EditUserResult> UpdateAsync(UserEditModel model);

    }
}
