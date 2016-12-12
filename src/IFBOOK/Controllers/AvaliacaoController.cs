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
using Microsoft.AspNetCore.Authorization;

namespace IFBOOK.Controllers
{
    [Authorize]
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
                avaliacao.TipoAvaliacaoID = _context.TipoAvaliacao.First(t=>t.Descricao=="Professor").ID;
                avaliacao.ProfessorID = ratedId;
            }
            else
            {
                avaliacao.TipoAvaliacaoID = _context.TipoAvaliacao.First(t => t.Descricao == "Disciplina").ID; ;
                avaliacao.DisciplinaID = ratedId;
            }
            if (!_context.Avaliacoes.Any(a => a.UsuarioID == avaliacao.UsuarioID && a.DisciplinaID == avaliacao.DisciplinaID && a.ProfessorID == avaliacao.ProfessorID)) _context.Add(avaliacao);
            else _context.Update(avaliacao);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", (Tipo=='P'?"Professor":"Disciplina"));
        }
        [Authorize(Roles ="Administrador")]
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
        [Authorize(Roles = "Administrador")]
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
