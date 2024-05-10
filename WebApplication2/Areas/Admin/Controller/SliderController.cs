using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using WebApplication2.DataAccesLayer;
using WebApplication2.Models;
using WebApplication2.ViewModels.Sliders;


namespace WebApplication2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController(MultiShopContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var data=await _context.Sliders
                .Where(x=> !x.IsDeleted)
                .Select(s=> new GetSliderVM
            {
                Discount = s.Discount,
                Id = s.Id,
                ImageUrl = s.ImageUrl,
                Subtitle = s.Subtitle,
                Title = s.Title
            }).ToListAsync();
            
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSliderVM vm)
        {
            if(!ModelState.IsValid)
            {
                return View(vm);
            }

            Slider slider = new Slider
            {
                Discount = vm.Discount,
                CreatedTime= DateTime.Now,
                ImageUrl = vm.ImageUrl,
                IsDeleted= false,
                Subtitle= vm.Subtitle,
                Title= vm.Title,
            };
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
		public IActionResult Update()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Update(int? id, UpdateSliderVM sliderVm)
		{
			if (id == null || id < 1) return BadRequest();
			Slider existed = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
			if (existed is null) return NotFound();

			existed.Title = sliderVm.Title;
			existed.ImageUrl = sliderVm.ImageUrl;
			existed.Subtitle = sliderVm.Subtitle;

			await _context.SaveChangesAsync();
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Delete(int? id, Slider sliderToDelete)
		{
			if (id == null || id < 1) return BadRequest();
			var slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
			if (slider is null) return NotFound();
			_context.Sliders.Remove(slider);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index");

		}
	}
}
