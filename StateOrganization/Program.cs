using Microsoft.EntityFrameworkCore;
using StrateInfo.Application.Services;
using StrateInfo.Infrastructure.DatabaseContext;
using StrateInfo.Infrastructure.Repositorys;

namespace StateOrganization
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
								options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
			builder.Services.AddScoped<IStateOrganizationService, StateOrganizationService>();
			builder.Services.AddScoped<IStateOrganizationRepository, StateOrganizationRepository>();
			// Add services to the container.
			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=GetAllOrganization}");

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Details}/{id?}");
			});

			app.Run();
		}
	}
}
