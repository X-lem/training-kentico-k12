using Business.Dto.BasicSection;
using Business.Services.Query;
using Business.Services.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using CMS.DocumentEngine.Types.MedioClinic;
using CMS.SiteProvider;
using CMS.DocumentEngine;

namespace Business.Repository.BasicSection
{
    public class BasicSectionRepository : BaseRepository, IBasicSectionRepository
    {
        private readonly string[] _basicSectionColumns =
        {
            // Defines database columns for retrieving data
            // NodeGuid is retrieved automatically
            "NodeID", "NodeAlias", "BasicSectionName"
        };

        private Func<CMS.DocumentEngine.Types.MedioClinic.BasicSection, BasicSectionDto> BasicSectionDtoSelect => basicSection => new BasicSectionDto()
        {
            NodeAlias = basicSection.NodeAlias,
            NodeGuid = basicSection.NodeGUID,
            NodeId = basicSection.NodeID,
            BasicSectionName = basicSection.BasicSectionName
        };

        ISiteContextService SiteContextService { get; }

        public BasicSectionRepository(IDocumentQueryService documentQueryService, ISiteContextService siteContextService) : base(documentQueryService)
        {
            SiteContextService = siteContextService;
        }

        public BasicSectionDto GetBasicSection(Guid nodeGuid)
        {
            return DocumentQueryService.GetDocument<CMS.DocumentEngine.Types.MedioClinic.BasicSection>(nodeGuid)
                .AddColumns(_basicSectionColumns)
                .Select(BasicSectionDtoSelect)
                .FirstOrDefault();
        }

        public CMS.DocumentEngine.Types.MedioClinic.BasicSection GetBasicSection(string pageAlias)
        {
            return BasicSectionProvider.GetBasicSections()
                               .LatestVersion(true)
                               .Published(true)
                               .OnSite(SiteContext.CurrentSiteName)
                               .Culture(DocumentContext.CurrentDocumentCulture.CultureCode)
                               .CombineWithDefaultCulture()
                               .WhereEquals("NodeAlias", pageAlias)
                               .TopN(1);
        }
    }
}
