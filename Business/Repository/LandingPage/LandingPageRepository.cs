using Business.Repository;
using Business.Services.Query;

public class LandingPageRepository : BaseRepository, ILandingPageRepository
{
    public LandingPageRepository(IDocumentQueryService documentQueryService) : base(documentQueryService)
    {
    }

    public LandingPageDto GetLandingPage(string pageAlias)
    {
        return DocumentQueryService.GetDocument<CMS.DocumentEngine.Types.MedioClinic.LandingPage>(pageAlias)
            .AddColumns("DocumentID", "DocumentName")
            .ToList()
            .Select(landingPage => new LandingPageDto()
            {
                DocumentId = landingPage.DocumentID,
                Title = landingPage.DocumentName
            })
            .FirstOrDefault();
    }
}