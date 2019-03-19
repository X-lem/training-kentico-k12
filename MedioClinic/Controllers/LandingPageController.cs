using Business.DependencyInjection;
using MedioClinic.Controllers;
using System;
using System.Web.Mvc;

public class LandingPageController : BaseController
{
    protected ILandingPageRepository LandingPageRepository { get; }

    public LandingPageController(
        IBusinessDependencies dependencies, ILandingPageRepository landingPageRepository) : base(dependencies)
    {
        LandingPageRepository = landingPageRepository ?? throw new ArgumentNullException(nameof(landingPageRepository));
    }

    // GET: LandingPage/[nodeAlias]
    public ActionResult Index(string nodeAlias)
    {
        var landingPageDto = LandingPageRepository.GetLandingPage(nodeAlias);

        if (landingPageDto == null)
        {
            return HttpNotFound();
        }

        var model = GetPageViewModel(landingPageDto.Title);
        HttpContext.Kentico().PageBuilder().Initialize(landingPageDto.DocumentId);

        return View(model);
    }
}