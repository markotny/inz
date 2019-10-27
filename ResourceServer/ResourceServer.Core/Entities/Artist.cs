using ResourceServer.Core.SharedKernel;
using System.Collections.Generic;

namespace ResourceServer.Core.Entities
{
	public class Artist : BaseEntity<string>
	{
		public string Name { get; set; }
		public virtual ICollection<Song> Songs { get; set; }
		public virtual ICollection<Album> Albums { get; set; }
	}
}
