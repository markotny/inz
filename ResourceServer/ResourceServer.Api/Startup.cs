using ResourceServer.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using HotChocolate;
using ResourceServer.Api.Types;
using HotChocolate.AspNetCore;

namespace ResourceServer.Api
{
	public class Startup
	{
		public Startup(IConfiguration config) => this.Configuration = config;

		public IConfiguration Configuration { get; }

		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext();

			services.AddControllers();

			services.AddGraphQL(sp => SchemaBuilder.New()
				.AddQueryType<QueryType>()
				.AddType<ToDoItemType>()
				.Create()
			);

			return ContainerSetup.InitializeApi(Assembly.GetExecutingAssembly(), services);
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.EnvironmentName == "Development")
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseRouting();

			app.UseWebSockets()
				.UseGraphQL("/graphql")
				.UseGraphiQL("/graphql")
				.UsePlayground("/graphql");

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
