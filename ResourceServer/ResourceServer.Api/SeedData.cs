using ResourceServer.Core.Entities;
using ResourceServer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ResourceServer.Api
{
    public static class SeedData
    {
		public static readonly Artist Artist1 = new Artist
		{
			Id = new Guid("a0000000-0000-0000-0000-000000000001"),
			Name = "Artist 1"
		};

		public static readonly Artist Artist2 = new Artist
		{
			Id = new Guid("a0000000-0000-0000-0000-000000000002"),
			Name = "Artist 2"
		};

		public static readonly Artist Artist3 = new Artist
		{
			Id = new Guid("a0000000-0000-0000-0000-000000000003"),
			Name = "Artist 3"
		};

		public static readonly Album Album1 = new Album
		{
			Id = new Guid("b0000000-0000-0000-0000-000000000001"),
			Title = "Album 1",
			AlbumArtist = Artist1,
			CoverSrc = "https://lastfm.freetls.fastly.net/i/u/770x0/4ec11bb31158f2569605740bbd28a907.jpg",
			AverageRating = 5,
			ReleaseDate = new DateTime()
		};

		public static readonly Album Album2 = new Album
		{
			Id = new Guid("b0000000-0000-0000-0000-000000000002"),
			Title = "Album 2",
			AlbumArtist = Artist2,
			CoverSrc = "https://lastfm.freetls.fastly.net/i/u/770x0/4ec11bb31158f2569605740bbd28a907.jpg",
			AverageRating = 3,
			ReleaseDate = new DateTime()
		};

		public static readonly Song Song1 = new Song
		{
			Id = new Guid("c0000000-0000-0000-0000-000000000001"),
			Title = "Song 1",
			AlbumId = new Guid("b0000000-0000-0000-0000-000000000001"),
			ArtistId = new Guid("a0000000-0000-0000-0000-000000000001"),
			TrackNumber = 1
		};

		public static readonly Song Song2 = new Song
		{
			Id = new Guid("c0000000-0000-0000-0000-000000000002"),
			Title = "Song 2",
			AlbumId = new Guid("b0000000-0000-0000-0000-000000000001"),
			ArtistId = new Guid("a0000000-0000-0000-0000-000000000001"),
			TrackNumber = 2
		};

		public static readonly Song Song3 = new Song
		{
			Id = new Guid("c0000000-0000-0000-0000-000000000003"),
			Title = "Song 3",
			AlbumId = new Guid("b0000000-0000-0000-0000-000000000001"),
			ArtistId = new Guid("a0000000-0000-0000-0000-000000000001"),
			TrackNumber = 3
		};

		public static readonly Song Song4 = new Song
		{
			Id = new Guid("c0000000-0000-0000-0000-000000000004"),
			Title = "Song 4",
			AlbumId = new Guid("b0000000-0000-0000-0000-000000000002"),
			ArtistId = new Guid("a0000000-0000-0000-0000-000000000002"),
			TrackNumber = 1
		};

		public static readonly Song Song5 = new Song
		{
			Id = new Guid("c0000000-0000-0000-0000-000000000005"),
			Title = "Song 5",
			AlbumId = new Guid("b0000000-0000-0000-0000-000000000003"),
			ArtistId = new Guid("a0000000-0000-0000-0000-000000000003"),
			TrackNumber = 2
		};

		public static void Initialize(IServiceProvider serviceProvider)
        {
            using var dbContext = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null);
			// Look for any TODO items.
			if (dbContext.Albums.Any())
			{
				return;   // DB has been seeded
			}

			PopulateTestData(dbContext);
        }
        public static void PopulateTestData(AppDbContext dbContext)
        {
			foreach (var item in dbContext.Songs)
			{
				dbContext.Remove(item);
			}
			foreach (var item in dbContext.Albums)
			{
				dbContext.Remove(item);
			}
			foreach (var item in dbContext.Artists)
			{
				dbContext.Remove(item);
			}
            dbContext.SaveChanges();

			dbContext.Artists.Add(Artist1);
			dbContext.Artists.Add(Artist2);
			dbContext.Artists.Add(Artist3);

			for(var i = 0; i < 10; i++)
			{
				dbContext.Albums.Add(new Album
				{
					Id = new Guid($"b0000000-0000-0000-0000-00000000000{i}"),
					Title = $"Album {i}",
					AlbumArtist = Artist1,
					CoverSrc = "https://lastfm.freetls.fastly.net/i/u/770x0/4ec11bb31158f2569605740bbd28a907.jpg",
					AverageRating = 5,
					ReleaseDate = new DateTime()
				});
				dbContext.SaveChanges();
			}

			dbContext.Songs.Add(Song1);
			dbContext.Songs.Add(Song2);
			dbContext.Songs.Add(Song3);
			dbContext.Songs.Add(Song4);
			dbContext.Songs.Add(Song5);

			dbContext.SaveChanges();
		}
    }
}
