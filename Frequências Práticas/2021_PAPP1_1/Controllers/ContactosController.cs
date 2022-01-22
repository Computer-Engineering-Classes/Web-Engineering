using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Freq1.Data;
using Freq1.Models;

namespace Freq1.Controllers
{
    public class ContactosController : Controller
    {
        private readonly Freq1Context _context;

        public ContactosController(Freq1Context context)
        {
            _context = context;
        }

        // GET: Contactos
        public async Task<IActionResult> Lista(string Amigos)
        {
            if(string.IsNullOrEmpty(Amigos) == false)
            {
                return View(await _context.Contacto.Where(x => x.Amigo == true).ToListAsync());
            }
            return View(await _context.Contacto.ToListAsync());
        }

        // GET: Contactos/Edit/5
        public async Task<IActionResult> Alterar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contacto.FindAsync(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }

        // POST: Contactos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alterar(int id, [Bind("Id,Email,NickName,Nome,Amigo")] Contacto contacto)
        {
            if (id != contacto.Id)
            {
                return NotFound();
            }

            if (contacto.NickName.Contains(' ') == true)
            {
                ModelState.AddModelError("NickName", "Nickname must be only one word");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TempData["nickname"] = contacto.NickName;
                    _context.Update(contacto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactoExists(contacto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Lista));
            }
            return View(contacto);
        }

        private bool ContactoExists(int id)
        {
            return _context.Contacto.Any(e => e.Id == id);
        }
    }
}
