using ResourceServer.Core.SharedKernel;
using System;

namespace ResourceServer.Core.Entities
{
	public class Song : BaseEntity
	{
		private Album? _album;
		private Artist? _artist;

		public string Title { get; set; } = null!;
		public int? Length { get; set; }
		public int? TrackNumber { get; set; }

		public Guid AlbumId { get; set; }

		public virtual Album Album
		{
			get => NavigationPropertyAccessor(_album);
			set => _album = value;
		}

		public Guid ArtistId { get; set; }

		public virtual Artist Artist
		{
			get => NavigationPropertyAccessor(_artist);
			set => _artist = value;
		}
	}
}