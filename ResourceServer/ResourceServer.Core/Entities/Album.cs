using ResourceServer.Core.SharedKernel;
using System;
using System.Collections.Generic;

namespace ResourceServer.Core.Entities
{
	public class Album : BaseEntity<Guid>
	{
		private Artist? _albumArtist;
		private ICollection<Song>? _songs;
		private ICollection<Rating>? _ratings;

		public string Title { get; set; } = null!;
		public DateTime? ReleaseDate { get; set; }
		public int? AverageRating { get; set; }

		public Guid AlbumArtistId { get; set; }

		public virtual Artist AlbumArtist
		{
			get => NavigationPropertyAccessor(_albumArtist);
			set => _albumArtist = value;
		}

		public virtual ICollection<Song> Songs
		{
			get => NavigationPropertyAccessor(_songs);
			set => _songs = value;
		}

		public virtual ICollection<Rating> Ratings
		{
			get => NavigationPropertyAccessor(_ratings);
			set => _ratings = value;
		}
	}
}