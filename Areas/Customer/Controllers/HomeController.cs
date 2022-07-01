using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spice.Data;
using Spice.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<IActionResult> Index()
        {
            IndexViewModel IndexVM = new IndexViewModel()
            {
                Categories = await db.Cateogries.ToListAsync(),
                Coupons = await db.Coupons.Where(m=>m.IsActive ==true).ToListAsync(),
                MenuItems = await db.MenuItems.Include(m => m.Category).Include(m => m.SubCategory).ToListAsync()
            };
            return View(IndexVM);
        }
    }
}
