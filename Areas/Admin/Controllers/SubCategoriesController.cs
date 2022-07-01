using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spice.Data;
using Spice.Models;
using Spice.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class SubCategoriesController : Controller
    {
        private readonly ApplicationDbContext db;
         
        [TempData] //Temprory Value
        public string StatusMessage { get; set; }
        public SubCategoriesController(ApplicationDbContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var subCategories = await db.SubCateogries.Include(m => m.Category).ToListAsync(); //عشان اججيب اسم الكاتيجوري
            return View(subCategories);
        }

        [HttpGet]
        public async Task <IActionResult> Create()
        {
            SubCategoryAndCategoryViewModel model = new SubCategoryAndCategoryViewModel()
            {
                CategoriesList = await db.Cateogries.ToListAsync(),
                SubCategory = new Models.SubCategory(),
            };

            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubCategoryAndCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                //include means join between to tables
                var doesExistSubCategory =await db.SubCateogries.Include(m => m.Category).Where(m => m.Category.Id == model.SubCategory.CategoryId && m.Name == model.SubCategory.Name).ToListAsync();
                if (doesExistSubCategory.Count() > 0)
                {
                    StatusMessage = "Error : This is Sub Category Exsists under " + doesExistSubCategory.FirstOrDefault().Category.Name + "Category";
                }
                else
                {
                    db.SubCateogries.Add(model.SubCategory);
                    await db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            SubCategoryAndCategoryViewModel modelVM = new SubCategoryAndCategoryViewModel()
            {
                CategoriesList = await db.Cateogries.ToListAsync(),
                SubCategory = model.SubCategory,
                StatusMessage = StatusMessage
            };

            return View(modelVM);

        }
        [HttpGet]
        public async Task<IActionResult> GetSubCategories(int id)
        {
            List<SubCategory> subCategories = new List<SubCategory>();
            subCategories = await db.SubCateogries.Where(m => m.CategoryId == id).ToListAsync();
            return Json(new SelectList(subCategories, "Id", "Name"));
        }





        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var subCategory = await db.SubCateogries.FindAsync(id);
            if(subCategory == null)
            {
                return NotFound();
            }


            SubCategoryAndCategoryViewModel model = new SubCategoryAndCategoryViewModel()
            {
                CategoriesList = await db.Cateogries.ToListAsync(),
                SubCategory = subCategory,
            };

            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SubCategoryAndCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                //include means join between to tables
                var doesExistSubCategory = await db.SubCateogries.Include(m => m.Category).Where(m => m.Category.Id == model.SubCategory.CategoryId && m.Name == model.SubCategory.Name &&  m.Id != model.SubCategory.Id).ToListAsync();
                if (doesExistSubCategory.Count() > 0)
                {
                    StatusMessage = "Error : This is Sub Category Exsists under " + doesExistSubCategory.FirstOrDefault().Category.Name + " Category";
                }
                else
                {
                    db.SubCateogries.Update(model.SubCategory);
                    await db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            SubCategoryAndCategoryViewModel modelVM = new SubCategoryAndCategoryViewModel()
            {
                CategoriesList = await db.Cateogries.ToListAsync(),
                SubCategory = model.SubCategory,
                StatusMessage = StatusMessage
            };

            return View(modelVM);

        }


        [HttpGet]
        public  IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var subCategory =  db.SubCateogries.Include(m=>m.Category).Where(m => m.Id == id).SingleOrDefault();
            if (subCategory == null)
            {
                return NotFound();
            }


            return View(subCategory);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(SubCategory subCategory)
        {
            db.SubCateogries.Remove(subCategory);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }




        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var subCategory = db.SubCateogries.Include(m => m.Category).Where(m => m.Id == id).SingleOrDefault();
            if (subCategory == null)
            {
                return NotFound();
            }


            return View(subCategory);

        }

    }


}
