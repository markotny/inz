using System;
using System.Collections.Generic;

namespace ResourceServer.Core.SharedKernel
{
	public abstract class BaseEntity<TId> : BaseEntity
	{
		public TId Id { get; set; } = default!;
	}

	public abstract class BaseEntity
	{
		public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();

		protected static T NavigationPropertyAccessor<T>(T? _privateProperty) where T : class
			=> _privateProperty
				?? throw new InvalidOperationException($"Uninitialized property: {nameof(T)}");
	}
}