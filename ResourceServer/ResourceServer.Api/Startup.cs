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
using HotChocolate.AspNetCore.Playground;
using Microsoft.IdentityModel.Logging;
using HotChocolate.Execution.Configuration;
using Serilog;
using HotChocolate.Types;
using ResourceServer.Api.Services;
using Microsoft.CodeAnalysis.Options;
using ResourceServer.Api.Directives;

namespace ResourceServer.Api
{
	public class Startup
	{
		public Startup(IConfiguration config) => this.Configuration = config;

		public IConfiguration Configuration { get; }

		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext(
				Configuration.GetConnectionString("DefaultConnection"));

			services.AddControllers();

			services.AddHttpContextAccessor();
			services.AddHttpClient<OpenIdService>();

			services.AddGraphQL(sp => SchemaBuilder.New()
				.AddServices(sp)
				.AddAuthorizeDirectiveType()
				.AddQueryType<QueryType>()
				.AddMutationType<MutationType>()
				//.AddDirectiveType<RecordUserDirectiveType>()
				.BindClrType<Guid, IdType>()
				.Create(),
				new QueryExecutionOptions
				{
					TracingPreference = TracingPreference.OnDemand,
					IncludeExceptionDetails = true
				}
			);

			services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
			{
				options.Authority = "http://authServer";
				options.Audience = "reServer";
				options.RequireHttpsMetadata = false;
				options.TokenValidationParameters.ValidIssuer = "http://auth";
				options.SaveToken = true;
			});

			return ContainerSetup.InitializeApi(Assembly.GetExecutingAssembly(), services);
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.EnvironmentName == "Development")
			{
				app.UseDeveloperExceptionPage();
				IdentityModelEventSource.ShowPII = true;
			}
			app.UseRouting();

			app.UseAuthentication();
			app.UseSerilogRequestLogging();

			app.UseWebSockets()
				.UseGraphQL("/graphql")
				.UsePlayground(new PlaygroundOptions
				{
					QueryPath = "/api/graphql/",
					Path = "/playground"
				});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
