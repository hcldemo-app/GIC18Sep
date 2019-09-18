using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GICMicro.Models;
using Microsoft.Extensions.Logging;

namespace GICMicro.Controllers
{
    public class HomeController : Controller
    {
        ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {

                _logger.LogInformation($"List of Dashboard Data retreived on : {DateTime.UtcNow}");


            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Web part of Application has critical error : {DateTime.UtcNow}", ex);
                // _logger.LogCritical("Web part of Application has critical error  : {DateTime.UtcNow}, ex);
                //  _logger.LogError(ex, "ur code iz buggy.");
            }
            //  AddLo

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
