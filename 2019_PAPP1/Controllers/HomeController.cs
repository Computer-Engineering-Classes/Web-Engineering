using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _2019_PAPP1.Data;
using _2019_PAPP1.Models;

namespace _2019_PAPP1.Controllers
{
    public class HomeController : Controller
    {
        private readonly _2019_PAPP1Context _context;

        public HomeController(_2019_PAPP1Context context)
        {
            _context = context;
        }

        // GET: Home
        public async Task<IActionResult> Index()
        {
            var pilotos = await _context.Piloto.Include(pilotos => pilotos.Carro).ToListAsync();
            pilotos.OrderByDescending(p => p.Pontos);
            return View(pilotos);
        }

        // GET: Home/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piloto = await _context.Piloto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (piloto == null)
            {
                return NotFound();
            }

            return View(piloto);
        }

        // GET: Home/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Pontos")] Piloto piloto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(piloto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(piloto);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
