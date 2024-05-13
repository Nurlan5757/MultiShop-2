using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WebApplication2.DataAccesLayer;
using WebApplication2.Migrations;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly MultiShopContext _context;

        public HomeController(MultiShopContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            var sliders = await _context.Sliders.ToListAsync();

            var categories = await _context.Categories
                                            .Where(x => !x.IsDeleted)
                                            .ToListAsync();

            HomeVM homeVM = new HomeVM
            {
                Sliders = sliders,
                Categories = categories
            };
            return View(homeVM);

        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}
