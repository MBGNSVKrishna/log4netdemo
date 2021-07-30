using log4netdemo.CustomFilter;
using log4netdemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace log4netdemo.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(HomeController));

        public IActionResult Privacy()
        {
            return View();
        }

        [CatchError]
        public IActionResult Exception(int? id)
        {
            try
            {
                if (id == null)
                    throw new Exception("Error Id cannot be null");
                else
                    return View((object)$"The value is {id}");
            }
            catch (Exception e)
            {
                _log4net.Error(e.Message);
                return View();
            }
         

        }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            // _log4net.Info("Hello logging world log4net!");
            _log4net.Warn("error occured");
            return View();

        }
   /*     public IActionResult Index1()
        {
            _log4net.Info("Hello It's me!");
            return View();
        }*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
