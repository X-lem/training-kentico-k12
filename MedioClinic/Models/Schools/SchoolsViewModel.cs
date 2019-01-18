using System.Collections.Generic;
using Business.Dto.Schools;

namespace MedioClinic.Models.Schools
{
    public class SchoolsViewModel : IViewModel
    {
        public SchoolSectionDto SchoolSection { get; set; }
        public IEnumerable<SchoolDto> Schools { get; set; }
    }
}