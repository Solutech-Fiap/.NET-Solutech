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
    public class ObjetivoFinanceiroesController : Controller
    {
        private readonly Contexto _context;

        public ObjetivoFinanceiroesController(Contexto context)
        {
            _context = context;
        }

        // GET: ObjetivoFinanceiroes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ObjetivoFinanceiro.ToListAsync());
        }

        // GET: ObjetivoFinanceiroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objetivoFinanceiro = await _context.ObjetivoFinanceiro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (objetivoFinanceiro == null)
            {
                return NotFound();
            }

            return View(objetivoFinanceiro);
        }

        // GET: ObjetivoFinanceiroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ObjetivoFinanceiroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,ValorAlvo,Prazo,Status,DataCriacao")] ObjetivoFinanceiro objetivoFinanceiro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(objetivoFinanceiro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(objetivoFinanceiro);
        }

        // GET: ObjetivoFinanceiroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objetivoFinanceiro = await _context.ObjetivoFinanceiro.FindAsync(id);
            if (objetivoFinanceiro == null)
            {
                return NotFound();
            }
            return View(objetivoFinanceiro);
        }

        // POST: ObjetivoFinanceiroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,ValorAlvo,Prazo,Status,DataCriacao")] ObjetivoFinanceiro objetivoFinanceiro)
        {
            if (id != objetivoFinanceiro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(objetivoFinanceiro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObjetivoFinanceiroExists(objetivoFinanceiro.Id))
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
            return View(objetivoFinanceiro);
        }

        // GET: ObjetivoFinanceiroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objetivoFinanceiro = await _context.ObjetivoFinanceiro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (objetivoFinanceiro == null)
            {
                return NotFound();
            }

            return View(objetivoFinanceiro);
        }

        // POST: ObjetivoFinanceiroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var objetivoFinanceiro = await _context.ObjetivoFinanceiro.FindAsync(id);
            if (objetivoFinanceiro != null)
            {
                _context.ObjetivoFinanceiro.Remove(objetivoFinanceiro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObjetivoFinanceiroExists(int id)
        {
            return _context.ObjetivoFinanceiro.Any(e => e.Id == id);
        }
    }
}
