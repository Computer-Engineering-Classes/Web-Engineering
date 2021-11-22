using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aula2.Controllers
{
    public class ExampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection formData)
        {
            // action used to process the form submission
            // transfer data to the view
            ViewData["text_inserted"] = formData["name"];
            ViewData["other_text_inserted"] = formData["age"];
            // uses another view instead of using the default view
            // usually the same name as the method - Index
            return View("Index2");
        }
    }
}
