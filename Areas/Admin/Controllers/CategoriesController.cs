using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spice.Data;
using Spice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Controllers
{
    [Area("Admin")]

    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext db;
        public CategoriesController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Index()  
        {
            return View(await db.Cateogries.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // للتأكد من انه القيم بتمر من خلال البوست مش من خلال تمرير قيم عشوائية بال url
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Cateogries.Add(category);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); //nameof(Index) == 'Index'
            }
            return View(category);
        }


        [HttpGet]
        public async Task<IActionResult> Edit (int? id)
        {
            if (id==null)
            {
                return NotFound();
            }

            var Category = await db.Cateogries.FindAsync(id);

            if (Category == null)
            {
                return NotFound();
            }

            return View(Category);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (Category category)
        {
            if (ModelState.IsValid)
            {
                db.Cateogries.Update(category);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Category = await db.Cateogries.FindAsync(id);

            if (Category == null)
            {
                return NotFound();
            }

            return View(Category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Category category)
        {
            db.Cateogries.Remove(category);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Category = await db.Cateogries.FindAsync(id);

            if (Category == null)
            {
                return NotFound();
            }

            return View(Category);
        }


    }
}
