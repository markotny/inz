using System;
using ResourceServer.Core.SharedKernel;
using System.Collections.Generic;
using System.Text;

namespace ResourceServer.Core.Entities
{
	public class Rating : BaseEntity
	{
		public short Stars { get; set; }

		public Guid UserId { get; set; }
		public Guid AlbumId { get; set; }
		public virtual User User { get; set; } = null!;
		public virtual Album Album { get; set; } = null!;
		public virtual Review? Review { get; set; }
	}
}
