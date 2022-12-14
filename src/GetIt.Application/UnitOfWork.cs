using GetIt.Core.Domain;
using GetIt.Data;
using GetIt.Domain;
using GetIt.Domain.Base;

namespace GetIt.Application;
public class UnitOfWork : IUnitOfWork
{
    private readonly GetItDbContext _db;
    private readonly IDomainEventsDispatcher _domainEventsDispatcher;

    public UnitOfWork(GetItDbContext db,IDomainEventsDispatcher domainEventsDispatcher)
    {
        _db = db;
        _domainEventsDispatcher = domainEventsDispatcher;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _domainEventsDispatcher.DispatchEventsAsync();
        SetAudit();
        return await _db.SaveChangesAsync(cancellationToken);
    }
    private void SetAudit()
    {
        //userid otomatik işlenebilir
        //outbox pattern uygulanabilir logging amaçları için 

        var changedEntities = _db.ChangeTracker.Entries<AuditEntity>().ToList();
        foreach (var entity in changedEntities)
        {
            switch (entity.State)
            {
                case Microsoft.EntityFrameworkCore.EntityState.Detached:
                    break;
                case Microsoft.EntityFrameworkCore.EntityState.Unchanged:
                    break;
                case Microsoft.EntityFrameworkCore.EntityState.Deleted:                    
                    break;
                case Microsoft.EntityFrameworkCore.EntityState.Modified:
                    entity.Entity.UpdateDate= DateTime.Now;
                    break;
                case Microsoft.EntityFrameworkCore.EntityState.Added:
                    entity.Entity.CreatedDate= DateTime.Now;
                    break;
                default:
                    break;
            }
        }
    }
}
