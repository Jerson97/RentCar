using Microsoft.EntityFrameworkCore;
using RentCar.Domain.Abstractions;

namespace RentCar.Infrastructure;

public sealed class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }
}