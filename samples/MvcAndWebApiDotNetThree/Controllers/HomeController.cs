using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using MvcAndWebApiDotNetThree.Models;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace MvcAndWebApiDotNetThree.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _hostEnvironment;

      public HomeController(ILogger<HomeController> logger,
         IConfiguration configuration,
         IWebHostEnvironment hostEnvironment)
        {
            this._logger = logger;
            this._configuration = configuration;
            this._hostEnvironment = hostEnvironment;
      }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
