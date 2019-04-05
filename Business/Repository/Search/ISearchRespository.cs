using Business.Dto.Doctors;
using Business.Dto.Search;
using System.Collections.Generic;

namespace Business.Repository.Search
{
    public interface ISearchRespository : IRepository
    {
        List<DoctorDto> SearchDoctors(string searchText);
        List<DoctorDto> SearchSchools(string searchText);
    }
}
