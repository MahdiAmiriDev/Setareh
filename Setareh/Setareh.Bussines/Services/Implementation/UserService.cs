
using Setareh.Bussines.Services.Interface;
using Setareh.DAL.Entities.User;
using Setareh.DAL.Repositories.Interface;
using Setareh.DAL.ViewModels;

namespace Setareh.Bussines.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CreateUserResult> CreateUserAsync(CreateUserModel model)
        {
            User user = new()
            {
                CreateDate = DateTime.Now,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Mobile = model.Mobile,
                Password = model.Password,
                IsActive = model.IsActive
            };

            await _userRepository.InsertAsync(user);
            await _userRepository.SaveAsync();

            return CreateUserResult.Success;
        }
    }
}
