using System.Linq;
using System.Web.Mvc;

using CMS.DocumentEngine;
using Kentico.PageBuilder.Web.Mvc;
using MedioClinic.Controllers.Widgets;
using MedioClinic.Models.Widgets;

[assembly: RegisterWidget(
    "MedioClinic.Widget.Image",
    typeof(ImageWidgetController),
    "Image",
    Description = "Image widget",
    IconClass = "icon-picture")]

namespace MedioClinic.Controllers.Widgets
{
    public class ImageWidgetController : WidgetController<ImageWidgetProperties>
    {
        public ActionResult Index()
        {
            var properties = GetProperties();
            var image = GetImage(properties);

            return PartialView("Widgets/_ImageWidget", new ImageWidgetViewModel
            {
                Image = image
            });
        }

        protected DocumentAttachment GetImage(ImageWidgetProperties properties)
        {
            var page = GetPage();

            return page?.AllAttachments.FirstOrDefault(x => x.AttachmentGUID == properties.ImageGuid);
        }
    }
}