using System;
using System.Web.Mvc;
using System.Web.UI;
using Business.DependencyInjection;
using Business.Dto.Schools;
using Business.Repository.School;
using Business.Services.Cache;
using CMS.DocumentEngine.Types.MedioClinic;
using MedioClinic.Models.Schools;

namespace MedioClinic.Controllers
{
    public class SchoolsController : BaseController
    {
        private ISchoolRepository SchoolRepository { get; }
        private ISchoolSectionRepository SchoolSectionRepository { get; }

        public SchoolsController(
            IBusinessDependencies dependencies,
            ISchoolRepository schoolRepository,
            ISchoolSectionRepository schoolSectionRepository
            ) : base(dependencies)
        {
            SchoolRepository = schoolRepository;
            SchoolSectionRepository = schoolSectionRepository;
        }

        // GET: Schools
        public ActionResult Index()
        {
            var schoolSection = Dependencies.CacheService.Cache(
                () => SchoolSectionRepository.GetSchoolSection(), // Gets data for the SchoolSection if there isn't any cached data (data was invalidated or cache expired)
                60, // Sets caching of data to 60 minutes
                $"{nameof(SchoolsController)}|{nameof(Index)}|{nameof(SchoolSectionDto)}", // cached data identifier
                Dependencies.CacheService.GetNodesCacheDependencyKey(School.CLASS_NAME, CacheDependencyType.All) // cache dependencies
                );

            if (schoolSection == null)
            {
                return HttpNotFound();
            }

            var model = GetPageViewModel(new SchoolsViewModel()
            {
                Schools = SchoolRepository.GetSchools(),
                SchoolSection = schoolSection
            }, schoolSection.Header);

            return View(model);
        }

        [OutputCache(Duration = 3600, VaryByParam = "nodeGuid", Location = OutputCacheLocation.Server)]
        public ActionResult Detail(Guid nodeGuid, string nodeAlias)
        {
            var school = SchoolRepository.GetSchool(nodeGuid);

            if (school == null)
            {
                return HttpNotFound();
            }

            // Sets cache dependency on single page based on NodeGUID
            // System clears the cache when given school is deleted or edited in Kentico
            Dependencies.CacheService.SetOutputCacheDependency(nodeGuid);

            var model = GetPageViewModel(new SchoolDetailViewModel()
            {
                School = school
            }, school.SchoolName);

            return View(model);
        }
    }
}