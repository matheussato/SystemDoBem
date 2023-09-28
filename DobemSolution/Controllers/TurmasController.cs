﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoBemSolution.Models;
using DobemSolution.Persistence;

namespace DobemSolution.Controllers
{
    public class TurmasController : Controller
    {
        private readonly OracleDbContext _context;

        public TurmasController(OracleDbContext context)
        {
            _context = context;
        }

        // GET: Turmas
        public async Task<IActionResult> Index()
        {
            var oracleDbContext = _context.Turma.Include(t => t.Curso);
            return View(await oracleDbContext.ToListAsync());
        }

        // GET: Turmas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Turma == null)
            {
                return NotFound();
            }

            var turma = await _context.Turma
                .Include(t => t.Curso)
                .FirstOrDefaultAsync(m => m.IdTurma == id);
            if (turma == null)
            {
                return NotFound();
            }

            return View(turma);
        }

        // GET: Turmas/Create
        public IActionResult Create()
        {
            ViewData["IdCurso"] = new SelectList(_context.Curso, "IdCurso", "NomeCurso");
            return View();
        }

        // POST: Turmas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTurma,Inicio,Encerramento,IdCurso")] Turma turma)
        {
         
                _context.Add(turma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           
            ViewData["IdCurso"] = new SelectList(_context.Curso, "IdCurso", "CargaHorariaCurso", turma.IdCurso);
            return View(turma);
        }

        // GET: Turmas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Turma == null)
            {
                return NotFound();
            }

            var turma = await _context.Turma.FindAsync(id);
            if (turma == null)
            {
                return NotFound();
            }
            ViewData["IdCurso"] = new SelectList(_context.Curso, "IdCurso", "CargaHorariaCurso", turma.IdCurso);
            return View(turma);
        }

        // POST: Turmas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTurma,Inicio,Encerramento,IdCurso")] Turma turma)
        {
            if (id != turma.IdTurma)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurmaExists(turma.IdTurma))
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
            ViewData["IdCurso"] = new SelectList(_context.Curso, "IdCurso", "CargaHorariaCurso", turma.IdCurso);
            return View(turma);
        }

        // GET: Turmas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Turma == null)
            {
                return NotFound();
            }

            var turma = await _context.Turma
                .Include(t => t.Curso)
                .FirstOrDefaultAsync(m => m.IdTurma == id);
            if (turma == null)
            {
                return NotFound();
            }

            return View(turma);
        }

        // POST: Turmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Turma == null)
            {
                return Problem("Entity set 'OracleDbContext.Turma'  is null.");
            }
            var turma = await _context.Turma.FindAsync(id);
            if (turma != null)
            {
                _context.Turma.Remove(turma);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurmaExists(int id)
        {
          return (_context.Turma?.Any(e => e.IdTurma == id)).GetValueOrDefault();
        }
    }
}
