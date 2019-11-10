using HotChocolate.Resolvers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using ResourceServer.Api.Services;
using ResourceServer.Core.Entities;
using ResourceServer.Core.Interfaces;
using Serilog;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ResourceServer.Api.Directives
{
	//public class RecordUserDirectiveType : DirectiveType
	//{
	//	protected override void Configure(IDirectiveTypeDescriptor descriptor)
	//	{
	//		descriptor.Name("recordUser");
	//		descriptor.Location(DirectiveLocation.FieldDefinition);
	//		descriptor.Use<RecordUserMiddleware>();
	//	}
	//}

	public class RecordUserMiddleware
	{
		private readonly FieldDelegate _next;
		private readonly OpenIdService _openIdService;

		public RecordUserMiddleware(FieldDelegate next, OpenIdService openIdService)
		{
			_next = next;
			_openIdService = openIdService;
		}

		public async Task InvokeAsync(IMiddlewareContext context, IRepository repository, IHttpContextAccessor httpContextAccessor)
		{
			var id = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

			var user = repository.GetById<User>(new Guid(id));

			if (user == null)
			{
				var accessToken = await httpContextAccessor.HttpContext.GetTokenAsync("access_token");
				var userInfo = await _openIdService.GetUserInfo(accessToken);

				user = new User
				{
					Id = userInfo.Sub,
					Username = userInfo.Name
				};

				Log.Debug($"Adding user {user.Id} {user.Username} to db");

				repository.Add(user);
			}

			await _next(context);
		}
	}
}