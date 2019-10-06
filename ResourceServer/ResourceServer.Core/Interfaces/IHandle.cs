using ResourceServer.Core.SharedKernel;

namespace ResourceServer.Core.Interfaces
{
    public interface IHandle<T> where T : BaseDomainEvent
    {
        void Handle(T domainEvent);
    }
}