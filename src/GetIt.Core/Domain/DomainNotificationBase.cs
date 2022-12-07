using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GetIt.Core.Domain
{
    public class DomainNotificationBase<T> : IDomainEventNotification<T> where T : IDomainEvent
    {
        [JsonIgnore]
        public T DomainEvent { get; }

        public string Id { get; }

        public DomainNotificationBase(T domainEvent)
        {
            Id = Guid.NewGuid().ToString("N");
            DomainEvent = domainEvent;
        }
    }
}
