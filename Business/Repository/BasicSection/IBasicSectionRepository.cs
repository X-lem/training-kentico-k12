using System;
using System.Collections.Generic;
using Business.Dto.BasicSection;
using CMS.DocumentEngine.Types.MedioClinic;

namespace Business.Repository.BasicSection
{
    public interface IBasicSectionRepository : IRepository
    {
        BasicSectionDto GetBasicSection(Guid nodeGuid);
        //CMS.DocumentEngine.Types.MedioClinic.BasicSection GetBasicSection(string pageAlias);
    }
}