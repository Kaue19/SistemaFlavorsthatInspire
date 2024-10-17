using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaFlavorsThatInspire.Models;

namespace SistemaFlavorsThatInspire.Controllers
{
    public class StatusDaEntregaController : Controller
    {
        private readonly Contexto _context;

        public StatusDaEntregaController(Contexto context)
        {
            _context = context;
        }

        // GET: StatusDaEntrega
        public async Task<IActionResult> Index()
        {
            var contexto = _context.StatusDaEntrega.Include(s => s.Pedido).Include(s => s.Usuario);
            return View(await contexto.ToListAsync());
        }

        // GET: StatusDaEntrega/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StatusDaEntrega == null)
            {
                return NotFound();
            }

            var statusDaEntrega = await _context.StatusDaEntrega
                .Include(s => s.Pedido)
                .Include(s => s.Usuario)
                .FirstOrDefaultAsync(m => m.StatusDaEntregaId == id);
            if (statusDaEntrega == null)
            {
                return NotFound();
            }

            return View(statusDaEntrega);
        }

        // GET: StatusDaEntrega/Create
        public IActionResult Create()
        {
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "PedidoId", "PedidoId");
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "NomeUsuario");
            return View();
        }

        // POST: StatusDaEntrega/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StatusDaEntregaId,UsuarioId,PedidoId,DataSaida,DataEntrega")] StatusDaEntrega statusDaEntrega)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusDaEntrega);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "PedidoId", "PedidoId", statusDaEntrega.PedidoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "NomeUsuario", statusDaEntrega.UsuarioId);
            return View(statusDaEntrega);
        }

        // GET: StatusDaEntrega/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StatusDaEntrega == null)
            {
                return NotFound();
            }

            var statusDaEntrega = await _context.StatusDaEntrega.FindAsync(id);
            if (statusDaEntrega == null)
            {
                return NotFound();
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "PedidoId", "PedidoId", statusDaEntrega.PedidoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "NomeUsuario", statusDaEntrega.UsuarioId);
            return View(statusDaEntrega);
        }

        // POST: StatusDaEntrega/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StatusDaEntregaId,UsuarioId,PedidoId,DataSaida,DataEntrega")] StatusDaEntrega statusDaEntrega)
        {
            if (id != statusDaEntrega.StatusDaEntregaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusDaEntrega);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusDaEntregaExists(statusDaEntrega.StatusDaEntregaId))
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
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "PedidoId", "PedidoId", statusDaEntrega.PedidoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "NomeUsuario", statusDaEntrega.UsuarioId);
            return View(statusDaEntrega);
        }

        // GET: StatusDaEntrega/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StatusDaEntrega == null)
            {
                return NotFound();
            }

            var statusDaEntrega = await _context.StatusDaEntrega
                .Include(s => s.Pedido)
                .Include(s => s.Usuario)
                .FirstOrDefaultAsync(m => m.StatusDaEntregaId == id);
            if (statusDaEntrega == null)
            {
                return NotFound();
            }

            return View(statusDaEntrega);
        }

        // POST: StatusDaEntrega/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StatusDaEntrega == null)
            {
                return Problem("Entity set 'Contexto.StatusDaEntrega'  is null.");
            }
            var statusDaEntrega = await _context.StatusDaEntrega.FindAsync(id);
            if (statusDaEntrega != null)
            {
                _context.StatusDaEntrega.Remove(statusDaEntrega);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusDaEntregaExists(int id)
        {
          return (_context.StatusDaEntrega?.Any(e => e.StatusDaEntregaId == id)).GetValueOrDefault();
        }
    }
}
