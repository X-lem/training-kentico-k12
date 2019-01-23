using Kentico.PageBuilder.Web.Mvc;
using System.Web.Mvc;
using Kentico.Web.Mvc;
using Business.Repository.BasicSection;


//[assembly: RegisterSection("LearningKit.Sections.BasicSection", typeof(BasicSectionController), "Basic Section",
//  Description = "A section with two widget zones displayed at 70/30. A main and callout widget zone")]
public class BasicSectionController : Controller
{
    private readonly IBasicSectionRepository mRepository;

    public BasicSectionController(IBasicSectionRepository repository)
    {
        mRepository = repository;
    }

    // GET: BasicSection
    public ActionResult Index(string pageAlias)
    {
        var basicSection = mRepository.GetBasicSection(pageAlias);
        if (basicSection == null)
        {
            return HttpNotFound();
        }
        HttpContext.Kentico().PageBuilder().Initialize(basicSection.DocumentID);

        return View();
    }
}