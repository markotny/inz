using ResourceServer.Core.SharedKernel;
using System;
using System.Collections.Generic;

namespace ResourceServer.Core.Entities
{
	public class Artist : BaseEntity<Guid>
	{
		private ICollection<Song>? _songs;
		private ICollection<Album>? _albums;
		public string Name { get; set; } = null!;

		public virtual ICollection<Song> Songs
		{
			get => _songs
				?? throw new InvalidOperationException($"Uninitialized property: {nameof(Songs)}");
			set => _songs = value;
		}

		public virtual ICollection<Album> Albums
		{
			get => _albums
				?? throw new InvalidOperationException($"Uninitialized property: {nameof(Albums)}");
			set => _albums = value;
		}
	}
}