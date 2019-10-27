using System.Collections.Generic;

namespace ResourceServer.Core.SharedKernel
{
    public abstract class BaseEntity<TId> : BaseEntity
    {
        public TId Id { get; set; }
    }

	public abstract class BaseEntity
	{
		public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
	}
}