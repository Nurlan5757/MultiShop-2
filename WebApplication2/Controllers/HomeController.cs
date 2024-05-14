using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WebApplication2.DataAccesLayer;
using WebApplication2.Migrations;
using WebApplication2.Models;
using WebApplication2.ViewModels;
using WebApplication2.ViewModels.Sliders;

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

            var data = await _context.Sliders
               .Where(x => !x.IsDeleted)
               .Select(s => new GetSliderVM
               {
                   Discount = s.Discount,
                   Id = s.Id,
                   ImageUrl = s.ImageUrl,
                   Subtitle = s.Subtitle,
                   Title = s.Title
               }).ToListAsync();

            return View(data);
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}
