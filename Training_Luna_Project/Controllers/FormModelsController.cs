using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Training_Luna_Project.Data;
using Training_Luna_Project.Data.Models;

namespace Training_Luna_Project.Controllers
{
    [Authorize]
    public class FormModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FormModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FormModels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FormModels.Include(f => f.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FormModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formModel = await _context.FormModels
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formModel == null)
            {
                return NotFound();
            }

            return View(formModel);
        }

        // GET: FormModels/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: FormModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,CreatedAt,UserId")] FormModel formModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", formModel.UserId);
            return View(formModel);
        }

        // GET: FormModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formModel = await _context.FormModels.FindAsync(id);
            if (formModel == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", formModel.UserId);
            return View(formModel);
        }

        // POST: FormModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,CreatedAt,UserId")] FormModel formModel)
        {
            if (id != formModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormModelExists(formModel.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", formModel.UserId);
            return View(formModel);
        }

        // GET: FormModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formModel = await _context.FormModels
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formModel == null)
            {
                return NotFound();
            }

            return View(formModel);
        }

        // POST: FormModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formModel = await _context.FormModels.FindAsync(id);
            if (formModel != null)
            {
                _context.FormModels.Remove(formModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormModelExists(int id)
        {
            return _context.FormModels.Any(e => e.Id == id);
        }
    }
}
