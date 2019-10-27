using ResourceServer.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceServer.Core.Entities
{
	public class Album : BaseEntity<string>

	{
		public string Title { get; set; }
		public virtual Artist AlbumArtist { get; set; }
		public DateTime ReleaseDate { get; set; }
		public virtual ICollection<Song> Songs { get; set; }
	}
}
