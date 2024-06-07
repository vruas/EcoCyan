using Microsoft.AspNetCore.Mvc;
using EcoCyan.Data;
using EcoCyan.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EcoCyan.Controllers
{
    public class PontoDeColetaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PontoDeColetaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PontoDeColeta

        public async Task<IActionResult> Index()
        {
            return View(await _context.PontoDeColeta.ToListAsync());
        }

        // GET: PontoDeColeta/Details

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontoDeColeta = await _context.PontoDeColeta.Include(p => p.EntregaLixo).FirstOrDefaultAsync(m => m.IdPontoColeta == id);
            if (pontoDeColeta == null)
            {
                return NotFound();
            }

            return View(pontoDeColeta);
        }

        // GET: PontoDeColeta/Create

        public IActionResult Create()
        {
            ViewData["IdEntregaLixo"] = new SelectList(_context.EntregaLixo, "IdEntregaLixo", "DataEntrega");
            return View();
        }

        // POST: PontoDeColeta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("IdPontoColeta,Endereco,IdEntregaLixo")] PontoDeColeta pontoDeColeta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pontoDeColeta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEntregaLixo"] = new SelectList(_context.EntregaLixo, "IdEntregaLixo", "DataEntrega", pontoDeColeta.IdEntregaLixo);
            return View(pontoDeColeta);
        }

        // GET: PontoDeColeta/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontoDeColeta = await _context.PontoDeColeta.FindAsync(id);
            if (pontoDeColeta == null)
            {
                return NotFound();
            }
            ViewData["IdEntregaLixo"] = new SelectList(_context.EntregaLixo, "IdEntregaLixo", "DataEntrega", pontoDeColeta.IdEntregaLixo);
            return View(pontoDeColeta);
        }

        // POST: PontoDeColeta/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, [Bind("IdPontoColeta,Endereco,IdEntregaLixo")] PontoDeColeta pontoDeColeta)
        {
            if (id != pontoDeColeta.IdPontoColeta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pontoDeColeta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PontoDeColetaExists(pontoDeColeta.IdPontoColeta))
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
            ViewData["IdEntregaLixo"] = new SelectList(_context.EntregaLixo, "IdEntregaLixo", "DataEntrega", pontoDeColeta.IdEntregaLixo);
            return View(pontoDeColeta);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontoDeColeta = await _context.PontoDeColeta.Include(p => p.EntregaLixo).FirstOrDefaultAsync(m => m.IdPontoColeta == id);
            if (pontoDeColeta == null)
            {
                return NotFound();
            }

            return View(pontoDeColeta);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pontoDeColeta = await _context.PontoDeColeta.FindAsync(id);
            _context.PontoDeColeta.Remove(pontoDeColeta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PontoDeColetaExists(int id)
        {
            return _context.PontoDeColeta.Any(e => e.IdPontoColeta == id);
        }

    }
}
