using RentCar.Application.Abstraction.Email;
using RentCar.Domain.Users;

namespace RentCar.Infrastructure;

internal sealed class EmailService : IEmailService
{
    public Task SendAsync(Email recipient, string subject, string body)
    {
        return Task.CompletedTask;
    }
}
