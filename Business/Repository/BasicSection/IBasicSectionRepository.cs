using System;
using System.Collections.Generic;
using Business.Dto.BasicSection;

namespace Business.Repository.BasicSection
{
   public interface IBasicSectionRepository : IRepository
    {
        IEnumerable<BasicSectionDto> GetBasicSection(string pageAlias);
        BasicSectionDto GetBasicSection(Guid nodeGuid);
    }
}