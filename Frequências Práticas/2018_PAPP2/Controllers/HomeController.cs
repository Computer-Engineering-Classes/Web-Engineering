using _2018_PAPP2.Data;
using _2018_PAPP2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace _2018_PAPP2.Controllers
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
            ViewData["NoInt"] = await _context.Interessados.CountAsync();
            return View();
        }

        [HttpPost]
        public async Task<string> EstouInteressado()
        {
            Thread.Sleep(5000);
            var userName = User.Identity.Name;
            Interessado interessado = new()
            {
                IdUser = userName,
            };
            _context.Add(interessado);
            await _context.SaveChangesAsync();
            HttpContext.Response.Cookies.Append("JaVotou", "1", 
                new CookieOptions()
                {
                    Expires = DateTime.Now.AddYears(1),
                });
            return (await _context.Interessados
                .CountAsync() + " Utilizadores Interessados");
        }

        public async Task<IActionResult> Mural()
        {
            return View(await _context.Mensagens
                .OrderByDescending(x => x.Data)
                .ToListAsync());
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Mural(IFormCollection pairs)
        {
            Mensagem mensagem = new()
            {
                IdUser = User.Identity.Name,
                NomeUser = User.Identity.Name,
                Corpo = pairs["Mensagem"],
            };
            _context.Add(mensagem);
            await _context.SaveChangesAsync();

            var mensagens = await _context.Mensagens
                .OrderByDescending(x => x.Data)
                .ToListAsync();
            return PartialView("Mensagens", mensagens);
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
