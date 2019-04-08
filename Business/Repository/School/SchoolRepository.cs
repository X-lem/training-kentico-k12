using System;
using System.Collections.Generic;
using System.Linq;
using Business.Dto.Schools;
using Business.Services.Context;
using Business.Services.Query;

namespace Business.Repository.School
{
    public class SchoolRepository : BaseRepository, ISchoolRepository
    {
        private readonly string[] _schoolColumns =
        {
            // Defines database columns for retrieving data
            // NodeGuid is retrieved automatically
            "NodeID", "NodeAlias", "SchoolName", "Street", "City", "State", "Country",
            "ZipCode", "PhoneNumber", "Bio", "Photo"
        };

        private Func<CMS.DocumentEngine.Types.MedioClinic.School, SchoolDto> SchoolDtoSelect => school => new SchoolDto()
        {
            NodeAlias = school.NodeAlias,
            NodeGuid = school.NodeGUID,
            NodeId = school.NodeID,
            SchoolName = school.SchoolName,
            Street = school.Street,
            City = school.City,
            State = school.State,
            Country = school.Country,
            ZipCode = school.ZipCode,
            PhoneNumber = school.PhoneNumber,
            Bio = school.Bio,
            Photo = school.Fields.Photo
        };

        ISiteContextService SiteContextService { get; }

        public SchoolRepository(IDocumentQueryService documentQueryService, ISiteContextService siteContextService) : base(documentQueryService)
        {
            SiteContextService = siteContextService;
        }

        public IEnumerable<SchoolDto> GetSchools()
        {
            return DocumentQueryService.GetDocuments<CMS.DocumentEngine.Types.MedioClinic.School>()
                .AddColumns(_schoolColumns)
                .ToList()
                .Select(SchoolDtoSelect);
        }

        public SchoolDto GetSchool(Guid nodeGuid)
        {
            return DocumentQueryService.GetDocument<CMS.DocumentEngine.Types.MedioClinic.School>(nodeGuid)
                .AddColumns(_schoolColumns)
                .Select(SchoolDtoSelect)
                .FirstOrDefault();
        }
    }
}
