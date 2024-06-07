using Microsoft.AspNetCore.Mvc;
using EcoCyan.Data;
using EcoCyan.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace EcoCyan.Controllers
{
    public class LixoColetadoController : Controller
    {
       private readonly ApplicationDbContext _context;

        public LixoColetadoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LixoColetado

        public async Task<IActionResult> Index()
        {
            return View(await _context.LixoColetado.ToListAsync());
        }

        // GET: LixoColetado/Details

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lixoColetado = await _context.LixoColetado.Include(l => l.User).FirstOrDefaultAsync(m => m.IdLixoColetado == id);
            if (lixoColetado == null)
            {
                return NotFound();
            }

            return View(lixoColetado);
        }

        // GET: LixoColetado/Create

        public IActionResult Create()
        {
            ViewData["IdUser"] = new SelectList(_context.Usuario, "IdUser", "NomeUser");
            return View();
        }

        // POST: LixoColetado/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLixoColetado,DataColeta,QuantidadeColetada,IdUser")] LixoColetado lixoColetado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lixoColetado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUser"] = new SelectList(_context.Usuario, "IdUser", "NomeUser", lixoColetado.IdUser);
            return View(lixoColetado);
        }

        // GET: LixoColetado/Edit

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lixoColetado = await _context.LixoColetado.FindAsync(id);
            if (lixoColetado == null)
            {
                return NotFound();
            }
            ViewData["IdUser"] = new SelectList(_context.Usuario, "IdUser", "NomeUser", lixoColetado.IdUser);
            return View(lixoColetado);
        }

        // POST: LixoColetado/Edit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLixoColetado,DataColeta,QuantidadeColetada,IdUser")] LixoColetado lixoColetado)
        {
            if (id != lixoColetado.IdLixoColetado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lixoColetado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LixoColetadoExists(lixoColetado.IdLixoColetado))
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
            ViewData["IdUser"] = new SelectList(_context.Usuario, "IdUser", "NomeUser", lixoColetado.IdUser);
            return View(lixoColetado);
        }

        // GET: LixoColetado/Delete

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lixoColetado = await _context.LixoColetado.Include(l => l.User).FirstOrDefaultAsync(m => m.IdLixoColetado == id);
            if (lixoColetado == null)
            {
                return NotFound();
            }
            ViewData["IdUser"] = new SelectList(_context.Usuario, "IdUser", "NomeUser", lixoColetado.IdUser);
            return View(lixoColetado);
        }


        // POST: LixoColetado/Delete

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lixoColetado = await _context.LixoColetado.FindAsync(id);
            _context.LixoColetado.Remove(lixoColetado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LixoColetadoExists(int id)
        {
            return _context.LixoColetado.Any(e => e.IdLixoColetado == id);
        }
        
    }
}
