using System.Collections.Generic;
using System.Linq;
using Business.Dto.Doctors;
using Business.Dto.Schools;
using Business.Dto.Search;
using Business.Repository.Doctor;
using Business.Services.Query;

namespace Business.Repository.Search
{
    //public class SearchRespository : BaseRepository, ISearchRespository
    //{
    //    public SearchRepository(IDocumentQueryService documentQueryService) : base(documentQueryService)
    //    {
    //    }

    //    public List<DoctorDto> SearchDoctors(string searchText)
    //    {
    //        var where = string.Format("FirstName like '%{0}%' OR LastName like '%{0}%' OR Bio like '%{0}%'", searchText);

    //        return DocumentQueryService.GetDocuments<CMS.DocumentEngine.Types.MedioClinic.Doctor>()
    //            .Where(where)
    //            .ToList()
    //    }

    //    public IEnumerable<SchoolDto> SearchSchools(string searchText)
    //    {

    //    }
    //}
}