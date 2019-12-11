using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ResourceServer.Api;
using ResourceServer.Core.Entities;
using ResourceServer.Tests;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ResourceServer.IntegrationTests
{
	public class GraphQLTests : IClassFixture<WebAppTestFactory<Startup>>
	{
		private readonly HttpClient _client;

		public GraphQLTests(WebAppTestFactory<Startup> factory)
		{
			_client = factory.CreateClient();
		}

		[Fact]
		public async Task ReturnsAlbumBasic()
		{
			var request = new JObject();
			request.Add("query", "query getAlbum {\n  album(id: \"b0000000000000000000000000000001\") {\n    id\n    title\n    averageRating  }\n}\n");

			var response = await _client.PostAsync("/", new StringContent(
				request.ToString(), Encoding.UTF8, "application/json"));

			response.EnsureSuccessStatusCode();

			var responseString = await response.Content.ReadAsStringAsync();
			dynamic actual = JObject.Parse(responseString);

			Assert.Equal("b0000000000000000000000000000001", Convert.ToString(actual.data.album.id));
			Assert.Equal("Album 1", Convert.ToString(actual.data.album.title));
			Assert.Equal(5, Convert.ToInt32(actual.data.album.averageRating));
		}

		[Fact]
		public async Task ReturnsAlbumWithArtist()
		{
			var request = new JObject();
			request.Add("query", "query getAlbum { album(id: \"b0000000000000000000000000000001\")" +
				"{ title albumArtist {name}}}");

			var response = await _client.PostAsync("/", new StringContent(
				request.ToString(), Encoding.UTF8, "application/json"));

			response.EnsureSuccessStatusCode();

			var responseString = await response.Content.ReadAsStringAsync();
			dynamic actual = JObject.Parse(responseString);

			Assert.Equal("Album 1", Convert.ToString(actual.data.album.title));
			Assert.Equal("Artist 1", Convert.ToString(actual.data.album.albumArtist.name));
		}
	}
}
