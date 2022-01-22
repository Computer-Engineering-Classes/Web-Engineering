using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Freq2.Data;
using Freq2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Freq2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Home
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var filmes = await _context.Filme
                .Where(x => x.Estado == true)
                .OrderByDescending(x => x.Duracao)
                .ToListAsync();
            return View(filmes);
        }

        // GET: Home/AddFilme
        public IActionResult AddFilme()
        {
            return View();
        }

        // POST: Home/AddFilme
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFilme(Filme filme)
        {
            if(ModelState.IsValid)
            {
                _context.Add(filme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filme);
        }

        // GET: Home/Delete/5
        public async Task<string> Delete(int id)
        {
            var filme = await _context.Filme.FindAsync(id);           
            if(filme == null)
            {
                return null;
            }

            filme.Estado = false;
            _context.Update(filme);
            await _context.SaveChangesAsync();

            HttpContext.Response.Cookies.Append("alreadyDeleted", User.Identity.Name,
                new CookieOptions
                {
                    Expires = DateTime.Now.AddMinutes(5)
                });

            return "";
        }

        // GET: Home/Privacy
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
