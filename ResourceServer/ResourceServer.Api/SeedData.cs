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
			ReleaseDate = new DateTime()
		};

		public static readonly Album Album2 = new Album
		{
			Id = new Guid("b0000000-0000-0000-0000-000000000002"),
			Title = "Album 2",
			AlbumArtist = Artist2,
			ReleaseDate = new DateTime()
		};

		public static readonly Song Song1 = new Song
		{
			Id = new Guid("c0000000-0000-0000-0000-000000000001"),
			Title = "Song 1",
			Album = Album1,
			Artist = Artist1,
			TrackNumber = 1
		};

		public static readonly Song Song2 = new Song
		{
			Id = new Guid("c0000000-0000-0000-0000-000000000002"),
			Title = "Song 2",
			Album = Album1,
			Artist = Artist1,
			TrackNumber = 2
		};

		public static readonly Song Song3 = new Song
		{
			Id = new Guid("c0000000-0000-0000-0000-000000000003"),
			Title = "Song 3",
			Album = Album1,
			Artist = Artist1,
			TrackNumber = 3
		};

		public static readonly Song Song4 = new Song
		{
			Id = new Guid("c0000000-0000-0000-0000-000000000004"),
			Title = "Song 4",
			Album = Album2,
			Artist = Artist2,
			TrackNumber = 1
		};

		public static readonly Song Song5 = new Song
		{
			Id = new Guid("c0000000-0000-0000-0000-000000000005"),
			Title = "Song 5",
			Album = Album2,
			Artist = Artist3,
			TrackNumber = 2
		};

		public static void Initialize(IServiceProvider serviceProvider)
        {
            using var dbContext = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null);
            // Look for any TODO items.
            //if (dbContext.Songs.Any())
            //{
            //    return;   // DB has been seeded
            //}

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
			dbContext.Artists.Add(Artist1);
			dbContext.Artists.Add(Artist3);

			dbContext.Albums.Add(Album1);
			dbContext.Albums.Add(Album2);

			dbContext.Songs.Add(Song1);
			dbContext.Songs.Add(Song2);
			dbContext.Songs.Add(Song3);
			dbContext.Songs.Add(Song4);
			dbContext.Songs.Add(Song5);

			dbContext.SaveChanges();
		}
    }
}
