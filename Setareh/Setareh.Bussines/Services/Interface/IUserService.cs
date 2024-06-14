using Setareh.DAL.Entities.Account;
using Setareh.DAL.Entities.User;
using Setareh.DAL.ViewModels;

namespace Setareh.Bussines.Services.Interface
{
    public interface IUserService
    {

        Task<CreateUserResult> CreateUserAsync(CreateUserModel model);

        Task<UserEditModel> GetForEditByIdAsync(int id);

        Task<EditUserResult> UpdateAsync(UserEditModel model);

        Task<UserFilterViewModel> FilterAsync(UserFilterViewModel model);

        Task<LoginResult> LoginAsync(LoginViewModel model);

        Task<User> GetByEmailAsync(string email);

        Task<UserDetailViewModel> GetUserInformationAsync(int userId);

    }
}
