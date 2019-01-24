using Kentico.PageBuilder.Web.Mvc;
using System.Web.Mvc;
using Kentico.Web.Mvc;
using Business.Repository.BasicSection;
using MedioClinic.Controllers;
using Business.DependencyInjection;


//[assembly: RegisterSection("LearningKit.Sections.BasicSection", typeof(BasicSectionController), "Basic Section",
//  Description = "A section with two widget zones displayed at 70/30. A main and callout widget zone")]
namespace MedioClinic.Controllers
{
    public class BasicSectionController : BaseController
    {
        private IBasicSectionRepository BasicSectionRepository { get; }

        public BasicSectionController(
            IBusinessDependencies dependencies,
            IBasicSectionRepository basicSectionRepository
            ) : base(dependencies)
        {
            BasicSectionRepository = BasicSectionRepository;
        }

        // GET: BasicSection
        public ActionResult Index(string pageAlias)
        {
            var basicSection = BasicSectionRepository.GetBasicSection(pageAlias);
            if (basicSection == null)
            {
                return HttpNotFound();
            }

            HttpContext.Kentico().PageBuilder().Initialize(basicSection.DocumentID);

            return View();
        }
    }
}