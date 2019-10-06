using ResourceServer.Core.SharedKernel;

namespace ResourceServer.Core.Interfaces
{
    public interface IDomainEventDispatcher
    {
        void Dispatch(BaseDomainEvent domainEvent);
    }
}