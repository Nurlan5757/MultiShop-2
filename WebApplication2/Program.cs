using WebApplication2.DataAccesLayer;

namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<MultiShopContext>();
          
            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute("areas", "{area:exists}/{controller=Admin}/{action=Index}/{id?}");
            app.MapControllerRoute("defaut", "{controller=Home}/{action=Index}");
            app.Run();
        }
    }
}
