using Business.Dto.Schools;

namespace Business.Repository.School
{
    public interface ISchoolSectionRepository : IRepository
    {
        SchoolSectionDto GetSchoolSection();
    }
}