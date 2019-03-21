using Business.Dto.LandingPage;

namespace Business.Repository.LandingPage
{
    public interface ILandingPageRepository : IRepository
    {
        LandingPageDto GetLandingPage(string pageAlias);
    }
}