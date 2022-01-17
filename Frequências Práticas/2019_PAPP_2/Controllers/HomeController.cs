using _2019_PAPP_2.Data;
using _2019_PAPP_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _2019_PAPP_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly _2019_PAPP_2Context _context;

        public HomeController(ILogger<HomeController> logger,
            _2019_PAPP_2Context context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var carros = await _context.Carro
                .Include(x => x.Marca)
                .ToListAsync();
            return View(carros);
        }

        public async Task<IActionResult> Editar(int id)
        {
            var carro = await _context.Carro
                .Include(x => x.Marca)
                .SingleOrDefaultAsync(x => x.Id == id);

            ViewData["MarcaId"] = new SelectList(
                _context.Marca, "Id", "Nome");

            return View(carro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Carro carro)
        {
            if(ModelState.IsValid)
            {
                _context.Update(carro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["MarcaId"] = new SelectList(
                _context.Marca, "Id", "Nome");

            return View(carro);
        }

        public async Task<IActionResult> Marcas(string ordem)
        {
            if (ordem == "crescente")
            {
                Response.Cookies.Append("ordem", "crescente");
                return RedirectToAction(nameof(Marcas));
            }
            if (ordem == "decrescente")
            {
                Response.Cookies.Append("ordem", "decrescente");
                return RedirectToAction(nameof(Marcas));
            }
            if (Request.Cookies["ordem"] == "decrescente")
            {
                return View(await _context.Marca
                        .Include(x => x.Carros)
                        .OrderByDescending(x => x.Nome)
                        .ToListAsync());
            }
            return View(await _context.Marca
                .Include(x => x.Carros)
                .OrderBy(x => x.Nome)
                .ToListAsync());
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
