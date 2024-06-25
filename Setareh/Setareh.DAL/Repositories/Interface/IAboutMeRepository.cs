using Setareh.DAL.Entities.AboutMe;
using Setareh.DAL.ViewModels.AboutMe;


namespace Setareh.DAL.Repositories.Interface
{
    public interface IAboutMeRepository
    {
        Task<AboutMeEditModel?> GetInfoAsync();

        void Update(AboutMe aboutMe);

        Task SaveAsync();

        Task<AboutMe?> GetAsync();

        Task<AboutMeViewModel?> GetClientSideInfoAsync();
    }
}
