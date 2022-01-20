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
            HttpContext.Session.SetString("podeEditar", "true");
            var pilotos = await _context.Piloto
                .Include(x => x.Carro)
                .OrderByDescending(x => x.Pontos)
                .ToListAsync();
            return View(pilotos);
        }

        [AjaxFilter]
        public IActionResult Adiciona(int id)
        {
            return PartialView(id);
        }

        [HttpPost]
        public async Task<IActionResult> Adiciona(int Id, int Novos)
        {
            var piloto = await _context.Piloto
                .SingleOrDefaultAsync(x => x.Id == Id);
            piloto.Pontos += Novos;
            _context.Update(piloto);
            await _context.SaveChangesAsync();

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
