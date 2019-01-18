using System;
using System.Collections.Generic;
using Business.Dto.Schools;

namespace Business.Repository.School
{
    public interface ISchoolRepository : IRepository
    {
        IEnumerable<SchoolDto> GetSChools();
        SchoolDto GetSchool(Guid nodeGuid);
    }
}