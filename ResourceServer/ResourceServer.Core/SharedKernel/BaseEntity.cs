using System;
using System.Collections.Generic;

namespace ResourceServer.Core.SharedKernel
{
	public abstract class BaseEntity
	{
		public Guid Id { get; set; } = default!;
		public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
	}
}