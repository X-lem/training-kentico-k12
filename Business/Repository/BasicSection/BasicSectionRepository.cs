using CMS.DocumentEngine.Types.MedioClinic;
using Business.Dto.BasicSection;
using Business.Services.Query;

namespace Business.Repository.BasicSection
{
    public class BasicSectionRepository : BaseRepository, IBasicSectionRepository
    {
        public BasicSectionRepository(IDocumentQueryService documentQueryService) : base(documentQueryService)
        {
        }

        public BasicSectionDto GetBasicSection()
        {
            return
        }
    }
}
