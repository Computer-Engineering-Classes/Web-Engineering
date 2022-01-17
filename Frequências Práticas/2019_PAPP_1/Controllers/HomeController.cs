using _2019_PAPP.Data;
using _2019_PAPP.Filters;
using _2019_PAPP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _2019_PAPP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly _2019_PAPPContext _context;

        public HomeController(ILogger<HomeController> logger,
            _2019_PAPPContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var pilotos = await _context.Piloto
                .Include(x => x.Carro)
                .OrderByDescending(x => x.Pontos)
                .ToListAsync();
            return View(pilotos);
        }

        [AjaxFilter]
        public async Task<IActionResult> Adiciona(int id)
        {
            var piloto = await _context.Piloto
                .SingleOrDefaultAsync(x => x.Id == id);
            return PartialView(nameof(Adiciona), piloto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Adiciona(IFormCollection pairs)
        {
            int id = Convert.ToInt32(pairs["Id"]);
            int pontos = Convert.ToInt32(pairs["novos"]);

            if(pontos >= 0)
            {
                var piloto = await _context.Piloto
                    .SingleOrDefaultAsync(x => x.Id == id);
                piloto.Pontos += pontos;
                _context.Update(piloto);
                await _context.SaveChangesAsync();
            }
            var pilotos = await _context.Piloto
                .Include(x => x.Carro)
                .OrderByDescending(x => x.Pontos)
                .ToListAsync();
            return PartialView("ListaPilotos", pilotos);
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
