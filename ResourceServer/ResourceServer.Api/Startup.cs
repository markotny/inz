﻿using ResourceServer.Infrastructure;
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
using Microsoft.AspNetCore.Authentication.JwtBearer;

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
				//.AddAuthorizeDirectiveType()
				.AddQueryType<QueryType>()
				.AddMutationType<MutationType>()
				.AddType<ToDoItemType>()
				.Create()
			);

			//services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
			//{
			//	options.Authority = "authServer";
			//	options.Audience = "reServer";
			//	options.RequireHttpsMetadata = false;
			//});

			return ContainerSetup.InitializeApi(Assembly.GetExecutingAssembly(), services);
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.EnvironmentName == "Development")
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseRouting();

			//app.UseAuthentication();

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
