using ResourceServer.Core.Entities;
using System;
using System.Collections.Generic;
using Xunit;

namespace ResourceServer.Tests
{
	public class AlbumAddRating
	{
		[Fact]
		public void AddFirstRating()
		{
			var album = new AlbumBuilder()
				.WithDefaultValues()
				.Build();

			var rating = new RatingBuilder()
				.WithDefaultValues()
				.Stars(4).Build();

			album.AddRating(rating);

			Assert.Equal(1, album.Ratings.Count);
			Assert.Equal(4, album.AverageRating);
		}

		[Fact]
		public void AddSubsequentRating()
		{
			var ratings = new List<Rating>
			{
				new RatingBuilder().WithDefaultValues()
				.Stars(1).Build(),
				new RatingBuilder().WithDefaultValues()
				.Stars(3).Build()
			};

			var album = new AlbumBuilder()
				.WithDefaultValues()
				.Ratings(ratings)
				.Build();

			var newRating = new RatingBuilder()
				.WithDefaultValues()
				.Stars(4)
				.Build();

			album.AddRating(newRating);

			var expected = (float)(8.0 / 3);
			Assert.Equal(expected, album.AverageRating);
		}
	}
}
