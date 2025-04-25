using RentCar.Domain.Abstractions;
using RentCar.Domain.Users;

namespace RentCar.Infrastructure.Repositories;

internal sealed class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

}
