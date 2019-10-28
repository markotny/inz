using ResourceServer.Core.SharedKernel;
using System;

namespace ResourceServer.Core.Entities
{
	public class Song : BaseEntity<Guid>
	{
		private Album? _album;
		private Artist? _artist;
		public string Title { get; set; } = null!;

		public virtual Album Album
		{
			get => _album
				?? throw new InvalidOperationException($"Uninitialized property: {nameof(Album)}");
			set => _album = value;
		}

		public virtual Artist Artist
		{
			get => _artist
				?? throw new InvalidOperationException($"Uninitialized property: {nameof(Artist)}");
			set => _artist = value;
		}

		public int? Length { get; set; }
		public int? TrackNumber { get; set; }
	}
}