using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

using Kentico.Web.Mvc;
using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;


namespace MedioClinic
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Gets the ApplicationBuilder instance
            // Allows you to enable and configure Kentico MVC features
            ApplicationBuilder builder = ApplicationBuilder.Current;

            // Enables the preview feature
            builder.UsePreview();

            // Enables the page builder feature
            builder.UsePageBuilder();


            // Enables and configures selected Kentico ASP.NET MVC integration features
            ApplicationConfig.RegisterFeatures(ApplicationBuilder.Current);

            // Registers routes including system routes for enabled features
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Dependency injection
            AutofacConfig.ConfigureContainer();

            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error()
        {
            // Sets 404 HTTP exceptions to be handled via IIS (behavior is specified in the "httpErrors" section in the MedioClinic.config file)
            var error = Server.GetLastError();
            if ((error as HttpException)?.GetHttpCode() == 404)
            {
                Server.ClearError();
                Response.StatusCode = 404;
            }
        }
    }
}
