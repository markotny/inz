using ResourceServer.Core.SharedKernel;
using System;

namespace ResourceServer.Core.Entities
{
	public class Review : BaseEntity
	{
		public string ReviewContent { get; set; } = null!;

		public Guid RatingId { get; set; }
		public virtual Rating Rating { get; set; } = null!;
	}
}