using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IFBOOK.Data;
using IFBOOK.Models;

namespace IFBOOK.Controllers
{
    public class RelacaoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RelacaoController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Relacao
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProfessorDisciplina.Include(p => p.Disciplina).Include(p => p.Professor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Relacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professorDisciplina = await _context.ProfessorDisciplina.SingleOrDefaultAsync(m => m.ProfessorID == id);
            if (professorDisciplina == null)
            {
                return NotFound();
            }

            return View(professorDisciplina);
        }

        // GET: Relacao/Create
        public IActionResult Create()
        {
            ViewData["DisciplinaID"] = new SelectList(_context.Disciplinas, "ID", "Nome");
            ViewData["ProfessorID"] = new SelectList(_context.Professores, "ID", "Nome");
            return View();
        }

        // POST: Relacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfessorID,DisciplinaID")] ProfessorDisciplina professorDisciplina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professorDisciplina);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["DisciplinaID"] = new SelectList(_context.Disciplinas, "ID", "Nome", professorDisciplina.DisciplinaID);
            ViewData["ProfessorID"] = new SelectList(_context.Professores, "ID", "Nome", professorDisciplina.ProfessorID);
            return View(professorDisciplina);
        }

        // GET: Relacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professorDisciplina = await _context.ProfessorDisciplina.SingleOrDefaultAsync(m => m.ProfessorID == id);
            if (professorDisciplina == null)
            {
                return NotFound();
            }
            ViewData["DisciplinaID"] = new SelectList(_context.Disciplinas, "ID", "Nome", professorDisciplina.DisciplinaID);
            ViewData["ProfessorID"] = new SelectList(_context.Professores, "ID", "Nome", professorDisciplina.ProfessorID);
            return View(professorDisciplina);
        }

        // POST: Relacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfessorID,DisciplinaID")] ProfessorDisciplina professorDisciplina)
        {
            if (id != professorDisciplina.ProfessorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professorDisciplina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessorDisciplinaExists(professorDisciplina.ProfessorID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["DisciplinaID"] = new SelectList(_context.Disciplinas, "ID", "Nome", professorDisciplina.DisciplinaID);
            ViewData["ProfessorID"] = new SelectList(_context.Professores, "ID", "Nome", professorDisciplina.ProfessorID);
            return View(professorDisciplina);
        }

        // GET: Relacao/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            string[] idS = id.Split('@');
            if (idS == null)
            {
                return NotFound();
            }

            var professorDisciplina = await _context.ProfessorDisciplina.SingleOrDefaultAsync(m => m.ProfessorID == int.Parse(idS[0]) && m.DisciplinaID == int.Parse(idS[1]));
            if (professorDisciplina == null)
            {
                return NotFound();
            }

            return View(professorDisciplina);
        }

        // POST: Relacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            string[] idS = id.Split('@');
            var professorDisciplina = await _context.ProfessorDisciplina.SingleOrDefaultAsync(m => m.ProfessorID == int.Parse(idS[0]) && m.DisciplinaID == int.Parse(idS[1]));
            _context.ProfessorDisciplina.Remove(professorDisciplina);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProfessorDisciplinaExists(int id)
        {
            return _context.ProfessorDisciplina.Any(e => e.ProfessorID == id);
        }
    }
}
