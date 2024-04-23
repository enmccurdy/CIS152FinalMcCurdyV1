using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CIS152FinalMcCurdyV1.Data;
using CIS152FinalMcCurdyV1.Models;

namespace CIS152FinalMcCurdyV1.Controllers
{
    public class DrinksController : Controller
    {
        private readonly DrinkShopAppContext _context;

        public DrinksController(DrinkShopAppContext context)
        {
            _context = context;
        }

        // GET: Drinks
        /*public IActionResult Index()
        {
            //var drinks = _context.Drinks.ToList();
            // Tutorial pluralized name of table but EF used singular form.
            var drinks = _context.Drink.ToList();
            return View(drinks);
        }*/

        // GET: Drinks
        public async Task<IActionResult> Index()
        {
            var drinkShopAppContext = _context.Drink.Include(d => d.Order);
            return View(await drinkShopAppContext.ToListAsync());
        }

        // GET: Drinks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Drink == null)
            {
                return NotFound();
            }

            var drink = await _context.Drink
                .Include(d => d.Order)
                .FirstOrDefaultAsync(m => m.DrinkId == id);
            if (drink == null)
            {
                return NotFound();
            }

            return View(drink);
        }

        // GET: Drinks/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Set<Order>(), "OrderId", "OrderId");
            return View();
        }

        // POST: Drinks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DrinkId,DrinkName,DrinkType,DrinkSize,DrinkImageUrl,DrinkPrice,OrderId")] Drink drink)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Set<Order>(), "OrderId", "OrderId", drink.OrderId);
            return View(drink);
        }

        // GET: Drinks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Drink == null)
            {
                return NotFound();
            }

            var drink = await _context.Drink.FindAsync(id);
            if (drink == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Set<Order>(), "OrderId", "OrderId", drink.OrderId);
            return View(drink);
        }

        // POST: Drinks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DrinkId,DrinkName,DrinkType,DrinkSize,DrinkImageUrl,DrinkPrice,OrderId")] Drink drink)
        {
            if (id != drink.DrinkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drink);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrinkExists(drink.DrinkId))
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
            ViewData["OrderId"] = new SelectList(_context.Set<Order>(), "OrderId", "OrderId", drink.OrderId);
            return View(drink);
        }

        // GET: Drinks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Drink == null)
            {
                return NotFound();
            }

            var drink = await _context.Drink
                .Include(d => d.Order)
                .FirstOrDefaultAsync(m => m.DrinkId == id);
            if (drink == null)
            {
                return NotFound();
            }

            return View(drink);
        }

        // POST: Drinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Drink == null)
            {
                return Problem("Entity set 'DrinkShopAppContext.Drink'  is null.");
            }
            var drink = await _context.Drink.FindAsync(id);
            if (drink != null)
            {
                _context.Drink.Remove(drink);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrinkExists(int id)
        {
          return (_context.Drink?.Any(e => e.DrinkId == id)).GetValueOrDefault();
        }
    }
}
