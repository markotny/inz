using ResourceServer.Core.SharedKernel;
using System;
using System.Collections.Generic;

namespace ResourceServer.Core.Entities
{
	public class Artist : BaseEntity
	{
		public string? MusicBrainzId { get; set; }
		public string Name { get; set; } = null!;

		public virtual ICollection<Song> Songs { get; set; } = null!;
		public virtual ICollection<Album> Albums { get; set; } = null!;
	}
}