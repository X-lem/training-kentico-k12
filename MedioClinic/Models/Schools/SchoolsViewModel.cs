using System.Collections.Generic;
using Business.Dto.Schools;

namespace MedioClinic.Models.Doctors
{
    public class SchoolsViewModel : IViewModel
    {
        public SchoolSectionDto DoctorSection { get; set; }
        public IEnumerable<SchoolDto> Doctors { get; set; }
    }
}