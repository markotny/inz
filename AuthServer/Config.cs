﻿using System.Collections.Generic;
using IdentityServer4.Models;

namespace AuthServer
{
	public class Config
	{
		public static IEnumerable<IdentityResource> GetIdentityResources()
		{
			return new List<IdentityResource>
			{
				new IdentityResources.OpenId(),
				new IdentityResources.Email(),
				new IdentityResources.Profile(),
			};
		}

		public static IEnumerable<ApiResource> GetApiResources()
		{
			return new List<ApiResource>
			{
				new ApiResource("reServer", "Resource API")
				{
					Scopes = {new Scope("api.read")}
				}
			};
		}

		public static IEnumerable<Client> GetClients()
		{
			return new[]
			{
				new Client {
					ClientId = "angular_spa",
					ClientName = "Angular SPA",
					RequireConsent = false,
					AllowedGrantTypes = GrantTypes.Code,
					RequirePkce = true,
					RequireClientSecret = false,
					AllowedScopes = { "openid", "profile", "email", "api.read" },
					RedirectUris = {"http://localhost/login-callback", "http://localhost/register-callback", "http://localhost/silent-refresh" },
					PostLogoutRedirectUris = {"http://localhost/"},
					AllowedCorsOrigins = {"http://localhost"},
					AllowAccessTokensViaBrowser = true,
					AccessTokenLifetime = 3600
				}
			};
		}
	}
}
