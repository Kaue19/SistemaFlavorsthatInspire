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
    public class PedidoProdutoController : Controller
    {
        private readonly Contexto _context;

        public PedidoProdutoController(Contexto context)
        {
            _context = context;
        }

        // GET: PedidoProduto
        public async Task<IActionResult> Index()
        {
            var contexto = _context.PedidoProduto.Include(p => p.Pedido).Include(p => p.Produto);
            return View(await contexto.ToListAsync());
        }

        // GET: PedidoProduto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PedidoProduto == null)
            {
                return NotFound();
            }

            var pedidoProduto = await _context.PedidoProduto
                .Include(p => p.Pedido)
                .Include(p => p.Produto)
                .FirstOrDefaultAsync(m => m.PedidoProdutoId == id);
            if (pedidoProduto == null)
            {
                return NotFound();
            }

            return View(pedidoProduto);
        }

        // GET: PedidoProduto/Create
        public IActionResult Create()
        {
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "PedidoId", "PedidoId");
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "ProdutoId");
            return View();
        }

        // POST: PedidoProduto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PedidoProdutoId,PedidoId,ProdutoId")] PedidoProduto pedidoProduto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedidoProduto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "PedidoId", "PedidoId", pedidoProduto.PedidoId);
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "ProdutoId", pedidoProduto.ProdutoId);
            return View(pedidoProduto);
        }

        // GET: PedidoProduto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PedidoProduto == null)
            {
                return NotFound();
            }

            var pedidoProduto = await _context.PedidoProduto.FindAsync(id);
            if (pedidoProduto == null)
            {
                return NotFound();
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "PedidoId", "PedidoId", pedidoProduto.PedidoId);
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "ProdutoId", pedidoProduto.ProdutoId);
            return View(pedidoProduto);
        }

        // POST: PedidoProduto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PedidoProdutoId,PedidoId,ProdutoId")] PedidoProduto pedidoProduto)
        {
            if (id != pedidoProduto.PedidoProdutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedidoProduto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoProdutoExists(pedidoProduto.PedidoProdutoId))
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
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "PedidoId", "PedidoId", pedidoProduto.PedidoId);
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "ProdutoId", pedidoProduto.ProdutoId);
            return View(pedidoProduto);
        }

        // GET: PedidoProduto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PedidoProduto == null)
            {
                return NotFound();
            }

            var pedidoProduto = await _context.PedidoProduto
                .Include(p => p.Pedido)
                .Include(p => p.Produto)
                .FirstOrDefaultAsync(m => m.PedidoProdutoId == id);
            if (pedidoProduto == null)
            {
                return NotFound();
            }

            return View(pedidoProduto);
        }

        // POST: PedidoProduto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PedidoProduto == null)
            {
                return Problem("Entity set 'Contexto.PedidoProduto'  is null.");
            }
            var pedidoProduto = await _context.PedidoProduto.FindAsync(id);
            if (pedidoProduto != null)
            {
                _context.PedidoProduto.Remove(pedidoProduto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoProdutoExists(int id)
        {
          return (_context.PedidoProduto?.Any(e => e.PedidoProdutoId == id)).GetValueOrDefault();
        }
    }
}
