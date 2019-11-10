using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ResourceServer.Api.Services
{
	public class OpenIdService
	{
		public HttpClient Client { get; }

		public OpenIdService(HttpClient client)
		{
			client.BaseAddress = new Uri("http://authServer/connect/");
			Client = client;
		}

		public async Task<UserInfo> GetUserInfo(string accessToken)
		{
			Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
			var response = await Client.GetAsync("userinfo");
			response.EnsureSuccessStatusCode();

			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<UserInfo>(responseStream);
		}
	}

	public class UserInfo
	{
		[JsonPropertyName("sub")]
		public Guid Sub { get; set; }

		[JsonPropertyName("preferred_username")]
		public string PreferredUsername { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("email")]
		public string Email { get; set; }

		[JsonPropertyName("email_verified")]
		public bool EmailVerified { get; set; }
	}
}
