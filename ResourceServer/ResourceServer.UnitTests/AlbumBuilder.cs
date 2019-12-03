using ResourceServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResourceServer.Tests
{
	public class AlbumBuilder
	{
		private Album _album = new Album();

		public AlbumBuilder Id(Guid id)
		{
			_album.Id = id;
			return this;
		}
		public AlbumBuilder Title(string title)
		{
			_album.Title = title;
			return this;
		}
		public AlbumBuilder AverageRating(int avg)
		{
			_album.AverageRating = avg;
			return this;
		}
		public AlbumBuilder Ratings(ICollection<Rating> ratings)
		{
			_album.Ratings = ratings;
			_album.AverageRating = ratings.Sum(x => x.Stars) / ratings.Count;
			return this;
		}
		public AlbumBuilder AlbumArtist(Artist artist)
		{
			_album.AlbumArtist = artist;
			return this;
		}
		public AlbumBuilder WithDefaultValues()
		{
			_album = new Album
			{
				Id = new Guid(),
				Title = "Test Album",
				AverageRating = 0,
				AlbumArtistId = new Guid("a0000000000000000000000000000001"),
				Ratings = new List<Rating>()
			};
			return this;
		}
		public Album Build() => _album;
	}
}
