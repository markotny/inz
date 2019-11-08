using ResourceServer.Core.SharedKernel;
using System;
using System.Collections.Generic;

namespace ResourceServer.Core.Entities
{
	public class User : BaseEntity
	{
		public string Username { get; set; } = null!;
		public virtual ICollection<Rating> Ratings { get; set; } = null!;
	}
}