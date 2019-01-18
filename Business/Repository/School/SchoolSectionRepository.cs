using System;
using System.Linq;
using CMS.DocumentEngine.Types.MedioClinic;
using Business.Dto.Schools;
using Business.Services.Query;

namespace Business.Repository.School
{
    public class SchoolSectionRepository : BaseRepository, ISchoolSectionRepository
    {

        public SchoolSectionRepository(IDocumentQueryService documentQueryService) : base(documentQueryService)
        {
        }

        public SchoolSectionDto GetSchoolSection()
        {
            return DocumentQueryService.GetDocuments<SchoolSection>()
                .AddColumns("Title")
                .TopN(1)
                .ToList()
                .Select(m => new SchoolSectionDto()
                {
                    Header = m.Title
                })
                .FirstOrDefault();
        }
    }
}