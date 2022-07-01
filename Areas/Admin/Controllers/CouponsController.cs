using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spice.Data;
using Spice.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class CouponsController : Controller
    {
        private readonly ApplicationDbContext db;

        public CouponsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task <IActionResult> Index()
        {
            var coupons = await db.Coupons.ToListAsync();
            return View(coupons);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Coupon coupon)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files; //حجيب الفايلز اللي تحملت
                
                if (files.Count > 0)
                {
                    byte[] picture = null;
                    var fs = files[0].OpenReadStream(); //حيستقبل الصورة عشان يحولها لداتا بايت وعشان نخزنها بالداتا بيس
                    var ms = new MemoryStream();// بعرف الميموري ستريم عشان أستخدمها بعيدن لتخزين الصورة فيها
                    fs.CopyTo(ms); //بنسخ الصورة على الميموري ستريم
                    picture = ms.ToArray(); //رح تتحول الصورة ك مصفوفة من البايتس واخزنها بفاريابيل
                    coupon.Picture = picture; // الموديل رح يوخذ قيمة
                }
                db.Coupons.Add(coupon);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                
            }
            return View(coupon);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var coupon = await db.Coupons.FindAsync(id);

            if(coupon == null)
            {
                return NotFound();
            }
            return View(coupon);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Coupon coupon)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files; //حجيب الفايلز اللي تحملت

                if (files.Count > 0)
                {
                    byte[] picture = null;
                    var fs = files[0].OpenReadStream(); //حيستقبل الصورة عشان يحولها لداتا بايت وعشان نخزنها بالداتا بيس
                    var ms = new MemoryStream();// بعرف الميموري ستريم عشان أستخدمها بعيدن لتخزين الصورة فيها
                    fs.CopyTo(ms); //بنسخ الصورة على الميموري ستريم
                    picture = ms.ToArray(); //رح تتحول الصورة ك مصفوفة من البايتس واخزنها بفاريابيل
                    coupon.Picture = picture; // الموديل رح يوخذ قيمة
                }
                db.Coupons.Update(coupon);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(coupon);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coupon = await db.Coupons.FindAsync(id);

            if (coupon == null)
            {
                return NotFound();
            }
            return View(coupon);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Coupon coupon)
        {
             
                db.Coupons.Remove(coupon);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

        }



        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coupon = await db.Coupons.FindAsync(id);

            if (coupon == null)
            {
                return NotFound();
            }
            return View(coupon);
        }


      
    }
}
