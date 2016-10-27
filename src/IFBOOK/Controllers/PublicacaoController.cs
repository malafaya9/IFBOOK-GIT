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
    public class PublicacaoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public PublicacaoController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Publicacao
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Publicacoes.Include(p => p.Usuario).Include(p=>p.Comentarios).OrderByDescending(p => p.Data);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Publicacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicacao = await _context.Publicacoes.Include(p=>p.Comentarios).Include(p=>p.Usuario).SingleOrDefaultAsync(m => m.ID == id);
            if (publicacao == null)
            {
                return NotFound();
            }

            return View(publicacao);
        }

        // GET: Publicacao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Publicacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Data,Descricao,UsuarioID")] Publicacao publicacao)
        {
            publicacao.UsuarioID = _userManager.GetUserId(HttpContext.User);
            publicacao.Data = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(publicacao);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(publicacao);
        }

        // GET: Publicacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicacao = await _context.Publicacoes.SingleOrDefaultAsync(m => m.ID == id);
            if (publicacao == null)
            {
                return NotFound();
            }
            return View(publicacao);
        }

        // POST: Publicacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Descricao,UsuarioID,Data")] Publicacao publicacao)
        {
            if (id != publicacao.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publicacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublicacaoExists(publicacao.ID))
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
            return View(publicacao);
        }

        // GET: Publicacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicacao = await _context.Publicacoes.SingleOrDefaultAsync(m => m.ID == id);
            if (publicacao == null)
            {
                return NotFound();
            }

            return View(publicacao);
        }

        // POST: Publicacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publicacao = await _context.Publicacoes.SingleOrDefaultAsync(m => m.ID == id);
            _context.Publicacoes.Remove(publicacao);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PublicacaoExists(int id)
        {
            return _context.Publicacoes.Any(e => e.ID == id);
        }
    }
}
