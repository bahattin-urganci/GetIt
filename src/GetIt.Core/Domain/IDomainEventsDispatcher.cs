namespace GetIt.Core.Domain;

public interface IDomainEventsDispatcher
{
    Task DispatchEventsAsync();
}
