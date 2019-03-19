using Kentico.PageBuilder.Web.Mvc;
using System.Web.Mvc;
using Kentico.Web.Mvc;
using Business.Repository.BasicSection;
using MedioClinic.Controllers;
using Business.DependencyInjection;
using System;
using MedioClinic.Models.BasicSection;


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
            BasicSectionRepository = basicSectionRepository;
        }

        // GET: BasicSection
        public ActionResult Detail(Guid nodeGuid, string nodeAlias)
        {
            var basicSection = BasicSectionRepository.GetBasicSection(nodeGuid);
            if (basicSection == null)
            {
                return HttpNotFound();
            }

            var model = GetPageViewModel(new BasicSectionViewModel()
            {
                BasicSection = basicSection
            }, basicSection.BasicSectionName);

            //HttpContext.Kentico().PageBuilder().Initialize(basicSection.DocumentID);

            return View(model);
        }
    }
}