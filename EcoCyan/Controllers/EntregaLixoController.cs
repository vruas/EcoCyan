using Microsoft.AspNetCore.Mvc;
using EcoCyan.Data;
using EcoCyan.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EcoCyan.Controllers
{
    public class EntregaLixoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EntregaLixoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EntregaLixo

        public async Task<IActionResult> Index()
        {
            return View(await _context.EntregaLixo.ToListAsync());
        }

        // GET: EntregaLixo/Details

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entregaLixo = await _context.EntregaLixo.Include(e => e.lixoColetado).FirstOrDefaultAsync(m => m.IdEntregaLixo == id);
            if (entregaLixo == null)
            {
                return NotFound();
            }

            return View(entregaLixo);
        }

        // GET: EntregaLixo/Create

        public IActionResult Create()
        {
            ViewData["IdLixoColetado"] = new SelectList(_context.LixoColetado, "IdLixoColetado", "TipoLixo");
            ViewData["IdUser"] = new SelectList(_context.Usuario, "IdUser", "NomeUser");
            return View();
        }

        // POST: EntregaLixo/Create


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEntregaLixo,DataEntrega,IdLixoColetado,IdUser")] EntregaLixo entregaLixo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entregaLixo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLixoColetado"] = new SelectList(_context.LixoColetado, "IdLixoColetado", "TipoLixo", entregaLixo.IdLixoColetado);
            ViewData["IdUser"] = new SelectList(_context.Usuario, "IdUser", "NomeUser", entregaLixo.IdUser);
            return View(entregaLixo);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entregaLixo = await _context.EntregaLixo.FindAsync(id);
            if (entregaLixo == null)
            {
                return NotFound();
            }
            ViewData["IdLixoColetado"] = new SelectList(_context.LixoColetado, "IdLixoColetado", "TipoLixo", entregaLixo.IdLixoColetado);
            ViewData["IdUser"] = new SelectList(_context.Usuario, "IdUser", "NomeUser", entregaLixo.IdUser);
            return View(entregaLixo);
        }

        // POST: EntregaLixo/Edit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEntregaLixo,DataEntrega,IdLixoColetado,IdUser")] EntregaLixo entregaLixo)
        {
            if (id != entregaLixo.IdEntregaLixo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entregaLixo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntregaLixoExists(entregaLixo.IdEntregaLixo))
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
            ViewData["IdLixoColetado"] = new SelectList(_context.LixoColetado, "IdLixoColetado", "TipoLixo", entregaLixo.IdLixoColetado);
            ViewData["IdUser"] = new SelectList(_context.Usuario, "IdUser", "NomeUser", entregaLixo.IdUser);
            return View(entregaLixo);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entregaLixo = await _context.EntregaLixo.Include(e => e.lixoColetado).FirstOrDefaultAsync(m => m.IdEntregaLixo == id);
            if (entregaLixo == null)
            {
                return NotFound();
            }

            return View(entregaLixo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entregaLixo = await _context.EntregaLixo.FindAsync(id);
            _context.EntregaLixo.Remove(entregaLixo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntregaLixoExists(int id)
        {
            return _context.EntregaLixo.Any(e => e.IdEntregaLixo == id);
        }

    }
}
