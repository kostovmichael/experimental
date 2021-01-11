using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MvcAndWebApiDotNetThree.Areas.AngularSample.Controllers
{
    [Area("AngularSample")]
    public class LandingController : Controller
    {
        private readonly ILogger<LandingController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _hostEnvironment;
        public LandingController(
           ILogger<LandingController> logger,
           IConfiguration configuration,
           IWebHostEnvironment hostEnvironment)
        {
            this._logger = logger;
            this._configuration = configuration;
            this._hostEnvironment = hostEnvironment;
        }

        public IActionResult Main()
        {
            return View();
        }




    }
}
