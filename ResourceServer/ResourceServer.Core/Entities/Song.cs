using ResourceServer.Core.SharedKernel;
using System;

namespace ResourceServer.Core.Entities
{
	public class Song : BaseEntity
	{
		public string Title { get; set; } = null!;
		public int? Length { get; set; }
		public int? TrackNumber { get; set; }

		public Guid AlbumId { get; set; }
		public Guid ArtistId { get; set; }
		public virtual Album Album { get; set; } = null!;
		public virtual Artist Artist { get; set; } = null!;
	}
}