using CloudA.Data;
using CloudAFront.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CloudAFront.Controllers
{
    public class HomeController : Controller
    {
        private readonly CloudAContext _context;
        public HomeController(CloudAContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            ViewBag.ModelEvents =
                   (
                       from events in _context.Event
                       orderby events.DateFrom
                       select events
                   ).ToList();


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
