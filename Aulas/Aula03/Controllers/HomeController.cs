using Aula3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Aula3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHostEnvironment _he; // necessary to get the app folder

        public HomeController(ILogger<HomeController> logger, IHostEnvironment e)
        {
            _logger = logger;
            _he = e; // injects in the constructor info about the host environment
        }

        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Upload(IFormFile Name)
        {
            // other file properties could be checked here but we assume everything is OK
            if (ModelState.IsValid)
            {
                string destination = Path.Combine(
                    _he.ContentRootPath, "wwwroot/Documents/",
                    Path.GetFileName(Name.FileName));

                // creates a filestream to store the file bytes
                FileStream fs = new(destination, FileMode.Create);
                Name.CopyTo(fs);
                fs.Close();

                //after saving the file, redirects to file listing
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Download(string id)
        {
            // id is the filename
            string pathFile = Path.Combine(
                _he.ContentRootPath, "wwwroot/Documents/", id);
            byte[] fileBytes = System.IO.File.ReadAllBytes(pathFile);
            //this code assumes that content type is always obatined
            // Otherwise, the result should be verified (boolean value)
            new FileExtensionContentTypeProvider().TryGetContentType(id, out string mimeType);

            return File(fileBytes, mimeType);
        }

        public IActionResult Delete(string id)
        {
            string pathFile = Path.Combine(
                _he.ContentRootPath, "wwwroot/Documents/", id);
            System.IO.File.Delete(pathFile);
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            // get the info for the files in the Documents folder
            // using the class DocFiles
            DocFiles files = new();
            return View(files.GetFiles(_he).OrderByDescending(e => e.Size));
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
