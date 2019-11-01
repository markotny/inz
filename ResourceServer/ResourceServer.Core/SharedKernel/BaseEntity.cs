using System;
using System.Collections.Generic;

namespace ResourceServer.Core.SharedKernel
{
	public abstract class BaseEntity
	{
		public Guid Id { get; set; } = default!;
		public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();

		protected static T NavigationPropertyAccessor<T>(T? _privateProperty) where T : class
			=> _privateProperty
				?? throw new InvalidOperationException($"Uninitialized property: {nameof(T)}");
	}
}