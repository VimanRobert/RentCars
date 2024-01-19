﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentCars.Data;
using RentCars.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace RentCars.Controllers
{
    public class CarsController : Controller
    {
        private readonly LibraryContext _context;

        public CarsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["TitleSortParm"] = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            ViewData["CurrentFilter"] = searchString;
            var car = from b in _context.Car
                        select b;
            var store = from c in _context.Store
                        select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                car = car.Where(s => s.carBrand.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "title_desc":
                    car = car.OrderByDescending(b => b.carBrand);
                    break;
                case "Price":
                    car = car.OrderBy(b => b.carPrice);
                    break;
                case "price_desc":
                    car = car.OrderByDescending(b => b.carPrice);
                    break;
                default:
                    store = store.OrderBy(c => c.isRented);
                    break;
            }
            return View(await car.AsNoTracking().ToListAsync());
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var book = await _context.Car.Include(s => s.Orders).ThenInclude(e => e.customer).AsNoTracking().FirstOrDefaultAsync(m => m.carId == id);

            var car = await _context.Car
                .FirstOrDefaultAsync(m => m.carId == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("carId,carBrand,carPrice")] Car car)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(car);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException e)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists ");
            }
            return View(car);
        }

        // GET: Cars/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car.FirstOrDefaultAsync(s => s.carId == id);
            if (await TryUpdateModelAsync<Car>(
                car,
                "",
                s => s.carId,
                s => s.carBrand,
                s => s.carPrice
                )
                )
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists");
                }
            }

            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("carId,carBrand,carPrice")] Car car)
        {
            if (id != car.carId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.carId))
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
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.carId == id);
            if (car == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                "Delete failed. Try again";
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Car.FindAsync(id);
            if (car == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Car.Remove(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch(DbUpdateException e)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });

            }
        }

        private bool CarExists(int id)
        {
            return _context.Car.Any(e => e.carId == id);
        }
    }
}
