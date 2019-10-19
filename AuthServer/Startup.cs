using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AuthServer.Areas.Identity;
using AuthServer.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Microsoft.AspNetCore.Http;

namespace AuthServer
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		readonly string AllowCorsOrigins = "_corsPolicy";

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseNpgsql(
					Configuration.GetConnectionString("DefaultConnection")));
			services.AddDefaultIdentity<IdentityUser>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();

			services.AddCors(options =>
			{
				options.AddPolicy(AllowCorsOrigins, builder =>
				{
					builder.WithOrigins(
						Config.GetClients().SelectMany(client => client.AllowedCorsOrigins)
						.Append("http://localhost:58944").ToArray())
						.AllowAnyHeader();
				});
			});

			services.AddIdentityServer().AddDeveloperSigningCredential()
				.AddOperationalStore(options =>
				{
					options.ConfigureDbContext = builder => builder.UseNpgsql(
						Configuration.GetConnectionString("DefaultConnection"),
						options => options.MigrationsAssembly("AuthServer"));
					options.EnableTokenCleanup = true;
					options.TokenCleanupInterval = 30;
				})
				.AddInMemoryIdentityResources(Config.GetIdentityResources())
				.AddInMemoryApiResources(Config.GetApiResources())
				.AddInMemoryClients(Config.GetClients())
				.AddAspNetIdentity<IdentityUser>();

			services.AddRazorPages();
			services.AddServerSideBlazor();
			services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
		}
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
			}
			app.UseCors(AllowCorsOrigins);
			app.UseSerilogRequestLogging();

			app.UseIdentityServer();

			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapBlazorHub();
				endpoints.MapFallbackToPage("/_Host");
			});
		}
	}
}
