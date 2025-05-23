using Microsoft.EntityFrameworkCore;
using RentCar.Domain.Abstractions;

namespace RentCar.Infrastructure.Repositories;

internal abstract class Repository<TEntity, TEntityId> where TEntity : Entity<TEntityId> where TEntityId : class
{
    protected readonly ApplicationDbContext _dbContext;
    protected Repository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TEntity?> GetByIdAsync(TEntityId id, CancellationToken cancellationToken= default)
    {
        return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public void Add(TEntity entity)
    {
        _dbContext.Add(entity);
    }
}