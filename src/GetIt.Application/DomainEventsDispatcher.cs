using GetIt.Core.Domain;
using GetIt.Data;
using GetIt.Domain.Base;
using MediatR;

namespace GetIt.Application
{
    public class DomainEventsDispatcher : IDomainEventsDispatcher
    {
        private readonly IMediator _mediator;
        private readonly GetItDbContext _db;

        public DomainEventsDispatcher(IMediator mediator, GetItDbContext db)
        {
            _mediator = mediator;
            _db = db;
        }

        public async Task DispatchEventsAsync()
        {
            var domainEntities = this._db.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            var domainEventNotifications = new List<IDomainEventNotification<IDomainEvent>>();

            domainEntities
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            var tasks = domainEvents
                .Select(async (domainEvent) =>
                {
                    await _mediator.Publish(domainEvent);
                });

            await Task.WhenAll(tasks);

            //loglama ve audit outbox pattern
        }
    }
}
