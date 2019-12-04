using ResourceServer.Core.Interfaces;
using ResourceServer.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceServer.IntegrationTests
{
	class NoOpDomainEventDispatcher : IDomainEventDispatcher
	{
		public void Dispatch(BaseDomainEvent domainEvent) { }
	}
}
