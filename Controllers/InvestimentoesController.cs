using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AplicacaoWeb.Models;

namespace Challange_SprintTwo.Controllers
{
    public class InvestimentoesController : Controller
    {
        private readonly Contexto _context;

        public InvestimentoesController(Contexto context)
        {
            _context = context;
        }

        // GET: Investimentoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Investimento.ToListAsync());
        }

        // GET: Investimentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investimento = await _context.Investimento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (investimento == null)
            {
                return NotFound();
            }

            return View(investimento);
        }

        // GET: Investimentoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Investimentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeAtivo,ValorInvestido,DataCompra,ValorAtual,DataAtualizacao")] Investimento investimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(investimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(investimento);
        }

        // GET: Investimentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investimento = await _context.Investimento.FindAsync(id);
            if (investimento == null)
            {
                return NotFound();
            }
            return View(investimento);
        }

        // POST: Investimentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeAtivo,ValorInvestido,DataCompra,ValorAtual,DataAtualizacao")] Investimento investimento)
        {
            if (id != investimento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(investimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvestimentoExists(investimento.Id))
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
            return View(investimento);
        }

        // GET: Investimentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investimento = await _context.Investimento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (investimento == null)
            {
                return NotFound();
            }

            return View(investimento);
        }

        // POST: Investimentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var investimento = await _context.Investimento.FindAsync(id);
            if (investimento != null)
            {
                _context.Investimento.Remove(investimento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvestimentoExists(int id)
        {
            return _context.Investimento.Any(e => e.Id == id);
        }
    }
}
