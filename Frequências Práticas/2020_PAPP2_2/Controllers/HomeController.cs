using _2020_PAPP2_2.Data;
using _2020_PAPP2_2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _2020_PAPP2_2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var dishes = await _context.Dishes
                .OrderBy(x => x.Price)
                .ToListAsync();
            return View(dishes);
        }

        public IActionResult AddDish()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDish(Dish dish)
        {
            if (ModelState.IsValid)
            {
                dish.User = User.Identity.Name;
                _context.Add(dish);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dish);
        }

        public async Task<IActionResult> MyDishes()
        {
            var dishes = await _context.Dishes
                .Where(x => x.User == User.Identity.Name)
                .ToListAsync();
            return PartialView(nameof(MyDishes), dishes);
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
