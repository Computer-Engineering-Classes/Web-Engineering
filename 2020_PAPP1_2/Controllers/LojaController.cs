using _2020_PAPP1_2.Data;
using _2020_PAPP1_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace _2020_PAPP1_2.Controllers
{
    public class LojaController : Controller
    {
        private readonly _2020_PAPP1_2Context _context;
        private readonly IHostEnvironment _he; // necessary to get the app folder

        public LojaController(_2020_PAPP1_2Context context, IHostEnvironment he)
        {
            _context = context;
            _he = he; // injects in the constructor info about the host environment
        }

        // GET: Loja
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carro.OrderByDescending(x => x.Ano).ToListAsync());
        }

        // GET: Loja/Inserir
        public IActionResult Inserir()
        {
            return View();
        }

        // POST: Loja/Inserir
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Inserir([Bind("Id,Marca,Ano,Foto,Vendido")] Carro carro, IFormFile Foto)
        {
            carro.Foto = Foto.FileName;

            if (!(carro.Ano >= 2000 && carro.Ano <= DateTime.Now.Year))
            {
                ModelState.AddModelError("Ano", "O ano tem de ser entre 2000 e o ano corrente");
            }
            if (Foto.ContentType != MediaTypeNames.Image.Jpeg)
            {
                ModelState.AddModelError("Foto", "A foto tem de ser JPG");
            }
            if (ModelState.IsValid)
            {
                string destination = Path.Combine(_he.ContentRootPath, "wwwroot/Images/",
                                Path.GetFileName(Foto.FileName));
                // creates a filestream to store the file bytes
                FileStream fs = new(destination, FileMode.Create);
                Foto.CopyTo(fs);
                fs.Close();

                _context.Add(carro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carro);
        }

        // GET: Loja/Comprar
        public async Task<IActionResult> Comprar(int id)
        {
            var carro = await _context.Carro.FindAsync(id);
            if (carro == null)
            {
                return NotFound();
            }
            carro.Vendido = true;

            try
            {
                _context.Update(carro);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarroExists(carro.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private bool CarroExists(int id)
        {
            return _context.Carro.Any(e => e.Id == id);
        }
    }
}
