using GetIt.Data;
using GetIt.Domain;

namespace GetIt.Application;
public class UnitOfWork : IUnitOfWork
{
    private readonly GetItDbContext _db;

    public UnitOfWork(GetItDbContext db)
    {
        _db = db;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        //TODO son değişikliklerin audit gibi bilgilerin otomatik yansıtılması 
        return await _db.SaveChangesAsync(cancellationToken);
    }
}
