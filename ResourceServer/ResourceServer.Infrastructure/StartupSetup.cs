using ResourceServer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ResourceServer.Infrastructure
{
	public static class StartupSetup
	{
		public static void AddDbContext(this IServiceCollection services, string connectionString) =>
			services.AddDbContext<AppDbContext>(options =>
			{
				options.EnableSensitiveDataLogging();
				options.UseLazyLoadingProxies();
				options.UseNpgsql(connectionString);
			});
	}
}
