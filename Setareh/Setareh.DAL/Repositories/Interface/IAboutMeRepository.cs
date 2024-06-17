using Setareh.DAL.Entities.AboutMe;
using Setareh.DAL.ViewModels;


namespace Setareh.DAL.Repositories.Interface
{
    public interface IAboutMeRepository
    {
        Task<AboutMeEditModel?> GetInfoAsync();

        void Update(AboutMe aboutMe);

        Task SaveAsync();

        Task<AboutMe?> GetAsync();
    }
}
