using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CloudA.Data;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CloudA.Data.Data;

namespace CloudAAdmin.Controllers
{
    public class EventController : Controller
    {
        private readonly CloudAContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private List<Images> photosEvent;
        private Images photoEvent;
        public EventController(CloudAContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
            photosEvent = new List<Images>();
            photoEvent = new Images();
        }

        // GET: Event
        public async Task<IActionResult> Index()
        {
           

            return View(await _context.Event.ToListAsync());
        }

        // GET: Event/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.ModelImages =
                  (
                      from img in _context.Image
                      where img.IdEvent == id
                      select img
                  ).ToList();

            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .FirstOrDefaultAsync(m => m.IdEvent == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Event/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEvent,TitlePL,TitleEng,TitleRos,DateFrom,DateTo,IsRegister,LogoUrl,Content,MaxNumOfPeople,ImageFile")] Event @event)
        {
            if (ModelState.IsValid)
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
                    photosEvent.Add(new Images { PathUrl =pathUrl });
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await item.CopyToAsync(fileStream);
                    }
                   
                }
               

                _context.Add(@event);
                await _context.SaveChangesAsync();
                var previousIdFromDataBase = _context.Event.OrderBy(x => x.IdEvent).LastOrDefault().IdEvent;
                foreach (var item in photosEvent)
                {
                    item.IdEvent = previousIdFromDataBase;
                    
                    
                }
                _context.Image.AddRange(photosEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(@event);
        }

        // GET: Event/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEvent,TitlePL,TitleEng,TitleRos,DateFrom,DateTo,IsRegister,LogoUrl,Content")] Event @event)
        {
            if (id != @event.IdEvent)
            {
                return NotFound();
            }

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
                return RedirectToAction("Index", "Home");
            }
            return View(@event);
        }

        // GET: Event/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            

            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .FirstOrDefaultAsync(m => m.IdEvent == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Event.FindAsync(id);
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "image", @event.LogoUrl);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            _context.Event.Remove(@event);
            await _context.SaveChangesAsync();

            var removeImages = _context.Image.All(x => x.IdEvent == id);
           
            return RedirectToAction("Index","Home");
        }

        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.IdEvent == id);
        }
    }
}
