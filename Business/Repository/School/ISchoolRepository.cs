using System;
using System.Collections.Generic;
using Business.Dto.Schools;

namespace Business.Repository.School
{
    public interface ISchoolRepository : IRepository
    {
        IEnumerable<SchoolDto> GetSchools();
        SchoolDto GetSchool(Guid nodeGuid);
    }
}