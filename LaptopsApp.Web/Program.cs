using Buchnat.LaptopsApp.BLC;
using Buchnat.LaptopsApp.DAOSQL;
using LaptopsApp.Web.Services;

namespace LaptopsApp.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddScoped<DAOSQL>();
            var dataSource = builder.Configuration.GetValue<string>("ConnectionStrings:DataSource");

            builder.Services.AddScoped<BLC>(provider => new BLC(dataSource));

            builder.Services.AddScoped<LaptopService>(provider => new LaptopService(provider.GetRequiredService<BLC>(), dataSource));
            builder.Services.AddScoped<ProducerService>(provider => new ProducerService(provider.GetRequiredService<BLC>(), dataSource));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.MapRazorPages();

            app.Run();
        }
    }
}
