using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LojaDeCarros.Data;
using LojaDeCarros.Models;
using LojaDeCarros.Validators;

namespace LojaDeCarros.Controllers
{
    public class NotesController : Controller
    {
        private readonly LojaDeCarrosContext _context;

        public NotesController(LojaDeCarrosContext context)
        {
            _context = context;
        }

        // GET: Notes
        public async Task<IActionResult> Index()
        {
            var lojaDeCarrosContext = _context.Note.Include(n => n.Buyer).Include(n => n.Car).Include(n => n.Salesperson);
            return View(await lojaDeCarrosContext.ToListAsync());
        }

        // GET: Notes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Note == null)
            {
                return NotFound();
            }

            var note = await _context.Note
                .Include(n => n.Buyer)
                .Include(n => n.Car)
                .Include(n => n.Salesperson)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        // GET: Notes/Create
        public IActionResult Create()
        {
            ViewData["Buyer"] = new SelectList(_context.Customer, "Id", "CPF");

            var carros = _context.Car
                .Select(c => new
                {
                    c.Id,
                    Descricao = $"{c.Model} - {c.ManufactureYear}/{c.ModelYear} - {c.Brand} - {c.ChassisNumber}"
                }).ToList();

            ViewData["Car"] = new SelectList(carros, "Id", "Descricao");

            ViewData["Seller"] = new SelectList(_context.Set<Seller>(), "Id", "Name");

            return View();
        }


        // POST: Notes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,IssueDate,Warranty,SaleValue,BuyerId,SellerId,CarId")] Note note)
        {

            if (!NoteValidator.IsValid(note, out var errors))
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError("IssueDate", error);
                }
            }

            if (ModelState.IsValid)
            {
                _context.Add(note);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Buyer"] = new SelectList(_context.Customer, "Id", "CPF", note.BuyerId);

            var carros = _context.Car
                .Select(c => new
                {
                    c.Id,
                    Descricao = $"{c.Model} - {c.ManufactureYear}/{c.ModelYear} - {c.Brand} - {c.ChassisNumber}"
                }).ToList();
            ViewData["Car"] = new SelectList(carros, "Id", "Descricao", note.CarId);

            ViewData["Seller"] = new SelectList(_context.Set<Seller>(), "Id", "Name", note.SellerId);

            return View(note);
        }

        // GET: Notes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Note == null)
            {
                return NotFound();
            }

            var note = await _context.Note.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }

            ViewData["Buyer"] = new SelectList(_context.Customer, "Id", "CPF", note.BuyerId);

            var carros = _context.Car
                .Select(c => new
                {
                    c.Id,
                    Descricao = $"{c.Model} - {c.ManufactureYear}/{c.ModelYear} - {c.Brand} - {c.ChassisNumber}"
                }).ToList();
            ViewData["Car"] = new SelectList(carros, "Id", "Descricao", note.CarId);

            ViewData["Seller"] = new SelectList(_context.Set<Seller>(), "Id", "Name", note.SellerId);
            return View(note);
        }

        // POST: Notes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,IssueDate,Warranty,SaleValue,BuyerId,SellerId,CarId")] Note note)
        {
            if (id != note.Id)
            {
                return NotFound();
            }

            if (!NoteValidator.IsValid(note, out var errors))
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError("IssueDate", error);
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(note);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoteExists(note.Id))
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

            ViewData["Buyer"] = new SelectList(_context.Customer, "Id", "CPF", note.BuyerId);

            var carros = _context.Car
                .Select(c => new
                {
                    c.Id,
                    Descricao = $"{c.Model} - {c.ManufactureYear}/{c.ModelYear} - {c.Brand} - {c.ChassisNumber}"
                }).ToList();
            ViewData["Car"] = new SelectList(carros, "Id", "Descricao", note.CarId);

            ViewData["Seller"] = new SelectList(_context.Set<Seller>(), "Id", "Name", note.SellerId);

            return View(note);
        }

        // GET: Notes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Note == null)
            {
                return NotFound();
            }

            var note = await _context.Note
                .Include(n => n.Buyer)
                .Include(n => n.Car)
                .Include(n => n.Salesperson)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        // POST: Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Note == null)
            {
                return Problem("Entity set 'LojaDeCarrosContext.Note'  is null.");
            }
            var note = await _context.Note.FindAsync(id);
            if (note != null)
            {
                _context.Note.Remove(note);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoteExists(int id)
        {
            return (_context.Note?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
