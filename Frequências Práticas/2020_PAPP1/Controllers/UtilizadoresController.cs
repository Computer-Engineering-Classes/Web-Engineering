using _2020_PAPP1.Data;
using _2020_PAPP1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace _2020_PAPP1.Controllers
{
    public class UtilizadoresController : Controller
    {
        private readonly _2020_PAPP1Context _context;

        public UtilizadoresController(_2020_PAPP1Context context)
        {
            _context = context;
        }

        // GET: Utilizadores/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Utilizadores/Login
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Utilizador utilizador)
        {
            var user = await _context.Utilizador.FirstOrDefaultAsync(m => m.UserName == utilizador.UserName
                                                                    && m.Password == utilizador.Password);
            if (user != null)
            {
                TempData["Id"] = user.Id;
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("UserName", "Credenciais inválidas! Tente de novo.");
                return View();
            }
        }

        // GET: Utilizadores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Utilizador.ToListAsync());
        }

        public IActionResult Registar()
        {
            return View();
        }

        // POST: Utilizadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registar([Bind("Id,UserName,Password,Email,Tipo")] Utilizador utilizador)
        {
            if (ModelState.IsValid)
            {
                bool exists = await _context.Utilizador.AnyAsync(x => x.UserName == utilizador.UserName);
                if(!exists)
                {
                    _context.Add(utilizador);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Login));
                }
                else
                {
                    ModelState.AddModelError("UserName", "Username já existe. Escolha um novo.");
                }
            }
            return View(utilizador);
        }

        // GET: Utilizadores/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizador = await _context.Utilizador.FindAsync(id);
            if (utilizador == null)
            {
                return NotFound();
            }
            return View(utilizador);
        }

        // POST: Utilizadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id,UserName,Password,Email,Tipo")] Utilizador utilizador)
        {
            if (id != utilizador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utilizador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilizadorExists(utilizador.Id))
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
            return View(utilizador);
        }

        private bool UtilizadorExists(int id)
        {
            return _context.Utilizador.Any(e => e.Id == id);
        }
    }
}
