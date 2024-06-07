using Microsoft.AspNetCore.Mvc;
using EcoCyan.Data;
using EcoCyan.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EcoCyan.Controllers
{
    public class ReciclagemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReciclagemController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reciclagem

        public async Task<IActionResult> Index()
        {
            return View(await _context.Reciclagem.ToListAsync());
        }

        // GET: Reciclagem/Details

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reciclagem = await _context.Reciclagem.Include(r => r.User).FirstOrDefaultAsync(m => m.IdReciclagem == id);
            if (reciclagem == null)
            {
                return NotFound();
            }

            return View(reciclagem);
        }

        // GET: Reciclagem/Create

        public IActionResult Create()
        {
            ViewData["IdUser"] = new SelectList(_context.Usuario, "IdUser", "NomeUser");
            return View();
        }

        // POST: Reciclagem/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReciclagem,DataReciclagem,QuantidadeReciclada,IdUser")] Reciclagem reciclagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reciclagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUser"] = new SelectList(_context.Usuario, "IdUser", "Nome", reciclagem.IdUser);
            return View(reciclagem);
        }


        // GET: Reciclagem/Edit

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reciclagem = await _context.Reciclagem.FindAsync(id);
            if (reciclagem == null)
            {
                return NotFound();
            }
            ViewData["IdUser"] = new SelectList(_context.Usuario, "IdUser", "NomeUser", reciclagem.IdUser);
            return View(reciclagem);
        }

        // POST: Reciclagem/Edit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReciclagem,DataReciclagem,QuantidadeReciclada,IdUser")] Reciclagem reciclagem)
        {
            if (id != reciclagem.IdReciclagem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reciclagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReciclagemExists(reciclagem.IdReciclagem))
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
            ViewData["IdUser"] = new SelectList(_context.Usuario, "IdUser", "NomeUser", reciclagem.IdUser);
            return View(reciclagem);
        }

        // GET: Reciclagem/Delete

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reciclagem = await _context.Reciclagem.Include(r => r.User).FirstOrDefaultAsync(m => m.IdReciclagem == id);
            if (reciclagem == null)
            {
                return NotFound();
            }

            return View(reciclagem);
        }

        // POST: Reciclagem/Delete

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reciclagem = await _context.Reciclagem.FindAsync(id);
            _context.Reciclagem.Remove(reciclagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReciclagemExists(int id)
        {
            return _context.Reciclagem.Any(e => e.IdReciclagem == id);
        }


    }
}
