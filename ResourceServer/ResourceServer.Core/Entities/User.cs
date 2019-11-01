using ResourceServer.Core.SharedKernel;
using System;
using System.Collections.Generic;

namespace ResourceServer.Core.Entities
{
	public class User : BaseEntity
	{
		private ICollection<Rating>? _ratings;

		public virtual ICollection<Rating> Ratings
		{
			get => NavigationPropertyAccessor(_ratings);
			set => _ratings = value;
		}
	}
}