using System.Web.Mvc;

using Kentico.PageBuilder.Web.Mvc;
using MedioClinic.Controllers.Sections;

[assembly: RegisterSection("MedioClinic.Section.ThreeColumn",
    typeof(ThreeColumnEqualSectionController), "{$Section.ThreeColumn.Name$}",
    Description = "{$Section.ThreeColumn.Description$}",
    IconClass = "icon-l-cols-3")]

namespace MedioClinic.Controllers.Sections
{
    public class ThreeColumnEqualSectionController : Controller
    {
        public ActionResult Index()
        {
            return PartialView("Sections/_ThreeColumnSection");
        }
    }
}