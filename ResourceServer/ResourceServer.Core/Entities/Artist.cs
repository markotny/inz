using ResourceServer.Core.SharedKernel;
using System;
using System.Collections.Generic;

namespace ResourceServer.Core.Entities
{
	public class Artist : BaseEntity<Guid>
	{
		public string Name { get; set; }
		public virtual List<Song> Songs { get; set; }
		public virtual List<Album> Albums { get; set; }
	}
}
