using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ViewModels.Categories
{
    public class UpdateCategoryVM
    {
        [MaxLength(32), Required]
        public string Name { get; set; }
        //[Required]
        //public string ImageUrl { get; set; }
    }
}
