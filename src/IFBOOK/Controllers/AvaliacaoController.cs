using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IFBOOK.Data;
using IFBOOK.Models;
using Microsoft.AspNetCore.Identity;

namespace IFBOOK.Controllers
{
    public class AvaliacaoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AvaliacaoController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Avaliacao
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Avaliacoes.Include(a => a.Disciplina).Include(a => a.Professor).Include(a => a.TipoAvaliacao).Include(a => a.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> Avaliar(string id, int Nota)
        {
            var Tipo = id[0];
            var ratedId =int.Parse(id.Substring(1));
            var avaliacao = new Avaliacao() { Data = DateTime.Now, UsuarioID = _userManager.GetUserId(User), Nota = Nota };
            if (Tipo == 'P')
            {
                avaliacao.TipoAvaliacaoID = 1;
                avaliacao.ProfessorID = ratedId;
            }
            else
            {
                avaliacao.TipoAvaliacaoID = 2;
                avaliacao.DisciplinaID = ratedId;
            }
            if (!_context.Avaliacoes.Any(a => a.UsuarioID == avaliacao.UsuarioID && a.DisciplinaID == avaliacao.DisciplinaID && a.ProfessorID == avaliacao.ProfessorID)) _context.Add(avaliacao);
            else _context.Update(avaliacao);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", (Tipo=='P'?"Professor":"Disciplina"));
        }
        // GET: Avaliacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaliacao = await _context.Avaliacoes.SingleOrDefaultAsync(m => m.ID == id);
            if (avaliacao == null)
            {
                return NotFound();
            }

            return View(avaliacao);
        }

        // GET: Avaliacao/Create
        public IActionResult Create()
        {
            ViewData["DisciplinaID"] = new SelectList(_context.Disciplinas, "ID", "Nome");
            ViewData["ProfessorID"] = new SelectList(_context.Professores, "ID", "Nome");
            ViewData["TipoAvaliacaoID"] = new SelectList(_context.TipoAvaliacao, "ID", "Descricao");
            ViewData["UsuarioID"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            return View();
        }

        // POST: Avaliacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Data,Descricao,DisciplinaID,Nota,ProfessorID,TipoAvaliacaoID,UsuarioID")] Avaliacao avaliacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(avaliacao);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["DisciplinaID"] = new SelectList(_context.Disciplinas, "ID", "Nome", avaliacao.DisciplinaID);
            ViewData["ProfessorID"] = new SelectList(_context.Professores, "ID", "Nome", avaliacao.ProfessorID);
            ViewData["TipoAvaliacaoID"] = new SelectList(_context.TipoAvaliacao, "ID", "Descricao", avaliacao.TipoAvaliacaoID);
            ViewData["UsuarioID"] = new SelectList(_context.ApplicationUser, "Id", "Id", avaliacao.UsuarioID);
            return View(avaliacao);
        }

        // GET: Avaliacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaliacao = await _context.Avaliacoes.SingleOrDefaultAsync(m => m.ID == id);
            if (avaliacao == null)
            {
                return NotFound();
            }
            ViewData["DisciplinaID"] = new SelectList(_context.Disciplinas, "ID", "Nome", avaliacao.DisciplinaID);
            ViewData["ProfessorID"] = new SelectList(_context.Professores, "ID", "Nome", avaliacao.ProfessorID);
            ViewData["TipoAvaliacaoID"] = new SelectList(_context.TipoAvaliacao, "ID", "Descricao", avaliacao.TipoAvaliacaoID);
            ViewData["UsuarioID"] = new SelectList(_context.ApplicationUser, "Id", "Id", avaliacao.UsuarioID);
            return View(avaliacao);
        }

        // POST: Avaliacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Data,Descricao,DisciplinaID,Nota,ProfessorID,TipoAvaliacaoID,UsuarioID")] Avaliacao avaliacao)
        {
            if (id != avaliacao.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avaliacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvaliacaoExists(avaliacao.ID))
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
            ViewData["DisciplinaID"] = new SelectList(_context.Disciplinas, "ID", "Nome", avaliacao.DisciplinaID);
            ViewData["ProfessorID"] = new SelectList(_context.Professores, "ID", "Nome", avaliacao.ProfessorID);
            ViewData["TipoAvaliacaoID"] = new SelectList(_context.TipoAvaliacao, "ID", "Descricao", avaliacao.TipoAvaliacaoID);
            ViewData["UsuarioID"] = new SelectList(_context.ApplicationUser, "Id", "Id", avaliacao.UsuarioID);
            return View(avaliacao);
        }

        // GET: Avaliacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaliacao = await _context.Avaliacoes.SingleOrDefaultAsync(m => m.ID == id);
            if (avaliacao == null)
            {
                return NotFound();
            }

            return View(avaliacao);
        }

        // POST: Avaliacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var avaliacao = await _context.Avaliacoes.SingleOrDefaultAsync(m => m.ID == id);
            _context.Avaliacoes.Remove(avaliacao);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AvaliacaoExists(int id)
        {
            return _context.Avaliacoes.Any(e => e.ID == id);
        }
    }
}
