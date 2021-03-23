using CloudA.Data;
using CloudA.Data.Data;
using CloudAAdmin.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly IWebHostEnvironment _hostEnvironment;
        private List<Images> photosEvent;
        private Images photoEvent;

        public HomeController(CloudAContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
            photosEvent = new List<Images>();
            photoEvent = new Images();

        }

        public IActionResult Index(string searchTerm, string NumOfPeople, bool isDateChange, DateTime dateFrom)
        {
           
            if (searchTerm == null && NumOfPeople == null && isDateChange == false)
            {
                ViewBag.ModelEvents =
                 (
                   from events in _context.Event
                   orderby events.DateFrom
                   select events
                 ).ToList();
                return View();
            }
            else
            {
                if (searchTerm != null)
                {
                    ViewBag.ModelEvents =
                  (
                    from events in _context.Event
                    where events.TitlePL.StartsWith(searchTerm)
                    orderby events.DateFrom
                    select events
                  ).ToList();
                    return View();
                }

                if (isDateChange)
                {
                    ViewBag.ModelEvents =
                  (
                    from events in _context.Event
                    where events.DateFrom == dateFrom
                    select events
                  ).ToList();
                    return View();
                }

                else
                {
                    ViewBag.ModelEvents =
                  (
                    from events in _context.Event
                    where events.MaxNumOfPeople == Convert.ToInt32(NumOfPeople)
                    orderby events.DateFrom
                    select events
                  ).ToList();
                    return View();
                }

            }


        }
        
        public IActionResult ShowEditItem(int id)
        {
            Event @event = _context.Event.FirstOrDefault(x => x.IdEvent == id);
            return PartialView(@event);
        }
      
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ShowEditItemm(int id, [Bind("IdEvent,TitlePL,TitleEng,TitleRos,DateFrom,DateTo,IsRegister,LogoUrl,Content,MaxNumOfPeople,ImageFile,NumOfRegistered")] Event @event)
        {
            //if (id != @event.IdEvent)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.IdEvent))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                //creating path to upload multiple images in database
                if (@event.ImageFile != null)
                {
                    var list = @event.ImageFile;
                    foreach (var item in list)
                    {
                        //_hostEnvironment.WebRootPath

                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string fileName = Path.GetFileNameWithoutExtension(item.FileName);
                        string extension = Path.GetExtension(item.FileName);
                        string pathUrl = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        @event.LogoUrl = pathUrl;
                        photoEvent.PathUrl = pathUrl;
                        photosEvent.Add(new Images { PathUrl = pathUrl });
                        string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await item.CopyToAsync(fileStream);
                        }

                    }

                    _context.Update(@event);

                    var previousIdFromDataBase = id;
                    foreach (var item in photosEvent)
                    {
                        item.IdEvent = previousIdFromDataBase;


                    }
                    _context.Image.AddRange(photosEvent);
                    await _context.SaveChangesAsync();
                }


                return RedirectToAction("Index", "Home");
            }
            return View(@event);
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
        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.IdEvent == id);
        }


    }
}
