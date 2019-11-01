using ResourceServer.Core.SharedKernel;
using System;
using System.Collections.Generic;

namespace ResourceServer.Core.Entities
{
	public class Album : BaseEntity
	{
		public string Title { get; set; } = null!;
		public DateTime? ReleaseDate { get; set; }
		public int? AverageRating { get; set; }

		public Guid AlbumArtistId { get; set; }
		public virtual Artist AlbumArtist { get; set; } = null!;
		public virtual ICollection<Song> Songs { get; set; } = null!;
		public virtual ICollection<Rating> Ratings { get; set; } = null!;
	}
}