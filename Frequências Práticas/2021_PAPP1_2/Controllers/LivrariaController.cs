using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _2021_PAPP1_2.Data;
using _2021_PAPP1_2.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Mime;

namespace _2021_PAPP1_2.Controllers
{
    public class LivrariaController : Controller
    {
        private readonly _2021_PAPP1_2Context _context;
        private readonly IHostEnvironment _he;

        public LivrariaController(_2021_PAPP1_2Context context,
            IHostEnvironment he)
        {
            _context = context;
            _he = he;
        }

        // GET: Livraria
        public async Task<IActionResult> Lista()
        {
            return View(await _context.Livro.ToListAsync());
        }

        // GET: Livraria/Create
        public IActionResult Inserir()
        {
            return View();
        }

        // POST: Livraria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Inserir(Livro livro, IFormFile Capa, IFormFile Contracapa)
        {
            if (Capa != null && Capa.ContentType != MediaTypeNames.Image.Jpeg)
            {
                ModelState.AddModelError("Capa", "Ficheiro deve ser JPEG.");
            }
            if (Contracapa != null && Contracapa.ContentType != MediaTypeNames.Image.Jpeg)
            {
                ModelState.AddModelError("Contracapa", "Ficheiro deve ser JPEG.");
            }

            livro.Capa = Capa?.FileName;
            livro.Contracapa = Contracapa?.FileName;

            if (ModelState.IsValid)
            {
                string destination = Path.Combine(
                    _he.ContentRootPath, $"wwwroot/{livro.ISBN}/");
                Directory.CreateDirectory(destination);

                if (Capa != null)
                {
                    string path = Path.Combine(destination,
                        Path.GetFileName(Capa.FileName));
                    FileStream fs = new(path, FileMode.Create);
                    Capa.CopyTo(fs);
                    fs.Close();
                }
                if (Contracapa != null)
                {
                    string path = Path.Combine(destination,
                        Path.GetFileName(Contracapa.FileName));
                    FileStream fs = new(path, FileMode.Create);
                    Contracapa.CopyTo(fs);
                    fs.Close();
                }
                _context.Add(livro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Lista));
            }
            return View(livro);
        }

        public async Task<IActionResult> Remover(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var livro = await _context.Livro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livro == null)
            {
                return NotFound();
            }

            string destination = Path.Combine(
                _he.ContentRootPath, $"wwwroot/{livro.ISBN}/");

            Directory.Delete(destination, true);

            _context.Livro.Remove(livro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }
    }
}
