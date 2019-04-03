using System.Web.Mvc;

using MedioClinic.Controllers.Widgets;
using MedioClinic.Models.Widgets;

using Kentico.PageBuilder.Web.Mvc;

[assembly: RegisterWidget(
    "MedioClinic.CustomTable.Text",
    typeof(CustomTableWidgetController),
    "{$Widget.CustomTable.Name$}",
    Description = "{$Widget.CustomTable.Description$}",
    IconClass = "icon-table")]

namespace MedioClinic.Controllers.Widgets
{
    public class CustomTableWidgetController : WidgetController<CustomTableWidgetProperties>
    {
        public ActionResult Index()
        {
            var properties = GetProperties();

            return PartialView("Widgets/_CustomTableWidget", new CustomTableWidgetViewModel {  });
        }
    }
}