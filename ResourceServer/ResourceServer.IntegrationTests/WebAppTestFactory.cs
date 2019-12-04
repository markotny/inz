using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.Types;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ResourceServer.Api;
using ResourceServer.Api.Types;
using ResourceServer.Core.Interfaces;
using ResourceServer.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceServer.IntegrationTests
{
	public class WebAppTestFactory<TStartup> : WebApplicationFactory<Startup>
	{
		protected override void ConfigureWebHost(IWebHostBuilder builder)
		{
			builder
				.Configure(app => app.UseGraphQL("/"))
				.ConfigureServices(services =>
			{
				// Create a new service provider.
				var serviceProvider = new ServiceCollection()
					.AddEntityFrameworkInMemoryDatabase()
					.AddEntityFrameworkProxies()
					.BuildServiceProvider();

				// Add a database context (AppDbContext) using an in-memory
				// database for testing.
				services.AddDbContext<AppDbContext>(options =>
				{
					options.UseInMemoryDatabase("TestDB");
					options.UseLazyLoadingProxies();
					options.UseInternalServiceProvider(serviceProvider);
				});

				services.AddScoped<IDomainEventDispatcher, NoOpDomainEventDispatcher>();
				services.AddScoped<IRepository, EfRepository>();

				services.AddGraphQL(sp => SchemaBuilder.New()
					.AddServices(sp)
					.AddQueryType<QueryType>()
					.AddMutationType<MutationType>()
					.BindClrType<Guid, IdType>()
					.Create());

				// Build the service provider.
				var sp = services.BuildServiceProvider();

				// Create a scope to obtain a reference to the database
				// context (AppDbContext).
				using (var scope = sp.CreateScope())
				{
					var scopedServices = scope.ServiceProvider;
					var db = scopedServices.GetRequiredService<AppDbContext>();

					// Ensure the database is created.
					db.Database.EnsureCreated();

					// Seed the database with test data.
					SeedData.PopulateTestData(db);
				}
			});
		}
	}
}
