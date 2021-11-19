using Aula6.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Aula6.Controllers
{
    public class StudentsController : Controller
    {
        private readonly Aula6Context context;

        public StudentsController(Aula6Context context)
        {
            this.context = context;
        }
        // GET: Students
        public async Task<IActionResult> Index()
        {
            var context = this.context.Students.Include(c => c.Course);
            return View(await context.ToListAsync());
        }

        // GET: Students by letter
        public async Task<IActionResult> Index2(string letter)
        {
            ViewBag.letter = letter;

            if(string.IsNullOrEmpty(letter) == false)
            {
                return View(await context.Students.Where(x => x.Name.StartsWith(letter)).Include(c => c.Course).ToListAsync());
            }
            else
            {
                return View(await context.Students.Include(c => c.Course).ToListAsync());
            }
        }
    }
}
