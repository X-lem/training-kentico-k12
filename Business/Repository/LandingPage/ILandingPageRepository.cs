using Business.Repository;

public interface ILandingPageRepository : IRepository
{
    LandingPageDto GetLandingPage(string pageAlias);
}