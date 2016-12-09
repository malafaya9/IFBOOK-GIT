using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IFBOOK.Data;
using IFBOOK.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace IFBOOK.Controllers
{
    [Authorize]
    public class PerguntaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public PerguntaController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;    
        }

        // GET: Pergunta
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Perguntas.Include(p => p.Curso).Include(p => p.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Pergunta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pergunta = await _context.Perguntas.SingleOrDefaultAsync(m => m.ID == id);
            if (pergunta == null)
            {
                return NotFound();
            }

            return View(pergunta);
        }

        // GET: Pergunta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pergunta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CursoID,Data,Descricao,UsuarioID")] Pergunta pergunta)
        {
            pergunta.UsuarioID = _userManager.GetUserId(HttpContext.User);
            pergunta.CursoID = (await _userManager.GetUserAsync(HttpContext.User)).CursoID;
            pergunta.Data=DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(pergunta);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pergunta);
        }

        // GET: Pergunta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pergunta = await _context.Perguntas.SingleOrDefaultAsync(m => m.ID == id);
            if (pergunta == null)
            {
                return NotFound();
            }
            return View(pergunta);
        }

        // POST: Pergunta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CursoID,Data,Descricao,UsuarioID")] Pergunta pergunta)
        {
            if (id != pergunta.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pergunta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerguntaExists(pergunta.ID))
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
            return View(pergunta);
        }

        // GET: Pergunta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pergunta = await _context.Perguntas.SingleOrDefaultAsync(m => m.ID == id);
            if (pergunta == null)
            {
                return NotFound();
            }

            return View(pergunta);
        }

        // POST: Pergunta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pergunta = await _context.Perguntas.SingleOrDefaultAsync(m => m.ID == id);
            _context.Perguntas.Remove(pergunta);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PerguntaExists(int id)
        {
            return _context.Perguntas.Any(e => e.ID == id);
        }
    }
}
