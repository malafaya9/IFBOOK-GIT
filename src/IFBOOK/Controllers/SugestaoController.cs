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
    public class SugestaoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public SugestaoController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;   
        }

        // GET: Sugestao
        [Authorize(Roles ="Administrador")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sugestoes.Include(s => s.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Sugestao/Details/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sugestao = await _context.Sugestoes.SingleOrDefaultAsync(m => m.ID == id);
            if (sugestao == null)
            {
                return NotFound();
            }

            return View(sugestao);
        }

        // GET: Sugestao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sugestao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Descricao,UsuarioID")] Sugestao sugestao)
        {
            sugestao.UsuarioID = _userManager.GetUserId(User);
            if (ModelState.IsValid)
            {
                _context.Add(sugestao);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Publicacao");
            }
            return View(sugestao);
        }

        // GET: Sugestao/Delete/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sugestao = await _context.Sugestoes.SingleOrDefaultAsync(m => m.ID == id);
            if (sugestao == null)
            {
                return NotFound();
            }

            return View(sugestao);
        }

        // POST: Sugestao/Delete/5
        [Authorize(Roles = "Administrador")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sugestao = await _context.Sugestoes.SingleOrDefaultAsync(m => m.ID == id);
            _context.Sugestoes.Remove(sugestao);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SugestaoExists(int id)
        {
            return _context.Sugestoes.Any(e => e.ID == id);
        }
    }
}