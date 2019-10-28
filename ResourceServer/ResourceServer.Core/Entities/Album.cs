using ResourceServer.Core.SharedKernel;
using System;
using System.Collections.Generic;

namespace ResourceServer.Core.Entities
{
	public class Album : BaseEntity<Guid>
	{
		private Artist? _albumArtist;
		private ICollection<Song>? _songs;
		public string Title { get; set; } = null!;
		public DateTime? ReleaseDate { get; set; }

		public virtual Artist AlbumArtist
		{
			get => _albumArtist
				?? throw new InvalidOperationException($"Uninitialized property: {nameof(AlbumArtist)}");
			set => _albumArtist = value;
		}

		public virtual ICollection<Song> Songs
		{
			get => _songs
				?? throw new InvalidOperationException($"Uninitialized property: {nameof(Songs)}");
			set => _songs = value;
		}
	}
}