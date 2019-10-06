using Ardalis.GuardClauses;
using ResourceServer.Core.Events;
using ResourceServer.Core.Interfaces;

namespace ResourceServer.Core.Services
{
    public class ItemCompletedEmailNotificationHandler : IHandle<ToDoItemCompletedEvent>
    {
        public void Handle(ToDoItemCompletedEvent domainEvent)
        {
            Guard.Against.Null(domainEvent, nameof(domainEvent));

            // Do Nothing
        }
    }
}
