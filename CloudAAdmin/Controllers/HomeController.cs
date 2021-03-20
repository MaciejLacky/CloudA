using CloudA.Data;
using CloudA.Data.Data;
using CloudAAdmin.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Topshelf.Runtime;

namespace CloudAAdmin.Controllers
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
