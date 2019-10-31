using ResourceServer.Core.SharedKernel;
using System;

namespace ResourceServer.Core.Entities
{
	public class Review : BaseEntity<Guid>
	{
		private Rating? _rating;

		public string ReviewContent { get; set; } = null!;

		public Guid RatingId { get; set; }

		public virtual Rating Rating
		{
			get => NavigationPropertyAccessor(_rating);
			set => _rating = value;
		}
	}
}