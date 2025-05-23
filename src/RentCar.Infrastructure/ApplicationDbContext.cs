using MediatR;
using Microsoft.EntityFrameworkCore;
using RentCar.Application.Exceptions;
using RentCar.Domain.Abstractions;

namespace RentCar.Infrastructure;

public sealed class ApplicationDbContext : DbContext, IUnitOfWork
{
    private readonly IPublisher _publisher;
    public ApplicationDbContext(DbContextOptions options, IPublisher publisher) : base(options)
    {
        _publisher = publisher;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            
        var result = await base.SaveChangesAsync(cancellationToken);

        await PublishDomainEventAsync();

        return result;

        }
        catch (DbUpdateConcurrencyException ex)
        {
            
            throw new ConcurrencyException(" La excepcion por concurrencia se disparo", ex);
        }
    }

    private async Task PublishDomainEventAsync()
    {
        var domainEvents = ChangeTracker
            .Entries<IEntity>()
            .Select(entry => entry.Entity)
            .SelectMany(entity => 
            {
                var domainEvents = entity.GetDomainEvents();
                entity.ClearDomainEvents();
                return domainEvents;
            }).ToList();

            foreach (var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent);
            }
    }
    
}